using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DndL.Core.Serialization
{
    public class BitmapJsonConverter
        : JsonConverter<Bitmap>
    {
        public override Bitmap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var bytes = Convert.FromBase64String(reader.GetString());
            using var ms = new MemoryStream(bytes);
            return new Bitmap(ms);
        }

        public override void Write(Utf8JsonWriter writer, Bitmap value, JsonSerializerOptions options)
        {
            var cv = new ImageConverter();
            var base64 = Convert.ToBase64String((byte[])cv.ConvertTo(value, typeof(byte[])));
            writer.WriteStringValue(base64);
        }
    }
}
