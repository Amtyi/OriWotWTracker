using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OriWotWTracker
{
    public static class Extensions
    {
        public static Visibility GetVisibilityFromString (this List<string> flags, string json)
        {
            return flags.Contains(json) ? Visibility.Visible : Visibility.Hidden;
        }
    };
}
