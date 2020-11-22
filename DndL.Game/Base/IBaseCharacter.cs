using System.Drawing;

namespace DndL.Game.Base
{
    public interface IBaseCharacter
    {
        string Name { get; set; }
        Bitmap CharImage { get; init; }

    }
}
