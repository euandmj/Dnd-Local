using System;
using System.Drawing;

namespace DndL.Game.Base
{
    public interface IBaseCharacter
    {
        public Guid ID { get; init; }
        string Name { get; set; }
        Bitmap CharImage { get; init; }

    }
}
