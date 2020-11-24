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

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PlayerSpellsView.xaml
    /// </summary>
    public partial class PlayerSpellsView : UserControl
    {
        public PlayerSpellsView()
        {
            InitializeComponent();

            DataContext = new PlayerSpellsViewModel();
        }
    }

    class PlayerSpellsViewModel
        : ViewModels.BaseViewModel
    {


        public PlayerSpellsViewModel()
        {
            Player.AttacksSpells = new()
            {
                new Game._5e.AttackSpell { DamageType = "dmgtype", Name = "spell1", Value = 5f }
            };
        }
    }
}
