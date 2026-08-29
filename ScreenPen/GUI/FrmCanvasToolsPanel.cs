using ScreenPen.Core;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FrmCanvasToolsPanel : Form
    {
        private readonly ICanvas _Canvas;
        private bool _ClosedByXButton = true;

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
            _Canvas.Redo();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            _Canvas.Undo();
        }

        public void CloseToolsPanel()
        {
            _ClosedByXButton = false;
            this.Close();
        }

        private void FrmCanvasToolsPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ClosedByXButton)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void DockToolsPanelToAboveCenter()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            int ScreenCenterX = Screen.PrimaryScreen.Bounds.Size.Width / 2;
            int PanelHalfWidth = this.Size.Width / 2;
            int PanelNewX = ScreenCenterX - PanelHalfWidth;

            this.Location = new Point(PanelNewX, 0);
        }

        private void UnDockToolsPanel()
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void dockToAboveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (dockToAboveToolStripMenuItem.Checked)
                DockToolsPanelToAboveCenter();
            else
                UnDockToolsPanel();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            _Canvas.ResetCanvas();
        }
    }
}
