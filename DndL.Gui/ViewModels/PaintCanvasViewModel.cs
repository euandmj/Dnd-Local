using DndL.Client;
using DndL.Core.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DndL.Gui.ViewModels
{
    class PaintCanvasViewModel
        : BaseViewModel
    {
        public EventHandler<DrawnLineEventArgs> LineReceived;

        private double strokeThickness = 1;
        private SolidColorBrush stroke = Brushes.Blue;
        private SolidColorBrush canvasBrush = Brushes.LightSlateGray;

        public PaintCanvasViewModel()
        {

            FooCommand = new Commands.Command((x) => MessageBox.Show("foo"));

            DoSubscribe();
        }

        public ICommand FooCommand { get; }

        public SolidColorBrush Stroke 
        {
            get => stroke;
            set => SetProperty(ref stroke, value);
        }

        public SolidColorBrush CanvasBrush
        {
            get => canvasBrush;
            set => SetProperty(ref canvasBrush, value);
        }

        public double StrokeThickness
        {
            get => strokeThickness;
            set => SetProperty(ref strokeThickness, value);
        }

        internal async void DoSubscribe()
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
