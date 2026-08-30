using ScreenPen.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
        
        private Bitmap _CanvasBitmap = null;
        public Bitmap CanvasBitmap
        {
            protected set
            {
                if (value != null)
                {
                    _CanvasBitmap = value;
                    CanvasBitmapGraphics = Graphics.FromImage(_CanvasBitmap);
                    CanvasBitmapGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                }
            }

            get
            {
                return _CanvasBitmap;
            }
        }
        public Graphics CanvasBitmapGraphics { set; get; }
        protected StrokePen? CanvasStrokePen { set; get; } = null; // I made it null so child canvasses don't create their own copy
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
            InitializeCanvasStrokePen();

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
        private void InitializeCanvasStrokePen()
        {
            CanvasStrokePen = new StrokePen(Color.Black, 5);
        }

        private void ParentMsrMainMenu_VisibleChanged(object sender, EventArgs e)
        {
            MsrMainMenu.Visible = ParentCanvas.MsrMainMenu.Visible;
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
            _CurrentStroke = new FormCanvasStroke(Canvas.CanvasStrokePen.Value, e.Location, this);
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
                Canvas.LDrawnStrokes.Add(_CurrentStroke); // this adds it to the LUndoList as well 
                Canvas.LRedoList.Clear();
            }

            _CurrentStroke = null;
        }

        private void ClearCurrentCanvasBitmap()
        {
            CanvasBitmapGraphics.Clear(Color.Transparent);
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
            Canvas.CanvasStrokePen = new StrokePen(Canvas.CanvasStrokePen.Value.color, NewWidth);
        }

        public void SetPenColorTo(Color NewColor)
        {
            Canvas.CanvasStrokePen = new StrokePen(NewColor, Canvas.CanvasStrokePen.Value.width);
        }

        public void SetNewPen(StrokePen NewPen)
        {
            Canvas.CanvasStrokePen = NewPen;
        }

        public virtual void SaveCanvas(string FolderPath, ImageFormat ImageType)
        {
            throw new NotImplementedException();
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
            RedrawCanvasBitmaps();
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
    }
}
