namespace ProjectManager.EditorPanel
{
    partial class ZoneEditor
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
            this.ZoneTypeLabel = new System.Windows.Forms.Label();
            this.ZoneTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.XLabel = new System.Windows.Forms.Label();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.YLabel = new System.Windows.Forms.Label();
            this.YNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.XNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.FillColorLabel = new System.Windows.Forms.Label();
            this.BorderColorLabel = new System.Windows.Forms.Label();
            this.FillButton = new System.Windows.Forms.Button();
            this.BorderButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ZoneTypeLabel
            // 
            this.ZoneTypeLabel.AutoSize = true;
            this.ZoneTypeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ZoneTypeLabel.Location = new System.Drawing.Point(0, 0);
            this.ZoneTypeLabel.Name = "ZoneTypeLabel";
            this.ZoneTypeLabel.Size = new System.Drawing.Size(55, 13);
            this.ZoneTypeLabel.TabIndex = 0;
            this.ZoneTypeLabel.Text = "Zone type";
            // 
            // ZoneTypeComboBox
            // 
            this.ZoneTypeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ZoneTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ZoneTypeComboBox.FormattingEnabled = true;
            this.ZoneTypeComboBox.Location = new System.Drawing.Point(0, 13);
            this.ZoneTypeComboBox.Name = "ZoneTypeComboBox";
            this.ZoneTypeComboBox.Size = new System.Drawing.Size(150, 21);
            this.ZoneTypeComboBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.RightPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LeftPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 113);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.XLabel.Location = new System.Drawing.Point(0, 0);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 13);
            this.XLabel.TabIndex = 1;
            this.XLabel.Text = "X";
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.FillButton);
            this.LeftPanel.Controls.Add(this.FillColorLabel);
            this.LeftPanel.Controls.Add(this.WidthNumericUpDown);
            this.LeftPanel.Controls.Add(this.WidthLabel);
            this.LeftPanel.Controls.Add(this.XNumericUpDown);
            this.LeftPanel.Controls.Add(this.XLabel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(3, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(69, 107);
            this.LeftPanel.TabIndex = 3;
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.BorderButton);
            this.RightPanel.Controls.Add(this.BorderColorLabel);
            this.RightPanel.Controls.Add(this.HeightNumericUpDown);
            this.RightPanel.Controls.Add(this.HeightLabel);
            this.RightPanel.Controls.Add(this.YNumericUpDown);
            this.RightPanel.Controls.Add(this.YLabel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(78, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(69, 107);
            this.RightPanel.TabIndex = 4;
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.YLabel.Location = new System.Drawing.Point(0, 0);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(14, 13);
            this.YLabel.TabIndex = 1;
            this.YLabel.Text = "Y";
            // 
            // YNumericUpDown
            // 
            this.YNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.YNumericUpDown.Location = new System.Drawing.Point(0, 13);
            this.YNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.YNumericUpDown.Name = "YNumericUpDown";
            this.YNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.YNumericUpDown.TabIndex = 2;
            // 
            // XNumericUpDown
            // 
            this.XNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.XNumericUpDown.Location = new System.Drawing.Point(0, 13);
            this.XNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.XNumericUpDown.Name = "XNumericUpDown";
            this.XNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.XNumericUpDown.TabIndex = 3;
            // 
            // WidthNumericUpDown
            // 
            this.WidthNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.WidthNumericUpDown.Location = new System.Drawing.Point(0, 46);
            this.WidthNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.WidthNumericUpDown.Name = "WidthNumericUpDown";
            this.WidthNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.WidthNumericUpDown.TabIndex = 5;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WidthLabel.Location = new System.Drawing.Point(0, 33);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(35, 13);
            this.WidthLabel.TabIndex = 4;
            this.WidthLabel.Text = "Width";
            // 
            // HeightNumericUpDown
            // 
            this.HeightNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeightNumericUpDown.Location = new System.Drawing.Point(0, 46);
            this.HeightNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.HeightNumericUpDown.Name = "HeightNumericUpDown";
            this.HeightNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.HeightNumericUpDown.TabIndex = 4;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeightLabel.Location = new System.Drawing.Point(0, 33);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(38, 13);
            this.HeightLabel.TabIndex = 3;
            this.HeightLabel.Text = "Height";
            // 
            // FillColorLabel
            // 
            this.FillColorLabel.AutoSize = true;
            this.FillColorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FillColorLabel.Location = new System.Drawing.Point(0, 66);
            this.FillColorLabel.Name = "FillColorLabel";
            this.FillColorLabel.Size = new System.Drawing.Size(51, 13);
            this.FillColorLabel.TabIndex = 6;
            this.FillColorLabel.Text = "Fill colour";
            // 
            // BorderColorLabel
            // 
            this.BorderColorLabel.AutoSize = true;
            this.BorderColorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderColorLabel.Location = new System.Drawing.Point(0, 66);
            this.BorderColorLabel.Name = "BorderColorLabel";
            this.BorderColorLabel.Size = new System.Drawing.Size(70, 13);
            this.BorderColorLabel.TabIndex = 7;
            this.BorderColorLabel.Text = "Border colour";
            // 
            // FillButton
            // 
            this.FillButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.FillButton.Location = new System.Drawing.Point(0, 79);
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(69, 23);
            this.FillButton.TabIndex = 7;
            this.FillButton.Text = "FFFFFF";
            this.FillButton.UseVisualStyleBackColor = true;
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // BorderButton
            // 
            this.BorderButton.BackColor = System.Drawing.SystemColors.Control;
            this.BorderButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BorderButton.Location = new System.Drawing.Point(0, 79);
            this.BorderButton.Name = "BorderButton";
            this.BorderButton.Size = new System.Drawing.Size(69, 23);
            this.BorderButton.TabIndex = 8;
            this.BorderButton.Text = "000000";
            this.BorderButton.UseVisualStyleBackColor = false;
            this.BorderButton.Click += new System.EventHandler(this.BorderButton_Click);
            // 
            // ZoneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ZoneTypeComboBox);
            this.Controls.Add(this.ZoneTypeLabel);
            this.Name = "ZoneEditor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ZoneTypeLabel;
        private System.Windows.Forms.ComboBox ZoneTypeComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.NumericUpDown HeightNumericUpDown;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.NumericUpDown YNumericUpDown;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.NumericUpDown WidthNumericUpDown;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown XNumericUpDown;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Button BorderButton;
        private System.Windows.Forms.Label BorderColorLabel;
        private System.Windows.Forms.Button FillButton;
        private System.Windows.Forms.Label FillColorLabel;
    }
}
