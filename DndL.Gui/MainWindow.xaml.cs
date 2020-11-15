﻿using DndL.Gui.ViewModels;
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

namespace DndL.Gui
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

            // bridge the gap between the canvas control drawing lines 
            // and the main view model knowing about it. 
            Canvas.LineDrawn += viewModel.OnLineDrawn;
            //viewModel
            viewModel.PointReceived += Canvas.OnAddPoint;
        }
    }
}
