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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.leftMouseButtonCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rightMouseButtonCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).BeginInit();
            this.notifyContextMenuStrip.SuspendLayout();
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
            this.thresholdNumericUpDown.Increment = 5;
            this.thresholdNumericUpDown.Location = new System.Drawing.Point(354, 11);
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
            // rightMouseButtonCheckBox
            // 
            this.rightMouseButtonCheckBox.AutoSize = true;
            this.rightMouseButtonCheckBox.Location = new System.Drawing.Point(12, 37);
            this.rightMouseButtonCheckBox.Name = "rightMouseButtonCheckBox";
            this.rightMouseButtonCheckBox.Size = new System.Drawing.Size(132, 19);
            this.rightMouseButtonCheckBox.TabIndex = 0;
            this.rightMouseButtonCheckBox.Text = "Right Mouse Button";
            this.rightMouseButtonCheckBox.UseVisualStyleBackColor = true;
            this.rightMouseButtonCheckBox.CheckedChanged += new System.EventHandler(this.RightMouseButtonCheckBox_CheckedChanged);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(259, 13);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(89, 15);
            this.thresholdLabel.TabIndex = 2;
            this.thresholdLabel.Text = "Threshold (ms):";
            // 
            // trayNotifyIcon
            // 
            this.trayNotifyIcon.ContextMenuStrip = this.notifyContextMenuStrip;
            this.trayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayNotifyIcon.Icon")));
            this.trayNotifyIcon.Text = "DoubleClickFix";
            this.trayNotifyIcon.Visible = true;
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(117, 48);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 64);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.rightMouseButtonCheckBox);
            this.Controls.Add(this.thresholdNumericUpDown);
            this.Controls.Add(this.leftMouseButtonCheckBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DoubleClickFix";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).EndInit();
            this.notifyContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox leftMouseButtonCheckBox;
        private System.Windows.Forms.NumericUpDown thresholdNumericUpDown;
        private System.Windows.Forms.CheckBox rightMouseButtonCheckBox;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.NotifyIcon trayNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}