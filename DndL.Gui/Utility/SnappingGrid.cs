using System.Windows;
using System.Collections.Generic;
using System;
using DndL.Gui.Controls;
using System.Windows.Controls;
using System.Linq;

namespace DndL.Gui.Utility
{
    public class SnappingGridUtil
    {
        private readonly FrameworkElement _parent;
        private readonly Grid _grid;

        public int Columns => _grid.ColumnDefinitions.Count;
        public int Rows => _grid.RowDefinitions.Count;

        public double CellWidth => _parent.ActualWidth / Columns;
        public double CellHeight => _parent.ActualHeight / Rows;

        public double Width => _parent.ActualWidth;
        public double Height => _parent.ActualWidth;


        public SnappingGridUtil(FrameworkElement parent, Grid focus)
        {
            _parent = parent ?? throw new ArgumentNullException(nameof(parent));
            _grid = focus ?? throw new ArgumentNullException(nameof(focus));
            if (double.IsNaN(parent.ActualWidth) || double.IsNaN(parent.ActualHeight)) throw new ArgumentException("parent dimensions cannot be NaN", nameof(parent));
        }

        public (int x, int y) GetCell(Point point)
        {
            int row = -1, column = -1;

            for (double i = 0; point.X > i; i += CellWidth)
            {
                column++;
            }
            for (double i = 0; point.Y > i; i += CellHeight)
            {
                row++;
            }

            if (row == -1 || column == -1) 
                throw new InvalidProgramException("unable to find row or column");
            return (column, row);
        }

        public IEnumerable<GridCellControl> GetControlsAtPoint((int x, int y) cell)
        {
            if (cell.x > Columns || cell.y > Rows) throw new ArgumentException("cell is not contained", nameof(cell));

            // GridCellControl interface
            return _grid.Children.FindAll<GridCellControl>(x => x.X == cell.x && x.Y == cell.y);
        }

        public void ClearCell((int x, int y) point, int maxDepth = int.MaxValue)
        {
            var element = GetControlsAtPoint(point).ToArray();

            for (int i = 0; i < maxDepth && i < element.Length; i++)
            {
                _grid.Children.Remove(element[i]);
            }
        }

        public void Resize(int newX, int newY)
        {
            int deltaX = Math.Abs(newX - Columns);
            int deltaY = Math.Abs(newY - Rows);
            bool incrX = newX > Columns;
            bool incrY = newY > Rows;

            for(int i = 0; i < deltaX; i++)
            {

                if (incrX)
                {
                    _grid.ColumnDefinitions.Add(new());
                }
                else if(Columns > 0)
                {
                    _grid.ColumnDefinitions.RemoveAt(Columns - 1);
                }
            }

            for (int i = 0; i < deltaY; i++)
            {
                if (incrY)
                {
                    _grid.RowDefinitions.Add(new());
                }
                else if (Rows > 0)
                {
                    _grid.RowDefinitions.RemoveAt(Rows - 1);
                }
            }
        }
    }
}
