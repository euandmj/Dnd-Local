using DndL.Client.Extensions;
using DndL.Core.Events;
using DndL.Gui.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static DndL.Core.Events.DrawnLineEventArgs;

namespace DndL.Gui.ViewModels
{
    class PaintCanvasViewModel
        : BaseViewModel
    {
        public DrawnLineEventHandler LineReceived;
        public DrawnLineEventHandler LineDrawn;

        private double strokeThickness = 1;
        private SolidColorBrush stroke = Brushes.Blue;
        private SolidColorBrush canvasBrush = Brushes.AntiqueWhite;

        private Point currentPoint;
        private Polyline currentLine;

        public PaintCanvasViewModel()
        {
            Subcribe_PointStream();

            LineDrawn += OnLineDrawn;
            LineReceived += OnLineReceived;

            FooCommand      = new Command((x) => MessageBox.Show("foo"));
            MouseUpCommand  = new Command((x) =>
            {
                if (currentLine?.Points?.Count != 0)
                    LineDrawn?.Invoke(new DrawnLineEventArgs(currentLine.ToDrawnLine(stroke, strokeThickness)));
            });
        }

        public ObservableCollection<IInputElement> CanvasChildren { get; set; } = new();
        public ICommand FooCommand { get; }
        public ICommand MouseUpCommand { get; }

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

        private async void Subcribe_PointStream()
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
                        LineReceived?.Invoke(new DrawnLineEventArgs(curr.ToDrawnLine()));
                    }
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Lines Subscription Errored:\n{0}", ex.Message), $"{ex.GetType()}", MessageBoxButton.OK);
                throw;
            }
        }

        public void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(sender as IInputElement);

                currentLine = new Polyline()
                {
                    Stroke = Stroke,
                    StrokeThickness = StrokeThickness
                };
                CanvasChildren.Add(currentLine);
            }
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (currentLine is null) return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var newPoint = e.GetPosition(sender as IInputElement);

                if (newPoint != currentPoint)
                {
                    currentLine.Points.Add(newPoint);
                    currentPoint = newPoint;
                }
                //TODO: compress lines after N 
            }
        }
        

        internal async void OnLineDrawn(DrawnLineEventArgs e)
        {
            await client.SendPoint(e.Point.ToPointPacket());
        }


        internal void OnLineReceived(DrawnLineEventArgs e)
        {
            // After moving logic into the view model i was getting STAThread exceptions.
            Application.Current.Dispatcher
                .Invoke(() => CanvasChildren.Add(e.Point.ToPolyLine()));
        }
    }
}
