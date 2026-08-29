namespace ScreenPen.GUI
{
    partial class FormCanvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCanvas));
            this.MsrMainMenu = new System.Windows.Forms.MenuStrip();
            this.canvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolsPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmresetCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmundoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmredoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CmshowToolsPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsaveCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmshowMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CmcloseCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsrMainMenu.SuspendLayout();
            this.CmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MsrMainMenu
            // 
            this.MsrMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canvasToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.drawingToolStripMenuItem});
            this.MsrMainMenu.Location = new System.Drawing.Point(0, 0);
            this.MsrMainMenu.Name = "MsrMainMenu";
            this.MsrMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MsrMainMenu.Size = new System.Drawing.Size(816, 24);
            this.MsrMainMenu.TabIndex = 0;
            // 
            // canvasToolStripMenuItem
            // 
            this.canvasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMenuToolStripMenuItem,
            this.hideMenuToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveCanvasToolStripMenuItem,
            this.closeCanvasToolStripMenuItem});
            this.canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            this.canvasToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.canvasToolStripMenuItem.Text = "&Canvas";
            // 
            // showMenuToolStripMenuItem
            // 
            this.showMenuToolStripMenuItem.Name = "showMenuToolStripMenuItem";
            this.showMenuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.showMenuToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.showMenuToolStripMenuItem.Text = "&Show Menu";
            this.showMenuToolStripMenuItem.Click += new System.EventHandler(this.showMenuToolStripMenuItem_Click);
            // 
            // hideMenuToolStripMenuItem
            // 
            this.hideMenuToolStripMenuItem.Name = "hideMenuToolStripMenuItem";
            this.hideMenuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.hideMenuToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.hideMenuToolStripMenuItem.Text = "&Hide Menu";
            this.hideMenuToolStripMenuItem.Click += new System.EventHandler(this.hideMenuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // saveCanvasToolStripMenuItem
            // 
            this.saveCanvasToolStripMenuItem.Name = "saveCanvasToolStripMenuItem";
            this.saveCanvasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveCanvasToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveCanvasToolStripMenuItem.Text = "Sa&ve Canvas";
            this.saveCanvasToolStripMenuItem.Click += new System.EventHandler(this.saveCanvasToolStripMenuItem_Click);
            // 
            // closeCanvasToolStripMenuItem
            // 
            this.closeCanvasToolStripMenuItem.Name = "closeCanvasToolStripMenuItem";
            this.closeCanvasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.closeCanvasToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.closeCanvasToolStripMenuItem.Text = "&Close Canvas";
            this.closeCanvasToolStripMenuItem.Click += new System.EventHandler(this.closeCanvasToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            this.actionsToolStripMenuItem.DropDownClosed += new System.EventHandler(this.actionsToolStripMenuItem_DropDownClosed);
            this.actionsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.actionsToolStripMenuItem_DropDownOpening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // drawingToolStripMenuItem
            // 
            this.drawingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolsPanelToolStripMenuItem,
            this.resetCanvasToolStripMenuItem});
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.drawingToolStripMenuItem.Text = "&Drawing";
            // 
            // showToolsPanelToolStripMenuItem
            // 
            this.showToolsPanelToolStripMenuItem.Name = "showToolsPanelToolStripMenuItem";
            this.showToolsPanelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.showToolsPanelToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.showToolsPanelToolStripMenuItem.Text = "&Show Tools Panel";
            this.showToolsPanelToolStripMenuItem.Click += new System.EventHandler(this.showToolsPanelToolStripMenuItem_Click);
            // 
            // resetCanvasToolStripMenuItem
            // 
            this.resetCanvasToolStripMenuItem.Name = "resetCanvasToolStripMenuItem";
            this.resetCanvasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.resetCanvasToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.resetCanvasToolStripMenuItem.Text = "&Reset Canvas";
            this.resetCanvasToolStripMenuItem.Click += new System.EventHandler(this.resetCanvasToolStripMenuItem_Click);
            // 
            // CmsMain
            // 
            this.CmsMain.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmresetCanvasToolStripMenuItem,
            this.CmundoToolStripMenuItem,
            this.CmredoToolStripMenuItem,
            this.toolStripSeparator2,
            this.CmshowToolsPanelToolStripMenuItem,
            this.CmsaveCanvasToolStripMenuItem,
            this.CmshowMenuToolStripMenuItem,
            this.toolStripSeparator3,
            this.CmcloseCanvasToolStripMenuItem});
            this.CmsMain.Name = "CmsMain";
            this.CmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.CmsMain.Size = new System.Drawing.Size(171, 170);
            this.CmsMain.Opening += new System.ComponentModel.CancelEventHandler(this.CmsMain_Opening);
            // 
            // CmresetCanvasToolStripMenuItem
            // 
            this.CmresetCanvasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CmresetCanvasToolStripMenuItem.Name = "CmresetCanvasToolStripMenuItem";
            this.CmresetCanvasToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CmresetCanvasToolStripMenuItem.Text = "&Reset Canvas";
            this.CmresetCanvasToolStripMenuItem.Click += new System.EventHandler(this.resetCanvasToolStripMenuItem_Click);
            // 
            // CmundoToolStripMenuItem
            // 
            this.CmundoToolStripMenuItem.Name = "CmundoToolStripMenuItem";
            this.CmundoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CmundoToolStripMenuItem.Text = "&Undo";
            this.CmundoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // CmredoToolStripMenuItem
            // 
            this.CmredoToolStripMenuItem.Name = "CmredoToolStripMenuItem";
            this.CmredoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CmredoToolStripMenuItem.Text = "&Redo";
            this.CmredoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // CmshowToolsPanelToolStripMenuItem
            // 
            this.CmshowToolsPanelToolStripMenuItem.Name = "CmshowToolsPanelToolStripMenuItem";
            this.CmshowToolsPanelToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CmshowToolsPanelToolStripMenuItem.Text = "Show &Tools Panel";
            this.CmshowToolsPanelToolStripMenuItem.Click += new System.EventHandler(this.showToolsPanelToolStripMenuItem_Click);
            // 
            // CmsaveCanvasToolStripMenuItem
            // 
            this.CmsaveCanvasToolStripMenuItem.Name = "CmsaveCanvasToolStripMenuItem";
            this.CmsaveCanvasToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CmsaveCanvasToolStripMenuItem.Text = "&Save Canvas";
            this.CmsaveCanvasToolStripMenuItem.Click += new System.EventHandler(this.saveCanvasToolStripMenuItem_Click);
            // 
            // CmshowMenuToolStripMenuItem
            // 
            this.CmshowMenuToolStripMenuItem.Name = "CmshowMenuToolStripMenuItem";
            this.CmshowMenuToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CmshowMenuToolStripMenuItem.Text = "Show &Menu";
            this.CmshowMenuToolStripMenuItem.Click += new System.EventHandler(this.showMenuToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // CmcloseCanvasToolStripMenuItem
            // 
            this.CmcloseCanvasToolStripMenuItem.Name = "CmcloseCanvasToolStripMenuItem";
            this.CmcloseCanvasToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.CmcloseCanvasToolStripMenuItem.Text = "&Close Canvas";
            this.CmcloseCanvasToolStripMenuItem.Click += new System.EventHandler(this.closeCanvasToolStripMenuItem_Click);
            // 
            // FormCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(816, 434);
            this.ContextMenuStrip = this.CmsMain;
            this.Controls.Add(this.MsrMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MsrMainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCanvas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Canvas";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.VisibleChanged += new System.EventHandler(this.FormCanvas_VisibleChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormCanvas_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormCanvas_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormCanvas_MouseUp);
            this.MsrMainMenu.ResumeLayout(false);
            this.MsrMainMenu.PerformLayout();
            this.CmsMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolsPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmundoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmshowMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmsaveCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmcloseCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmresetCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmshowToolsPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CmredoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.MenuStrip MsrMainMenu;
        protected System.Windows.Forms.ContextMenuStrip CmsMain;
    }
}