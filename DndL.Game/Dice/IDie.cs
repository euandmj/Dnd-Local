using System;
using System.Collections.Generic;

namespace DndL.Game.Dice
{
    public interface IDie<TValues>
        : IEnumerable<TValues>
        where TValues : Enum
    {
        TValues Roll();
    }
}
