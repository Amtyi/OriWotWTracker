using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OriWotWTracker
{
    public class Collectible
    {
        public int Amount { get; set; }
        //public Image image;
        public string name;

        public Collectible(string Name)
        //public Collectible(string Name, Image img)
        {
            name = Name;
            Amount = 0;
            //image = img;
        }
    }

    public class Skill
    {
        public string name;
        BitmapImage source_active;
        BitmapImage source_inactive;

        public bool Collected { get; set; }
        public bool Upgraded { get; set; }
        public BitmapImage Source_current { get { return Collected ? source_active : source_inactive; } }

        public Skill(string Name)
        {
            name = Name;
            Collected = false;
            source_active = new BitmapImage(new Uri("img/" + Name + "_unlocked.png", UriKind.Relative));
            source_inactive = new BitmapImage(new Uri("img/" + Name + ".png", UriKind.Relative));
        }
    }

    public class Event
    {
        public bool collected;
        public Image image;
        public string name;

        public Event(string Name, Image img)
        {
            name = Name;
            collected = false;
            image = img;
        }
    }

    public class Teleporter
    {
        public bool collected;
        //public Image image;
        public string name;

        public Teleporter(string Name)
        {
            name = Name;
            collected = false;
        }
    }


    public class GameState
    {
        private readonly List<string> ref_skills = new List<string>()
        {
            "Sword",
            "Spike",
            "Shuriken",
            "Hammer",
            "Sentry",
            "WaterBreath",
            "DoubleJump",
            "Regenerate",
            "Bow",
            "Dash",
            "Bash",
            "Grapple",
            "Glide",
            "Flap",
            "WaterDash",
            "LightBurst",
            "Flash",
            "Burrow",
            "Launch",
            "WeaponUpgrade2",
            "WeaponUpgrade1"
        };

        private Collectible spiritlight = new Collectible("SpiritLight");
        private Collectible keystones = new Collectible("Keystones");
        private Collectible ore = new Collectible("Ore");

        public Dictionary<string, Skill> skills = new Dictionary<string, Skill>();
        public Dictionary<string, Event> Events = new Dictionary<string, Event>();
        public Dictionary<string, Teleporter> Teleporters = new Dictionary<string, Teleporter>();

        public Collectible SpiritLight { get => spiritlight; set => spiritlight = value; }
        public Collectible Keystones { get => keystones; set => keystones = value; }
        public Collectible Ore { get => ore; set => ore = value; }

        public Dictionary<string, Skill> Skills { get => skills; set => skills = value; }

        public GameState()
        {
            foreach (string skill in ref_skills)
            {
                skills.Add(skill, new Skill(skill));
            }
        }
    }
}
