using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace OriWotWTracker
{
    /// <summary>
    /// Image that switches to monochrome when disabled.
    /// </summary>
    public class GrayscaleEffect : ShaderEffect
    {
        public GrayscaleEffect()
        {
            PixelShader = CreatePixelShader();
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(SaturationFactorProperty);
        }

        /// <summary>
        /// Dependency property for Input
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(GrayscaleEffect), 0);

        /// <summary>
        /// Implicit input
        /// </summary>
        public Brush Input
        {
            get => (Brush)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        /// <summary>
        /// Dependency property for saturation factor
        /// </summary>
        public static readonly DependencyProperty SaturationFactorProperty = DependencyProperty.Register(nameof(SaturationFactor), typeof(double), typeof(GrayscaleEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), CoerceSaturationFactor));

        public double SaturationFactor
        {
            get => (double)GetValue(SaturationFactorProperty);
            set => SetValue(SaturationFactorProperty, value);
        }

        private static object CoerceSaturationFactor(DependencyObject d, object value)
        {
            var effect = (GrayscaleEffect)d;
            double newFactor = (double)value;

            return newFactor < 0.0 || newFactor > 1.0 ? effect.SaturationFactor : (object)newFactor;
        }

        private PixelShader CreatePixelShader()
        {
            var pixelShader = new PixelShader();

            if (DesignerProperties.GetIsInDesignMode(this) == false)
            {
                pixelShader.UriSource = new Uri("E:\\Documenten\\Projecten\\OriWotWTracker\\effects\\grayscale.ps", UriKind.Absolute);
            }

            return pixelShader;
        }
    }

    public class AutoGrayableImage : Image
    {   
        private double _storedOpacity = 1.0;
        private static readonly Effect _grayscaleEffect = new GrayscaleEffect();
        /// <summary>
        /// Overwritten to handle changes of IsEnabled, Source and OpacityMask properties
        /// </summary>
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name.Equals(nameof(IsEnabled)))
            {
                if (IsEnabled)
                {
                    //Opacity = _storedOpacity;
                    Effect = null;
                }
                else
                {
                    //_storedOpacity = Opacity;
                    //Opacity = 0.5;
                    Effect = _grayscaleEffect;
                }
            }
        }
    }


    /// <summary>
    /// Interaction logic for TrackerWindow.xaml
    /// </summary>
    public partial class TrackerWindow : Window
    {

        private bool always_on_top;

        private GameState current_gamestate;

        public GameState Current_gamestate { get => current_gamestate; set => current_gamestate = value; }

        public TrackerWindow(GameState Current_Gamestate)
        {
            Current_gamestate = Current_Gamestate;
            DataContext = Current_gamestate;

            always_on_top = bool.Parse(ConfigController.GetConfig("AlwaysOnTop", "false"));

            if (always_on_top)
            {
                this.Topmost = true;
            }
            else
            {
                this.Topmost = false;
            }


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
            if (always_on_top)
            {
                window.Topmost = true;
            }
        }

        private void Trigger_contextMenu(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            ContextMenu contextMenu = image.ContextMenu;
            contextMenu.PlacementTarget = image;
            contextMenu.IsOpen = true;
        }

        private void AlwaysOnTop_Checked(object sender, RoutedEventArgs e)
        {
            always_on_top = true;
            this.Topmost = true;
            ConfigController.SetConfig("AlwaysOnTop", "true");
        }

        private void AlwaysOnTop_Unchecked(object sender, RoutedEventArgs e)
        {
            always_on_top = false;
            this.Topmost = false;
            ConfigController.SetConfig("AlwaysOnTop", "false");
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
