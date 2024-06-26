﻿
using DndL.Game._5e;
using DndL.Game.Views.ViewModels;
using DndL.Gui.Core;
using System;
using System.Collections.Generic;
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

namespace DndL.Game.Views.Views
{
    /// <summary>
    /// Interaction logic for PlayerStatControl.xaml
    /// </summary>
    public partial class PlayerStatsView 
        : UserControl, IRuntimeControl
    {
        public int Column { get; } = 1;
        public int Row { get; }
        public int? ColumnSpan { get; }
        public int? RowSpan { get; }

        public PlayerStatsView()
        {
            InitializeComponent();

            DataContext = new PlayerStatsViewModel();
        }
    }    
}
