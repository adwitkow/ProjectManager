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
            // TeamEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TeamNameTextBox);
            this.Controls.Add(this.TeamNameLabel);
            this.Name = "TeamEditor";
            this.Size = new System.Drawing.Size(150, 184);
            this.Controls.SetChildIndex(this.TeamNameLabel, 0);
            this.Controls.SetChildIndex(this.TeamNameTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TeamNameLabel;
        private System.Windows.Forms.TextBox TeamNameTextBox;
    }
}
