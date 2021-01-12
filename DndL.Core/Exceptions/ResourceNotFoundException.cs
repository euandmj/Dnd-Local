using System;

namespace DndL.Core.Exceptions
{
    public class ResourceNotFoundException
        : Exception
    {
        public string ResourceName { get; }
        public ResourceNotFoundException(string resname)
            => ResourceName = resname;
    }
}
