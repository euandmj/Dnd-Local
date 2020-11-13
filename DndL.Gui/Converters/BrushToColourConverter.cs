using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DndL.Gui.Converters
{
    public class BrushToColourConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SolidColorBrush b)) return null;

            return b.Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color c)) return null;

            return new SolidColorBrush(c);
        }
    }
}
