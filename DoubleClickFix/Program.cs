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

using DoubleClickFix.Configuration;
using DoubleClickFix.Presenter;
using DoubleClickFix.View;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;

namespace DoubleClickFix
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configuration = InitializeConfiguration("appsettings.json");

            var mouseEventBlocker = new MouseEventBlocker();
            try
            {
                mouseEventBlocker.Start();

                var mainForm = new MainForm();
                var mainPresenter = new MainPresenter(mainForm, mouseEventBlocker, configuration);

                Application.Run(mainForm);
            }
            finally
            {
                mouseEventBlocker.Stop();
            }
        }

        private static IConfigurationRoot InitializeConfiguration(string path)
        {
            var configuration = new ConfigurationBuilder()
                .AddWriteableJsonFile(path, optional: true, reloadOnChange: true, createIfMissing: true)
                .Build();

            // TODO set defaults

            return configuration;
        }
    }
}
