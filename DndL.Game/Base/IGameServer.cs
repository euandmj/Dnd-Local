using System;
using System.Collections.Generic;

namespace DndL.Game.Base
{
    public interface IGameServer
    {
        IDictionary<Guid, IBaseCharacter> PartyMembers { get; set; }
        IDictionary<Guid, IBaseCharacter> PlayerCharacters { get; set; }

        int PlayerCount => PlayerCharacters.Count;



    }
}
