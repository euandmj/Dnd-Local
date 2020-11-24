using DndL.Game.Base;
using System;
using System.Drawing;

namespace DndL.Game._5e
{
    public class NPlayerCharacter
        : IBaseCharacter
    {
        public Guid ID { get; init; } = new Guid();
        public string Name { get; set; }
        public Bitmap CharImage { get; init; }

        public string DescriptionShort { get; set; }



    }
}
