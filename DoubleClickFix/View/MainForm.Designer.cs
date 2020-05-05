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
            this.statsCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.statsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.blockedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.statsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            this.statsStatusStrip.SuspendLayout();
            this.statsPanel.SuspendLayout();
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
            // statsCheckBox
            // 
            this.statsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.statsCheckBox.AutoSize = true;
            this.statsCheckBox.Location = new System.Drawing.Point(395, 33);
            this.statsCheckBox.Name = "statsCheckBox";
            this.statsCheckBox.Size = new System.Drawing.Size(27, 25);
            this.statsCheckBox.TabIndex = 3;
            this.statsCheckBox.Text = "▼";
            this.statsCheckBox.UseVisualStyleBackColor = true;
            this.statsCheckBox.CheckedChanged += new System.EventHandler(this.StatsCheckBox_CheckedChanged);
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
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.statsTextBox);
            this.statsPanel.Location = new System.Drawing.Point(12, 64);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(409, 236);
            this.statsPanel.TabIndex = 6;
            // 
            // statsTextBox
            // 
            this.statsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsTextBox.Location = new System.Drawing.Point(0, 0);
            this.statsTextBox.Multiline = true;
            this.statsTextBox.Name = "statsTextBox";
            this.statsTextBox.Size = new System.Drawing.Size(409, 236);
            this.statsTextBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 325);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.statsStatusStrip);
            this.Controls.Add(this.statsCheckBox);
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
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox leftMouseButtonCheckBox;
        private System.Windows.Forms.CheckBox rightMouseButtonCheckBox;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.NotifyIcon trayNotifyIcon;
        private System.Windows.Forms.CheckBox statsCheckBox;
        private System.Windows.Forms.TrackBar thresholdTrackBar;
        private System.Windows.Forms.StatusStrip statsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel blockedToolStripStatusLabel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.TextBox statsTextBox;
    }
}