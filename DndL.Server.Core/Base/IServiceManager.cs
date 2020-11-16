using System;

namespace DndL.Server.Core.Base
{
    public interface IServiceManager<TSource, TData, TPacket>
    {
        event Action<TData> Added;

        static TSource Instance { get; }

        void Add(TPacket packet);
        IObservable<TData> Get();
    }
}
