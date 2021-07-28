using System;
using System.Collections;
using UnityEngine;
using QuestTales.Core.Abilities;
using System.Collections.Generic;

public class AbilityController : MonoBehaviour
{
    public AbilityAim abilityAim;
    public AbilityAnimation abilityAnimation;
    public AbilityAnimationData abilityAnimationData;
    public AbilityBookData abilityBookData;
    public AbilityHitDetector abilityHitCollider;
    public CooldownController cooldownController;
    public int abilityArrayIndex;
    public Vector2 offset;
    public Action<bool> BlockInputDelegate;

    public void Init()
    {
        AbilityFactory.InitAbilityFactory();
        abilityAim = new AbilityAim(transform, offset, transform.GetChild(0).gameObject);
        abilityAnimation = new AbilityAnimation(abilityAnimationData, transform);
        abilityHitCollider = gameObject.transform.GetChild(0).GetComponent<AbilityHitDetector>();
        cooldownController = GetComponent<CooldownController>();
    }
    
    public void CallAbilityLogic(IdType idType,Vector3 spawnPosition)
    {
        if(!cooldownController.IsAbilityOnCooldown())
        {
            var ability = AbilityFactory.GetAbilityByName(abilityBookData.abilityIdList[abilityArrayIndex]);
            if (ability.rangeType == RangeType.Melee)
            {
                StartCoroutine(BlockInputRoutine(1.0f));
                CallAbilityAnimation(ability);
                var instance = ability.InstantiateAbility(spawnPosition,abilityAim.weapon.transform.rotation);
                SetCasterAsParent(instance);
                instance.GetComponent<AbilityHitDetector>().ability = ability;
                StartCoroutine(ability.ReturnAbilityRoutine(instance, 1.0f));
                cooldownController.SetCooldownToMaximum(abilityBookData.abilityIdList);
            }
        }
    }

    public void CallAbilityAnimation(Ability ability)
    {
        if (ability != null)
        {
            var isAnglePositive = abilityAim.IsAnglePositive(abilityAim.GetAimAngle());
            switch (ability.animationType)
            {
                case AnimationType.Swing:
                    StartCoroutine(abilityAnimation.SwingAnimationRoutine(ability, abilityAim.weapon, isAnglePositive, BlockInputDelegate));
                    break;
                case AnimationType.ThreeSixty:
                    StartCoroutine(abilityAnimation.ThreeSixtyAnimationRoutine(ability, abilityAim.weapon, isAnglePositive, BlockInputDelegate));
                    break;
            }
        }
    }

    public void SetCasterAsParent(GameObject abilityPrefab)
    {
        abilityPrefab.transform.SetParent(transform);
    }

    public IEnumerator BlockInputRoutine(float seconds)
    {
        BlockInputDelegate.Invoke(true);
        yield return new WaitForSeconds(seconds);
        BlockInputDelegate.Invoke(false);
    }
}
