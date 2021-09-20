using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace OriWotWTracker
{
    
    public class Controller
	{
		//private GameState gamestate;
		private TrackerWindow view;
        private GameState current_gamestate;

        public GameState Current_Gamestate { get => current_gamestate; set => current_gamestate = value; }
        public string Seedname { get; set; }
        public string CurrentSeedPath { get; set; }

        //private readonly Dictionary<string, Image> ref_image;

        public Controller(GameState Current_gamestate, TrackerWindow View)
        {
            view = View;
            Current_Gamestate = Current_gamestate;
        }

        public void ParseChanges(JSONObj data)
        {
            view.Dispatcher.Invoke(() =>
            {
                GameState gamestate = new GameState();

                foreach (string skill in data.skills)
                {
                    gamestate.Skills[skill].Collected = true;
                }

                // Probably not the best way of doing this, but it works.
                if (data.upgraded.Contains("DamageUp"))
                {
                    gamestate.Skills["DamageUp2"].Collected = true;
                }
                else
                {
                    gamestate.Skills["DamageUp2"].Collected = false;
                }

                gamestate.Ore.Amount = data.ore;
                gamestate.Keystones.Amount = data.keystones;
                gamestate.SpiritLight.Amount = data.spiritLight;

                TrackerWindow window = (TrackerWindow)Application.Current.MainWindow;

                window.DataContext = gamestate;
            });
        }

        public void UpdateSeedName(string Seedpath)
        {
            view.Dispatcher.Invoke(() =>
            {
                CurrentSeedPath = Seedpath;
                string config = File.ReadLines(Seedpath).Last().Replace("// Config: ", "");

                var configjson = JObject.Parse(config);
                var flags = JsonConvert.DeserializeObject<List<string>>(configjson["goalmodes"].ToString());

                TrackerWindow window = (TrackerWindow)Application.Current.MainWindow;

                window.WispsFlag.Visibility = flags.GetVisibilityFromString("Wisps");
                window.TreesFlag.Visibility = flags.GetVisibilityFromString("Trees");
                window.QuestsFlag.Visibility = flags.GetVisibilityFromString("Quests");
                window.WorldTourFlag.Visibility = flags.GetVisibilityFromString("Relics");

            });
        }
    }
}
