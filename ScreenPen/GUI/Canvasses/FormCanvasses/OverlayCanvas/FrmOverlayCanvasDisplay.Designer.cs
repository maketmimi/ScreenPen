using System.Windows.Forms;

namespace ScreenPen.GUI.Canvasses.FormCanvasses.OverlayCanvas
{
    partial class FrmOverlayCanvasDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOverlayCanvasDisplay));
            this.PbCanvasDisplay = new System.Windows.Forms.PictureBox();
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
            this.resetCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolsPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbCanvasDisplay)).BeginInit();
            this.MsrMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbCanvasDisplay
            // 
            this.PbCanvasDisplay.BackColor = System.Drawing.Color.Transparent;
            this.PbCanvasDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbCanvasDisplay.Location = new System.Drawing.Point(0, 0);
            this.PbCanvasDisplay.Name = "PbCanvasDisplay";
            this.PbCanvasDisplay.Size = new System.Drawing.Size(800, 450);
            this.PbCanvasDisplay.TabIndex = 0;
            this.PbCanvasDisplay.TabStop = false;
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
            this.MsrMainMenu.Size = new System.Drawing.Size(800, 24);
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
            // 
            // hideMenuToolStripMenuItem
            // 
            this.hideMenuToolStripMenuItem.Name = "hideMenuToolStripMenuItem";
            this.hideMenuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.hideMenuToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.hideMenuToolStripMenuItem.Text = "&Hide Menu";
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
            // 
            // closeCanvasToolStripMenuItem
            // 
            this.closeCanvasToolStripMenuItem.Name = "closeCanvasToolStripMenuItem";
            this.closeCanvasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.closeCanvasToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.closeCanvasToolStripMenuItem.Text = "&Close Canvas";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // drawingToolStripMenuItem
            // 
            this.drawingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetCanvasToolStripMenuItem,
            this.toolStripSeparator2,
            this.showToolsPanelToolStripMenuItem});
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.drawingToolStripMenuItem.Text = "&Drawing";
            // 
            // resetCanvasToolStripMenuItem
            // 
            this.resetCanvasToolStripMenuItem.Name = "resetCanvasToolStripMenuItem";
            this.resetCanvasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.resetCanvasToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.resetCanvasToolStripMenuItem.Text = "&Reset Canvas";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // showToolsPanelToolStripMenuItem
            // 
            this.showToolsPanelToolStripMenuItem.Name = "showToolsPanelToolStripMenuItem";
            this.showToolsPanelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.showToolsPanelToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.showToolsPanelToolStripMenuItem.Text = "&Show Tools Panel";
            // 
            // FrmOverlayCanvasDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.MsrMainMenu);
            this.Controls.Add(this.PbCanvasDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOverlayCanvasDisplay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PbCanvasDisplay)).EndInit();
            this.MsrMainMenu.ResumeLayout(false);
            this.MsrMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbCanvasDisplay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.MenuStrip MsrMainMenu;
        public System.Windows.Forms.ToolStripMenuItem canvasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem showMenuToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem hideMenuToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveCanvasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem closeCanvasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem drawingToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem showToolsPanelToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem resetCanvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}