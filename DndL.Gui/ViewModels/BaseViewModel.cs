using DndL.Game.Base;

namespace DndL.Gui.ViewModels
{
    abstract class BaseViewModel
        : DndL.Core.NotifyPropertyChanged
    {
        private string title = string.Empty;
        protected readonly Client.CanvasClientServiceWrapper canvasClient = new();
        protected IGame game;

        public BaseViewModel()
        {
            game = Game.Base.GameContainer.GetGame();
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}
