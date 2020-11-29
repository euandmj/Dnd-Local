using System;
using System.Drawing;

namespace DndL.Game.Base
{
    public interface IBaseCharacter
    {
        public Guid ID { get; init; }
        string Name { get; set; }
        Bitmap CharImage { get; set; }

        //static IBaseCharacter Deserialize(string json, byte[] imgBytes, params object[] args);
    }
}
