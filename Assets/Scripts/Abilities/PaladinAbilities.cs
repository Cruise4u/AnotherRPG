using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestTales.Core.Abilities;


namespace QuestTales.Core.Abilities.Paladin
{
    public class HolyStrike : Ability
    {
        public override void Execute(TargetReference targetReference)
        {
            targetReference.TakeDamage(abilityStats.power);
            targetReference.Push(targetReference.pushDirection);
        }
    }

    //public class DivineShield : Ability, IProtector
    //{
    //    public override AbilityStatsData abilityStats => Resources.Load<AbilityStatsData>("Data/Ability/Paladin/DivineShield/DivineShieldStats");
    //    public override ObjectPoolRef poolName => ObjectPoolRef.AnotherObjectPool;
    //    public override AbilityID idType => AbilityID.DivineShield;
    //    public override RangeType rangeType => RangeType.Melee;
    //    public override AnimationType animationType => AnimationType.None;

    //    public override void ProcessAbility(GameObject target)
    //    {
    //        if(target != null)
    //        {
    //            Protect(target.transform.parent.GetComponent<UnitPhysiology>());
    //        }
    //    }
    //    public override void SpawnParticles(Vector3 position)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void Protect(IProtectable protectable)
    //    {
    //        protectable.GetProtected(abilityStats.power);
    //    }
    //}

}
