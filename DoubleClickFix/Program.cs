using DoubleClickFix.Presenter;
using DoubleClickFix.View;
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

            var mouseEventBlocker = new MouseEventBlocker();
            try
            {
                //mouseEventBlocker.Hook();

                var mainForm = new MainForm();
                var mainPresenter = new MainPresenter(mainForm, mouseEventBlocker);

                Application.Run(mainForm);
            }
            finally
            {
                //mouseEventBlocker.Unhook();
            }
        }
    }
}
