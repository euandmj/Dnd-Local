using System;
using System.Collections;
using System.Collections.Generic;

namespace DndL.Game.Dice
{
    public class BaseDie<TDieEnum>
        : IDie<TDieEnum>
        where TDieEnum : Enum
    {
        protected readonly ICollection<TDieEnum> Values = (ICollection<TDieEnum>)Enum.GetValues(typeof(TDieEnum));
        protected readonly int limit = Enum.GetValues(typeof(TDieEnum)).Length;
        protected readonly Random rand = new Random();

        public BaseDie(int seed) => rand = new Random(seed);
        public BaseDie() { }

        public TDieEnum Roll()
        {
            var randInt = rand.Next(0, limit);

            if (!Enum.TryParse(typeof(TDieEnum), randInt.ToString(), out var enu))
            {
                throw new InvalidProgramException("the random int should be convertable to TValue. Is Die value enum int?");
            }
            return (TDieEnum)enu;
        }

        public IEnumerator<TDieEnum> GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.Values).GetEnumerator();
        }
    }
}
