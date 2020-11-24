using DndL.Game.Dice;
using System;
using System.ComponentModel;

namespace DndL.Game._5e
{
    public enum FiveDieEnum
    { 
        One,
        Two,
        Three,
        Four,
        Five
    }

    public enum FooDieEnum
    {
        Stone,
        Water,
        Fire,
        Air
    }


    //public class FiveDie
    //    : BaseDie<FiveDieEnum>
    //{

    //}

    public class FooDie
        : BaseDie<FooDieEnum>
    {

    }
}
