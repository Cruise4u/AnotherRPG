using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestTales.Core.Abilities;


namespace QuestTales.Core.Abilities.Paladin
{
    public class HolyStrike : Ability,IDamager,IPusher
    {
        public override AbilityStatsData abilityStats => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/HolyStrike/HolyStrikeStats");
        public override string poolName => "HolyStrikePool";
        public override IdType idType => IdType.HolyStrike;
        public override RangeType rangeType => RangeType.Melee;
        public override AnimationType animationType => AnimationType.ThreeSixty;
        public override void ProcessAbility(GameObject target)
        {
            if(target != null)
            {
                DealDamage(target.transform.parent.GetComponent<UnitPhysiology>());
                PushEnemy(target.transform.parent.GetComponent<UnitPhysiology>());
            }
        }
        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }
        public void DealDamage(IDamagable damagable)
        {
            if (damagable != null)
            {
                damagable.TakeDamage(abilityStats.power);
            }
        }
        public void PushEnemy(IPushable pushable)
        {
            pushable.Push(pushable.pushDirection);
        }
    }

    public class DivineShield : Ability, IProtector
    {
        public override AbilityStatsData abilityStats => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/DivineShield/DivineShieldStats");
        public override string poolName => "DivineShieldPool";
        public override IdType idType => IdType.DivineShield;
        public override RangeType rangeType => RangeType.Melee;
        public override AnimationType animationType => AnimationType.None;
        public override void ProcessAbility(GameObject target)
        {
            if(target != null)
            {
                Protect(target.transform.parent.GetComponent<UnitPhysiology>());
            }
        }
        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }
        public void Protect(IProtectable protectable)
        {
            protectable.GetProtected(abilityStats.power);
        }
    }

}
