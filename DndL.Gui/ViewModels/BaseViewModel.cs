using DndL.Client;
using DndL.Game._5e;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DndL.Gui.ViewModels
{
    abstract class BaseViewModel
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title = string.Empty;

        protected IDictionary<Guid, PlayerCharacter> partyCharacters =
            new Dictionary<Guid, PlayerCharacter>()
            {
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.adventurer1, Name = "adventurer" } },
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.arcane2, Name = "arcane2" } },
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.arcane4, Name = "arcane4" } },
                { Guid.NewGuid(), new PlayerCharacter { CharImage = Game.Properties.Resources.warrior2, Name = "warrior" } }
            };
        protected readonly ClientContainer client = new();


        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
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
