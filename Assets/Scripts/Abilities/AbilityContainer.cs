using QuestTales.Core.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AbilityContainer : ScriptableObject
{
    public Dictionary<AbilityID,Ability> abilityDictionary;
}