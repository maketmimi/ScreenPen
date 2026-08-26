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
        protected Bitmap CanvasBitmap
        {
            set
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
        protected Pen CanvasPen { set; get; } = null;
        private bool _IsUserDrawing = false;
        private FormCanvasStroke _CurrentStroke = null;

        protected List<FormCanvasStroke> LDrawnStrokes = null;
        protected List<FormCanvasStroke> LUndoList = null;
        protected List<FormCanvasStroke> LRedoList = null;

        protected readonly FrmCanvasToolsPanel CanvasToolPanel = null;

        // parent canves consrtuctor
        protected FormCanvas()
        {
            InitializeComponent();

            CanvasScreen = Screen.PrimaryScreen;
            InitializeChildCanvasses();
            InitializeCanvasPen();

            LUndoList = new List<FormCanvasStroke>();
            LDrawnStrokes = LUndoList;
            LRedoList = new List<FormCanvasStroke>();
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
        }

        private void ParentCanvas_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = ParentCanvas.Visible;
        }

        private void InitializeCanvasPen()
        {
            CanvasPen = new Pen(Color.Black, 5)
            {
                LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };
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
            throw new NotImplementedException();
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
            if (_IsChild)
            {
                ParentCanvas.RefreshAllCanvasses();
                return;
            }

            if (ChildCanvasses == null) return;

            foreach (var ChildCanvas in ChildCanvasses)
                ChildCanvas.RefreshCurrentCanvas();
        }

        private void FormCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _IsUserDrawing = true;
            _CurrentStroke = new FormCanvasStroke(Canvas.CanvasPen, e.Location, this);
        }

        private void FormCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsUserDrawing) return;

            _CurrentStroke.AddPoint(e.Location);
            _CurrentStroke.DrawLastSegment();
            RefreshCurrentCanvas();
        }

        private void FormCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _IsUserDrawing = false;

            Canvas.LDrawnStrokes.Add(_CurrentStroke); // this adds it to the LUndoList as well 
            Canvas.LRedoList.Clear();
            _CurrentStroke = null;
        }

        private void ResetCurrentCanvasBitmap()
        {
            CanvasBitmapGraphics.Clear(Color.Transparent);
        }

        private void ResetAllCanvasBitmaps()
        {
            Canvas.ResetCurrentCanvasBitmap();

            if (Canvas.ChildCanvasses.Length > 0)
            {
                foreach (var ChildCanvas in Canvas.ChildCanvasses)
                {
                    ChildCanvas.ResetCurrentCanvasBitmap();
                }
            }
        }

        private void RedrawCanvasBitmaps()
        {
            ResetAllCanvasBitmaps();

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
            Canvas.CanvasPen.Width = NewWidth;
        }

        public void SetPenColorTo(Color NewColor)
        {
            Canvas.CanvasPen.Color = NewColor;
        }

        public void SetNewPen(Pen NewPen)
        {
            Canvas.CanvasPen = NewPen;
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

        private void showMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas.MsrMainMenu.Show();
        }

        private void hideMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas.MsrMainMenu.Hide();
        }

        private void saveCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FolderPath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "ScreenPen");
            SaveCanvas(FolderPath, ImageFormat.Png);
        }

        private void closeCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideCanvas();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void actionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = CanUndo();
            redoToolStripMenuItem.Enabled = CanRedo();
        }

        private void resetCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllCanvasBitmaps();
        }

        private void ShowCanvasToolPanel()
        {
            Canvas.CanvasToolPanel.Show();
        }

        private void showToolsPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCanvasToolPanel();
        }

        private void CmsMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CmundoToolStripMenuItem.Enabled = CanUndo();
            CmredoToolStripMenuItem.Enabled = CanRedo();
        }
    }
}
