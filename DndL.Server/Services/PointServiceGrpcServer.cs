﻿using DndL.Server.ServiceControllers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DndL.Server.Services
{
    public class PointServiceGrpcServer
        : CanvasService.CanvasServiceBase
    {
        private readonly ILogger<PointServiceGrpcServer> _logger;
        private readonly PointServiceController _controller;

        public PointServiceGrpcServer(ILogger<PointServiceGrpcServer> logger)
        {
            _logger = logger;
            _controller = PointServiceController.Instance;
        }

        public override async Task<Empty> SendPoint(
            PointPacket request, 
            ServerCallContext context)
        {
            _controller.Add(request);
            return await Task.FromResult(new Empty());
        }

        public override async Task PointSubscription(Empty request, 
            IServerStreamWriter<PointPacket> responseStream, 
            ServerCallContext context)
        {

            try
            {
                await _controller
                    .Get()
                    .ToAsyncEnumerable()
                    .ForEachAwaitAsync(async (x) => await responseStream.WriteAsync(x), context.CancellationToken)
                    .ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {

            }
        }


    }
}
