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
        public override AnimationType animationType => AnimationType.Circular;
        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/HolyStrikeCollider");
        public override AbilityStatsData abilityData => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/HolyStrikeData");

        public override string abilityParticlePoolName => "";

        public override string abilityRangedObjectPoolName => "";

        public override void ProcessAbility(List<GameObject> targets)
        {
            if(targets != null && targets.Count > 0)
            {
                foreach (GameObject target in targets)
                {
                    DealDamage(target.transform.parent.GetComponent<UnitPhysiology>());
                    PushEnemy(target.transform.parent.GetComponent<UnitPhysiology>());
                }
            }
        }
        public void DealDamage(IDamagable damagable)
        {
            if (damagable != null)
            {
                damagable.TakeDamage(abilityData.power);
            }
        }
        public void PushEnemy(IPushable pushable)
        {
            pushable.Push(pushable.pushDirection);
        }
    }

    public class Smite : Ability,IDamager,IStunner
    {

        public override IdType idType => IdType.Smite;

        public override RangeType rangeType => RangeType.Range;

        public override ColliderType abilityColliderType => ColliderType.Circle;

        public override AnimationType animationType => AnimationType.Ranged;

        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/SmiteCollider");

        public override AbilityStatsData abilityData => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/SmiteData");

        public override string abilityParticlePoolName => throw new NotImplementedException();

        public override string abilityRangedObjectPoolName => throw new NotImplementedException();

        public override void ProcessAbility(List<GameObject> targets)
        {
            if (targets != null && targets.Count > 0)
            {
                foreach (GameObject target in targets)
                {
                    DealDamage(target.transform.parent.GetComponent<UnitPhysiology>());
                    Stun(target.transform.parent.GetComponent<UnitPhysiology>());
                }
            }
        }

        public void DealDamage(IDamagable damagable)
        {
            damagable.TakeDamage(abilityData.power);
        }

        public void Stun(IStunnable stunnable)
        {
            if(stunnable != null)
            {
                stunnable.GetStunned();
            }
        }
    }
}
