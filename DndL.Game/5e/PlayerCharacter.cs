using DndL.Game.Base;
using System.Drawing;

namespace DndL.Game._5e
{
    public class PlayerCharacter
        : IBaseCharacter<float>
    {
        public string Name { get; set; }
        public Stat<float>[] KeyStats
        {
            get => new Stat<float>[]
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
        public Bitmap CharImage { get; init; }


        public Stat<float> Strength = new() { Name = nameof(Strength), Value = 10 };
        public Stat<float> Dexterity = new() { Name = nameof(Dexterity), Value = 5 };
        public Stat<float> Constitution = new() { Name = nameof(Constitution), Value = 10 };
        public Stat<float> Intelligence = new() { Name = nameof(Intelligence), Value = 10 };
        public Stat<float> Wisdom = new() { Name = nameof(Wisdom), Value = 3 };
        public Stat<float> Charisma = new() { Name = nameof(Charisma), Value = 0 };

    }

    
}
