using System.Windows;

namespace DndL.Gui.Utility
{
    class SnappingGridUtil
    {
        private readonly FrameworkElement Parent;

        public int High { get; set; }
        public int Wide { get; set; }

        public float CellWidth => (float)(Parent.Width / Wide);

        public float CellHeight => (float)(Parent.Height / High);

        public double Width => Parent.Width;
        public double Height => Parent.Height;


        public SnappingGridUtil(FrameworkElement parent)
        {
            //if (double.IsNaN(parent.Width) || double.IsNaN(parent.Height)) throw new System.ArgumentException("parent dimensions cannot be NaN", nameof(parent));


            Parent = parent;
        }

        public (int x, int y) GetCell(Point point)
        {
            int row = -1, column = -1;

            for (float i = 0; point.X > i; i += CellWidth)
            {
                column++;
            }
            for (float i = 0; point.Y > i; i += CellHeight)
            {
                row++;
            }

            if (row == -1 || column == -1) 
                throw new System.InvalidProgramException("unable to find row or column");
            return (column, row);
        }

    }
}
