using DndL.Client;

namespace DndL.Gui.ViewModels
{
    abstract class BaseViewModel
        : DndL.Core.NotifyPropertyChanged
    {
        private string title = string.Empty;
        protected readonly ClientContainer client = new();

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}
