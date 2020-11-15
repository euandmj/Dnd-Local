using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace DndL.Server
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        private List<string> previousNames = new List<string>();

        public override async Task FullDuplexHello(IAsyncStreamReader<HelloRequest> requestStream, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            while(await requestStream.MoveNext())
            {
                var curr = requestStream.Current;

                previousNames.Add(curr.Name);

                var resp = string.Join(',', previousNames);

                await responseStream.WriteAsync(new HelloReply { Message = resp });
            }
        }

        //public override async Task PointStream(IAsyncStreamReader<PointPacket> requestStream, IServerStreamWriter<PointPacket> responseStream, ServerCallContext context)
        //{
        //    //while (await requestStream.MoveNext())
        //    //{
        //    //    base.

        //    //}
        //    await base.PointStream(requestStream, responseStream, context);



        //}
    }
}
