using System;
using System.Windows.Forms;

namespace DoubleClickFix
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Application.SetHighDpiMode(HighDpiMode.SystemAware);
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("test");
            var mouseEventBlocker = new MouseEventBlocker();
            try
            {
                mouseEventBlocker.Hook();
                Application.Run();
            }
            finally
            {
                mouseEventBlocker.Unhook();
            }
        }
    }
}
