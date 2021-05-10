using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OriWotWTracker
{
    /// <summary>
    /// Interaction logic for TrackerWindow.xaml
    /// </summary>
    public partial class TrackerWindow : Window
    {

        private GameState current_gamestate;

        public GameState Current_gamestate { get => current_gamestate; set => current_gamestate = value; }

        public TrackerWindow(GameState Current_Gamestate)
        {
            Current_gamestate = Current_Gamestate;
            DataContext = Current_gamestate;

            InitializeComponent();
        }

        private void Toggle_on(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;

            string str = "img/" + img.Name + "_unlocked.png";
            Uri urisource = new Uri(str, UriKind.Relative);
            img.Source = new BitmapImage(urisource);
        }

        private void Toggle_off(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;

            string str = "img/" + img.Name + ".png";
            Uri urisource = new Uri(str, UriKind.Relative);
            img.Source = new BitmapImage(urisource);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save the coordinates of the tracker on Exit so we can reopen it in the same place.
            ConfigController.SetConfig("xpos", Left.ToString());
            ConfigController.SetConfig("ypos", Top.ToString());
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }

        private void Trigger_contextMenu(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            ContextMenu contextMenu = image.ContextMenu;
            contextMenu.PlacementTarget = image;
            contextMenu.IsOpen = true;
        }


        //private void Cycle_WeaponUpgrade(object sender, MouseButtonEventArgs e)
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
    }
}
