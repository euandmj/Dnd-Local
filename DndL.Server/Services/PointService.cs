using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndL.Server.Services
{
    public class PointServiceGrpcServer
        : PointService.PointServiceBase
    {
        private readonly ILogger<PointServiceGrpcServer> _logger;
        private readonly PointServiceController _controller;

        public PointServiceGrpcServer(ILogger<PointServiceGrpcServer> logger)
        {
            _logger = logger;
            _controller = PointServiceController.PointController;
        }

        public override async Task<Empty> SendPoint(PointPacket request, ServerCallContext context)
        {
            _controller.AddPoint(request);
            return await Task.FromResult(new Empty());
        }

        public override async Task Subscribe(Empty request, IServerStreamWriter<PointPacket> responseStream, ServerCallContext context)
        {

            try
            {
                await _controller
                    .GetPoints()
                    .ToAsyncEnumerable()
                    .ForEachAwaitAsync(async (x) => await responseStream.WriteAsync(x.ToPointPacket()), context.CancellationToken)
                    .ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {

            }
        }
    }


    public static class DrawnLine_PointPacket_ConversionExtensions
    {
        public static PointPacket ToPointPacket(this Core.Model.DrawnLine dl)
        {
            var pp = new PointPacket
            {
                StrokeBrush = dl.StrokeBrush,
                StrokeThickness = dl.StrokeThickness
            };

            pp.X.AddRange(dl.X);
            pp.Y.AddRange(dl.Y);

            return pp;
        }

        public static Core.Model.DrawnLine ToDrawnLine(this PointPacket pp)
            => new Core.Model.DrawnLine
            {
                X = pp.X,
                Y = pp.Y,
                StrokeBrush = pp.StrokeBrush,
                StrokeThickness = pp.StrokeThickness
            };

    }

}
