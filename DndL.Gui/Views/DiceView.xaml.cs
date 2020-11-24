using DndL.Gui.ViewModels;
using System.Windows.Controls;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for DiceView.xaml
    /// </summary>
    public partial class DiceView : UserControl
    {
        public DiceView()
        {
            InitializeComponent();

            DataContext = new DiceViewModel();
        }
    }


}
