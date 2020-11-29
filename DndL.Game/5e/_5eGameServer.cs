using DndL.Game.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndL.Game._5e
{
    class _5eGameServer
        : IGameServer
    {
        public IDictionary<Guid, IBaseCharacter> PartyMembers { get; set; }
        public IDictionary<Guid, IBaseCharacter> PlayerCharacters { get; set; }


        public _5eGameServer()
        {
            PartyMembers = new Dictionary<Guid, IBaseCharacter>();
            PlayerCharacters = new Dictionary<Guid, IBaseCharacter>();
        }
    }
}
