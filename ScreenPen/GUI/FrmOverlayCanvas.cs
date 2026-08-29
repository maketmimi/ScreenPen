using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FrmOverlayCanvas : FormCanvas
    {
        private FrmOverlayCanvasDisplay _CanvasDisplay;

        public FrmOverlayCanvas()
        {
            InitializeComponent();
            InitializeCanvasDisplay();
            CanvasToolPanel.Owner = _CanvasDisplay;
        }

        private FrmOverlayCanvas(FrmOverlayCanvas ParentCanvas, Screen CanvasScreen) : base(ParentCanvas, CanvasScreen)
        {
            InitializeComponent();
            InitializeCanvasDisplay();
            // test 
            this.Text = "Child";
        }

        protected override void CanvasToolPanel_LocationChanged(object sender, EventArgs e)
        {
            if (CanvasScreen.Bounds.Contains(CanvasToolPanel.Location))
                CanvasToolPanel.Owner = _CanvasDisplay;
        }

        private void InitializeCanvasDisplay()
        {
            _CanvasDisplay = new FrmOverlayCanvasDisplay(this);
            _CanvasDisplay.Owner = this;
            
            // mouse event
            
            _CanvasDisplay.Display.MouseDown += this.FormCanvas_MouseDown;
            _CanvasDisplay.Display.MouseMove += this.FormCanvas_MouseMove;
            _CanvasDisplay.Display.MouseUp += this.FormCanvas_MouseUp;
            
            // menu strips
            
            _CanvasDisplay.ContextMenuStrip = this.CmsMain;

            _CanvasDisplay.showMenuToolStripMenuItem.Click += this.showMenuToolStripMenuItem_Click;
            _CanvasDisplay.hideMenuToolStripMenuItem.Click += this.hideMenuToolStripMenuItem_Click;
            _CanvasDisplay.saveCanvasToolStripMenuItem.Click += this.saveCanvasToolStripMenuItem_Click;
            _CanvasDisplay.closeCanvasToolStripMenuItem.Click += this.closeCanvasToolStripMenuItem_Click;
            _CanvasDisplay.redoToolStripMenuItem.Click += this.redoToolStripMenuItem_Click;
            _CanvasDisplay.undoToolStripMenuItem.Click += this.undoToolStripMenuItem_Click;
            _CanvasDisplay.showToolsPanelToolStripMenuItem.Click += this.showToolsPanelToolStripMenuItem_Click;
            _CanvasDisplay.resetCanvasToolStripMenuItem.Click += this.resetCanvasToolStripMenuItem_Click;
            this.MsrMainMenu.VisibleChanged += MsrMainMenu_VisibleChanged;
        }

        private void MsrMainMenu_VisibleChanged(object sender, EventArgs e)
        {
            _CanvasDisplay.MsrMainMenu.Visible = this.MsrMainMenu.Visible;
        }

        public override void SaveCanvas(string FolderPath, ImageFormat ImageType)
        {
            throw new NotImplementedException();
        }

        protected override FormCanvas CreateChildCanvas(FormCanvas ParentCanvas, Screen CanvasScreen)
        {
            return new FrmOverlayCanvas((FrmOverlayCanvas) ParentCanvas, CanvasScreen);
        }

        protected override void RefreshCurrentCanvas()
        {
            _CanvasDisplay.RefreashCanvasDisplay();
        }
    }
}
