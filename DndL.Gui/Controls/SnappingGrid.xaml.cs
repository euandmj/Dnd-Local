using DndL.Gui.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        SnappingGridUtil<GridCellControl> sg;
        private (int x, int y) lastPoint = default;
        private Cursor cursorHand = Cursors.Hand;

        public SnappingGrid()
        {
            InitializeComponent();

            sg = new SnappingGridUtil<GridCellControl>(this)
            {
                High = gridsnapper.RowDefinitions.Count,
                Wide = gridsnapper.ColumnDefinitions.Count
            };

            gridsnapper.MouseDown += this.Gridsnapper_MouseDown;
            gridsnapper.MouseUp += this.Gridsnapper_MouseUp;
        }


        private void Gridsnapper_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var p = sg.GetCell(e.GetPosition(gridsnapper));
            var ctrl = sg.GetControlsAtPoint(gridsnapper, lastPoint).FirstOrDefault();

            bool isDrag = ctrl != default && lastPoint != p;

            if (isDrag)
            {
                // remove control, place it in new cell
                gridsnapper.Children.Remove(ctrl);
                sg.AddToCell(gridsnapper, ctrl, p);
            }
            else
            {
                // spawn a control
                var lbl = new GridCellControl();
                sg.AddToCell(gridsnapper, lbl, p);
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
