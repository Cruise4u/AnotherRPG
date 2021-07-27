using System;
using System.Collections;
using UnityEngine;
using QuestTales.Core.Abilities;
using System.Collections.Generic;

public class AbilityController : MonoBehaviour
{
    public WeaponAnimator weaponAnimator;
    public WeaponAnimationData weaponAnimationData;
    public Ability currentAbility;
    public AbilityAim abilityAim;
    public AbilityBookData abilityBookData;
    public AbilityHitHandler abilityHitCollider;
    public CooldownController cooldownController;


    public Vector2 offset;
    public Action<bool> BlockInputDelegate;


    public void Init()
    {
        AbilityFactory.InitAbilityFactory();
        weaponAnimator = new WeaponAnimator(transform.GetChild(0).gameObject);
        weaponAnimator.weaponAnimation.SetAnimationSettings(weaponAnimationData);
        abilityAim = new AbilityAim(transform, offset, weaponAnimator.weapon);
        abilityHitCollider = gameObject.transform.GetChild(0).GetComponent<AbilityHitHandler>();
        cooldownController = GetComponent<CooldownController>();
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
            if(currentAbility.rangeType == RangeType.Melee)
            {
                AbilityColliderConfigurator.EnableCollider(weaponAnimator.weapon);
                AnimateAbility(currentAbility);
                StartCoroutine(WaitForSecondsBeforeProcessingAbility(0.25f));
                StartCoroutine(CoroutineInputBlockage(0.85f));
                cooldownController.SetCooldownToMaximum(abilityBookData.abilityIdList);
            }
            else
            {
                AnimateAbility(currentAbility);
                StartCoroutine(WaitForSecondsBeforeProcessingAbility(0.25f));
                StartCoroutine(CoroutineInputBlockage(0.85f));
                cooldownController.SetCooldownToMaximum(abilityBookData.abilityIdList);
            }
        }
    }

    public IEnumerator WaitForSecondsBeforeProcessingAbility(float time)
    {
        yield return new WaitForSeconds(time);
        currentAbility.ProcessAbility(abilityHitCollider.hittedTargetsList);
    }

    public void AnimateAbility(Ability ability)
    {
        if(ability != null)
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