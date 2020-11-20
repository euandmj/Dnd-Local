using System;

namespace DndL.Server.Core.Base
{
    public interface IServiceManager<TSource, TPacket>
    {
        event Action<TPacket> Added;

        static TSource Instance { get; }

        void Add(TPacket packet);
        IObservable<TPacket> Get();
    }
}
