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
        private bool _IsUpdatingNudWidthValue = false;

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
                _Canvas.SetPenColorTo(value);
                PnlCurrentColorSwatch.BackColor = _Canvas.GetCanvasPenColor();
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
            if (_IsUpdatingNudWidthValue) return;

            switch (_Canvas.GetSelectedCanvasTool())
            {
                case EnCanvasTools.Pen:
                    _Canvas.SetPenWidthTo(((float)NudWidth.Value));
                    break;
                case EnCanvasTools.Eraser:
                    _Canvas.SetEraserWidth(((float)NudWidth.Value));
                    break;
            }
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

        public void CloseToolsPanelByCode()
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

        public void DockToolsPanelToAboveCenter()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            int ScreenCenterX = Screen.PrimaryScreen.Bounds.Size.Width / 2;
            int PanelHalfWidth = this.Size.Width / 2;
            int PanelNewX = ScreenCenterX - PanelHalfWidth;

            this.Location = new Point(PanelNewX, 0);
        }

        public void UnDockToolsPanel()
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

        private void UpdateNudWidthValue(decimal NewValue)
        {
            _IsUpdatingNudWidthValue = true;
            NudWidth.Value = NewValue;
            _IsUpdatingNudWidthValue = false;
        }

        private void RbEraser_CheckedChanged(object sender, EventArgs e)
        {
            if (RbEraser.Checked)
            {
                _Canvas.SelectCanvasTool(EnCanvasTools.Eraser);
                UpdateNudWidthValue(((decimal)_Canvas.GetEraserWidth()));
            }
        }

        private void RbPen_CheckedChanged(object sender, EventArgs e)
        {
            if (RbPen.Checked)
            {
                _Canvas.SelectCanvasTool(EnCanvasTools.Pen);
                UpdateNudWidthValue(((decimal)_Canvas.GetPenWidth()));
            }
        }
    }
}
