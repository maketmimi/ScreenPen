using Microsoft.Win32;
using ScreenPen.Core;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ScreenPen.GUI
{
    public partial class FrmMain : Form
    {
        private ICanvas _Canvas = null;
        private ICanvas Canvas
        {
            set
            {
                if (value == null)
                    throw new Exception("Why are you here? Please Contact the developer to investigate this unknown Error!");

                if (_Canvas != null)
                    _Canvas.CloseCanvas();

                _Canvas = value;
                _Canvas.ShowMainFormWhenCanvasIsHidden(this);
            }

            get
            {
                return _Canvas;
            }
        }

        public FrmMain()
        {
            InitializeComponent();
            InitializeCanvasTypeRadioButtons();
            Canvas = Factory.GetCanvasObject(GetSelectedCanvasType());
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        private Factory.EnCanvasType GetSelectedCanvasType()
        {
            if (RbOverlayCanvas.Checked)
                return (Factory.EnCanvasType)RbOverlayCanvas.Tag;
            else if (RbScreenshotCanvas.Checked)
                return (Factory.EnCanvasType)RbScreenshotCanvas.Tag;
            else
                throw new Exception("Some thing went really wrong, you shouldn't be here at all!");
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Thread.Sleep(1000); // just wait for the system to settle down

            bool WasCanvasVisible = Canvas.IsCanvasVisibile();
            
            Canvas = Factory.GetCanvasObject(GetSelectedCanvasType());

            if (WasCanvasVisible)
                StartDrawing();
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

        private void StartDrawing()
        {
            this.Hide();

            // TODO: We must wait for the main form to be hidden before showing the canvas

            Canvas.ShowCanvas();
        }

        private void StartDrawing_Click(object sender, EventArgs e)
        {
            StartDrawing();
        }

        private void CanvasType_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton RbSender && RbSender.Checked)
            {
                Canvas = Factory.GetCanvasObject((Factory.EnCanvasType)RbSender.Tag);
            }
        }
    }
}
