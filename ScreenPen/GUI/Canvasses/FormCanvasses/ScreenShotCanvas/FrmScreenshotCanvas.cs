using ScreenPen.Core;
using ScreenPen.Properties;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScreenPen.GUI.Canvasses.FormCanvasses.ScreenShotCanvas
{
    public partial class FrmScreenshotCanvas : FormCanvas
    {
        private Bitmap _DesktopImage = null; 

        public FrmScreenshotCanvas()
        {
            InitializeComponent();
            InitializePbCanvasDisplay();
        }

        protected FrmScreenshotCanvas(FormCanvas ParentCanvas, Screen CanvasScreen) : base(ParentCanvas, CanvasScreen)
        {
            InitializeComponent();
            InitializePbCanvasDisplay();
        }

        private void InitializePbCanvasDisplay()
        {
            PbCanvasDisplay.Image = CanvasBitmap;
            RecalculatePbCanvasDisplaySizeAndLocation();

            // Test

            //PbCanvasDisplay.Cursor = new Cursor(new MemoryStream(Resources.PenTest));

            // Test

            PbCanvasDisplay.MouseDown += FormCanvas_MouseDown;
            PbCanvasDisplay.MouseMove += FormCanvas_MouseMove;
            PbCanvasDisplay.MouseUp += FormCanvas_MouseUp;
        }

        private void UpdateDesktopImage()
        {
            if (_DesktopImage != null)
                _DesktopImage.Dispose();

            _DesktopImage = new Bitmap(CanvasScreen.Bounds.Width, CanvasScreen.Bounds.Height);
            Graphics DesktopImageGraphics = Graphics.FromImage(_DesktopImage);

            DesktopImageGraphics.CopyFromScreen(CanvasScreen.Bounds.Location, new Point(0, 0), CanvasScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            BitmapsUtils.PutOverlayOnBitmap(_DesktopImage, Color.FromArgb(102, Color.Black)); // it's a black color with 40% opecity

            PbCanvasDisplay.BackgroundImage = _DesktopImage;

            DesktopImageGraphics.Dispose();
        }

        private void RecalculatePbCanvasDisplaySizeAndLocation()
        {
            PbCanvasDisplay.Size = CanvasScreen.Bounds.Size;
            PbCanvasDisplay.Location = new Point(0, 0);
            PbCanvasDisplay.SendToBack();
        }

        protected override FormCanvas CreateChildCanvas(FormCanvas ParentCanvas, Screen CanvasScreen)
        {
            return new FrmScreenshotCanvas(ParentCanvas, CanvasScreen);
        }

        protected override void RefreshCurrentCanvas()
        {
            PbCanvasDisplay.Invalidate();
        }

        protected override void ShowForm()
        {
            UpdateDesktopImage(); // this must be done here once unless you want to ubdate he background image each time the canvas is shown
            base.ShowForm();
        }

        private void FrmScreenshotCanvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_DesktopImage != null)
                _DesktopImage.Dispose();
        }
    }
}
