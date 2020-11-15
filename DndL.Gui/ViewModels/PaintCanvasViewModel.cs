using DndL.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DndL.Gui.ViewModels
{
    class PaintCanvasViewModel
        : BaseViewModel
    {
        public EventHandler<DrawnLineEventArgs> LineDrawnEvent;

        private double strokeThickness = 1;
        private SolidColorBrush stroke = Brushes.Blue;
        private SolidColorBrush canvasBrush = Brushes.LightSlateGray;

        public PaintCanvasViewModel()
        {

            FooCommand = new Commands.Command((x) => MessageBox.Show("foo"));

            LineDrawnEvent += OnLineDrawn;

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


        private void OnLineDrawn(object sender, DrawnLineEventArgs e)
        {

        }
    }
}
