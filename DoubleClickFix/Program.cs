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
            var interceptMouse = new InterceptMouse();
            try
            {
                interceptMouse.Hook();
                Application.Run();
            }
            finally
            {
                interceptMouse.Unhook();
            }
        }
    }
}
