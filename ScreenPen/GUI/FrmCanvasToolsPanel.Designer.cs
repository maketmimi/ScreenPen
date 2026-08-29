namespace ScreenPen.GUI
{
    partial class FrmCanvasToolsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCanvasToolsPanel));
            this.PnlCurrentColorSwatch = new System.Windows.Forms.Panel();
            this.NudPenWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnUndo = new System.Windows.Forms.Button();
            this.ImgMain = new System.Windows.Forms.ImageList(this.components);
            this.BtnRedo = new System.Windows.Forms.Button();
            this.PnlActions = new System.Windows.Forms.Panel();
            this.CmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dockToAboveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCloseCanvas = new System.Windows.Forms.Button();
            this.BtnSaveCanvas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PnlRedSwatch = new System.Windows.Forms.Panel();
            this.PnlGreenSwatch = new System.Windows.Forms.Panel();
            this.PnlBlueSwatch = new System.Windows.Forms.Panel();
            this.PnlBlackSwatch = new System.Windows.Forms.Panel();
            this.MainColorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.NudPenWidth)).BeginInit();
            this.PnlActions.SuspendLayout();
            this.CmsMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlCurrentColorSwatch
            // 
            this.PnlCurrentColorSwatch.BackColor = System.Drawing.Color.Black;
            this.PnlCurrentColorSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlCurrentColorSwatch.Location = new System.Drawing.Point(339, 4);
            this.PnlCurrentColorSwatch.Name = "PnlCurrentColorSwatch";
            this.PnlCurrentColorSwatch.Size = new System.Drawing.Size(40, 40);
            this.PnlCurrentColorSwatch.TabIndex = 0;
            this.PnlCurrentColorSwatch.DoubleClick += new System.EventHandler(this.PnlCurrentColorSwatch_DoubleClick);
            // 
            // NudPenWidth
            // 
            this.NudPenWidth.BackColor = System.Drawing.Color.White;
            this.NudPenWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NudPenWidth.DecimalPlaces = 1;
            this.NudPenWidth.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NudPenWidth.ForeColor = System.Drawing.Color.Black;
            this.NudPenWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NudPenWidth.Location = new System.Drawing.Point(118, 9);
            this.NudPenWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NudPenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudPenWidth.Name = "NudPenWidth";
            this.NudPenWidth.Size = new System.Drawing.Size(54, 30);
            this.NudPenWidth.TabIndex = 5;
            this.NudPenWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudPenWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudPenWidth.ValueChanged += new System.EventHandler(this.NudPenWidth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pen Width:";
            // 
            // BtnUndo
            // 
            this.BtnUndo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.BtnUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUndo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUndo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnUndo.ImageKey = "undo.png";
            this.BtnUndo.ImageList = this.ImgMain;
            this.BtnUndo.Location = new System.Drawing.Point(6, 8);
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(36, 32);
            this.BtnUndo.TabIndex = 8;
            this.BtnUndo.UseVisualStyleBackColor = true;
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // ImgMain
            // 
            this.ImgMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgMain.ImageStream")));
            this.ImgMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgMain.Images.SetKeyName(0, "redo.png");
            this.ImgMain.Images.SetKeyName(1, "undo.png");
            this.ImgMain.Images.SetKeyName(2, "Save.png");
            this.ImgMain.Images.SetKeyName(3, "close.png");
            // 
            // BtnRedo
            // 
            this.BtnRedo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnRedo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.BtnRedo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRedo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRedo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnRedo.ImageKey = "redo.png";
            this.BtnRedo.ImageList = this.ImgMain;
            this.BtnRedo.Location = new System.Drawing.Point(48, 8);
            this.BtnRedo.Name = "BtnRedo";
            this.BtnRedo.Size = new System.Drawing.Size(36, 32);
            this.BtnRedo.TabIndex = 9;
            this.BtnRedo.UseVisualStyleBackColor = true;
            this.BtnRedo.Click += new System.EventHandler(this.BtnRedo_Click);
            // 
            // PnlActions
            // 
            this.PnlActions.BackColor = System.Drawing.Color.Transparent;
            this.PnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlActions.ContextMenuStrip = this.CmsMain;
            this.PnlActions.Controls.Add(this.BtnCloseCanvas);
            this.PnlActions.Controls.Add(this.BtnSaveCanvas);
            this.PnlActions.Controls.Add(this.BtnRedo);
            this.PnlActions.Controls.Add(this.BtnUndo);
            this.PnlActions.Location = new System.Drawing.Point(405, 7);
            this.PnlActions.Name = "PnlActions";
            this.PnlActions.Size = new System.Drawing.Size(176, 51);
            this.PnlActions.TabIndex = 10;
            // 
            // CmsMain
            // 
            this.CmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dockToAboveToolStripMenuItem});
            this.CmsMain.Name = "CmsMain";
            this.CmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.CmsMain.Size = new System.Drawing.Size(154, 26);
            // 
            // dockToAboveToolStripMenuItem
            // 
            this.dockToAboveToolStripMenuItem.CheckOnClick = true;
            this.dockToAboveToolStripMenuItem.Name = "dockToAboveToolStripMenuItem";
            this.dockToAboveToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.dockToAboveToolStripMenuItem.Text = "Dock to above ";
            this.dockToAboveToolStripMenuItem.CheckedChanged += new System.EventHandler(this.dockToAboveToolStripMenuItem_CheckedChanged);
            // 
            // BtnCloseCanvas
            // 
            this.BtnCloseCanvas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnCloseCanvas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.BtnCloseCanvas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnCloseCanvas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseCanvas.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCloseCanvas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnCloseCanvas.ImageKey = "close.png";
            this.BtnCloseCanvas.ImageList = this.ImgMain;
            this.BtnCloseCanvas.Location = new System.Drawing.Point(132, 8);
            this.BtnCloseCanvas.Name = "BtnCloseCanvas";
            this.BtnCloseCanvas.Size = new System.Drawing.Size(36, 32);
            this.BtnCloseCanvas.TabIndex = 11;
            this.BtnCloseCanvas.UseVisualStyleBackColor = true;
            this.BtnCloseCanvas.Click += new System.EventHandler(this.BtnCloseCanvas_Click);
            // 
            // BtnSaveCanvas
            // 
            this.BtnSaveCanvas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSaveCanvas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.BtnSaveCanvas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnSaveCanvas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveCanvas.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveCanvas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnSaveCanvas.ImageKey = "Save.png";
            this.BtnSaveCanvas.ImageList = this.ImgMain;
            this.BtnSaveCanvas.Location = new System.Drawing.Point(90, 8);
            this.BtnSaveCanvas.Name = "BtnSaveCanvas";
            this.BtnSaveCanvas.Size = new System.Drawing.Size(36, 32);
            this.BtnSaveCanvas.TabIndex = 10;
            this.BtnSaveCanvas.UseVisualStyleBackColor = true;
            this.BtnSaveCanvas.Click += new System.EventHandler(this.BtnSaveCanvas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ContextMenuStrip = this.CmsMain;
            this.panel1.Controls.Add(this.PnlRedSwatch);
            this.panel1.Controls.Add(this.PnlGreenSwatch);
            this.panel1.Controls.Add(this.PnlBlueSwatch);
            this.panel1.Controls.Add(this.PnlBlackSwatch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PnlCurrentColorSwatch);
            this.panel1.Controls.Add(this.NudPenWidth);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 51);
            this.panel1.TabIndex = 11;
            // 
            // PnlRedSwatch
            // 
            this.PnlRedSwatch.BackColor = System.Drawing.Color.Red;
            this.PnlRedSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlRedSwatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PnlRedSwatch.Location = new System.Drawing.Point(198, 9);
            this.PnlRedSwatch.Name = "PnlRedSwatch";
            this.PnlRedSwatch.Size = new System.Drawing.Size(30, 30);
            this.PnlRedSwatch.TabIndex = 4;
            this.PnlRedSwatch.Click += new System.EventHandler(this.QuickColor_Click);
            // 
            // PnlGreenSwatch
            // 
            this.PnlGreenSwatch.BackColor = System.Drawing.Color.Green;
            this.PnlGreenSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlGreenSwatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PnlGreenSwatch.Location = new System.Drawing.Point(233, 9);
            this.PnlGreenSwatch.Name = "PnlGreenSwatch";
            this.PnlGreenSwatch.Size = new System.Drawing.Size(30, 30);
            this.PnlGreenSwatch.TabIndex = 3;
            this.PnlGreenSwatch.Click += new System.EventHandler(this.QuickColor_Click);
            // 
            // PnlBlueSwatch
            // 
            this.PnlBlueSwatch.BackColor = System.Drawing.Color.Blue;
            this.PnlBlueSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlBlueSwatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PnlBlueSwatch.Location = new System.Drawing.Point(268, 9);
            this.PnlBlueSwatch.Name = "PnlBlueSwatch";
            this.PnlBlueSwatch.Size = new System.Drawing.Size(30, 30);
            this.PnlBlueSwatch.TabIndex = 2;
            this.PnlBlueSwatch.Click += new System.EventHandler(this.QuickColor_Click);
            // 
            // PnlBlackSwatch
            // 
            this.PnlBlackSwatch.BackColor = System.Drawing.Color.Black;
            this.PnlBlackSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlBlackSwatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PnlBlackSwatch.Location = new System.Drawing.Point(303, 9);
            this.PnlBlackSwatch.Name = "PnlBlackSwatch";
            this.PnlBlackSwatch.Size = new System.Drawing.Size(30, 30);
            this.PnlBlackSwatch.TabIndex = 1;
            this.PnlBlackSwatch.Click += new System.EventHandler(this.QuickColor_Click);
            // 
            // FrmCanvasToolsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 64);
            this.ContextMenuStrip = this.CmsMain;
            this.Controls.Add(this.PnlActions);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCanvasToolsPanel";
            this.ShowInTaskbar = false;
            this.Text = "Tools Panel";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCanvasToolsPanel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.NudPenWidth)).EndInit();
            this.PnlActions.ResumeLayout(false);
            this.CmsMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlCurrentColorSwatch;
        private System.Windows.Forms.NumericUpDown NudPenWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnUndo;
        private System.Windows.Forms.ImageList ImgMain;
        private System.Windows.Forms.Button BtnRedo;
        private System.Windows.Forms.Panel PnlActions;
        private System.Windows.Forms.Button BtnSaveCanvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCloseCanvas;
        private System.Windows.Forms.ContextMenuStrip CmsMain;
        private System.Windows.Forms.ToolStripMenuItem dockToAboveToolStripMenuItem;
        private System.Windows.Forms.ColorDialog MainColorDialog;
        private System.Windows.Forms.Panel PnlRedSwatch;
        private System.Windows.Forms.Panel PnlGreenSwatch;
        private System.Windows.Forms.Panel PnlBlueSwatch;
        private System.Windows.Forms.Panel PnlBlackSwatch;
    }
}