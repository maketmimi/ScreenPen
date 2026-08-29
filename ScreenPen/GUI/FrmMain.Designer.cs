namespace ScreenPen.GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.MsrMain = new System.Windows.Forms.MenuStrip();
            this.appToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSavedCanvasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LibMalekGithub = new System.Windows.Forms.LinkLabel();
            this.ImgMain = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbScreenshotCanvas = new System.Windows.Forms.RadioButton();
            this.RbOverlayCanvas = new System.Windows.Forms.RadioButton();
            this.BtnStartDrawing = new System.Windows.Forms.Button();
            this.MsrMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MsrMain
            // 
            this.MsrMain.BackColor = System.Drawing.SystemColors.Control;
            this.MsrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.MsrMain.Location = new System.Drawing.Point(0, 0);
            this.MsrMain.Name = "MsrMain";
            this.MsrMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MsrMain.Size = new System.Drawing.Size(310, 24);
            this.MsrMain.TabIndex = 0;
            // 
            // appToolStripMenuItem
            // 
            this.appToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSavedCanvasesToolStripMenuItem,
            this.startDrawingToolStripMenuItem});
            this.appToolStripMenuItem.Name = "appToolStripMenuItem";
            this.appToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.appToolStripMenuItem.Text = "App";
            // 
            // showSavedCanvasesToolStripMenuItem
            // 
            this.showSavedCanvasesToolStripMenuItem.Name = "showSavedCanvasesToolStripMenuItem";
            this.showSavedCanvasesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.showSavedCanvasesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showSavedCanvasesToolStripMenuItem.Text = "Show Saved Canvases";
            this.showSavedCanvasesToolStripMenuItem.Click += new System.EventHandler(this.showSavedCanvasesToolStripMenuItem_Click);
            // 
            // startDrawingToolStripMenuItem
            // 
            this.startDrawingToolStripMenuItem.Name = "startDrawingToolStripMenuItem";
            this.startDrawingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.startDrawingToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.startDrawingToolStripMenuItem.Text = "Start Drawing";
            this.startDrawingToolStripMenuItem.Click += new System.EventHandler(this.StartDrawing_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Checked = true;
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.CheckedChanged += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_CheckedChanged);
            // 
            // LibMalekGithub
            // 
            this.LibMalekGithub.ActiveLinkColor = System.Drawing.Color.Black;
            this.LibMalekGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LibMalekGithub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LibMalekGithub.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LibMalekGithub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LibMalekGithub.ImageKey = "MalekAltamimi_Logo.png";
            this.LibMalekGithub.ImageList = this.ImgMain;
            this.LibMalekGithub.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LibMalekGithub.LinkColor = System.Drawing.Color.Black;
            this.LibMalekGithub.Location = new System.Drawing.Point(4, 183);
            this.LibMalekGithub.Name = "LibMalekGithub";
            this.LibMalekGithub.Size = new System.Drawing.Size(252, 27);
            this.LibMalekGithub.TabIndex = 5;
            this.LibMalekGithub.TabStop = true;
            this.LibMalekGithub.Text = "Developed by Malek Altamimi";
            this.LibMalekGithub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LibMalekGithub.VisitedLinkColor = System.Drawing.Color.Black;
            this.LibMalekGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LibMalekGithub_LinkClicked);
            // 
            // ImgMain
            // 
            this.ImgMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgMain.ImageStream")));
            this.ImgMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgMain.Images.SetKeyName(0, "MalekAltamimi_Logo.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbScreenshotCanvas);
            this.groupBox1.Controls.Add(this.RbOverlayCanvas);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 148);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canvas Type";
            // 
            // RbScreenshotCanvas
            // 
            this.RbScreenshotCanvas.Enabled = false;
            this.RbScreenshotCanvas.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.RbScreenshotCanvas.ForeColor = System.Drawing.Color.Black;
            this.RbScreenshotCanvas.Location = new System.Drawing.Point(15, 78);
            this.RbScreenshotCanvas.Name = "RbScreenshotCanvas";
            this.RbScreenshotCanvas.Size = new System.Drawing.Size(164, 52);
            this.RbScreenshotCanvas.TabIndex = 1;
            this.RbScreenshotCanvas.Text = "Stopped Screen Canvas";
            this.RbScreenshotCanvas.UseVisualStyleBackColor = true;
            // 
            // RbOverlayCanvas
            // 
            this.RbOverlayCanvas.AutoSize = true;
            this.RbOverlayCanvas.Checked = true;
            this.RbOverlayCanvas.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.RbOverlayCanvas.ForeColor = System.Drawing.Color.Black;
            this.RbOverlayCanvas.Location = new System.Drawing.Point(15, 45);
            this.RbOverlayCanvas.Name = "RbOverlayCanvas";
            this.RbOverlayCanvas.Size = new System.Drawing.Size(141, 27);
            this.RbOverlayCanvas.TabIndex = 0;
            this.RbOverlayCanvas.TabStop = true;
            this.RbOverlayCanvas.Text = "Overlay Canvas";
            this.RbOverlayCanvas.UseVisualStyleBackColor = true;
            // 
            // BtnStartDrawing
            // 
            this.BtnStartDrawing.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnStartDrawing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.BtnStartDrawing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnStartDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStartDrawing.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStartDrawing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnStartDrawing.Location = new System.Drawing.Point(210, 44);
            this.BtnStartDrawing.Name = "BtnStartDrawing";
            this.BtnStartDrawing.Size = new System.Drawing.Size(88, 136);
            this.BtnStartDrawing.TabIndex = 7;
            this.BtnStartDrawing.Text = "Start Drawing";
            this.BtnStartDrawing.UseVisualStyleBackColor = true;
            this.BtnStartDrawing.Click += new System.EventHandler(this.StartDrawing_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(310, 213);
            this.Controls.Add(this.BtnStartDrawing);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LibMalekGithub);
            this.Controls.Add(this.MsrMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MsrMain;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "ScreenPen";
            this.TopMost = true;
            this.MsrMain.ResumeLayout(false);
            this.MsrMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MsrMain;
        private System.Windows.Forms.ToolStripMenuItem appToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSavedCanvasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDrawingToolStripMenuItem;
        private System.Windows.Forms.LinkLabel LibMalekGithub;
        private System.Windows.Forms.ImageList ImgMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RbScreenshotCanvas;
        private System.Windows.Forms.RadioButton RbOverlayCanvas;
        private System.Windows.Forms.Button BtnStartDrawing;
    }
}