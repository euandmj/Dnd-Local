using DndL.Client;
using DndL.Game._5e;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DndL.Gui.ViewModels
{
    abstract class BaseViewModel
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title = string.Empty;
        private PlayerCharacter character;
        protected readonly ClientContainer client = new();

        protected IDictionary<Guid, PlayerCharacter> partyCharacters =
           new Dictionary<Guid, PlayerCharacter>()
           {
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.adventurer1, Name = "adventurer", AttacksSpells = new() { new AttackSpell { DamageType = "dmgtype", Name = "spell1", Value = 5f } } } },
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.arcane2, Name = "arcane2" } },
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.arcane4, Name = "arcane4" } },
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.warrior2, Name = "warrior" } }
           };

        public BaseViewModel()
        {
            // Todo: replace with like GetSelfCharacter
            Player = partyCharacters.First().Value;
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public PlayerCharacter Player
        {
            get => character;
            set => SetProperty(ref character, value);
        }

        protected void SetProperty<T>(
            ref T backingStore, 
            T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            onChanged?.Invoke();
            backingStore = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
