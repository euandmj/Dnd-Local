using DndL.Core.Events;
using DndL.Game.Base;
using DndL.Gui.Core.Commands;
using DndL.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PartyBarControl.xaml
    /// </summary>
    public partial class PartyBarView : UserControl
    {
        public event EventHandler<GenericEventArgs<IBaseCharacter>> PlayerSelectedEvent;

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
        public event EventHandler<GenericEventArgs<IBaseCharacter>> PlayerSelectedEvent;

        public PartyBarViewModel()
        {
            Characters = DndL.Game.Base.GameContainer.GetGame().Party.Values;


            MouseLeftButtonDownCommand = new Command(x =>
            {
                PlayerSelectedEvent?.Invoke(this, new GenericEventArgs<IBaseCharacter>((IBaseCharacter)x));
            });
        }

        public ICollection<IBaseCharacter> Characters { get; init; }
        public ICommand MouseLeftButtonDownCommand { get; }
    }
}
