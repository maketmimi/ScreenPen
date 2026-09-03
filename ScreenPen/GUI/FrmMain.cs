using ScreenPen.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FrmMain : Form
    {
        private ICanvas _Canvas;

        public FrmMain()
        {
            InitializeComponent();
            InitializeCanvasTypeRadioButtons();
            _Canvas = Factory.GetCanvasObject(Factory.EnCanvasType.OverlayCanvas);
            _Canvas.ShowMainFormWhenCanvasIsHidden(this);
        }

        private void InitializeCanvasTypeRadioButtons()
        {
            RbOverlayCanvas.Tag = Factory.EnCanvasType.OverlayCanvas;
            RbScreenshotCanvas.Tag = Factory.EnCanvasType.ScreenShotCanvas;
        }

        private void LibMalekGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/maketmimi");
            LibMalekGithub.LinkVisited = true;
        }

        private void showSavedCanvasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FolderPath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "ScreenPen");

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            System.Diagnostics.Process.Start(FolderPath);
        }

        private void alwaysOnTopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void StartDrawing_Click(object sender, EventArgs e)
        {
            this.Hide();
            _Canvas.ShowCanvas();
        }

        private void CanvasType_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton RbSender && RbSender.Checked)
            {
                _Canvas.CloseCanvas();
                _Canvas = Factory.GetCanvasObject((Factory.EnCanvasType)RbSender.Tag);
                _Canvas.ShowMainFormWhenCanvasIsHidden(this);
            }
        }
    }
}
