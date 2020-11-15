using DndL.Core.Model;
using System;
using System.Drawing;

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
