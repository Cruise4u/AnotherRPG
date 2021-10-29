using System;
using System.Collections;
using UnityEngine;
using QuestTales.Core.Abilities;
using System.Collections.Generic;

public class AbilityController : MonoBehaviour
{
    public AbilityAim abilityAim;
    public AbilityContainer abilityContainer;
    public AbilityHitDetector abilityHitCollider;
    public CooldownController cooldownController;

    //public AbilityAnimation abilityAnimation;
    public AbilityAnimationData abilityAnimationData;

    public Action<bool> BlockInputDelegate;
    public bool isAimBlocked;
    public Vector2 offset;
    public int abilityArrayIndex;

    public void Init()
    {
        abilityAim = new AbilityAim(transform, offset, transform.GetChild(0).gameObject);
        abilityHitCollider = gameObject.transform.GetChild(0).GetComponent<AbilityHitDetector>();
        cooldownController = GetComponent<CooldownController>();
    }
    public void CallAbilityLogic(AbilityID abilityID, Vector3 spawnPosition)
    {
        if (!cooldownController.IsAbilityOnCooldown())
        {
            var ability = abilityContainer.abilityDictionary[abilityID];
            if (ability.skillReferences.rangeType == RangeType.Melee)
            {
                StartCoroutine(BlockInputRoutine(0.85f));
                var abilityInstance = ObjectPool.Instance.SpawnPoolObject(ability.skillReferences.poolName,spawnPosition);
                abilityInstance.GetComponent<AbilityHitDetector>().ability = ability;
                //CallAbilityAnimation(ability);
                SetCasterAsParent(abilityInstance);
                ObjectPool.Instance.ReturnAbilityRoutine(ability.skillReferences.poolName, abilityInstance, 1.0f);
                cooldownController.SetCooldownToMaximum(ability);
            }
            else
            {
                //StartCoroutine(BlockInputRoutine(0.85f));
                //CallAbilityAnimation(ability);
                //var instance = ability.InstantiateAbility(spawnPosition, abilityAim.weapon.transform.rotation);
                //instance.GetComponent<RangedProjectile>().SetProjectileOrientation(abilityAim.weapon.transform.rotation);
                //instance.GetComponent<RangedProjectile>().SetProjectileNewDirection(abilityAim.weapon, ability.abilityStats.range, 1.0f);
                //instance.GetComponent<AbilityHitDetector>().ability = ability;
                //StartCoroutine(ability.ReturnAbilityRoutine(instance, 3));
                //cooldownController.SetCooldownToMaximum(abilityBookData.abilityIdList);
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
