using DndL.Game._5e;
using DndL.Game.Base;
using System;
using System.Collections.Generic;

namespace DndL.Game.Views.ViewModels
{
    abstract class BaseViewModel
        : Core.NotifyPropertyChanged
    {

        private string title = string.Empty;
        // move client stuff into a wrapper in DndL.Game.
        //protected readonly ClientContainer client = new();

        protected PlayerCharacter selfPlayer =
            DndL.Game.Base.GameContainer.GetGame().Player as PlayerCharacter;

        protected IDictionary<Guid, IBaseCharacter> partyCharacters =
            DndL.Game.Base.GameContainer.GetGame().Party;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public PlayerCharacter Player
        {
            get => selfPlayer;
            set => SetProperty(ref selfPlayer, value);
        }




    }
}
