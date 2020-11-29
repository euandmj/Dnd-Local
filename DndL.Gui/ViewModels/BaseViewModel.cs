using DndL.Game.Base;
using System;

namespace DndL.Gui.ViewModels
{
    abstract class BaseViewModel
        : DndL.Core.NotifyPropertyChanged
    {
        private string title = string.Empty;
        protected readonly Guid UserID;
        protected readonly Client.CanvasClientServiceWrapper canvasClient = new();
        protected IGame game;

        public BaseViewModel()
        {
            game = Game.Base.GameContainer.GetGame();
            //UserID = (Guid)(game.Player?.ID);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}
