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
        public AbilityHitHandler abilityColliderDetector;

        public abstract IdType idType { get; }

        public abstract RangeType rangeType { get; }

        public abstract ColliderType abilityColliderType { get; }

        public abstract AnimationType animationType { get; }

        public abstract void ProcessAbility(List<GameObject> targets);

        public abstract void InstantiateAbility(Vector3 position);

        public abstract void SpawnParticles(Vector3 position);

        public abstract ColliderData colliderData { get; }

        public abstract AbilityStatsData abilityData { get; }

        public abstract string abilityParticlePoolName { get; }

        public virtual IEnumerator DisableColliderAfterSeconds(GameObject weapon, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            AbilityColliderConfigurator.DisableCollider(weapon);
        }
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

