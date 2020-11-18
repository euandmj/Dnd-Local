using System;
using System.Collections.Generic;
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

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for GridCellControl.xaml
    /// </summary>
    public partial class GridCellControl : UserControl
    {
        public GridCellControl()
        {
            InitializeComponent();
        }


        public int X { get; init; }
        public int Y { get; init; }
    }
}
