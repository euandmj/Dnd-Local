using DndL.Core.Events;
using DndL.Game.Base;
using DndL.Gui.Core.Commands;
using DndL.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for LauncherWindow.xaml
    /// </summary>
    public partial class LauncherWindow : Window
    {
        private readonly LauncherWindowViewModel viewModel; 

        public LauncherWindow()
        {
            InitializeComponent();

            DataContext = viewModel = new();
            viewModel.PlayerChose += this.ViewModel_PlayerChose;
        }

        private void ViewModel_PlayerChose(object sender, EventArgs e)
        {
            var gameWin = new ClientWindow();
            this.Close();
            gameWin.Show();
        }
    }

    class LauncherWindowViewModel
        : BaseViewModel
    {
        public event EventHandler<EventArgs> PlayerChose;
        private ICollection<IBaseCharacter> members;

        public LauncherWindowViewModel()
            : base()
        {

            
            PartyMembers = game.Party.Values;

            PlayerProfileSelectedCommand = new Command(x =>
            {
                //game.Player = (IBaseCharacter)x;
                //game.
                game.SetPlayer(((IBaseCharacter)x).ID);
                PlayerChose?.Invoke(null, EventArgs.Empty);
            });
        }


        public ICollection<IBaseCharacter> PartyMembers
        {
            get => members;
            set => SetProperty(ref members, value);
        }
        public ICommand PlayerProfileSelectedCommand { get; }

    }
}
