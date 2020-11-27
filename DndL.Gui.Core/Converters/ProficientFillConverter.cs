using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DndL.Gui.Core.Converters
{
    public class ProficientFillConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool b) throw new ArgumentException(nameof(value));

            return b
                ? new SolidColorBrush(Colors.Black)
                : new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
