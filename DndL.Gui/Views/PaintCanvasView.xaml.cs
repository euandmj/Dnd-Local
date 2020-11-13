using DndL.Gui.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PaintCanvasView.xaml
    /// </summary>
    public partial class PaintCanvasView : UserControl
    {
        public EventHandler<LineDrawnEventArgs> LineDrawnEvent;

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
            }
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

                    LineDrawnEvent?.Invoke(null, new LineDrawnEventArgs(currentPoint));
                }
                //TODO: compress lines after N 
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
