using System.Windows;
using System.Collections.Generic;
using System;
using DndL.Gui.Controls;
using System.Windows.Controls;
using System.Linq;

namespace DndL.Gui.Utility
{
    class SnappingGridUtil<TCtrl>
        where TCtrl : GridCellControl
    {
        private readonly FrameworkElement _parent;
        private readonly FrameworkElement _focusedControl;

        public int High { get; init; }
        public int Wide { get; init; }

        public double CellWidth => _parent.ActualWidth / Wide;
        public double CellHeight => _parent.ActualHeight / High;

        public double Width => _parent.Width;
        public double Height => _parent.Height;


        public SnappingGridUtil(FrameworkElement parent)
        {
            _ = parent ?? throw new ArgumentNullException(nameof(parent));
            //_ = focus ?? throw new System.ArgumentNullException(nameof(focus));
            if (double.IsNaN(parent.ActualWidth) || double.IsNaN(parent.ActualHeight)) throw new ArgumentException("parent dimensions cannot be NaN", nameof(parent));


            _parent = parent;
            //_focusedControl = focus;
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

        public IEnumerable<UIElement> GetControlsAtPoint(Panel host, (int x, int y) cell)
        {
            if (cell.x > Wide || cell.y > High) throw new ArgumentException(nameof(cell));

            return host.Children.FindAll<TCtrl>(x => x.X == cell.x && x.Y == cell.y);
            //return host.Children.FindAll<UIElement>(x => Grid.GetRow(x) == cell.y && Grid.GetColumn(x) == cell.x);
        }

        public void ClearCell((int x, int y) point, Panel host, int maxDepth = int.MaxValue)
        {
            var found = GetControlsAtPoint(host, point).ToArray();

            for (int i = 0; i < maxDepth && i < found.Length; i++)
            {
                host.Children.Remove(found[i]);
            }
        }

        public void AddToCell(Panel host, UIElement ctrl, (int x, int y) point)
        {
            Grid.SetColumn(ctrl, point.x);
            Grid.SetRow(ctrl, point.y);
            host.Children.Add(ctrl);
        }

    }
}
