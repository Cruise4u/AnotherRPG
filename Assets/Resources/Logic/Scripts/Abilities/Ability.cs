using System;
using System.Collections;
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
        public AbilityColliderDetector abilityColliderDetector;

        public abstract ControllerType controllerType { get; }

        public abstract IdType abilityName { get; }

        public abstract RangeType abilityRange { get; }

        public abstract ColliderType abilityColliderType { get; }

        public abstract AnimationType animationType { get; }

        public abstract void ProcessAbility();

        public abstract ColliderData colliderData { get; }

        public abstract AbilityStatsData abilityData { get; }
    }
}

