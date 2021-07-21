using System;
using System.Collections;
using UnityEngine;
using QuestTales.Core.Abilities;
using System.Collections.Generic;

public class AbilityController : MonoBehaviour
{
    public AbilityBook abilityBook;
    public AbilityBookData abilityBookData;
    public WeaponAnimator weaponAnimator;
    public WeaponAnimationData weaponAnimationData;

    public AbilityAim abilityAim;
    public Vector2 offset;
    public Action<bool> BlockInputDelegate;

    public void Init()
    {
        AbilityFactory.InitAbilityFactory();
        abilityBook = new AbilityBook();
        abilityBook.Init(abilityBookData.abilityIdList);
        weaponAnimator = new WeaponAnimator(transform.GetChild(0).gameObject);
        abilityAim = new AbilityAim(transform, offset, weaponAnimator.weapon);
        weaponAnimator.weaponAnimation.SetAnimationSettings(weaponAnimationData);
    }

    public void SetCurrentAbility(IdType id)
    {
        abilityBook.currentAbility = AbilityFactory.GetAbilityByName(id);
        AbilityColliderConfigurator.SetCollider(weaponAnimator.weapon, abilityBook.currentAbility);
    }

    public void CastAbility()
    {
        AbilityColliderConfigurator.EnableCollider(weaponAnimator.weapon);
        AnimateAbility(abilityBook.currentAbility);
        StartCoroutine(CoroutineInputBlockage(0.5f));
        StartCoroutine(AbilityColliderConfigurator.WaitForSecondsToDisableCollider(weaponAnimator.weapon, 0.5f));
        abilityBook.currentAbility.ProcessAbility();
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

public class AbilityBook
{
    public Ability currentAbility;
    public CooldownController cooldownController;

    public void Init(List<IdType> abilityIdList)
    {
        cooldownController = new CooldownController();
        cooldownController.Init();
        cooldownController.AddEntriesToCooldownDictionary(abilityIdList);
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