using System;

namespace DndL.Game.Dice
{
    [AttributeUsage(validOn: AttributeTargets.Enum, AllowMultiple = false, Inherited = true)]
    public class DieAttribute
        : Attribute
    {
        public string Name { get; init; }
    }

    [AttributeUsage(validOn: AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class DieValueAttribute
        : Attribute
    {
        public string FriendlyName { get; init; }
        public string ImageResourceName { get; init; }
        public string BackColor { get; init; }
    }
}
