using ScreenPen.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FrmCanvasToolsPanel : Form
    {
        private readonly ICanvas _Canvas; 

        public FrmCanvasToolsPanel(ICanvas Canvas)
        {
            InitializeComponent();

            if (Canvas == null)
                throw new ArgumentNullException();

            _Canvas = Canvas;
        }

        private Color CurrentPenColor
        {
            set
            {
                PnlCurrentColorSwatch.BackColor = value;
                _Canvas.SetPenColorTo(value);
            }

            get
            {
                return PnlCurrentColorSwatch.BackColor;
            }
        }
    
        private void QuickColor_Click(object sender, EventArgs e)
        {
            CurrentPenColor = ((Panel)sender).BackColor;
        }

        private void PnlCurrentColorSwatch_DoubleClick(object sender, EventArgs e)
        {
            MainColorDialog.Color = CurrentPenColor;

            if (MainColorDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentPenColor = MainColorDialog.Color;
            }
        }

        private void NudPenWidth_ValueChanged(object sender, EventArgs e)
        {
            _Canvas.SetPenWidthTo(((float)NudPenWidth.Value));
        }

        private void BtnCloseCanvas_Click(object sender, EventArgs e)
        {
            _Canvas.HideCanvas();
        }

        private void BtnSaveCanvas_Click(object sender, EventArgs e)
        {
            string FolderPath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "ScreenPen");
            _Canvas.SaveCanvas(FolderPath, ImageFormat.Png);
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {

        }
    }
}
