using DoubleClickFix.Presenter;
using System;
using System.Windows.Forms;

namespace DoubleClickFix.View
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public bool LeftMouseButton
        {
            get => leftMouseButtonCheckBox.Checked;
            set => leftMouseButtonCheckBox.Checked = value;
        }

        public bool RightMouseButton
        {
            get => rightMouseButtonCheckBox.Checked;
            set => rightMouseButtonCheckBox.Checked = value;
        }

        public int Threshold
        {
            get => thresholdTrackBar.Value;
            set => thresholdTrackBar.Value = value;
        }

        public string ThresholdLabel
        {
            get => thresholdLabel.Text;
            set => thresholdLabel.Text = value;
        }

        public MainPresenter Presenter { private get; set; }

        private void ThresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Presenter.UpdateThreshold();
        }

        private void LeftMouseButtonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.UpdateLeftMouseButton();
        }

        private void RightMouseButtonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.UpdateRightMouseButton();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void TrayNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void StatsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            statsPanel.Visible = !statsPanel.Visible;
            Height += (statsPanel.Visible ? 1 : -1) * statsPanel.Height;
        }
    }
}
