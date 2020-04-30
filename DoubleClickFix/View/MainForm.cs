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

        public uint Threshold
        {
            get => (uint)thresholdNumericUpDown.Value;
            set => thresholdNumericUpDown.Value = value;
        }
        public MainPresenter Presenter { private get; set; }

        private void ThresholdNumericUpDown_ValueChanged(object sender, EventArgs e)
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
    }
}
