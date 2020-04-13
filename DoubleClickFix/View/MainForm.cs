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
            Presenter.UpdateLeftButton();
        }
    }
}
