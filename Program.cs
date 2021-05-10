using System;
using System.Windows;

namespace OriWotWTracker
{
    class Program
    {

        [STAThread]
        static void Main()
        {
            //AllocConsole();



            GameState current_gamestate = new GameState();  // TODO We probably want to save this and load it on startup so it's immediately up to date instead of blank.

            TrackerWindow view = new TrackerWindow(current_gamestate);

            // Get position from settings file and set the window position to those coordinates.
            view.Left = double.Parse(ConfigController.GetConfig("xpos", "100"));
            view.Top = double.Parse(ConfigController.GetConfig("ypos", "100"));

            Controller controller = new Controller(current_gamestate, view);

            TrackFileWatcher.Run(controller);
            SeedFileWatcher.Run(controller);

            Application app = new Application();
            app.Run(view);
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
    }

}
