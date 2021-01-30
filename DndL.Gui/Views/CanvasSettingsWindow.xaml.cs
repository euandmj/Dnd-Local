using DndL.Core.Configs;
using DndL.Gui.ViewModels;
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
using System.Windows.Shapes;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for CanvasSettingsWindow.xaml
    /// </summary>
    public partial class CanvasSettingsWindow : Window, IExportable<CanvasSettingsConfig>
    {
        private readonly CanvasSettingsViewModel _viewModel;

        public CanvasSettingsWindow()
        {
            InitializeComponent();

            DataContext = _viewModel = new CanvasSettingsViewModel();
        }

        public CanvasSettingsConfig Export()
        {
            return new CanvasSettingsConfig()
            {
                IsFogEnabled = _viewModel.IsFogEnabled,
                Rows = _viewModel.RowCount,
                Columns = _viewModel.ColumnCount
            };
        }

        public void Import(CanvasSettingsConfig item)
        {
            _viewModel.IsFogEnabled = item.IsFogEnabled;
            _viewModel.RowCount = item.Rows;
            _viewModel.ColumnCount = item.Columns;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
