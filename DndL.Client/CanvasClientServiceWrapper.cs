using DndL.Client.Extensions;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DndL.Client.CanvasService;
using static DndL.Client.GameService;

namespace DndL.Client
{
    public static class App
    {
        public static Guid ClientSessionID = Guid.NewGuid();
    }

    public class CanvasClientServiceWrapper
    {        
        private readonly CanvasServiceClient _client =
              new(GrpcChannel.ForAddress("https://localhost:5001"));

        public async Task SendPoint(PointPacket p)
        {
            p.Id = App.ClientSessionID.ToString();
            await _client.SendPointAsync(p);
        }

        public IAsyncEnumerable<PointPacket> PointStream()
        {
            var call = _client.PointSubscription(new Empty());

            return call.ResponseStream
                .ToAsyncEnumerable();
        }
    }

    public class GameServiceWrapper
    {
        private readonly GameServiceClient _client =
            new(GrpcChannel.ForAddress("https://localhost:5001"));

        public async Task SendMember(PartyMemberMessage m)
            => await _client.SendPartyMemberAsync(m);

        public PartyMembers GetMembers()
        {
            return _client.GetMembers(new Empty());
        }

        public PartyMemberMessage GetMember(Guid id)
        {
            return _client.GetPlayer(new IDMessage { ID = id.ToString() });
        }

    }
}
