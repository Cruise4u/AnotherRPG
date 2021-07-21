using QuestTales.Core.Abilities;
using System;
using System.Collections.Generic;

public class CooldownController
{
    public Dictionary<Ability, float> cooldownDictionary;

    public void Init()
    {
        cooldownDictionary = new Dictionary<Ability, float>();
    }

    public void AddEntriesToCooldownDictionary(List<IdType> abilityIdList)
    {
        foreach(IdType abilityId in abilityIdList)
        {
            var ability = AbilityFactory.GetAbilityByName(abilityId);
            cooldownDictionary.Add(ability, ability.abilityData.cooldown);
        }
    }

    public void IterateThroughAbilitiesOnCooldown(List<IdType> abilityIdList, float amount)
    {
        foreach (IdType abilityId in abilityIdList)
        {
            var ability = AbilityFactory.GetAbilityByName(abilityId);
            cooldownDictionary.Add(ability, ability.abilityData.cooldown);
            if (cooldownDictionary[ability] > 0.05f)
            {
                //Reduce Cooldown every (Time.deltaTime)
                cooldownDictionary[ability] = -amount;
            }
            else
            {
                //Or if it reaches near 0, sets it to max, so it can be used again!
                cooldownDictionary[ability] = ability.abilityData.cooldown;
            }
        }
    }

    public bool IsAbilityOnCooldown(Ability ability)
    {
        bool condition;
        if(cooldownDictionary[ability] > 0.05f)
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

