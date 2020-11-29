using DndL.Core.Extensions;
using DndL.Game._5e;
using DndL.Game.Base;
using DndL.Server.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text.Json;

namespace DndL.Server.ServiceManagers
{
    public class GameServiceController
        : IServiceManager
    {
        private readonly IGameServer game;


        public GameServiceController()
        {
            game = Game.Base.GameContainer.GetGameServer();


            //var pc = new PlayerCharacter { CharImage = Game.Properties.Resources.adventurer1, Name = "adventurer", ArmorClass = 5 };
            //game.PlayerCharacters.Add(pc.ID, pc);

            var pnclist = new List<IBaseCharacter>()
            {
                new PlayerCharacter { CharImage = DndL.Game.Properties.Resources.adventurer1, Name = "adventurer"  },
                new PlayerCharacter { CharImage = DndL.Game.Properties.Resources.arcane2, Name = "arcane2"  },
                new PlayerCharacter { CharImage = DndL.Game.Properties.Resources.arcane4, Name = "arcane4"  },
                new PlayerCharacter { CharImage = DndL.Game.Properties.Resources.warrior2, Name = "warrior"  }
            };
            game.PlayerCharacters = pnclist.ToDictionary(k => k.ID, v => v);
        }

        public PartyMembers GetMembers()
        {
            var mems = new List<PartyMemberMessage>();

            foreach(var p in game.PlayerCharacters)
            {
                mems.Add(new PartyMemberMessage
                {
                    JSON = JsonSerializer.Serialize(p.Value, typeof(PlayerCharacter))
                });
            }
            var party = new PartyMembers();
            party.Members.AddRange(mems);
            return party;
        }

        public PartyMemberMessage GetPlayer(string id)
        {
            var pc = game.PlayerCharacters[Guid.Parse(id)];

            return new PartyMemberMessage()
            {
                JSON = JsonSerializer.Serialize(pc, typeof(PlayerCharacter))
            };
        }



        private static readonly Lazy<GameServiceController> GSC =
            new Lazy<GameServiceController>(() => new GameServiceController());
        public static GameServiceController Instance => GSC.Value;
    }
}
