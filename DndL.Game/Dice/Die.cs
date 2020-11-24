using System;
using System.Collections;
using System.Collections.Generic;

namespace DndL.Game.Dice
{
    public class BaseDie<TValues>
        : IDie<TValues>, IEnumerable<TValues>
        where TValues : Enum
    {
        protected readonly ICollection<TValues> Values = (ICollection<TValues>)Enum.GetValues(typeof(TValues));
        protected readonly int limit = Enum.GetValues(typeof(TValues)).Length;
        protected readonly Random rand = new Random();

        public BaseDie(int seed) => rand = new Random(seed);
        public BaseDie() { }

        public TValues Roll()
        {
            var randInt = rand.Next(0, limit);

            if (!Enum.TryParse(typeof(TValues), randInt.ToString(), out var enu))
            {
                throw new InvalidProgramException("the random int should be convertable to TValue. Is Die value enum int?");
            }
            return (TValues)enu;
        }

        public IEnumerator<TValues> GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.Values).GetEnumerator();
        }
    }
}
