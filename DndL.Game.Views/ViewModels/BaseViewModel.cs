//using DndL.Client;
using DndL.Game._5e;
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

        // Todo: replace with like GetSelfCharacter
        protected PlayerCharacter selfPlayer =
            new PlayerCharacter { CharImage = Game.Properties.Resources.adventurer1, Name = "adventurer", ArmorClass = 5 };
        protected IDictionary<Guid, NPlayerCharacter> partyCharacters =
           new Dictionary<Guid, NPlayerCharacter>()
           {
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = Game.Properties.Resources.adventurer1, Name = "adventurer" } },
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = Game.Properties.Resources.arcane2, Name = "arcane2" } },
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = Game.Properties.Resources.arcane4, Name = "arcane4" } },
                { Guid.NewGuid(), new NPlayerCharacter { CharImage = Game.Properties.Resources.warrior2, Name = "warrior" } }
           };


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
