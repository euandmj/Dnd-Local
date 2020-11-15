using DndL.Client;
using DndL.Core.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DndL.Gui.ViewModels
{
    class MainWindowViewModel
        : BaseViewModel
    {
        public event EventHandler<DrawnLineEventArgs> LineReceived;

        private readonly ClientContainer client;

        


        public MainWindowViewModel()
        {
            // should the client be owned by the base view model statically?

            client = new ClientContainer();

            DoSubscribe();
                
        }

        async void DoSubscribe()
        {
            try
            {
                var ctx = new CancellationTokenSource();
                var call = client._client.Subscribe(new Google.Protobuf.WellKnownTypes.Empty());

                await Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext(ctx.Token))
                    {
                        var curr = call.ResponseStream.Current;

                        LineReceived?.Invoke(this, new DrawnLineEventArgs(curr.ToDrawnLine()));
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lines Subscription Errored:\n{0}", ex.Message), $"{ex.GetType()}", MessageBoxButton.OK);
            }
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
