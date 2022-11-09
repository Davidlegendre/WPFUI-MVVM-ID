using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace UiDesktopApp2.Helpers
{
    public class ConvertThemeColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not SolidColorBrush)
                throw new Exception("solo colores");
            var color = (SolidColorBrush)value;
            return color.Color.ToString() == "#FF202020" ? new SolidColorBrush(System.Windows.Media.Color.FromRgb(46,46,46))
                : System.Windows.Media.Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
