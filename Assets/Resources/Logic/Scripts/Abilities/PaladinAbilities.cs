using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestTales.Core.Abilities;


namespace QuestTales.Core.Abilities.Paladin
{
    public class HolyStrike : Ability,IDamager,IPusher
    {
        public override IdType idType => IdType.HolyStrike;
        public override RangeType rangeType => RangeType.Melee;
        public override ColliderType abilityColliderType => ColliderType.Fan;
        public override AnimationType animationType => AnimationType.ThreeSixty;
        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/Holystrike/HolyStrikeCollider");
        public override AbilityStatsData abilityStats => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/HolyStrike/HolyStrikeStats");
        public override string poolName => "HolyStrikePool";
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

    public class Smite : Ability,IDamager,IStunner
    {
        public override string poolName => "SmiteParticlePool";

        public override IdType idType => IdType.Smite;

        public override RangeType rangeType => RangeType.Range;

        public override ColliderType abilityColliderType => ColliderType.Circle;

        public override AnimationType animationType => AnimationType.Ranged;

        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/Smite/SmiteCollider");

        public override AbilityStatsData abilityStats => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/Smite/SmiteStats");

        public override void ProcessAbility(GameObject target)
        {
            DealDamage(target.transform.parent.GetComponent<UnitPhysiology>());
            Stun(target.transform.parent.GetComponent<UnitPhysiology>());
        }
   
        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public void DealDamage(IDamagable damagable)
        {
            damagable.TakeDamage(abilityStats.power);
        }

        public void Stun(IStunnable stunnable)
        {
            if (stunnable != null)
            {
                stunnable.GetStunned();
            }
        }
    }

}
