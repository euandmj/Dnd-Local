using DndL.Core.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DndL.Gui
{
    public static class Extensions
    {
        public static DrawnLine ToDrawnLine(
            this Polyline line,
            SolidColorBrush brush,
            double thickness)
        {
            var x = new List<int>();
            var y = new List<int>();

            foreach (var p in line.Points)
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

        public static Polyline ToPolyLine(this DrawnLine line)
            => new Polyline()
            {
                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(line.StrokeBrush)),
                StrokeThickness = line.StrokeThickness,
                Points = line.ToPointCollection()
            };

        public static PointCollection ToPointCollection(this DrawnLine drawnLine)
        {
            IList<int> x = drawnLine.X, y = drawnLine.Y;

            if (x.Count != y.Count)
                throw new InvalidProgramException("lengths of received points should match");

            var pc = new PointCollection();
            for (int i = 0; i < x.Count; i++)
            {
                pc.Add(new Point(x[i], y[i]));
            }
            return pc;
        }

        public static IEnumerable<T> FindAll<T>(this UIElementCollection @this, Func<T, bool> func)
        {
            foreach(var child in @this)
            {
                if(child.GetType() == typeof(T))
                {
                    if (func((T)child)) yield return (T)child;
                }
            }
        }
    }
}
