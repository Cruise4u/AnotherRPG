using System;
using UnityEngine;

public enum AbilityName
{
    DivineGuard,
    HolyStrike,
    Smite,
}
public enum RangeType
{
    Melee,
    Range,
}
public enum ColliderType
{
    Fan,
    Cone,
    Rectangle,
    Circle,
}

public enum AnimationType
{
    Swing,
    Stab,
    Other,
}

public abstract class Ability
{
    public AbilityColliderDetector abilityColliderDetector;

    public abstract AbilityName abilityName { get; }

    public abstract RangeType abilityRange { get; }

    public abstract ColliderType abilityColliderType { get;}

    public abstract AnimationType animationType { get; }

    public abstract void ProcessAbility();

    public abstract ColliderData colliderData { get; }
}

public class HolyStrike : Ability
{
    public override AbilityName abilityName => AbilityName.HolyStrike;

    public override RangeType abilityRange => RangeType.Melee;

    public override ColliderType abilityColliderType => ColliderType.Fan;

    public override ColliderData colliderData => Resources.Load<ColliderData>("Data/Ability/Paladin/HolyStrikeCollider");

    public override AnimationType animationType => AnimationType.Swing;

    public override void ProcessAbility()
    {
        throw new NotImplementedException();
    }
}
