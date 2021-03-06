using QuestTales.Core.Abilities;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CooldownController : MonoBehaviour
{
    public List<float> cooldownList;
    public List<bool> abilityReadyList;
    public int lastSelectedId;

    public void Init()
    {
        cooldownList = new List<float>();
        abilityReadyList = new List<bool>();
    }

    public void AddCooldownToList(List<IdType> abilityIdList)
    {
        for(int i = 0; i < abilityIdList.ToArray().Length; i++)
        {
            var ability = AbilityFactory.GetAbilityByName(abilityIdList.ToArray()[i]);
            cooldownList.Add(0);
            abilityReadyList.Add(true);
        }
    }

    public void SetCooldownToMaximum(List<IdType> abilityIdList)
    {
        var idType = AbilityFactory.GetAbilityByName(abilityIdList[lastSelectedId]).idType;
        cooldownList[lastSelectedId] = AbilityFactory.GetAbilityByName(idType).abilityStats.cooldown;
        abilityReadyList[lastSelectedId] = false;
    }

    public void IterateThroughAbilitiesOnCooldown(List<IdType> abilityIdList)
    {
        for(int i = 0; i< cooldownList.ToArray().Length; i++)
        {
            if (IsAbilityOnCooldown())
            {
                cooldownList[i] -= Time.deltaTime;
                if (cooldownList[i] < 0.05f)
                {
                    abilityReadyList[i] = true;
                }
            }
        }
    }

    public bool IsAbilityOnCooldown()
    {
        bool condition;
        if(cooldownList[lastSelectedId] > 0.05f && abilityReadyList[lastSelectedId] == false)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
}
