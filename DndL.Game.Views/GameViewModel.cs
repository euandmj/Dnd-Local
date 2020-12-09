using DndL.Game._5e;
using DndL.Game.Base;

namespace DndL.Game.Views.ViewModels
{
    public abstract class GameViewModel
        : Core.NotifyPropertyChanged
    {

        private string title = string.Empty;
        protected readonly IGame _game;
        protected PlayerCharacter selfPlayer;

        public GameViewModel()
        {
            _game = Game.Base.GameContainer.GetGame();

            selfPlayer = _game.Player as PlayerCharacter;
        }

       

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
