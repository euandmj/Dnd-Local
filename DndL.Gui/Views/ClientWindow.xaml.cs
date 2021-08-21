using DndL.Game.Views._5e.ViewModels;
using DndL.Gui.ViewModels;
using System.Windows;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private readonly ClientWindowViewModel viewModel;

        //private UserControl playerStatsFull, selfStats, selfSkills, entityDesc; 

        public ClientWindow()
        {
            InitializeComponent();

            DataContext = viewModel = new ClientWindowViewModel();


            partyBar.PlayerSelectedEvent += (_, e) =>
            {
                otherStats.DataContext = new EntityDescriptionViewModel(e.Value);
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // USE THIS METHOD AS A TEMPLATE FOR HOT SWAPPING UI
            if (true)
            {
                //playerStatsFull = new PlayerStatsView();
                //Grid.SetRow(playerStatsFull, 1);
                //Grid.SetColumn(playerStatsFull, 0);
                //Grid.SetRowSpan(playerStatsFull, 3);

                //entityDesc = new EntityDescriptionView();
                //Grid.SetRow(entityDesc, 1);
                //Grid.SetColumn(entityDesc, 2);

                //selfStats = new SelfStatsView();
                //Grid.SetColumn(selfStats, 0);

                //selfSkills = new PlayerSpellsView();
                //Grid.SetColumn(selfSkills, 1);
                
                //grid.Children.Add(playerStatsFull);
                //grid.Children.Add(entityDesc);
                //selfGrid.Children.Add(selfStats);
                //selfGrid.Children.Add(selfSkills);
            }
        }

        private void partyBar_DragLeave(object sender, DragEventArgs e)
        {

        }
    }
}
