using System;
using System.Collections;
using UnityEngine;
using QuestTales.Core.Abilities;
using System.Collections.Generic;

public class AbilityController : MonoBehaviour
{
    public Ability currentAbility;
    public AbilityAim abilityAim;
    public AbilityBookData abilityBookData;
    public CooldownController cooldownController;
    public WeaponAnimator weaponAnimator;
    public WeaponAnimationData weaponAnimationData;

    public Vector2 offset;
    public Action<bool> BlockInputDelegate;

    public void Init()
    {
        AbilityFactory.InitAbilityFactory();
        weaponAnimator = new WeaponAnimator(transform.GetChild(0).gameObject);
        weaponAnimator.weaponAnimation.SetAnimationSettings(weaponAnimationData);
        abilityAim = new AbilityAim(transform, offset, weaponAnimator.weapon);
    }

    public void SetCurrentAbility(int index)
    {
        currentAbility = AbilityFactory.GetAbilityByName(abilityBookData.abilityIdList[index]);
        AbilityColliderConfigurator.SetCollider(weaponAnimator.weapon, currentAbility);
    }

    public void CastAbility()
    {
        if(!cooldownController.IsAbilityOnCooldown())
        {
            AbilityColliderConfigurator.EnableCollider(weaponAnimator.weapon);
            AnimateAbility(currentAbility);
            StartCoroutine(CoroutineInputBlockage(0.5f));
            StartCoroutine(AbilityColliderConfigurator.WaitForSecondsToDisableCollider(weaponAnimator.weapon, 0.5f));
            currentAbility.ProcessAbility();
            cooldownController.SetCooldownToMaximum(abilityBookData.abilityIdList);
        }
    }

    public void AnimateAbility(Ability ability)
    {
        var data = ability.colliderData;
        switch (ability.animationType)
        {
            case AnimationType.Swing:
                StartCoroutine(weaponAnimator.weaponAnimation.CoroutineSwingTweenAnimation(this));
                break;
            case AnimationType.Circular:
                StartCoroutine(weaponAnimator.weaponAnimation.CoroutineFullCircleTweenAnimation(this));
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

public class WeaponAnimator
{
    public GameObject weapon;
    public WeaponAnimation weaponAnimation;

    public WeaponAnimator(GameObject weapon)
    {
        this.weapon = weapon;
        weaponAnimation = new WeaponAnimation();
    }

}