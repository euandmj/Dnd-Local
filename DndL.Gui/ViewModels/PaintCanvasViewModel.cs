using DndL.Client.Extensions;
using DndL.Core.Events;
using DndL.Gui.Core.Commands;
using DndL.Gui.Core.Modes;
using DndL.Gui.Model;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static DndL.Core.Events.DrawnLineEventArgs;

namespace DndL.Gui.ViewModels
{
    class PaintCanvasViewModel
        : BaseViewModel
    {
        public DrawnLineEventHandler LineReceived;
        public DrawnLineEventHandler LineDrawn;
        public event EventHandler<CanvasModeChangedEventArgs> ModeChanged;


        private CanvasBrush activeBrush;
        private readonly CanvasBrush brush1 = new();
        private readonly CanvasBrush brush2 = new();

        private CanvasMode currentMode;

        private BitmapImage canvasBackground;

        private SolidColorBrush canvasBrush = Brushes.AntiqueWhite;

        private Point currentPoint;
        private Polyline currentLine;

        public PaintCanvasViewModel()
        {
            Subcribe_PointStream();

            LineDrawn += OnLineDrawn;
            LineReceived += OnLineReceived;

            Brush1Command = new Command((x) =>
            {
                CanvasMode = CanvasMode.Brush;
                ActiveBrush = brush1;
            });
            Brush2Command = new Command((x) =>
            {
                CanvasMode = CanvasMode.Brush;
                ActiveBrush = brush2;
            });
            //MouseUpCommand = new Command((x) =>
            //{
            //    if (currentLine?.Points?.Count > 0)
            //        LineDrawn?.Invoke(
            //            new DrawnLineEventArgs(
            //                currentLine.ToDrawnLine(ActiveBrush.Color, 
            //                ActiveBrush.Thickness)));
            //});


            activeBrush = brush1;
        }

        public ObservableCollection<IInputElement> CanvasChildren { get; set; } = new();
        public ICommand Brush1Command { get; }
        public ICommand Brush2Command { get; }
        public ICommand MouseUpCommand 
            => new Command((x) =>
            {
                if (currentLine?.Points?.Count > 0)
                    LineDrawn?.Invoke(
                        new DrawnLineEventArgs(
                            currentLine.ToDrawnLine(ActiveBrush.Color,
                                                    ActiveBrush.Thickness)));
            });
        public ICommand SwitchBackgroundCommand
            => new Command((x) =>
            {
                var dialog = new OpenFileDialog
                {
                    CheckPathExists = true,
                    DefaultExt = "png",
                    Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
                };

                var res = dialog.ShowDialog();
                if (res.HasValue && res.Value)
                {
                    //var xx = new ImageBrush(LoadImage(dialog.FileName));
                    Background = LoadImage(dialog.FileName);
                }
            });
        public ICommand MoveCommand
            => new Command((x) =>
            {
                CanvasMode = CanvasMode.Grid;
                ActiveBrush = null;
            });


        public SolidColorBrush CanvasBrush
        {
            get => canvasBrush;
            set => SetProperty(ref canvasBrush, value);
        }

        public CanvasBrush ActiveBrush
        {
            get => activeBrush;
            set
            {
                SetProperty(ref activeBrush, value);
                OnPropertyChanged(nameof(Brush1Enabled));
                OnPropertyChanged(nameof(Brush2Enabled));
                OnPropertyChanged(nameof(MoveEnabled));
            }
        }

        public BitmapImage Background
        {
            get => canvasBackground;
            set => SetProperty(ref canvasBackground, value);
        }

        public CanvasMode CanvasMode
        {
            get => currentMode;
            set
            {
                SetProperty(
                    ref currentMode, 
                    value, 
                    nameof(CanvasMode), 
                    () => ModeChanged?.Invoke(this, new(currentMode, value)));
            }
        }


        public bool Brush1Enabled => activeBrush != brush1;
        public bool Brush2Enabled => activeBrush != brush2;
        public bool MoveEnabled => currentMode != CanvasMode.Grid;





        private BitmapImage LoadImage(string filename)
        {
            //using var fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            var img = new BitmapImage();

            img.BeginInit();
            img.UriSource = new Uri(filename, UriKind.Absolute);
            //img.StreamSource = fs;
            img.EndInit();

            return img;

        }




        private async void Subcribe_PointStream()
        {
            try
            {
                await canvasClient.PointStream().ForEachAsync(x =>
                {
                    if (Guid.Parse(x.Id) != DndL.Client.App.ClientSessionID)
                        LineReceived?.Invoke(new DrawnLineEventArgs(x.ToDrawnLine()));
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }



        public void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(sender as IInputElement);

                currentLine = new Polyline()
                {
                    Stroke = ActiveBrush.Color,
                    StrokeThickness = ActiveBrush.Thickness
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
            try
            {
                await canvasClient.SendPoint(e.Point.ToPointPacket());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


        internal void OnLineReceived(DrawnLineEventArgs e)
        {
            // After moving logic into the view model i was getting STAThread exceptions.
            Application.Current.Dispatcher
                .Invoke(() => CanvasChildren.Add(e.Point.ToPolyLine()));
        }
    }
}
