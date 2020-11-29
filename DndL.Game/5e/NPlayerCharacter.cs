using DndL.Core.Extensions;
using DndL.Game.Base;
using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace DndL.Game._5e
{
    public class NPlayerCharacter
        : IBaseCharacter
    {
        [JsonInclude] public Guid ID { get; init; } = Guid.NewGuid();
        [JsonInclude] public string Name { get; set; }

        [JsonIgnore] public Bitmap CharImage { get; set; }

        [JsonInclude] public string DescriptionShort { get; set; }

        [JsonInclude] public byte[] CharImageBytes
        {
            get => CharImage.ToBytes();
            set => CharImage = BitmapExtensions.FromBytes(value);
        }

      


        //public static NPlayerCharacter Deserialize(string json, byte[] imgbytes)
        //{
        //    if (string.IsNullOrWhiteSpace(json)) throw new ArgumentNullException(nameof(json));

        //    var npc = (NPlayerCharacter)JsonSerializer.Deserialize(json, typeof(NPlayerCharacter));
        //    npc.CharImage = BitmapExtensions.FromBytes(imgbytes);

        //    return npc;
        //}

        //public static IBaseCharacter Deserialize(string json, byte[] imgBytes, params object[] args)
        //{
        //    if (string.IsNullOrWhiteSpace(json)) throw new ArgumentNullException(nameof(json));

        //    var npc = (NPlayerCharacter)JsonSerializer.Deserialize(json, typeof(NPlayerCharacter));
        //    npc.CharImage = BitmapExtensions.FromBytes(imgBytes);

        //    return npc;
        //}
    }
}
