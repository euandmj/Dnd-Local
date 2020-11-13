using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DndL.Client
{
    public class ClientContainer
        : IDisposable
    {
        private bool disposedValue;
        public readonly Greeter.GreeterClient _client =
            new Greeter.GreeterClient(
                GrpcChannel.ForAddress("https://localhost:5001"));

        public async Task SendPoint(PointPacket p)
            => await _client.SendPointsAsync(p);

        public IAsyncEnumerable<PointPacket> PointStream()
        {
            var call = _client.Subscribe(new Google.Protobuf.WellKnownTypes.Empty());

            return call.ResponseStream
                .ToAsyncEnumerable();
        }



        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ClientContainer()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
