﻿using DndL.Gui.Controls;
using DndL.Gui.Model;
using DndL.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
                var x = selfStats.DataContext as PlayerStatsViewModel;
                x.Player = e.Value;
                //otherStats.Character = e.Value;
            };
        }
    }
}
