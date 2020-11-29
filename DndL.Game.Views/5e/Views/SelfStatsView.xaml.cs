using DndL.Gui.Core.Commands;
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
    /// Interaction logic for SelfStatsView.xaml
    /// </summary>
    public partial class SelfStatsView : UserControl
    {
        public SelfStatsView()
        {
            InitializeComponent();

            DataContext = new SelfStatsViewModel();
        }
    }

    class SelfStatsViewModel 
        : ViewModels.GameViewModel
    {


        public SelfStatsViewModel()
        {



            TextChangedCommand = new Command((x) =>
            {

            });
        }

       

        public ICommand TextChangedCommand { get; }


        public void MouseMove(object sender, TextChangedEventArgs e)
        {

        }

    }
}
