using DndL.Server.ServiceManagers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DndL.Server.Services
{
    public class GameServiceGrpcServer
        : GameService.GameServiceBase
    {
        private readonly ILogger<GameServiceGrpcServer> _logger;
        private readonly GameServiceController _controller;



        public GameServiceGrpcServer(ILogger<GameServiceGrpcServer> logger)
        {
            _logger = logger;
            _controller = GameServiceController.Instance;
        }

        public override Task<PartyMembers> GetMembers(Empty request, ServerCallContext context)
        {
            return Task.FromResult(_controller.GetMembers());
        }

        public override Task<PartyMemberMessage> GetPlayer(IDMessage request, ServerCallContext context)
        {
            return Task.FromResult(_controller.GetPlayer(request.ID));
        }

        //public override async Task<Empty> SendPartyMember(PartyMemberMessage request, ServerCallContext context)
        //{
        //    _controller.Add(request);
        //    return await Task.FromResult(new Empty());
        //}

        //public override async Task GetMembers(Empty request, IServerStreamWriter<PartyMemberMessage> responseStream, ServerCallContext context)
        //{
        //    try
        //    {
        //        await _controller
        //            .Get()
        //            .ToAsyncEnumerable()
        //            .ForEachAwaitAsync(async (x) => await responseStream.WriteAsync(x), context.CancellationToken)
        //            .ConfigureAwait(false);
        //    }
        //    catch (TaskCanceledException)
        //    {

        //    }
        //}
    }
}
