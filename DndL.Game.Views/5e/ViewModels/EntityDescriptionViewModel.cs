using DndL.Game.Base;
using DndL.Game.Views.ViewModels;

namespace DndL.Game.Views._5e.ViewModels
{
    public class EntityDescriptionViewModel
        : GameViewModel
    {
        private IBaseCharacter _character;

        public EntityDescriptionViewModel(IBaseCharacter npc)
        {
            Character = npc ?? throw new System.ArgumentNullException(nameof(npc));
        }

        public IBaseCharacter Character
        {
            get => _character;
            set => SetProperty(ref _character, value);
        }
    }
}
