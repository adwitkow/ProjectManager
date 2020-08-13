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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorplanEditor));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FloorplanCanvasPanel = new System.Windows.Forms.Panel();
            this.FloorplanCanvas = new ProjectManager.Canvas();
            this.SideControlPanel = new System.Windows.Forms.Panel();
            this.ZoneTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.ZoneTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MainTableLayoutPanel.SuspendLayout();
            this.FloorplanCanvasPanel.SuspendLayout();
            this.SideControlPanel.SuspendLayout();
            this.ZoneTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.MainTableLayoutPanel.Controls.Add(this.FloorplanCanvasPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.SideControlPanel, 1, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // FloorplanCanvasPanel
            // 
            this.FloorplanCanvasPanel.AutoScroll = true;
            this.FloorplanCanvasPanel.Controls.Add(this.FloorplanCanvas);
            this.FloorplanCanvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FloorplanCanvasPanel.Location = new System.Drawing.Point(4, 4);
            this.FloorplanCanvasPanel.Name = "FloorplanCanvasPanel";
            this.FloorplanCanvasPanel.Size = new System.Drawing.Size(629, 442);
            this.FloorplanCanvasPanel.TabIndex = 1;
            // 
            // FloorplanCanvas
            // 
            this.FloorplanCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FloorplanCanvas.Image = null;
            this.FloorplanCanvas.Location = new System.Drawing.Point(0, 0);
            this.FloorplanCanvas.Name = "FloorplanCanvas";
            this.FloorplanCanvas.Size = new System.Drawing.Size(629, 442);
            this.FloorplanCanvas.TabIndex = 0;
            // 
            // SideControlPanel
            // 
            this.SideControlPanel.Controls.Add(this.ZoneTypeGroupBox);
            this.SideControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideControlPanel.Location = new System.Drawing.Point(640, 4);
            this.SideControlPanel.Name = "SideControlPanel";
            this.SideControlPanel.Size = new System.Drawing.Size(156, 442);
            this.SideControlPanel.TabIndex = 2;
            // 
            // ZoneTypeGroupBox
            // 
            this.ZoneTypeGroupBox.AutoSize = true;
            this.ZoneTypeGroupBox.Controls.Add(this.ZoneTypeComboBox);
            this.ZoneTypeGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ZoneTypeGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ZoneTypeGroupBox.Name = "ZoneTypeGroupBox";
            this.ZoneTypeGroupBox.Size = new System.Drawing.Size(156, 40);
            this.ZoneTypeGroupBox.TabIndex = 0;
            this.ZoneTypeGroupBox.TabStop = false;
            this.ZoneTypeGroupBox.Text = "Zone";
            // 
            // ZoneTypeComboBox
            // 
            this.ZoneTypeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ZoneTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ZoneTypeComboBox.FormattingEnabled = true;
            this.ZoneTypeComboBox.Location = new System.Drawing.Point(3, 16);
            this.ZoneTypeComboBox.Name = "ZoneTypeComboBox";
            this.ZoneTypeComboBox.Size = new System.Drawing.Size(150, 21);
            this.ZoneTypeComboBox.TabIndex = 0;
            // 
            // FloorplanEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Name = "FloorplanEditor";
            this.Text = "FloorplanEditor";
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.FloorplanCanvasPanel.ResumeLayout(false);
            this.SideControlPanel.ResumeLayout(false);
            this.SideControlPanel.PerformLayout();
            this.ZoneTypeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Panel FloorplanCanvasPanel;
        private System.Windows.Forms.Panel SideControlPanel;
        private System.Windows.Forms.GroupBox ZoneTypeGroupBox;
        private System.Windows.Forms.ComboBox ZoneTypeComboBox;
        private Canvas FloorplanCanvas;
    }
}