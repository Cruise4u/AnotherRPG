using QuestTales.Core.Abilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestTales.Core.Abilities
{
    public enum AbilityID
    {
        DivineShield,
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
        None,
        ThreeSixty,
        Swing,
        Stab,
    }

    public abstract class Ability : ScriptableObject
    {
        public AbilityReferences skillReferences;
        public AbilityStats abilityStats;
        public abstract void Execute(TargetReference targetReference);
    }


}
