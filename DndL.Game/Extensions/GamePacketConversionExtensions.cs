using DndL.Client;
using DndL.Core.Extensions;
using DndL.Game._5e;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DndL.Game.Extensions
{
    public static class GamePacketConversionExtensions
    {
        public static IEnumerable<PlayerCharacter> ToPCs(this PartyMembers msg)
        {
            foreach (var m in msg.Members)
                yield return m.ToPC();
        }

        public static NPlayerCharacter ToNPC(this PartyMemberMessage msg)
        {
            if (string.IsNullOrWhiteSpace(msg.JSON)) throw new ArgumentNullException(nameof(msg));

            var npc = (NPlayerCharacter)JsonSerializer.Deserialize(msg.JSON, typeof(NPlayerCharacter));
            //npc.CharImage = BitmapExtensions.FromBytes(msg.Image.ToArray());

            return npc;
        }

        public static PlayerCharacter ToPC(this PartyMemberMessage msg)
        {
            if (string.IsNullOrWhiteSpace(msg.JSON)) throw new ArgumentNullException(nameof(msg));

            var npc = (PlayerCharacter)JsonSerializer.Deserialize(msg.JSON, typeof(PlayerCharacter));
            //npc.CharImage = BitmapExtensions.FromBytes(msg.Image.ToArray());

            return npc;
        }

    }
}
