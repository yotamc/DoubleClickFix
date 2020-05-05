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
            this.rightMouseButtonCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.statsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.blockedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.debugPanel = new System.Windows.Forms.Panel();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            this.statsStatusStrip.SuspendLayout();
            this.debugPanel.SuspendLayout();
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
            this.thresholdLabel.Location = new System.Drawing.Point(232, 38);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(86, 15);
            this.thresholdLabel.TabIndex = 2;
            this.thresholdLabel.Text = "Threshold (ms)";
            // 
            // trayNotifyIcon
            // 
            this.trayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayNotifyIcon.Icon")));
            this.trayNotifyIcon.Text = "DoubleClickFix";
            this.trayNotifyIcon.Visible = true;
            this.trayNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotifyIcon_MouseDoubleClick);
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Checked = true;
            this.debugCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.debugCheckBox.Location = new System.Drawing.Point(395, 33);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(27, 25);
            this.debugCheckBox.TabIndex = 3;
            this.debugCheckBox.Text = "▼";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckedChanged += new System.EventHandler(this.DebugCheckBox_CheckedChanged);
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.Location = new System.Drawing.Point(232, 11);
            this.thresholdTrackBar.Maximum = 500;
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size(157, 45);
            this.thresholdTrackBar.TabIndex = 4;
            this.thresholdTrackBar.TickFrequency = 25;
            this.thresholdTrackBar.ValueChanged += new System.EventHandler(this.ThresholdTrackBar_ValueChanged);
            // 
            // statsStatusStrip
            // 
            this.statsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blockedToolStripStatusLabel});
            this.statsStatusStrip.Location = new System.Drawing.Point(0, 303);
            this.statsStatusStrip.Name = "statsStatusStrip";
            this.statsStatusStrip.Size = new System.Drawing.Size(433, 22);
            this.statsStatusStrip.TabIndex = 5;
            // 
            // blockedToolStripStatusLabel
            // 
            this.blockedToolStripStatusLabel.Name = "blockedToolStripStatusLabel";
            this.blockedToolStripStatusLabel.Size = new System.Drawing.Size(155, 17);
            this.blockedToolStripStatusLabel.Text = "blockedToolStripStatusLabel";
            // 
            // debugPanel
            // 
            this.debugPanel.Controls.Add(this.debugTextBox);
            this.debugPanel.Location = new System.Drawing.Point(12, 64);
            this.debugPanel.Name = "debugPanel";
            this.debugPanel.Size = new System.Drawing.Size(409, 236);
            this.debugPanel.TabIndex = 6;
            // 
            // debugTextBox
            // 
            this.debugTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugTextBox.Location = new System.Drawing.Point(0, 0);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.debugTextBox.Size = new System.Drawing.Size(409, 236);
            this.debugTextBox.TabIndex = 0;
            this.debugTextBox.TextChanged += new System.EventHandler(this.DebugTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 325);
            this.Controls.Add(this.debugPanel);
            this.Controls.Add(this.statsStatusStrip);
            this.Controls.Add(this.debugCheckBox);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.rightMouseButtonCheckBox);
            this.Controls.Add(this.leftMouseButtonCheckBox);
            this.Controls.Add(this.thresholdTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DoubleClickFix";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).EndInit();
            this.statsStatusStrip.ResumeLayout(false);
            this.statsStatusStrip.PerformLayout();
            this.debugPanel.ResumeLayout(false);
            this.debugPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox leftMouseButtonCheckBox;
        private System.Windows.Forms.CheckBox rightMouseButtonCheckBox;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.NotifyIcon trayNotifyIcon;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.TrackBar thresholdTrackBar;
        private System.Windows.Forms.StatusStrip statsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel blockedToolStripStatusLabel;
        private System.Windows.Forms.Panel debugPanel;
        private System.Windows.Forms.TextBox debugTextBox;
    }
}