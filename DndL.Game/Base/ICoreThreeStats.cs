using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndL.Game.Base
{
    interface ICoreThreeStats<TStat>
    {
        public TStat Health { get; set; }
        public TStat Armor { get; set; }
    }
}
