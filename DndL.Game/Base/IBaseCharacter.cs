using System.Drawing;

namespace DndL.Game.Base
{
    public interface IBaseCharacter<TStat>
    {
        string Name { get; set; }

        Stat<TStat>[] KeyStats { get; }
        Bitmap CharImage { get; init; }

    }
}
