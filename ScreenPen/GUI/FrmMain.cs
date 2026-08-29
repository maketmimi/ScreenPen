using ScreenPen.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            _Canvas = GetSelectedCanvasTypeObject();
        }

        private ICanvas _Canvas;

        private ICanvas GetSelectedCanvasTypeObject()
        {
            FrmOverlayCanvas Canvas = new FrmOverlayCanvas();
            Canvas.ShowMainFormWhenCanvasIsHidden(this);
            return Canvas;
            // rest of logic here
            // do not forget to unsbuscreibe
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
    }
}
