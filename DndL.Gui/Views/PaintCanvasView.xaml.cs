using DndL.Core.Events;
using DndL.Gui.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PaintCanvasView.xaml
    /// </summary>
    public partial class PaintCanvasView : UserControl
    {
        private readonly PaintCanvasViewModel viewModel;


        public PaintCanvasView()
        {
            InitializeComponent();

            DataContext = viewModel = new PaintCanvasViewModel();
        }
    }
}
