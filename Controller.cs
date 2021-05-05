using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OriWotWTracker
{
    
    public class Controller
	{
		//private GameState gamestate;
		private TrackerWindow view;
        private GameState current_gamestate;

        public GameState Current_Gamestate { get => current_gamestate; set => current_gamestate = value; }

        //private readonly Dictionary<string, Image> ref_image;

        public Controller(GameState Current_gamestate, TrackerWindow View)
		{
			view = View;
            Current_Gamestate = Current_gamestate;

  //          ref_image.Add("Sword", view.Sword);
  //          ref_image.Add("Spike", view.Sword);
  //          ref_image.Add("Shuriken", view.Sword);
  //          ref_image.Add("Hammer", view.Sword);
  //          ref_image.Add("Sentry", view.Sword);
  //          ref_image.Add("WaterBreath", view.Sword);
  //          ref_image.Add("DoubleJump", view.Sword);
  //          ref_image.Add("Regenerate", view.Sword);
  //          ref_image.Add("Bow", view.Sword);
  //          ref_image.Add("Dash", view.Sword);
  //          ref_image.Add("Bash", view.Sword);
  //          ref_image.Add("Grapple", view.Sword);
  //          ref_image.Add("Glide", view.Sword);
  //          ref_image.Add("Flap", view.Sword);
  //          ref_image.Add("WaterDash", view.Sword);
  //          ref_image.Add("LightBurst", view.Sword);
  //          ref_image.Add("Flash", view.Sword);
  //          ref_image.Add("Burrow", view.Sword);
  //          ref_image.Add("Launch", view.Sword);
  //          ref_image.Add("WeaponUpgrade2", view.Sword);
  //          ref_image.Add("WeaponUpgrade1", view.Sword);
		}

		//public void toggle_skill(string name)
		//{
		//	Skill skill = gamestate.Skills[name];

		//	skill.collected = !skill.collected;

		//	if (skill.collected)
		//	{
		//		string str = "img/" + skill.name + "_unlocked.png";
		//		Uri urisource = new Uri(str, UriKind.Relative);
		//		skill.image.Source = new BitmapImage(urisource);
		//	}
		//	else
		//	{
		//		string str = "img/" + skill.name + ".png";
		//		Uri urisource = new Uri(str, UriKind.Relative);
		//		skill.image.Source = new BitmapImage(urisource);
		//	}
		//	//Update_skill(gamestate.Skills[name]);
		//}

        //public void Update_skill(Skill skill)
        //{
        //	if (skill.collected)
        //	{
        //		string str = "img/" + skill.name + "_unlocked.png";
        //		Uri urisource = new Uri(str, UriKind.Relative);
        //		skill.image.Source = new BitmapImage(urisource);
        //	}
        //	else
        //	{
        //		string str = "img/" + skill.name + ".png";
        //		Uri urisource = new Uri(str, UriKind.Relative);
        //		skill.image.Source = new BitmapImage(urisource);
        //	}
        //}

        //private void Cycle_WeaponUpgrade()
        //{

        //    BitmapImage Weapon0 = new BitmapImage(new Uri("img/WeaponUpgrade.png", UriKind.Relative));
        //    BitmapImage Weapon1 = new BitmapImage(new Uri("img/WeaponUpgrade_unlocked.png", UriKind.Relative));
        //    BitmapImage Weapon2 = new BitmapImage(new Uri("img/WeaponUpgrade2_unlocked.png", UriKind.Relative));

        //    if (WeaponUpgrade.Source.ToString().Contains("img/WeaponUpgrade.png"))
        //    {
        //        WeaponUpgrade.Source = Weapon1;
        //    }
        //    else if (WeaponUpgrade.Source.ToString().Contains("img/WeaponUpgrade_unlocked.png"))
        //    {
        //        WeaponUpgrade.Source = Weapon2;
        //    }
        //}

        public void ParseChanges(JSONObj data)
        {
            GameState gamestate = new GameState();
           
            foreach (string skill in data.skills)
            {
                gamestate.Skills[skill].Collected = true;
            }

            gamestate.Ore.Amount = data.ore;
            gamestate.Keystones.Amount = data.keystones;
            gamestate.SpiritLight.Amount = data.spiritLight;

            Application.Current.Dispatcher.Invoke(() =>
            {
                TrackerWindow window = (TrackerWindow)Application.Current.MainWindow;
                window.DataContext = gamestate;
            });

            foreach (string skill in gamestate.Skills.Keys)
            {
                Current_Gamestate.Skills[skill].Collected = gamestate.Skills[skill].Collected;
            }

            Current_Gamestate.Ore.Amount = gamestate.Ore.Amount;
            Current_Gamestate.Keystones.Amount = gamestate.Keystones.Amount;
            Current_Gamestate.SpiritLight.Amount = gamestate.SpiritLight.Amount;







            //foreach (KeyValuePair<string, Skill> skill in gamestate.Skills)
            //{
                
                //if (skill.Value.collected)
                //{
                //    string str = "img/" + skill.Key + "_unlocked.png";
                //    Uri urisource = new Uri(str, UriKind.Relative);
                //    ref_image[skill.Key].Source = new BitmapImage(urisource);
                    
                //}
                //else
                //{
                //    string str = "img/" + skill.Key + ".png";
                //    Uri urisource = new Uri(str, UriKind.Relative);
                //    ref_image[skill.Key].Source = new BitmapImage(urisource);
                //}
            //}
        }
	}
}
