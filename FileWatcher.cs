using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OriWotWTracker
{
    public class Watcher
    {

        public static string OldFileContents = "";

        public static void Run()
        {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = "C:\\moon";
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            watcher.Filter = "trackfile.json";

            watcher.Changed += ParseChanges;

            watcher.EnableRaisingEvents = true;

        }

        public static void ParseChanges(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            string FileContents = File.ReadAllText(e.FullPath);

            // Since the file gets updated on every save, we skip parsing if the contents didn't actually change.
            if (FileContents == Watcher.OldFileContents)
            {
                return;
            }

            Data JsonObject = JsonSerializer.Deserialize<Data>(FileContents);

            string[] skills = JsonObject.Skills;
            string[] upgraded = JsonObject.Upgraded;
            string[] events = JsonObject.Events;
            string[] teleporters = JsonObject.Teleporters;
            string spiritlight = JsonObject.SpiritLight;
            string keystones = JsonObject.Keystones;
            string gorlekore = JsonObject.Ore;

            // Do stuff to check if skills need to be updated.
            // Keep in mind that skills can go back to unaccuired in case of a death or a backup save.

            Watcher.OldFileContents = FileContents;
            CheckStringContents(skills, upgraded, events, teleporters);

        }
        public static void CheckStringContents(string[] skills, string[] upgraded, string[] events, string[] teleporters)
        {
            foreach (string skill in skills)
            {
                if (skills.Contains("Sword"))
                {
                    Console.WriteLine("Works");
                }
            }
            foreach (string upgrade in upgraded)
            {

            }
            foreach (string occuredevent in events)
            {

            }
            foreach (string teleporter in teleporters)
            {

            }
        }
    }
}
