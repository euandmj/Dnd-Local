using DndL.Gui.ViewModels;
using System.Windows;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel = new MainWindowViewModel();






            partyBar.PlayerSelectedEvent += (_, e) =>
            {



            };
        }
    }
}
