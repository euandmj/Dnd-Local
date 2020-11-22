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

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for SnappingGrid.xaml
    /// </summary>
    public partial class SnappingGrid : UserControl
    {
        private readonly SnappingGridViewModel viewModel;

        public SnappingGrid()
        {
            InitializeComponent();
            //grid.DataContext = viewModel = new();
            DataContext = viewModel = new();


            viewModel.Items.Add(new GridCellControl { X = 1, Y = 1 });
            viewModel.Items.Add(new GridCellControl { X = 2, Y = 2 });
            viewModel.Items.Add(new GridCellControl { X = 3, Y = 1 });

            grid.DataContext = viewModel.Items;
        }
    }

    public class SnappingGridViewModel
    {
        public ObservableCollection<GridCellControl> Items { get; set; } = new();

        public int Columns { get; } = 5;
        public int Rows { get; } = 5;
    }
}
