using DndL.Game._5e;
using DndL.Game.Dice;
using DndL.Gui.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DndL.Gui.ViewModels
{
    class DiceViewModel
        : BaseViewModel
    {
        private string currValue;

        public DiceViewModel()
        {
            // both declarations are acceptible.
            DiceOptions = new List<Type> { typeof(BaseDie<FiveDieEnum>), typeof(FooDie) };

            DiceSwitchedCommand = new Command((x) =>
            {
                CurrentValue = null;
                SelectedDie = (IDie)Activator.CreateInstance((Type)x);
            });
            RollCommand = new Command((x) =>
            {
                CurrentValue = SelectedDie.Roll().ToString();
            });
        }

        public string CurrentValue
        {
            get => currValue;
            set => SetProperty(ref currValue, value);
        }
        public IDie SelectedDie { get; set; }
        public ICollection<Type> DiceOptions { get; init; }
        public ICommand DiceSwitchedCommand { get; }
        public ICommand RollCommand { get; }



    }
}
