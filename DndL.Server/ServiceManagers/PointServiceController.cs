using DndL.Core.Model;
using DndL.Server.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Reactive.Linq;

namespace DndL.Server.ServiceControllers
{
    public class PointServiceController
        : IServiceManager<PointServiceController, PointPacket>
    {
        public event Action<PointPacket> Added;

        private readonly List<PointPacket> points = new();

        public void Add(PointPacket packet)
        {
            points.Add(packet);
            Added?.Invoke(packet);
        }

        public IObservable<PointPacket> Get()
        {
            var existing = points.AsReadOnly().ToObservable();
            var newl = Observable.FromEvent<PointPacket>((x) => Added += x, (x) => Added -= x);

            return existing.Concat(newl);
        }

        private static readonly Lazy<PointServiceController> PSC = new Lazy<PointServiceController>(() => new PointServiceController());
        public static PointServiceController Instance => PSC.Value;
    }
}
