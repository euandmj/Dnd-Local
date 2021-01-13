using DndL.Gui.Controls;
using DndL.Gui.Utility;
using DndL.Gui.ViewModels;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

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
