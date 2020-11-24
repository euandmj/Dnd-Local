using System;
using System.Collections.Generic;

namespace DndL.Game.Dice
{
    public interface IDie<TDieEnum>
        : IEnumerable<TDieEnum>
        where TDieEnum : Enum
    {
        TDieEnum Roll();
    }
}
