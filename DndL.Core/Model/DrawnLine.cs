using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndL.Core.Model
{
    public record DrawnLine
    {
        public IList<int> X;
        public IList<int> Y;
        public string StrokeBrush;
        public int StrokeThickness;

    }
}
