using DndL.Gui.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for GridCellControl.xaml
    /// </summary>
    public partial class GridCellControl : UserControl, INotifyPropertyChanged
    {
        public GridCellControl()
        {
            InitializeComponent();

            DataContext = this;
        }

        public string Textt => $"{X}:{Y}";

        public int X => Grid.GetColumn(this);
        public int Y => Grid.GetRow(this);

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dragged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Textt)));
        }
    }
}
