using DndL.Game.Dice;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DndL.Gui.Core.Converters
{
    public class DieAttributeImageConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not DieValueAttribute attr) return null;

            var bmp = Game.EoE.DiceMediaProvider.GetDiceImage(attr.ImageResourceName);

            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bmp.GetHbitmap(),
                IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromWidthAndHeight(bmp.Width, bmp.Height));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
