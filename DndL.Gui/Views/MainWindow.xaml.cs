using DndL.Gui.ViewModels;
using DndL.Game.Dice;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Collections.Generic;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // USE THIS METHOD AS A TEMPLATE FOR HOT SWAPPING UI
            var x = new TestView();

            x.Sync += (_, _) =>
            {

            };

            Grid.SetRow(x, 0);
            Grid.SetColumn(x, 0);

            grid.Children.Add(x);
        }
    }
}
