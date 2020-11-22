using DndL.Game.Base;

namespace DndL.Game._5e
{
    public class AttackSpell
        : IStat<float>
    {
        public string Name { get; init; }
        public float Value { get; set; }
        public string DamageType { get; set; }
    }
}
