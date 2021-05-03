using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Diagnostics;
using System.Windows;

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

            string a = "a";

        }

        public static void ParseChanges(object source, FileSystemEventArgs e)
        {
            Debug.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            string FileContents = File.ReadAllText(e.FullPath);

            // Since the file gets updated on every save, we skip parsing if the contents didn't actually change.
            if (FileContents == Watcher.OldFileContents)
            {
                return;
            }


            string[] skills;
            string[] upgraded;
            string[] events;
            string[] teleporters;
            string spiritlight;
            string keystones;
            string gorlekore;

            try
            {
                Data JsonObject = JsonSerializer.Deserialize<Data>(FileContents);

                skills = JsonObject.Skills;
                upgraded = JsonObject.Upgraded;
                events = JsonObject.Events;
                teleporters = JsonObject.Teleporters;
                spiritlight = JsonObject.SpiritLight;
                keystones = JsonObject.Keystones;
                gorlekore = JsonObject.Ore;

            }
            catch
            {
                Debug.WriteLine("Unable to parse the trackfile contents.");
                return;
            }

            foreach (string skill in skills)
            {
                
            }


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
