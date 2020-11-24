using DndL.Game.Base;
using System.ComponentModel;

namespace DndL.Game._5e
{
    public class AttackSpell
        : IStat<float>
    {
        public string Name { get; init; }

        [DisplayName(displayName:"ATK Bonus")]
        public float Value { get; set; }


        [DisplayName(displayName: "Damage/Type")]
        public string DamageType { get; set; }
    }
}
