using System;
using UnityEngine;

public enum AbilityName
{
    DivineGuard,
    HolyStrike,
    Smite,
}
public enum AbilityRange
{
    Melee,
    Range,
}
public enum AbilityCollider
{
    Fan,
    Cone,
    Rectangle,
    Circle,
}

public abstract class Ability
{
    public AbilityColliderDetector abilityColliderDetector;
    public AbilityStats abilityStats;
    public abstract AbilityName abilityName { get; }
    public abstract void ProcessAbility();
}

public class HolyStrike : Ability
{

    public override AbilityName abilityName => AbilityName.HolyStrike;

    public override void ProcessAbility()
    {
        throw new NotImplementedException();
    }
}
