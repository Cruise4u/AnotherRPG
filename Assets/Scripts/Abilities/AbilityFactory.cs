using System;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

public static class AbilityFactory
{
    public static Dictionary<AbilityName, Type> abilityDictionary;
    public static bool isInitialized => abilityDictionary != null;
    public static void InitAbilityFactory()
    {
        var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes().Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(Ability)) && type.IsClass);

        abilityDictionary = new Dictionary<AbilityName, Type>();

        foreach(var type in abilityTypes)
        {
            var reference = Activator.CreateInstance(type) as Ability;
            abilityDictionary.Add(reference.abilityName, type);
        }
    }
    public static Ability GetAbilityByName(AbilityName abilityName)
    {
        if (abilityDictionary.ContainsKey(abilityName))
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

//public abstract class ConcreteClassAbilityFactory
//{
//    public AbilityNameDataReference abilityNameReference;

//    public abstract Dictionary<AbilityName, Ability> ClassDictionary { get; }

//    public abstract AbilityName[] AbilityNameArray { get;}

//    public abstract void InitClassAbilityFactory(AbilityName[] abilitieNameKeys);

//    public abstract
//}

////public class PaladinAbilityFactory : ConcreteClassAbilityFactory
////{
////    public override AbilityName[] AbilityNameArray { get => abilityNameReference.abilityNameList.ToArray(); }

////    public override Dictionary<AbilityName, Ability> ClassDictionary => new Dictionary<AbilityName, Ability>();

////    public override void InitClassAbilityFactory(AbilityName[] abilitieNameKeys)
////    {
////        foreach(AbilityName name in abilitieNameKeys)
////        {
////            if(AbilityFactory.abilityDictionary.ContainsKey(name))
////            {
////                ClassDictionary.Add(name, AbilityFactory.abilityDictionary[name]);
////            }
////        }
////    }


////}
