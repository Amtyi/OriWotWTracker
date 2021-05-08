using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Diagnostics;
using System.Windows;
using System.Collections.Generic;
using System.Threading;

namespace OriWotWTracker
{
    public class JSONObj
    {
        public int spiritLight { get; set; }
        public int keystones { get; set; }
        public int ore { get; set; }
        public IList<string> skills { get; set; }
        public IList<string> upgraded { get; set; }
        public IList<string> events { get; set; }
        public IList<string> teleporters { get; set; }
    }


    public static class FileWatcher
    {

        public static string OldFileContents = "";
        private static Controller controller;

        public static void Run(Controller Controller)
        {
            controller = Controller;

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher filewatcher = new FileSystemWatcher();

            filewatcher.Path = "C:\\moon";
            filewatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            filewatcher.Filter = "trackfile.json";

            filewatcher.Changed += ParseChanges;

            filewatcher.EnableRaisingEvents = true;
        }

        public static void ParseChanges(object source, FileSystemEventArgs e)
        {

            // Small sleep to prevent the tracker trying to access the file before its ready.
            Thread.Sleep(100);

            Debug.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            string FileContents;
            try
            {
                FileContents = File.ReadAllText(e.FullPath);

                // Since the file gets updated on every save, we skip parsing if the contents didn't actually change.
                //if (FileContents == FileWatcher.OldFileContents)
                //{
                //    return;
                //}

            
                JSONObj JsonObject = JsonSerializer.Deserialize<JSONObj>(FileContents);


                FileWatcher.OldFileContents = FileContents;
                controller.ParseChanges(JsonObject);
            }
            catch (IOException err)
            {
                if (err.HResult == -2147024864)
                {
                    return;
                }
                
                Debug.WriteLine("Unable to parse the trackfile contents.");
                return;
            }
            catch
            {
                Debug.WriteLine("Unable to parse the trackfile contents.");
                return;
            }
        }
    }
}
