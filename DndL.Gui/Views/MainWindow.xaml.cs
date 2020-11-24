using DndL.Gui.ViewModels;
using DndL.Game.Dice;
using System;
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
                if (otherStats.DataContext.GetType() != typeof(EntityDescriptionViewModel))
                    throw new InvalidProgramException("expects view model");

                otherStats.DataContext = new EntityDescriptionViewModel(e.Value);

            };
        }
    }
}
