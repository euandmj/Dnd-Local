using DndL.Game.Base;

namespace DndL.Game._5e
{
    public class Stat
        : IStat<int>
    {
        public string Name { get; init; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
    }
}
