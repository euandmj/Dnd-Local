using DndL.Game.Base;
using System;
using System.Collections.Generic;

namespace DndL.Game._5e
{
    public class _5eGame
        : IGame
    {
        public IBaseCharacter Player { get; set; }
        public IDictionary<Guid, IBaseCharacter> Party { get; set; }


        public _5eGame()
        {
            Player = new PlayerCharacter { CharImage = Game.Properties.Resources.adventurer1, Name = "adventurer", ArmorClass = 5 };
            Party = new Dictionary<Guid, IBaseCharacter>()
            {
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = DndL.Game.Properties.Resources.adventurer1, Name = "adventurer" } },
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = DndL.Game.Properties.Resources.arcane2, Name = "arcane2" } },
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = DndL.Game.Properties.Resources.arcane4, Name = "arcane4" } },
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = DndL.Game.Properties.Resources.warrior2, Name = "warrior" } }
            };
        }
    }
}
