using DndL.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using DndL.Core.Events;

namespace DndL.Gui.ViewModels
{
    class MainWindowViewModel
        : BaseViewModel
    {
        public event EventHandler<DrawnLineEventArgs> PointReceived;

        private readonly ClientContainer client;

        


        public MainWindowViewModel()
        {
            // should the client be owned by the base view model statically?

            client = new ClientContainer();

            doofoo();
                
        }

        async void doofoo()
        {
            var ctx = new CancellationTokenSource();
            var call = client._client.Subscribe(new Google.Protobuf.WellKnownTypes.Empty());

            await Task.Run(async () =>
            {
                while (await call.ResponseStream.MoveNext(ctx.Token))
                {
                    var curr = call.ResponseStream.Current;

                    PointReceived?.Invoke(this, new DrawnLineEventArgs(curr.ToDrawnLine()));
                }
            });

        }

        internal async void OnLineDrawn(object sender, DrawnLineEventArgs e)
        {
            await Task.Run(async () =>
            {
                await client.SendPoint(e.Point.ToPointPacket());
            });
        }
    }
}
