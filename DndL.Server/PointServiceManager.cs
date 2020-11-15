using DndL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace DndL.Server
{
    public class PointServiceController
    {
        public event Action<DrawnLine> Added;

        private readonly List<DrawnLine> points = new();



        private void AddLine(DrawnLine nl)
        {
            points.Add(nl);
        }

        public void Add(PointPacket packet)
        {
            var newLine = new DrawnLine
            {
                X = packet.X,
                Y = packet.Y,
                StrokeBrush = packet.StrokeBrush,
                StrokeThickness = packet.StrokeThickness
            };

            AddLine(newLine);
            Added?.Invoke(newLine);
        }

        public IObservable<DrawnLine> Get()
        {
            var existing = points.AsReadOnly().ToObservable();
            var newl = Observable.FromEvent<DrawnLine>((x) => Added += x, (x) => Added -= x);

            return existing.Concat(newl);
        }

        private static readonly Lazy<PointServiceController> PSC = new Lazy<PointServiceController>(() => new PointServiceController());
        public static PointServiceController Instance => PSC.Value;
    }
}
