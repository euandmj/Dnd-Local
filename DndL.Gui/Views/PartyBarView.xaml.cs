using DndL.Core.Events;
using DndL.Game._5e;
using DndL.Game.Base;
using DndL.Gui.Commands;
using DndL.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PartyBarControl.xaml
    /// </summary>
    public partial class PartyBarView : UserControl
    {
        public event EventHandler<GenericEventArgs<NPlayerCharacter>> PlayerSelectedEvent;

        private readonly PartyBarViewModel viewModel;

        public PartyBarView()
        {
            InitializeComponent();

            DataContext = viewModel = new PartyBarViewModel();

            viewModel.PlayerSelectedEvent += (s, e) =>
            {
                PlayerSelectedEvent?.Invoke(s, e);
            };
        }
    }

    class PartyBarViewModel
        : BaseViewModel
    {
        public event EventHandler<GenericEventArgs<NPlayerCharacter>> PlayerSelectedEvent;

        public PartyBarViewModel()
        {
            Characters = base.partyCharacters.Values;


            MouseLeftButtonDownCommand = new Command(x =>
            {
                PlayerSelectedEvent?.Invoke(this, new GenericEventArgs<NPlayerCharacter>((NPlayerCharacter)x));
            });
        }

        public ICollection<NPlayerCharacter> Characters { get; init; }
        public ICommand MouseLeftButtonDownCommand { get; }
    }
}
