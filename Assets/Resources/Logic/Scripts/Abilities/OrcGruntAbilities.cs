using System;
using QuestTales.Core.Abilities;

namespace QuestTales.Core.Abilities.OrcGrunt
{
    public class Bash : Ability
    {
        public override IdType abilityName => IdType.Bash;

        public override RangeType abilityRange => RangeType.Melee;

        public override ColliderType abilityColliderType => ColliderType.Fan;

        public override AnimationType animationType => AnimationType.Swing;

        public override ColliderData colliderData => throw new NotImplementedException();

        public override void ProcessAbility()
        {
            throw new NotImplementedException();
        }
    }
}
