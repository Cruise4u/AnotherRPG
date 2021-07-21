using System;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using QuestTales.Core.Abilities;

public static class AbilityFactory
{
    public static Dictionary<IdType, Type> abilityDictionary;
    public static bool isInitialized => abilityDictionary != null;
    public static void InitAbilityFactory()
    {
        if (isInitialized)
            return;
        Debug.Log("Initializing Ability Factory!");
        abilityDictionary = new Dictionary<IdType, Type>();
        
        var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes().Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(Ability)) && type.IsClass);


        foreach(var type in abilityTypes)
        {
            var reference = Activator.CreateInstance(type) as Ability;
            abilityDictionary.Add(reference.abilityName, type);
        }
    }

    public static Ability GetAbilityByName(IdType abilityName)
    {
        if(abilityDictionary.ContainsKey(abilityName))
        {
            Type type = abilityDictionary[abilityName];
            var ability = Activator.CreateInstance(type) as Ability;
            return ability;
        }
        else
        {
            return null;
        }
    }
}

public class AbilityCreator
{
    private List<IdType> abilityIdTypeList;
    public Dictionary<IdType, Ability> abilityDictionary;

    public AbilityCreator(List<IdType> abilityIdTypeList)
    {
        this.abilityIdTypeList = abilityIdTypeList;

    }

    public void Init()
    {
        abilityDictionary = new Dictionary<IdType, Ability>();
    }

    public void CreateAbilityOnDemand()
    {

    }





}

