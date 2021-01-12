using System;
using System.Collections;
using System.Collections.Generic;

namespace DndL.Game.Dice
{
    public class BaseDie<TDieEnum>
        : IDie, IEnumerable<TDieEnum>
        where TDieEnum : Enum
    {
        protected readonly ICollection<TDieEnum> Values = (ICollection<TDieEnum>)Enum.GetValues(typeof(TDieEnum));
        protected readonly int limit = Enum.GetValues(typeof(TDieEnum)).Length;
        protected readonly Random rand = new Random();

        public virtual Enum Roll()
        {
            var randInt = rand.Next(0, limit).ToString();

            if (!Enum.TryParse(typeof(TDieEnum), randInt, out var enu))
            {
                throw new InvalidProgramException("the random int should be convertable to T. Is T enum int?");
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
