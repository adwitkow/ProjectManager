namespace ProjectManager.EditorPanel
{
    partial class TeamEditor
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
            this.TeamNameLabel = new System.Windows.Forms.Label();
            this.TeamNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.LabelScaleUpDown = new ProjectManager.Util.Controls.PercentageUpDown();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LabelScaleUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TeamNameLabel
            // 
            this.TeamNameLabel.AutoSize = true;
            this.TeamNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TeamNameLabel.Location = new System.Drawing.Point(0, 147);
            this.TeamNameLabel.Name = "TeamNameLabel";
            this.TeamNameLabel.Size = new System.Drawing.Size(63, 13);
            this.TeamNameLabel.TabIndex = 3;
            this.TeamNameLabel.Text = "Team name";
            // 
            // TeamNameTextBox
            // 
            this.TeamNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.TeamNameTextBox.Location = new System.Drawing.Point(0, 160);
            this.TeamNameTextBox.Name = "TeamNameTextBox";
            this.TeamNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.TeamNameTextBox.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 180);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 44);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(78, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 38);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LabelScaleUpDown);
            this.panel2.Controls.Add(this.ScaleLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(69, 38);
            this.panel2.TabIndex = 3;
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScaleLabel.Location = new System.Drawing.Point(0, 0);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(61, 13);
            this.ScaleLabel.TabIndex = 1;
            this.ScaleLabel.Text = "Label scale";
            // 
            // LabelScaleUpDown
            // 
            this.LabelScaleUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelScaleUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.LabelScaleUpDown.Location = new System.Drawing.Point(0, 13);
            this.LabelScaleUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LabelScaleUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.LabelScaleUpDown.Name = "LabelScaleUpDown";
            this.LabelScaleUpDown.Size = new System.Drawing.Size(69, 20);
            this.LabelScaleUpDown.TabIndex = 2;
            this.LabelScaleUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LabelScaleUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TeamEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.TeamNameTextBox);
            this.Controls.Add(this.TeamNameLabel);
            this.Name = "TeamEditor";
            this.Size = new System.Drawing.Size(150, 224);
            this.Controls.SetChildIndex(this.TeamNameLabel, 0);
            this.Controls.SetChildIndex(this.TeamNameTextBox, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LabelScaleUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TeamNameLabel;
        private System.Windows.Forms.TextBox TeamNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ScaleLabel;
        private Util.Controls.PercentageUpDown LabelScaleUpDown;
    }
}
