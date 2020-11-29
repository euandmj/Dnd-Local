using DndL.Core;
using DndL.Core.Extensions;
using DndL.Game.Base;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text.Json.Serialization;

namespace DndL.Game._5e
{
    public class PlayerCharacter
        : NotifyPropertyChanged, IBaseCharacter
    {
        [JsonInclude]
        public Guid ID { get; init; } = Guid.NewGuid();

        [JsonInclude] 
        public string Name { get; set; }

        [JsonInclude]
        [JsonConverter(typeof(Core.Serialization.BitmapJsonConverter))]
        public Bitmap CharImage { get; set; }


        [JsonInclude]
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

        [JsonInclude]
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

        [JsonInclude]
        public ObservableCollection<AttackSpell> AttacksSpells { get; set; }
        
        [JsonIgnore] private int _armorClass;

        [JsonInclude] public int ArmorClass { get => _armorClass; set => SetProperty(ref _armorClass, value); }
        
        [JsonInclude] public int Initiative { get; set; }
        
        [JsonInclude] public int Speed { get; set; }
                      
        [JsonInclude] public int MaxHP { get; set; }
                      
        [JsonInclude] public float CurrentHP { get; set; }
                      
        [JsonInclude] public float TemporaryHP { get; set; }
                      
        [JsonInclude] public int TotalHitDice { get; set; }
                      
        [JsonInclude] public int CurrentHitDice { get; set; }
    }
}
