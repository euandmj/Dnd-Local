using DndL.Game.Dice;
using DndL.Game.EoE;
using DndL.Gui.Core.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using static DndL.Game.EoE.DiceDefinitions;

namespace DndL.Gui.ViewModels
{
    class DiceViewModel
        : BaseViewModel
    {
        private string currValue;
        private DieValueAttribute currAttr;
        private IDie selectedDie;

        public DiceViewModel()
        {
            DiceOptions = new List<Type> 
            { 
                typeof(BaseDie<Boost>),
                typeof(BaseDie<Ability>),
                typeof(BaseDie<Proficiency>),
                typeof(BaseDie<Setback>),
                typeof(BaseDie<Difficulty>),
                typeof(BaseDie<Challenge>),
                typeof(BaseDie<Force>)
            };

            DiceSwitchedCommand = new Command((x) =>
            {
                CurrentAttribute = null;
                selectedDie = (IDie)Activator.CreateInstance((Type)x);
            });
            RollCommand = new Command((x) =>
            {
                var roll = selectedDie.Roll();
                CurrentAttribute = roll.GetDieValue();
                CurrentValue = CurrentAttribute is null ? roll.ToString() : CurrentAttribute.FriendlyName;
            });
        }

        public string CurrentValue
        {
            get => currValue;
            set => SetProperty(ref currValue, value);
        }
        public DieValueAttribute CurrentAttribute
        {
            get => currAttr;
            set 
            { 
                SetProperty(ref currAttr, value); 
            }
        }
        public ICollection<Type> DiceOptions { get; init; }
        public ICommand DiceSwitchedCommand { get; }
        public ICommand RollCommand { get; }



    }
}
