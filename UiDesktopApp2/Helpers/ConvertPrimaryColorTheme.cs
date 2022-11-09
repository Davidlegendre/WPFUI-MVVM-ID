using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace UiDesktopApp2.Helpers
{
    public class ConvertPrimaryColorTheme : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not SolidColorBrush)
                throw new Exception("solo colores");
            var color = (SolidColorBrush)value;
            return color.Color.ToString() == "#FF202020" ? value : new SolidColorBrush(Color.FromRgb(234,234,234));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
