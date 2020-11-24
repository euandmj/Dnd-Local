using DndL.Core;
using DndL.Game.Base;

namespace DndL.Game._5e
{
    public class Stat
        : NotifyPropertyChanged, IStat<int>
    {
        private int _value;
        private bool _proficient;

        public string Name { get; init; }
        public int Value { get => _value; set => SetProperty(ref _value, value); }
        public bool Proficient { get => _proficient; set => SetProperty(ref _proficient, value); }
    }
}
