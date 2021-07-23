using System;
using System.Collections.Generic;
using QuestTales.Core.Abilities;
using UnityEngine;

namespace QuestTales.Core.Abilities.OrcGrunt
{
    public class Bash : Ability, IDamager
    {
        public override ControllerType controllerType => ControllerType.AI;

        public override IdType abilityIdType => IdType.Bash;

        public override RangeType abilityRange => RangeType.Melee;

        public override ColliderType abilityColliderType => ColliderType.Fan;

        public override AnimationType animationType => AnimationType.Swing;

        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Orc/BashCollider");

        public override AbilityStatsData abilityData => Resources.Load<AbilityStatsData>("Data/Ability/Orc/BashStatsData");

        public void DealDamage(IDamagable damagable)
        {
            damagable.TakeDamage(abilityData.power);
        }

        public override void ProcessAbility(List<GameObject> targets)
        {
            foreach(GameObject target in targets)
            {
                DealDamage(target.GetComponent<CombatController>());
            }
        }
    }
}
