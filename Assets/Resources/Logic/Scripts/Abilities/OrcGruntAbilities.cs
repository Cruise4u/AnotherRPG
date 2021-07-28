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

        public override AbilityStatsData abilityData => Resources.Load<AbilityStatsData>("Data/Ability/Orc/BashStatsData");

        public override string abilityParticlePoolName => throw new NotImplementedException();

        public override void CalculateAbilityColliders(GameObject instance, string tag)
        {
            throw new NotImplementedException();
        }

        public void DealDamage(IDamagable damagable)
        {
            damagable.TakeDamage(abilityData.power);
        }

        public override GameObject InstantiateAbility(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public override void ProcessAbility(List<GameObject> targets)
        {
            if(targets != null & targets.Count > 0)
            {
                foreach (GameObject target in targets)
                {
                    DealDamage(target.transform.parent.GetComponent<UnitPhysiology>());
                }
            }
        }

        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }
    }
}
