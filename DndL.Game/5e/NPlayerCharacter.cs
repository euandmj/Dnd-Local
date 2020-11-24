using DndL.Game.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndL.Game._5e
{
    public class NPlayerCharacter
        : IBaseCharacter, ICoreThreeStats<int>
    {
        public Guid ID { get; init; } = new Guid();
        public string Name { get; set; }
        public Bitmap CharImage { get; init; }

        public string DescriptionShort { get; set; }

        public int Health { get; set; }
        public int Armor { get; set; }



    }
}
