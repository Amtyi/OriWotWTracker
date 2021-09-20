using System;
using System.Windows;
using System.Windows.Media;

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

            // Set the background colour to the value in the config file. If not valid, set it to the default value.
            string bgcolour = ConfigController.GetConfig("BackgroundColour", "#FF4D4D4D");
            if (System.Text.RegularExpressions.Regex.IsMatch(bgcolour, @"^#\w{8}$"))
            {
                view.MainGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(bgcolour));
            }
            else
            {
                view.MainGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4D4D4D"));
            }

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
