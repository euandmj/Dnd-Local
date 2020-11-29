using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;

namespace DndL.Core.Extensions
{
    public static class BitmapExtensions
    {
        public static byte[] ToBytes(this Bitmap b)
        {
            var conv = new ImageConverter();
            return (byte[])new ImageConverter().ConvertTo(b, typeof(byte[]));
        }

        public static Bitmap FromBytes(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return new Bitmap(ms);
        }

    }
}
