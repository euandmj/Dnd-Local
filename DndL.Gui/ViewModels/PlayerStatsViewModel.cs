﻿using DndL.Game._5e;
using System.Linq;

namespace DndL.Gui.ViewModels
{
    class PlayerStatsViewModel
        : BaseViewModel
    {
        private PlayerCharacter character;


        public PlayerStatsViewModel()
        {
            // Todo: replace with like GetSelfCharacter
            Player = base.partyCharacters.First().Value;
        }

        public PlayerCharacter Player
        {
            get => character;
            set => SetProperty(ref character, value);
        }
    }
}
