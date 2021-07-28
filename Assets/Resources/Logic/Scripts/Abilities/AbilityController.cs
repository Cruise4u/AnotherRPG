using System;
using System.Collections;
using UnityEngine;
using QuestTales.Core.Abilities;
using System.Collections.Generic;

public class AbilityController : MonoBehaviour
{
    public AbilityAim abilityAim;
    public AbilityAnimation abilityAnimation;
    public AbilityAnimationData weaponAnimationData;
    public AbilityBookData abilityBookData;
    public AbilityHitHandler abilityHitCollider;
    public CooldownController cooldownController;
    public Vector2 offset;
    public Action<bool> BlockInputDelegate;
    public int abilityArrayIndex;

    public void Init()
    {
        AbilityFactory.InitAbilityFactory();
        abilityAim = new AbilityAim(transform, offset, transform.GetChild(0).gameObject);
        abilityHitCollider = gameObject.transform.GetChild(0).GetComponent<AbilityHitHandler>();
        cooldownController = GetComponent<CooldownController>();
    }
    
    public void CallAbilityLogic(IdType idType,Vector3 spawnPosition)
    {
        if(!cooldownController.IsAbilityOnCooldown() && abilityArrayIndex != -1)
        {
            var ability = AbilityFactory.GetAbilityByName(abilityBookData.abilityIdList[abilityArrayIndex]);
            if (ability.rangeType == RangeType.Melee)
            {
                Debug.Log("Starting the ability logic call..");
                StartCoroutine(BlockInputRoutine(1.0f));
                var instance = ability.InstantiateAbility(spawnPosition);
                SetCasterAsParent(instance);
                CallAbilityAnimation(ability);
                ability.CalculateAbilityColliders(instance, "Enemy");
                //StartCoroutine(ProcessAbilityRoutine(ability,0.25f));
                cooldownController.SetCooldownToMaximum(abilityBookData.abilityIdList);
            }
            else
            {
                CallAbilityAnimation(ability);
                StartCoroutine(ProcessAbilityRoutine(ability,0.25f));
                StartCoroutine(BlockInputRoutine(0.85f));
                cooldownController.SetCooldownToMaximum(abilityBookData.abilityIdList);
            }
        }
    }

    public void CallAbilityAnimation(Ability ability)
    {
        if (ability != null)
        {
            var data = ability.colliderData;
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

    public IEnumerator ProcessAbilityRoutine(Ability ability,float time)
    {
        yield return new WaitForSeconds(time);
        ability.ProcessAbility(abilityHitCollider.hittedTargetsList);
    }

    public IEnumerator BlockInputRoutine(float seconds)
    {
        BlockInputDelegate.Invoke(true);
        yield return new WaitForSeconds(seconds);
        BlockInputDelegate.Invoke(false);
    }

}
