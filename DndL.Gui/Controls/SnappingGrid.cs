using System.Windows;

namespace DndL.Gui.Controls
{
    class SnappingGrid
    {
        private readonly FrameworkElement Parent;

        public int High { get; set; }
        public int Wide { get; set; }

        public float CellWidth => (float)(Parent.Width / Wide);

        public float CellHeight => (float)(Parent.Height / High);

        public double Width => Parent.Width;
        public double Height => Parent.Height;


        public SnappingGrid(FrameworkElement parent)
        {
            Parent = parent;
        }

        public (int x, int y) GetCell(Point point)
        {
            var relX = point.X;
            var relY = point.Y;

            int row = -1, column = -1;

            for (float i = 0; relX > i; i += CellWidth)
            {
                column++;
            }
            for (float i = 0; relY > i; i += CellHeight)
            {
                row++;
            }

            if (row == -1 || column == -1) 
                throw new System.InvalidProgramException("unable to find row or column");
            return (column, row);
        }

    }
}
