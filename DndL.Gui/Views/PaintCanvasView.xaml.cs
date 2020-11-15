using DndL.Core.Events;
using DndL.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PaintCanvasView.xaml
    /// </summary>
    public partial class PaintCanvasView : UserControl
    {
        public EventHandler<DrawnLineEventArgs> LineStarted;
        public EventHandler<DrawnLineEventArgs> LineDrawn;

        private Point currentPoint;
        private Polyline line;

        private readonly PaintCanvasViewModel viewModel;
        public PaintCanvasView()
        {
            InitializeComponent();


            DataContext = viewModel = new PaintCanvasViewModel();

            
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);                
                
                line = new Polyline()
                {
                    Stroke = viewModel.Stroke,
                    StrokeThickness = viewModel.StrokeThickness
                };

                Canvas.Children.Add(line);

                //LineStarted?.Invoke(this, new PointEventArgs(currentPoint.X, currentPoint.Y));
            }
        }

        internal void OnAddPoint(object sender, DrawnLineEventArgs e)
        {
            Canvas.Dispatcher.Invoke(() =>
            {
                Canvas.Children.Add(new Polyline()
                {
                    Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(e.Point.StrokeBrush)),
                    StrokeThickness = e.Point.StrokeThickness,
                    Points = GetPoints(e.Point.X, e.Point.Y)
                });
            });
        }

        private PointCollection GetPoints(IList<int> x, IList<int> y)
        {
            if (x.Count != y.Count)
                throw new InvalidProgramException("lengths of received points should match");
            var pc = new PointCollection();
            for(int i = 0; i < x.Count; i++)
            {
                pc.Add(new Point(x[i], y[i]));
            }
            return pc;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (line is null) return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var newPoint = e.GetPosition(sender as IInputElement);

                if (newPoint != currentPoint)
                {
                    line.Points.Add(newPoint);
                    currentPoint = newPoint;
                }
                //TODO: compress lines after N 
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LineDrawn?.Invoke(
                null, 
                new DrawnLineEventArgs(line.ToDrawnLine(viewModel.Stroke, viewModel.StrokeThickness)));
        }
    }
}
