using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace DndL.Gui.Core.Converters
{
    public class ObjectToDisplayValueConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var attr = (DisplayNameAttribute)value.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();

            return attr is null
                ? value.ToString()
                : attr.DisplayName;
            //return attr?.DisplayName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
