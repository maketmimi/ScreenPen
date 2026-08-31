using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FrmOverlayCanvasDisplay : Form
    {
        public static readonly Color DisplayTransparencyKey = Color.FromArgb(254, 254, 254);
        private readonly FrmOverlayCanvas _Canvas;
        public PictureBox Display
        {
            get
            {
                return PbCanvasDisplay;
            }
        }

        public FrmOverlayCanvasDisplay(FrmOverlayCanvas Canvas)
        {
            if (Canvas == null)
                throw new ArgumentNullException();

            InitializeComponent();
            _Canvas = Canvas;
            this.Location = _Canvas.Location;
            this.PbCanvasDisplay.Image = _Canvas.CanvasBitmap;
            this.TransparencyKey = DisplayTransparencyKey;
            //this.BackColor = DisplayTransparencyKey;

            _Canvas.VisibleChanged += _Canvas_VisibleChanged;
            _Canvas.FormClosed += _Canvas_FormClosed;
        }

        private void _Canvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void _Canvas_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = _Canvas.Visible;
        }


        public void RefreashCanvasDisplay()
        {
            PbCanvasDisplay.Invalidate();
        }
    }
}
