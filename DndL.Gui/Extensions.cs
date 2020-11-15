using DndL.Core.Model;
using System.Collections.Generic;

namespace DndL.Gui
{
    public static class Extensions
    {
        public static DrawnLine ToDrawnLine(
            this System.Windows.Shapes.Polyline line, 
            System.Windows.Media.SolidColorBrush brush, 
            double thickness)
        {
            var x = new List<int>();
            var y = new List<int>();

            foreach(var p in line.Points)
            {
                x.Add((int)p.X);
                y.Add((int)p.Y);
            }

            return new DrawnLine()
            {
                X = x,
                Y = y,
                StrokeBrush = brush.ToString(),
                StrokeThickness = (int)thickness
            };
        }
    }
}
