using DndL.Game.Views.Views;
using DndL.Gui.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
                //if (otherStats.DataContext.GetType() != typeof(EntityDescriptionViewModel))
                //    throw new InvalidProgramException("expects view model");

                //otherStats.DataContext = new EntityDescriptionViewModel(e.Value);

            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // USE THIS METHOD AS A TEMPLATE FOR HOT SWAPPING UI
            if (true)
            {
                var playerStats = new PlayerStatsView();
                Grid.SetRow(playerStats, 1);
                Grid.SetColumn(playerStats, 0);
                Grid.SetRowSpan(playerStats, 3);

                var entityDesc = new EntityDescriptionView();
                Grid.SetRow(entityDesc, 1);
                Grid.SetColumn(entityDesc, 2);

                var selfStats = new SelfStatsView();
                Grid.SetColumn(selfStats, 0);

                var selfSkills = new PlayerSpellsView();
                Grid.SetColumn(selfSkills, 1);
                
                grid.Children.Add(playerStats);
                grid.Children.Add(entityDesc);
                selfGrid.Children.Add(selfStats);
                selfGrid.Children.Add(selfSkills);

            }

        }
    }
}
