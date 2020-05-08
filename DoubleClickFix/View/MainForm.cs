// Copyright (C) 2020 Yotam Cohen
//
// This file is part of DoubleClickFix.
//
// DoubleClickFix is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DoubleClickFix is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DoubleClickFix.  If not, see <http://www.gnu.org/licenses/>.

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

        public string BlockStatusLabel
        {
            get => blockedToolStripStatusLabel.Text;
            set => blockedToolStripStatusLabel.Text = value;
        }

        public string[] DebugLog
        {
            get => debugTextBox.Lines;
            set => debugTextBox.Lines = value;
        }

        public bool IsDebugging
        {
            get => debugCheckBox.Checked;
            set => debugCheckBox.Checked = value;
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

        private void TrayNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void DebugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var visible = debugCheckBox.Checked;
            debugPanel.Visible = visible;
            Height += (visible ? 1 : -1) * debugPanel.Height;
        }

        private void DebugTextBox_TextChanged(object sender, EventArgs e)
        {
            debugTextBox.SelectionStart = debugTextBox.Text.Length;
            debugTextBox.ScrollToCaret();
        }
    }
}
