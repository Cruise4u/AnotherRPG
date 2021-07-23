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
        Swing,
        Stab,
        Circular,
        Ranged,
    }
    public enum ControllerType
    {
        Player,
        AI,
    }
    public abstract class Ability
    {
        public AbilityHitCollider abilityColliderDetector;

        public abstract ControllerType controllerType { get; }

        public abstract IdType abilityIdType { get; }

        public abstract RangeType abilityRange { get; }

        public abstract ColliderType abilityColliderType { get; }

        public abstract AnimationType animationType { get; }

        public abstract void ProcessAbility(List<GameObject> targets);

        public abstract ColliderData colliderData { get; }

        public abstract AbilityStatsData abilityData { get; }

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

