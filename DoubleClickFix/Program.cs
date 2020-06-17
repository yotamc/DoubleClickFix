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
using DoubleClickFix.Options;
using DoubleClickFix.Presenter;
using DoubleClickFix.View;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddWriteableJsonFile("appsettings.json", optional: true, reloadOnChange: true, createIfMissing: true);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();

            var services = host.Services;

            var mainForm = services.GetRequiredService<MainForm>();
            var mouseEventBlocker = services.GetRequiredService<MouseEventBlocker>();
            mouseEventBlocker.Start();
            try
            {
                services.GetRequiredService<MainPresenter>();
                Application.Run(mainForm);
            }
            finally
            {
                mouseEventBlocker.Stop();
            }
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.ConfigureWritable<AppSettings>(configuration.GetSection(nameof(AppSettings)));

            var mainForm = new MainForm();
            services.AddSingleton(mainForm);
            services.AddSingleton<IMainView>(mainForm);

            services.AddSingleton<MouseEventBlocker>();

            services.AddSingleton<MainPresenter>();
        }
    }
}
