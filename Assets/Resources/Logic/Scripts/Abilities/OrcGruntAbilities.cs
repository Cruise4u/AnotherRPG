using System;
using System.Collections.Generic;
using QuestTales.Core.Abilities;
using UnityEngine;

namespace QuestTales.Core.Abilities.OrcGrunt
{
    public class Bash : Ability, IDamager
    { 
        public override IdType idType => IdType.Bash;

        public override RangeType rangeType => RangeType.Melee;

        public override ColliderType abilityColliderType => ColliderType.Fan;

        public override AnimationType animationType => AnimationType.Swing;

        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Orc/BashCollider");

        public override AbilityStatsData abilityStats => Resources.Load<AbilityStatsData>("Data/Ability/Orc/BashStatsData");

        public override string poolName => throw new NotImplementedException();

        public void DealDamage(IDamagable damagable)
        {
            damagable.TakeDamage(abilityStats.power);
        }

        public override GameObject InstantiateAbility(Vector3 position, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public override void ProcessAbility(GameObject target)
        {
            if(target != null)
            {
                DealDamage(target.transform.parent.GetComponent<UnitPhysiology>());
            }
        }

        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }
    }
}
