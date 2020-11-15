using DndL.Core.Events;
using DndL.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;

namespace DndL.Server
{
    public class PointServiceController
    {
        public EventHandler<DrawnLineEventArgs> PointAdded;
        public EventHandler<DrawnLineEventArgs> PointRemoved;
        public EventHandler<DrawnLineEventArgs> PointsCleared;

        public event Action<DrawnLine> Added;


        private List<DrawnLine> points = new();

        public PointServiceController()
        {
        }


        public void AddPoint(PointPacket packet)
        {
            var newLine = new DrawnLine
            {
                X = packet.X,
                Y = packet.Y,
                StrokeBrush = packet.StrokeBrush,
                StrokeThickness = packet.StrokeThickness
            };

            points.Add(newLine);
            Added?.Invoke(newLine);
        }

        public IObservable<DrawnLine> GetPoints()
        {
            var existing = points.AsReadOnly().ToObservable();
            var newl = Observable.FromEvent<DrawnLine>((x) => Added += x, (x) => Added -= x);

            return existing.Concat(newl);
        }


        public static readonly PointServiceController PointController = new PointServiceController();
    }
}
