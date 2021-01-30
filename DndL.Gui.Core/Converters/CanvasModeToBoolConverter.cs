using DndL.Gui.Core.Modes;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DndL.Gui.Core.Converters
{
    public class CanvasModeToBoolConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is not CanvasMode mode)
            {
                return null;
            }
            if(parameter is not CanvasMode param)
            {
                return null;
            }

            return mode == param;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}