namespace ProjectManager
{
    partial class Canvas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.VerticalScrollBar = new System.Windows.Forms.VScrollBar();
            this.DummyPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // HorizontalScrollBar
            // 
            this.HorizontalScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HorizontalScrollBar.LargeChange = 1;
            this.HorizontalScrollBar.Location = new System.Drawing.Point(0, 133);
            this.HorizontalScrollBar.Maximum = 0;
            this.HorizontalScrollBar.Name = "HorizontalScrollBar";
            this.HorizontalScrollBar.Size = new System.Drawing.Size(133, 17);
            this.HorizontalScrollBar.TabIndex = 0;
            this.HorizontalScrollBar.ValueChanged += new System.EventHandler(this.HorizontalScrollBar_ValueChanged);
            this.HorizontalScrollBar.MouseEnter += new System.EventHandler(this.ScrollBar_MouseEnter);
            // 
            // VerticalScrollBar
            // 
            this.VerticalScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VerticalScrollBar.LargeChange = 1;
            this.VerticalScrollBar.Location = new System.Drawing.Point(133, 0);
            this.VerticalScrollBar.Maximum = 0;
            this.VerticalScrollBar.Name = "VerticalScrollBar";
            this.VerticalScrollBar.Size = new System.Drawing.Size(17, 133);
            this.VerticalScrollBar.TabIndex = 1;
            this.VerticalScrollBar.ValueChanged += new System.EventHandler(this.VerticalScrollBar_ValueChanged);
            this.VerticalScrollBar.MouseEnter += new System.EventHandler(this.ScrollBar_MouseEnter);
            // 
            // DummyPanel
            // 
            this.DummyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DummyPanel.Location = new System.Drawing.Point(133, 133);
            this.DummyPanel.Name = "DummyPanel";
            this.DummyPanel.Size = new System.Drawing.Size(17, 17);
            this.DummyPanel.TabIndex = 2;
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DummyPanel);
            this.Controls.Add(this.VerticalScrollBar);
            this.Controls.Add(this.HorizontalScrollBar);
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar HorizontalScrollBar;
        private System.Windows.Forms.VScrollBar VerticalScrollBar;
        private System.Windows.Forms.Panel DummyPanel;
    }
}
