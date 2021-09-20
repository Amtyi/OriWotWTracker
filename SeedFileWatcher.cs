using System;
using System.IO;
using System.Threading;

namespace OriWotWTracker
{
    class SeedFileWatcher
    {
        private static Controller controller;

        public static void Run(Controller Controller)
        {
            controller = Controller;

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher filewatcher = new FileSystemWatcher();

            //filewatcher.Path = Directory.GetCurrentDirectory();
            filewatcher.Path = "C:\\moon";
            filewatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            filewatcher.Filter = ".currentseedpath";

            filewatcher.Changed += ParseChanges;

            filewatcher.EnableRaisingEvents = true;
        }

        public static void ParseChanges(object source, FileSystemEventArgs e)
        {

            // Small sleep to prevent the tracker trying to access the file before its ready.
            Thread.Sleep(75);

            try
            {
                string CurrentSeedPath = File.ReadAllText(e.FullPath);

                controller.UpdateSeedName(CurrentSeedPath);
            }
            catch (IOException err)
            {
                if (err.HResult == -2147024864)
                {
                    return;
                }

                //Debug.WriteLine("Unable to parse the trackfile contents.");
                return;
            }
            catch (Exception err)
            {
                //Debug.WriteLine("Unable to parse the trackfile contents.");
                return;
            }
        }
    }
}
