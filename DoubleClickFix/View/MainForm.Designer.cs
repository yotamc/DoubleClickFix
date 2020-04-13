namespace DoubleClickFix.View
{
    partial class MainForm
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
            this.leftMouseButtonCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // leftMouseButtonCheckBox
            // 
            this.leftMouseButtonCheckBox.AutoSize = true;
            this.leftMouseButtonCheckBox.Location = new System.Drawing.Point(12, 12);
            this.leftMouseButtonCheckBox.Name = "leftMouseButtonCheckBox";
            this.leftMouseButtonCheckBox.Size = new System.Drawing.Size(124, 19);
            this.leftMouseButtonCheckBox.TabIndex = 0;
            this.leftMouseButtonCheckBox.Text = "Left Mouse Button";
            this.leftMouseButtonCheckBox.UseVisualStyleBackColor = true;
            this.leftMouseButtonCheckBox.CheckedChanged += new System.EventHandler(this.LeftMouseButtonCheckBox_CheckedChanged);
            // 
            // thresholdNumericUpDown
            // 
            this.thresholdNumericUpDown.Location = new System.Drawing.Point(142, 11);
            this.thresholdNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.thresholdNumericUpDown.Name = "thresholdNumericUpDown";
            this.thresholdNumericUpDown.Size = new System.Drawing.Size(67, 23);
            this.thresholdNumericUpDown.TabIndex = 1;
            this.thresholdNumericUpDown.ValueChanged += new System.EventHandler(this.ThresholdNumericUpDown_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 377);
            this.Controls.Add(this.thresholdNumericUpDown);
            this.Controls.Add(this.leftMouseButtonCheckBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox leftMouseButtonCheckBox;
        private System.Windows.Forms.NumericUpDown thresholdNumericUpDown;
    }
}