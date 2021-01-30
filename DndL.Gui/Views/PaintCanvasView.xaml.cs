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

        private void SettingsButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: roll into global config
            var win = new CanvasSettingsWindow();
            win.Import(new()
            {
                IsFogEnabled = false,
                Rows = SnappingGrid.RowCount,
                Columns = SnappingGrid.ColumnCount
            });
            var result = win.ShowDialog();
            if(result.HasValue &&
                result.Value == true)
            {
                var newCfg = win.Export();
                SnappingGrid.Resize(newCfg.Columns, newCfg.Rows);
            }
        }
    }
}
