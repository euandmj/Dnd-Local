using DndL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndL.Gui.ViewModels
{
    class CanvasSettingsViewModel     
        : NotifyPropertyChanged
    {
        private bool _isFogEnabled;
        private int _rows;
        private int _columns;






        public bool IsFogEnabled
        {
            get => _isFogEnabled;
            set => SetProperty(ref _isFogEnabled, value);
        }

        public int RowCount
        {
            get => _rows;
            set => SetProperty(ref _rows, value);
        }

        public int ColumnCount
        {
            get => _columns;
            set => SetProperty(ref _columns, value);
        }
    }
}
