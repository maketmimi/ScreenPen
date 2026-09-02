using ScreenPen.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FormCanvas : Form, ICanvas
    {
        private Screen _ScreenToShowCanvasOn;
        protected Screen CanvasScreen
        {
            set
            {
                if (value != null)
                {
                    _ScreenToShowCanvasOn = value;
                    this.Location = value.Bounds.Location;

                    if (CanvasBitmap == null)
                        CanvasBitmap = new Bitmap(value.Bounds.Size.Width, value.Bounds.Size.Width);
                    else
                        CanvasBitmap = new Bitmap(CanvasBitmap, value.Bounds.Size);
                }
            }

            get
            {
                return _ScreenToShowCanvasOn;
            }
        }
        private Form _MainForm = null;
        private Form MainForm
        {
            set
            {
                Canvas._MainForm = value;
            }

            get
            {
                return Canvas._MainForm;
            }
        }
        private bool _IsClosedByCode = false;
        private bool IsClosedByCode
        {
            set
            {
                Canvas._IsClosedByCode = value;
            }

            get
            {
                return Canvas._IsClosedByCode;
            }
        }

        protected bool _IsChild = false;
        protected readonly FormCanvas ParentCanvas = null;
        protected FormCanvas[] ChildCanvasses = null;
        protected FormCanvas Canvas
        {
            get
            {
                return _IsChild ? ParentCanvas : this;
            }
        }

        private Bitmap _PreviousCanvasBitMap = null; // this is used for handeling the eraser undo and redo
        private Bitmap _CanvasBitmap = null;
        public Bitmap CanvasBitmap
        {
            protected set
            {
                if (value != null)
                {
                    _CanvasBitmap = value;
                    CanvasBitmapGraphics = Graphics.FromImage(_CanvasBitmap);
                    CanvasBitmapGraphics.Clear(Color.FromArgb(0, 0, 0, 0));
                }
            }

            get
            {
                return _CanvasBitmap;
            }
        }
        private Graphics _CanvasBitmapGraphics = null;
        public Graphics CanvasBitmapGraphics
        {
            set
            {
                if (value == null) throw new ArgumentNullException();

                value.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                _CanvasBitmapGraphics = value;
            }

            get
            {
                return _CanvasBitmapGraphics;
            }
        }
       
        // Canvas Tools
        private StrokePen? _PenTool { set; get; } = null;
        private StrokePen? _EraserTool { set; get; }  = null;
        private CompositingMode SelectedCanvasToolCompositingMode
        {
            get
            {
                if (SelectedCanvasTool == EnCanvasTools.Eraser)
                    return CompositingMode.SourceCopy;
                else
                    return CompositingMode.SourceOver;
            }
        }
        private EnCanvasTools? _SelectedCanvasTool { set; get; } = null;
        private EnCanvasTools SelectedCanvasTool
        {
            set
            {
                switch (value)
                {
                    case EnCanvasTools.Pen:
                        Canvas._SelectedCanvasTool = EnCanvasTools.Pen;
                        break;
                    case EnCanvasTools.Eraser:
                        Canvas._SelectedCanvasTool = EnCanvasTools.Eraser;
                        break;
                }
            }

            get
            {
                return Canvas._SelectedCanvasTool.Value;
            }
        }
        protected StrokePen CanvasStrokePen
        {
            get
            {
                switch (SelectedCanvasTool)
                {
                    case EnCanvasTools.Pen:
                        return Canvas._PenTool.Value;
                    case EnCanvasTools.Eraser:
                        return Canvas._EraserTool.Value;
                    default:
                        return Canvas._PenTool.Value;
                }
            }
        }

        private bool _IsUserDrawing = false;
        private FormCanvasStroke _CurrentStroke = null;

        protected List<FormCanvasStroke> LDrawnStrokes = null;
        protected List<FormCanvasStroke> LUndoList = null;
        protected List<FormCanvasStroke> LRedoList = null;

        private readonly FrmCanvasToolsPanel _CanvasToolPanel = null;
        protected FrmCanvasToolsPanel CanvasToolPanel
        {
            get
            {
                return Canvas._CanvasToolPanel;
            }
        } 
        
        // parent canves consrtuctor
        protected FormCanvas()
        {
            InitializeComponent();

            CanvasScreen = Screen.PrimaryScreen;
            InitializeCanvasTools();

            LUndoList = new List<FormCanvasStroke>();
            LDrawnStrokes = LUndoList;
            LRedoList = new List<FormCanvasStroke>();

            _CanvasToolPanel = new FrmCanvasToolsPanel(this);
            _CanvasToolPanel.Owner = this;
            _CanvasToolPanel.LocationChanged += CanvasToolPanel_LocationChanged;

            InitializeChildCanvasses();
        }

        protected virtual void CanvasToolPanel_LocationChanged(object sender, EventArgs e)
        {
            if (CanvasScreen.Bounds.Contains(Canvas._CanvasToolPanel.Location))
                Canvas._CanvasToolPanel.Owner = this;
        }

        // Child counstructor
        protected FormCanvas(FormCanvas ParentCanvas, Screen CanvasScreen)
        {
            InitializeComponent();
            this.CanvasScreen = CanvasScreen;
            this.ParentCanvas = ParentCanvas;
            _IsChild = true;

            this.ParentCanvas.FormClosed += ParentCanvas_FormClosed;
            this.ParentCanvas.VisibleChanged += ParentCanvas_VisibleChanged;
            this.ParentCanvas.MsrMainMenu.VisibleChanged += ParentMsrMainMenu_VisibleChanged;
            this.ParentCanvas._CanvasToolPanel.LocationChanged += CanvasToolPanel_LocationChanged;
        }

        private void ParentCanvas_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = ParentCanvas.Visible;
        }

        // this should only be called in the parent constructor
        private void InitializeCanvasTools()
        {
            _PenTool = new StrokePen(Color.Black, 5);
            _EraserTool = new StrokePen(Color.FromArgb(0, 0, 0, 0), 5);
            SelectedCanvasTool = EnCanvasTools.Pen;
        }

        private void ParentMsrMainMenu_VisibleChanged(object sender, EventArgs e)
        {
            this.MsrMainMenu.Visible = ParentCanvas.MsrMainMenu.Visible;
        }

        private void ParentCanvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        protected virtual FormCanvas CreateChildCanvas(FormCanvas ParentCanvas, Screen CanvasScreen)
        {
            // this is not implemented , it should be implemented in the child classes
            return null;
        }

        private void InitializeChildCanvasses()
        {
            Screen[] AllScreens = Screen.AllScreens;

            if (AllScreens.Length > 1)
            {
                ChildCanvasses = new FormCanvas[AllScreens.Length - 1];

                int ChildCanvasIndex = 0;
                for (int i = 0; i < AllScreens.Length; i++)
                {
                    if (AllScreens[i].Primary) continue;

                    ChildCanvasses[ChildCanvasIndex] = CreateChildCanvas(this, AllScreens[i]);

                    ChildCanvasIndex++;
                }
            }
        }

        protected virtual void RefreshCurrentCanvas()
        {
            throw new NotImplementedException();
        }
        
        protected void RefreshAllCanvasses()
        {
            Canvas.RefreshCurrentCanvas();

            if (Canvas.ChildCanvasses != null && Canvas.ChildCanvasses.Length > 0)
            {
                foreach (var ChildCanvas in Canvas.ChildCanvasses)
                    ChildCanvas.RefreshCurrentCanvas();
            }
        }

        protected void FormCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _IsUserDrawing = true;
            _CurrentStroke = new FormCanvasStroke(Canvas.CanvasStrokePen, e.Location, this, SelectedCanvasToolCompositingMode);
        
            if (SelectedCanvasTool == EnCanvasTools.Eraser)
            {
                _PreviousCanvasBitMap = BitmapsUtils.CopyBitmap(CanvasBitmap);
            }
        }

        protected void FormCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsUserDrawing) return;

            _CurrentStroke.AddPoint(e.Location);
            _CurrentStroke.DrawLastSegment();
            RefreshCurrentCanvas();
        }

        protected void FormCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !_IsUserDrawing) return;

            _IsUserDrawing = false;

            if (_CurrentStroke.PointsCount > 1) // cancel the stroke if it only contained the initial point
            {
                if (!(SelectedCanvasTool == EnCanvasTools.Eraser && !HaveBitmapBeenErased(_PreviousCanvasBitMap, CanvasBitmap)))
                {
                    Canvas.LDrawnStrokes.Add(_CurrentStroke); // this adds it to the LUndoList as well 
                    Canvas.LRedoList.Clear();
                }
            }

            _CurrentStroke = null;

            if (SelectedCanvasTool == EnCanvasTools.Eraser)
            {
                _PreviousCanvasBitMap.Dispose();
                _PreviousCanvasBitMap = null;
            }
        }

        // note that the oreder of the parameters is importent
        private bool HaveBitmapBeenErased(Bitmap PreviousBitmap, Bitmap CurrentBitmap)
        {
            if (PreviousBitmap == null || CurrentBitmap == null || PreviousBitmap.Size != CurrentBitmap.Size || PreviousBitmap.PixelFormat != CurrentBitmap.PixelFormat)
                throw new ArgumentException();


            BitmapData PreviousBData = PreviousBitmap.LockBits(BitmapsUtils.GetBitmapFullRectangle(PreviousBitmap), ImageLockMode.ReadOnly, PreviousBitmap.PixelFormat);
            BitmapData CurrentBData = CurrentBitmap.LockBits(BitmapsUtils.GetBitmapFullRectangle(CurrentBitmap), ImageLockMode.ReadOnly, CurrentBitmap.PixelFormat);

            try
            {
                for (int y = 0; y < PreviousBData.Height; y++)
                {
                    IntPtr ptrPreviousBRowBeginning = IntPtr.Add(PreviousBData.Scan0, y * PreviousBData.Stride);
                    IntPtr ptrCurrentBRowBeginning = IntPtr.Add(CurrentBData.Scan0, y * CurrentBData.Stride);

                    // assumming always 32bbpArgb we should make it dynamic in the future
                    for (int x = 0; x < PreviousBData.Width; x++)
                    {
                        IntPtr ptrPreviousBPixelBeginning = IntPtr.Add(ptrPreviousBRowBeginning, x * 4); // another words rowptr + pixelNumber * bytesPerPixel 
                        byte PreviousAlpha = Marshal.ReadByte(ptrPreviousBPixelBeginning, 3);

                        if (PreviousAlpha == 255)
                        {
                            IntPtr ptrCurrentBPixelBeginning = IntPtr.Add(ptrCurrentBRowBeginning, x * 4);
                            byte CurrentAlpha = Marshal.ReadByte(ptrCurrentBPixelBeginning, 3);

                            if (CurrentAlpha == 0)
                                return true;
                        }
                    }
                }

                return false;
            }
            finally
            {
                PreviousBitmap.UnlockBits(PreviousBData);
                CurrentBitmap.UnlockBits(CurrentBData);
            }
        }

        private void ClearCurrentCanvasBitmap()
        {
            CanvasBitmapGraphics.Clear(Color.FromArgb(0, 0, 0, 0));
        }

        private void ClearAllCanvasBitmaps()
        {
            Canvas.ClearCurrentCanvasBitmap();

            if (Canvas.ChildCanvasses != null && Canvas.ChildCanvasses.Length > 0)
            {
                foreach (var ChildCanvas in Canvas.ChildCanvasses)
                {
                    ChildCanvas.ClearCurrentCanvasBitmap();
                }
            }
        }

        private void RedrawCanvasBitmaps()
        {
            ClearAllCanvasBitmaps();

            if (Canvas.LDrawnStrokes.Count > 0)
            {
                foreach (var stroke in Canvas.LDrawnStrokes)
                {
                    stroke.DrawFullStroke();
                }
            }
        }

        // ICanvas Implementation

        public void SetPenWidthTo(float NewWidth)
        {
            Canvas._PenTool = new StrokePen(Canvas._PenTool.Value.color, NewWidth);
        }

        public virtual void SetPenColorTo(Color NewColor)
        {
            Canvas._PenTool = new StrokePen(NewColor, Canvas._PenTool.Value.width);
        }

        public void SetNewPen(StrokePen NewPen)
        {
            Canvas._PenTool = NewPen;
        }

        public virtual void SaveCanvas(string FolderPath, ImageFormat ImageType)
        {
            bool tempToolPanelVisibile = CanvasToolPanel.Visible;

            CanvasToolPanel.Hide();

            Rectangle VirtualScreenRec = SystemInformation.VirtualScreen;
            Bitmap CanvasToSave = new Bitmap(VirtualScreenRec.Size.Width, VirtualScreenRec.Size.Height);
            Graphics CanvasToSaveGraphics = Graphics.FromImage(CanvasToSave);

            try
            {
                CanvasToSaveGraphics.CopyFromScreen(VirtualScreenRec.Location, new Point(0, 0), VirtualScreenRec.Size, CopyPixelOperation.SourceCopy);

                string FileName = $"ScreenPen_{DateTime.Now:HHmmss}.{ImageType}";

                CanvasToSave.Save(Path.Combine(FolderPath, FileName), ImageType);
            
                MessageBox.Show($"Canvas saved successfully to {FolderPath}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show($"Ops... cannot save canvas", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                CanvasToolPanel.Visible = tempToolPanelVisibile;
                CanvasToSave.Dispose();
                CanvasToSaveGraphics.Dispose();
            }
        }

        public void HideCanvas()
        {
            Canvas.Hide();
        }

        public void ShowCanvas()
        {
            Canvas.Show();
        }

        public void Undo()
        {
            if (!CanUndo()) return;

            Canvas.LRedoList.Add(Canvas.LUndoList.Last());
            Canvas.LUndoList.Remove(Canvas.LUndoList.Last());
            RedrawCanvasBitmaps();
            RefreshAllCanvasses();
        }

        public bool CanUndo()
        {
            return Canvas.LUndoList.Count > 0;
        }

        public void Redo()
        {
            if (!CanRedo()) return;

            Canvas.LUndoList.Add(Canvas.LRedoList.Last());
            Canvas.LRedoList.Remove(Canvas.LRedoList.Last());
            Canvas.LUndoList.Last().DrawFullStroke();
            RefreshAllCanvasses();
        }

        public bool CanRedo()
        {
            return Canvas.LRedoList.Count > 0;
        }

        protected void showMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas.MsrMainMenu.Show();
        }

        protected void hideMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas.MsrMainMenu.Hide();
        }

        protected void saveCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FolderPath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "ScreenPen");
            SaveCanvas(FolderPath, ImageFormat.Png);
        }

        protected void closeCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCanvas();
        }

        protected void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        protected void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void actionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = CanUndo();
            redoToolStripMenuItem.Enabled = CanRedo();
        }

        public void ResetCanvas()
        {
            ClearAllCanvasBitmaps();
            Canvas.LUndoList.Clear();
            Canvas.LRedoList.Clear();
            RefreshAllCanvasses();
        }

        protected void resetCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetCanvas();
        }

        private void ShowCanvasToolPanel()
        {
            Canvas._CanvasToolPanel.Show();
        }

        protected void showToolsPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCanvasToolPanel();
        }

        protected void CmsMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CmundoToolStripMenuItem.Enabled = CanUndo();
            CmredoToolStripMenuItem.Enabled = CanRedo();
        }

        private void FormCanvas_VisibleChanged(object sender, EventArgs e)
        {
            if (_IsChild) return;

            _CanvasToolPanel.Visible = this.Visible;
        }

        public bool IsCanvasVisibile()
        {
            return Canvas.Visible;
        }

        private void actionsToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in actionsToolStripMenuItem.DropDownItems)
                item.Enabled = true;
        }

        public void CloseCanvas()
        {
            IsClosedByCode = true;
            Canvas.Close();
        }

        public void ShowMainFormWhenCanvasIsHidden(Form MainForm)
        {
            this.MainForm = MainForm;
            Canvas.VisibleChanged += MainFormHandeling;
        }

        private void MainFormHandeling(object sender, EventArgs e)
        {
            // this must be like this , cuz it says ahow when hidden AND DOES NOT SAY HIDE WHEN SHOWN
            if (!IsCanvasVisibile())
            {
                if (MainForm != null && !MainForm.IsDisposed)
                    MainForm.Show();
            }
        }

        private void FormCanvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsClosedByCode)
            {
                e.Cancel = true;
                HideCanvas();
            }
        }

        public Color GetCanvasPenColor()
        {
            return Canvas._PenTool.Value.color;
        }

        private void FormCanvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CanvasBitmap.Dispose();
            //CanvasBitmapGraphics.Dispose();

            if (_IsChild) return;
            CanvasToolPanel.CloseToolsPanelByCode();
        }

        public void SelectCanvasTool(EnCanvasTools ToolToSelect)
        {
            Canvas.SelectedCanvasTool = ToolToSelect;
        }

        public void SetEraserWidth(float NewWidth)
        {
            Canvas._EraserTool = new StrokePen(Canvas._EraserTool.Value.color, NewWidth);
        }

        public float GetEraserWidth()
        {
            return Canvas._EraserTool.Value.width;
        }

        public EnCanvasTools GetSelectedCanvasTool()
        {
            return SelectedCanvasTool;
        }

        public float GetPenWidth()
        {
            return Canvas._PenTool.Value.width;
        }
    }
}
