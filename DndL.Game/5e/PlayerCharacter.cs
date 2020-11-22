using DndL.Game.Base;
using System.Collections.ObjectModel;
using System.Drawing;

namespace DndL.Game._5e
{
    public class PlayerCharacter
        : IBaseCharacter
    {
        public string Name { get; set; }
        public Bitmap CharImage { get; init; }
        public IStat<int>[] KeyStats
        {
            get => new Stat[]
            {
                Strength,
                Dexterity,
                Dexterity,
                Constitution,
                Intelligence,
                Wisdom,
                Charisma
            };
        }
        public IStat<int>[] MinorStats
        {
            get => new Stat[]
            {
                Acrobatics,
                AnimalHandling,
                Arcana ,
                Athletics,
                Deception,
                History ,
                Insight ,
                Intimidation,
                Investigation,
                Medicine,
                Nature ,
                Perception,
                Performance,
                Persuasion,
                Religion,
                SleightOfHand,
                Stealth ,
                Survival
            };
        }

        public ObservableCollection<AttackSpell> AttacksSpells { get; set; }

        public int ArmorClass;
        public int Initiative;
        public int Speed;
        public int MaxHP;
        public float CurrentHP;
        public float TemporaryHP;

        public Stat Strength = new() { Name = nameof(Strength) };
        public Stat Dexterity = new() { Name = nameof(Dexterity) };
        public Stat Constitution = new() { Name = nameof(Constitution) };
        public Stat Intelligence = new() { Name = nameof(Intelligence) };
        public Stat Wisdom = new() { Name = nameof(Wisdom) };
        public Stat Charisma = new() { Name = nameof(Charisma) };

        public Stat Acrobatics = new() { Name = nameof(Acrobatics) };
        public Stat AnimalHandling = new() { Name = nameof(AnimalHandling) };
        public Stat Arcana = new() { Name = nameof(Arcana) };
        public Stat Athletics = new() { Name = nameof(Athletics) };
        public Stat Deception = new() { Name = nameof(Deception) };
        public Stat History = new() { Name = nameof(History) };
        public Stat Insight = new() { Name = nameof(Insight) };
        public Stat Intimidation = new() { Name = nameof(Intimidation) };
        public Stat Investigation = new() { Name = nameof(Investigation) };
        public Stat Medicine = new() { Name = nameof(Medicine) };
        public Stat Nature = new() { Name = nameof(Nature) };
        public Stat Perception = new() { Name = nameof(Perception) };
        public Stat Performance = new() { Name = nameof(Performance) };
        public Stat Persuasion = new() { Name = nameof(Persuasion) };
        public Stat Religion = new() { Name = nameof(Religion) };
        public Stat SleightOfHand = new() { Name = nameof(SleightOfHand) };
        public Stat Stealth = new() { Name = nameof(Stealth) };
        public Stat Survival = new() { Name = nameof(Survival) };


    }
}
