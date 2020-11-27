using DndL.Game._5e;
using DndL.Game.Views.ViewModels;
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
    /// Interaction logic for EntityDescriptionView.xaml
    /// </summary>
    public partial class EntityDescriptionView : UserControl
    {
        public EntityDescriptionView()
        {
            InitializeComponent();

            DataContext = new EntityDescriptionViewModel(
                new NPlayerCharacter()
                {
                    Name = "bob jovine",
                    CharImage = Game.Properties.Resources.psionic3,
                    DescriptionShort = "Tonight I'll probably be playing games to tide over time but I have some training for work I need to do so staying late"
                });
        }

    }

    class EntityDescriptionViewModel
        : BaseViewModel
    {
        private NPlayerCharacter _character;


        public EntityDescriptionViewModel(NPlayerCharacter npc)
        {

            Character = npc;
        }



        public NPlayerCharacter Character
        {
            get => _character;
            set => SetProperty(ref _character, value);
        }
    }
}
