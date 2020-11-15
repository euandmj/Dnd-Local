using DndL.Core.Model;
using System;

namespace DndL.Core.Events
{
    public class DrawnLineEventArgs
       : EventArgs
    {
        public DrawnLine Point { get; }

        public DrawnLineEventArgs(DrawnLine newP)
        {
            Point = newP;
        }
    }
}
