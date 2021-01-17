using DndL.Gui.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DndL.Gui.Controls
{
    /// <summary>
    /// Interaction logic for SnappingGrid.xaml
    /// </summary>
    public partial class SnappingGrid : UserControl
    {
        SnappingGridUtil sg;
        private (int x, int y) lastPoint = default;
        private Cursor cursorHand = Cursors.Hand;

        public SnappingGrid()
        {
            InitializeComponent();

            sg = new SnappingGridUtil(this, gridsnapper);

            gridsnapper.MouseDown += this.Gridsnapper_MouseDown;
            gridsnapper.MouseUp += this.Gridsnapper_MouseUp;
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Debug.WriteLine($"{e.HorizontalChange} : {e.VerticalChange}");

            int xChange = (int)(e.HorizontalChange / 25);
            int yChange = (int)(e.VerticalChange / 25);

            sg.Resize(xChange, yChange);

            if (e.HorizontalChange < 0)
            {
            }
        }


        private void Gridsnapper_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var point = sg.GetCell(e.GetPosition(gridsnapper));
            var topControlInCell = sg.GetControlsAtPoint(lastPoint).FirstOrDefault();

            bool isDrag = topControlInCell != default && lastPoint != point;

            if (isDrag)
            {
                // remove control, place it in new cell
                gridsnapper.Children.Remove(topControlInCell);
                sg.ClearCell(point);
                sg.AddToCell(topControlInCell, point);
            }
            else
            {
                // spawn a control
                var lbl = new GridCellControl();
                sg.ClearCell(point);
                sg.AddToCell(lbl, point);
            }
            Cursor = Cursors.Arrow;
        }

        private void Gridsnapper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var p = lastPoint = sg.GetCell(e.GetPosition(gridsnapper));
            Cursor = cursorHand;
        }
    }
}
