namespace ProjectManager
{
    partial class FloorplanEditor
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
            this.FloorplanCanvas = new ProjectManager.Canvas();
            ((System.ComponentModel.ISupportInitialize)(this.FloorplanCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // FloorplanCanvas
            // 
            this.FloorplanCanvas.Location = new System.Drawing.Point(0, 0);
            this.FloorplanCanvas.Name = "FloorplanCanvas";
            this.FloorplanCanvas.Size = new System.Drawing.Size(274, 126);
            this.FloorplanCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.FloorplanCanvas.TabIndex = 0;
            this.FloorplanCanvas.TabStop = false;
            this.FloorplanCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.FloorplanCanvas_Paint);
            this.FloorplanCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FloorplanCanvas_MouseDown);
            this.FloorplanCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FloorplanCanvas_MouseMove);
            this.FloorplanCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FloorplanCanvas_MouseUp);
            // 
            // FloorplanEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FloorplanCanvas);
            this.Name = "FloorplanEditor";
            this.Text = "FloorplanEditor";
            ((System.ComponentModel.ISupportInitialize)(this.FloorplanCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Canvas FloorplanCanvas;
    }
}