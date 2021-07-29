using System;
using System.Collections.Generic;
using QuestTales.Core.Abilities;
using UnityEngine;

namespace QuestTales.Core.Abilities.OrcGrunt
{
    public class Bash : Ability, IDamager
    {
        public override AbilityStatsData abilityStats => Resources.Load<AbilityStatsData>("Data/Ability/Orc/BashStatsData");
        public override string poolName => throw new NotImplementedException();
        public override IdType idType => IdType.Bash;
        public override RangeType rangeType => RangeType.Melee;
        public override AnimationType animationType => AnimationType.Swing;
        public override void ProcessAbility(GameObject target)
        {
            if (target != null)
            {
                DealDamage(target.transform.parent.GetComponent<UnitPhysiology>());
            }
        }
        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }
        public void DealDamage(IDamagable damagable)
        {
            damagable.TakeDamage(abilityStats.power);
        }
    }
}
