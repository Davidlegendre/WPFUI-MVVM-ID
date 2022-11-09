using System;
using System.Windows.Media;
using Wpf.Ui.Appearance;
using Wpf.Ui.Common;

namespace UiDesktopApp2.Models
{
    public class DataColor
    {
        public DataColor()
        {
            var random = new Random();
            SolidColorBrush = new SolidColorBrush(Color.FromArgb(50,(byte)random.Next(0, 250), (byte)random.Next(0, 250), (byte)random.Next(0, 250)));
        }
        public SymbolRegular Icon { get; set; }
        public SolidColorBrush SolidColorBrush { get; }
    }
}
