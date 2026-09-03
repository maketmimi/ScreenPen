namespace ScreenPen.GUI.Canvasses.FormCanvasses.ScreenShotCanvas
{
    partial class FrmScreenshotCanvas
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
            this.PbCanvasDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbCanvasDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // PbCanvasDisplay
            // 
            this.PbCanvasDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PbCanvasDisplay.Location = new System.Drawing.Point(39, 12);
            this.PbCanvasDisplay.Name = "PbCanvasDisplay";
            this.PbCanvasDisplay.Size = new System.Drawing.Size(723, 374);
            this.PbCanvasDisplay.TabIndex = 2;
            this.PbCanvasDisplay.TabStop = false;
            // 
            // FrmScreenshotCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PbCanvasDisplay);
            this.Name = "FrmScreenshotCanvas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScreenshotCanvas_FormClosed);
            this.Controls.SetChildIndex(this.PbCanvasDisplay, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PbCanvasDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbCanvasDisplay;
    }
}