using System.ComponentModel;
using System.Windows.Controls;

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

        public string Text => $"{X}:{Y}";

        public int X => Grid.GetColumn(this);
        public int Y => Grid.GetRow(this);

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dragged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
        }

        
    }
}
