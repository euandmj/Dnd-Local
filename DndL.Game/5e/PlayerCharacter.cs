using DndL.Core;
using DndL.Game.Base;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace DndL.Game._5e
{
    public class PlayerCharacter
        : NotifyPropertyChanged, IBaseCharacter
    {
        public Guid ID { get; init; } = new Guid();
        public string Name { get; set; }
        public Bitmap CharImage { get; init; }

        public ObservableCollection<Stat> MajorStats
        {
            get => new ObservableCollection<Stat>()
            {
                new Stat { Name = "Strength" },
                new Stat { Name = "Dexterity" },
                new Stat { Name = "Constitution" },
                new Stat { Name = "Intelligence" },
                new Stat { Name = "Wisdom" },
                new Stat { Name = "Charisma" },
            };
        }
        public ObservableCollection<Stat> MinorStats
        {
            get => new ObservableCollection<Stat>()
            {
                new Stat() { Name = "Acrobatics" },
                new Stat() { Name = "AnimalHandling" },
                new Stat() { Name = "Arcana" },
                new Stat() { Name = "Athletics" },
                new Stat() { Name = "Deception" },
                new Stat() { Name = "Acrobatics" },
                new Stat() { Name = "History" },
                new Stat() { Name = "Insight" },
                new Stat() { Name = "Intimidation" },
                new Stat() { Name = "Investigation" },
                new Stat() { Name = "Medicine" },
                new Stat() { Name = "Nature" },
                new Stat() { Name = "Perception" },
                new Stat() { Name = "Performance" },
                new Stat() { Name = "Persuasion" },
                new Stat() { Name = "Religion" },
                new Stat() { Name = "SleightOfHand" },
                new Stat() { Name = "Stealth" },
                new Stat() { Name = "Survival" },
            };
        }

        public ObservableCollection<AttackSpell> AttacksSpells { get; set; }

        private int _armorClass;
        public int ArmorClass { get => _armorClass; set => SetProperty(ref _armorClass, value); }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int MaxHP { get; set; }
        public float CurrentHP { get; set; }
        public float TemporaryHP { get; set; }
        public int TotalHitDice { get; set; }
        public int CurrentHitDice { get; set; }
    }
}
