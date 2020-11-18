using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DndL.Gui.Model
{
    public class CanvasBrush
    {
        public double Thickness { get; set; } = 1;
        public SolidColorBrush Color { get; set; } = Brushes.Black;
    }
}
