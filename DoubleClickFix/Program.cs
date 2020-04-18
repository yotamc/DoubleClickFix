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
