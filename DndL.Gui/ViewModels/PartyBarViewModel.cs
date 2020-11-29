using DndL.Core.Events;
using DndL.Game.Base;
using DndL.Gui.Core.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DndL.Gui.ViewModels
{
    class PartyBarViewModel
        : BaseViewModel
    {
        public event EventHandler<GenericEventArgs<IBaseCharacter>> PlayerSelectedEvent;

        public PartyBarViewModel()
        {

            Characters = game.Party.Values;

            MouseLeftButtonDownCommand = new Command(x =>
            {
                PlayerSelectedEvent?.Invoke(this, new GenericEventArgs<IBaseCharacter>((IBaseCharacter)x));
            });
        }

        private ICollection<IBaseCharacter> mems;
        public ICollection<IBaseCharacter> Characters
        {
            get => mems;
            set => SetProperty(ref mems, value);
        }
        public ICommand MouseLeftButtonDownCommand { get; }


    }
}
