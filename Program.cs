using System;
using System.Windows;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OriWotWTracker
{
    class Program
    {

        [STAThread]
        static void Main()
        {
            //AllocConsole();

            // Start the filewatcher 

            
            GameState current_gamestate = new GameState();  // TODO We probably want to save this and load it on startup so it's immediately up to date instead of blank.

            TrackerWindow view = new TrackerWindow(current_gamestate);
            Controller controller = new Controller(current_gamestate, view);

            //FileWatcher Watcher = new FileWatcher(controller);
            FileWatcher.Run(controller);

            Application app = new Application();
            app.Run(view);
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
    }

}
