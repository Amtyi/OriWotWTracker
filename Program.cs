using System;
using System.Windows;
using System.Runtime.InteropServices;

namespace OriWotWTracker
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            //AllocConsole();

            // Start the filewatcher 
            Watcher.Run();

            Application app = new Application();
            app.Run(new TrackerWindow());
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
    }

}
