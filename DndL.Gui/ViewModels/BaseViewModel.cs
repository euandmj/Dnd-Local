using DndL.Client;
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(property)));
        }
    }
}
