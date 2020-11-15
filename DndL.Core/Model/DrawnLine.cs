using System.Collections.Generic;

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
