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
        public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/HolyStrikeCollider");
        public override AbilityStatsData abilityData => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/HolyStrikeData");
        public override string abilityParticlePoolName => "HolyStrikePool";
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

        public override GameObject InstantiateAbility(Vector3 position)
        {
            return ObjectPool.Instance.SpawnPoolObject(abilityParticlePoolName, position);
        }

        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public override void CalculateAbilityColliders(GameObject abilityInstance,string tag)
        {
            var colliderPoints = abilityInstance.GetComponent<PolygonCollider2D>().points;
            foreach (Vector2 point in colliderPoints)
            {
                if(Physics2D.OverlapPoint(point).CompareTag(tag))
                {
                    Debug.Log("It's overlapping a point in the ability collider! That's awesome!");
                    DealDamage(Physics2D.OverlapPoint(point).gameObject.GetComponent<UnitPhysiology>());
                }
            }
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

        public override string abilityParticlePoolName => "SmiteParticlePool";

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

        public override GameObject InstantiateAbility(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public override void SpawnParticles(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public override void CalculateAbilityColliders(GameObject instance, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
