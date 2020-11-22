using System;

namespace DndL.Core.Events
{
    public class GenericEventArgs<T>
        : EventArgs
    {
        public T Value { get; }

        public GenericEventArgs(T val)
            => Value = val;
    }
}
