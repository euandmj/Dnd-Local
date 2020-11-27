using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DndL.Gui.Core.Converters
{
    public class BrushToColourConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not SolidColorBrush b) return null;

            return b.Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Color c) return null;

            return new SolidColorBrush(c);
        }
    }
}
