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

        SnappingGridUtil sg;


        public PaintCanvasView()
        {
            InitializeComponent();

            DataContext = viewModel = new PaintCanvasViewModel(); 
            
            sg = new SnappingGridUtil(this)
            {
                High = 4,
                Wide = 4
            };
            gridsnapper.MouseDown += this.Gridsnapper_MouseDown;
        }

        private void Gridsnapper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var p = sg.GetCell(e.GetPosition(gridsnapper));

            var lbl = new GridCellControl { X = p.x, Y = p.y };

            Grid.SetColumn(lbl, p.x);
            Grid.SetRow(lbl, p.y);

            var ll = gridsnapper.Children.FindAll<GridCellControl>(x =>
            {
                return x is GridCellControl l
                && l.X == lbl.X && l.Y == lbl.Y;
            }).ToList();

            foreach (var old in ll)
                gridsnapper.Children.Remove(old);

            gridsnapper.Children.Add(lbl);
        }
    }
}
