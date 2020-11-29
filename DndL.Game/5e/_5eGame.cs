using DndL.Core.Events;
using DndL.Game.Base;
using DndL.Game.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DndL.Game._5e
{
    public class _5eGame
        : IGame
    {
        public static string PlayerName { get; set; }

        public event EventHandler<GenericEventArgs<IBaseCharacter>> PlayerConnected;

        protected Client.GameServiceWrapper client;

        public IBaseCharacter Player { get; set; }
        public IDictionary<Guid, IBaseCharacter> Party { get; set; }


        public _5eGame()
        {
            client = new();

            // load player from disk
            
            Party = new ObservableConcurrentDictionary<Guid, IBaseCharacter>();


            LoadPlayers();
        }

        private void LoadPlayers()
        {
            var response = client.GetMembers();

            foreach(var npc in response.ToPCs())
            {
                Party[npc.ID] = npc;
            }
        }

        public void SetPlayer(Guid id)
        {
            var recv = client.GetMember(id);
            Player = recv.ToPC();
        }

        private async void UploadPlayer()
        {
            //await client.SendMember(new Client.PartyMemberMessage()
            //{
            //    JSON = System.Text.Json.JsonSerializer.Serialize(Player, typeof(PlayerCharacter)),
            //    Image = Google.Protobuf.ByteString.CopyFrom(Player.CharImage.ToBytes())
            //});
        }

        //private async void SubscribeToPlayerUpdates()
        //{
        //    await client.
        //        GetMembersJson().
        //        ForEachAsync((resp) =>
        //        {
        //            var member = NPlayerCharacter.Deserialize(resp.JSON, resp.Image.ToArray());
        //            Dispatcher.CreateDefault().InvokeAsync(() => Party[member.ID] = member);
        //            PlayerConnected?.Invoke(this, new GenericEventArgs<IBaseCharacter>(member));
        //        });
        //}

        public void Init(params object[] args)
        {
            LoadPlayers();
        }
    }
}
