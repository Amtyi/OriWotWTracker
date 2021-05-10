using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace OriWotWTracker
{
    static class ConfigController
    {
        
        private static string configfile = "C:/moon/settings.ini";
        private static readonly FileIniDataParser Parser = new FileIniDataParser();
        public static IniData Config = Parser.ReadFile(configfile);

        public static string GetConfig(string key, string defaultval = "")
        {

            if (Config["Tracker"][key] == null || Config["Tracker"][key] == "")
            {
                return defaultval;
            }
            else
            {
                return Config["Tracker"][key];

            }
        }

        public static void SetConfig(string key, string value)
        {
            Config["Tracker"][key] = value;
            Parser.WriteFile(configfile, Config);
        }
    }
}
