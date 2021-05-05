using System;
using System.Collections.Generic;
using System.Windows.Controls;

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
        public bool Collected { get; set; }
        public bool Upgraded { get; set; }
        public string Source { get; set; }
        //public Image image;
        public string name;

        //public Skill(string Name, Image img)
        public Skill(string Name)
        {
            name = Name;
            Collected = false;
            //image = img;
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

        public Dictionary<string, Skill> Skills = new Dictionary<string, Skill>();
        public Dictionary<string, Event> Events = new Dictionary<string, Event>();
        public Dictionary<string, Teleporter> Teleporters = new Dictionary<string, Teleporter>();

        public Collectible SpiritLight { get => spiritlight; set => spiritlight = value; }
        public Collectible Keystones { get => keystones; set => keystones = value; }
        public Collectible Ore { get => ore; set => ore = value; }

        public GameState()
        {
            foreach (string skill in ref_skills)
            {
                Skills.Add(skill, new Skill(skill));
            }
        }
    }
}
