using System;
using System.Collections;
using UnityEngine;
using QuestTales.Core.Abilities;

public class AbilityController : MonoBehaviour
{
    public GameObject weapon;
    public AbilityAim abilityAim;
    public Ability currentAbility;
    public WeaponAnimation weaponAnimation;
    public Action<bool> BlockInputDelegate;
    public Vector2 offset;

    public void Start()
    {
        weaponAnimation = new WeaponAnimation();
        abilityAim = new AbilityAim(transform, offset,weapon);
        AbilityFactory.InitAbilityFactory();
    }

    public void SetCurrentAbility(IdType id)
    {
        currentAbility = AbilityFactory.GetAbilityByName(id);
        AbilityColliderConfigurator.SetCollider(weapon, currentAbility);
    }

    public void CastAbility()
    {
        AbilityColliderConfigurator.EnableCollider(weapon);
        AnimateAbility(currentAbility);
        StartCoroutine(CoroutineInputBlockage(0.5f));
        StartCoroutine(AbilityColliderConfigurator.WaitForSecondsToDisableCollider(weapon, 0.5f));
        currentAbility.ProcessAbility();
    }

    public void AnimateAbility(Ability ability)
    {
        var data = ability.colliderData;
        switch (ability.animationType)
        {
            case AnimationType.Swing:
                StartCoroutine(AbilityTweenAnimator.CoroutineSwingTweenAnimation(this));
                break;
            case AnimationType.Circular:
                StartCoroutine(AbilityTweenAnimator.CoroutineFullCircleTweenAnimation(this));
                break;
        }
    }

    public IEnumerator CoroutineInputBlockage(float seconds)
    {
        BlockInputDelegate.Invoke(true);
        yield return new WaitForSeconds(seconds);
        BlockInputDelegate.Invoke(false);
    }

}

