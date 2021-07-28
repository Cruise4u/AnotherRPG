using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestTales.Core.Abilities
{
    public enum IdType
    {
        DivineGuard,
        HolyStrike,
        Smite,
        Bash,
        Charge,
    }
    public enum RangeType
    {
        Melee,
        Range,
    }
    public enum ColliderType
    {
        Fan,
        Triangle,
        Rectangle,
        Circle,
    }
    public enum AnimationType
    {
        ThreeSixty,
        Ranged,
        Swing,
        Stab,
    }

    public abstract class Ability
    {
        public abstract string poolName { get; }
        public abstract IdType idType { get; }

        public abstract RangeType rangeType { get; }

        public abstract ColliderType abilityColliderType { get; }

        public abstract AnimationType animationType { get; }

        public abstract void ProcessAbility(GameObject target);

        public virtual GameObject InstantiateAbility(Vector3 position, Quaternion rotation)
        {
            var instance = ObjectPool.Instance.SpawnPoolObject(poolName, position);
            instance.transform.rotation = rotation;
            return instance;
        }

        public virtual IEnumerator ReturnAbilityRoutine(GameObject instance,float time)
        {
            yield return new WaitForSeconds(time);
            ObjectPool.Instance.ReturnToPool(poolName,instance);
        }

        public abstract void SpawnParticles(Vector3 position);

        public abstract ColliderData colliderData { get; }

        public abstract AbilityStatsData abilityStats { get; }
    }
}



//public interface IAbilityFactory
//{
//    IAbilityProduct CreateAbilityProduct();
//}

//public interface IAbilityProduct
//{
//    void ProcessAbility();
//}

//public class AbFactory : IAbilityFactory
//{
//    public IAbilityProduct CreateAbilityProduct()
//    {
//        return new Fireball();
//    }
//}

//public class Fireball : IAbilityProduct
//{
//    public void ProcessAbility()
//    {
//        throw new NotImplementedException();
//    }
//}

