using QuestTales.Core.Abilities;
using System.Collections;
using UnityEngine;

[CreateAssetMenu()]
public class AbilityReferences : ScriptableObject
{
    public ObjectPoolRef poolName;
    public AbilityID idType;
    public RangeType rangeType;
    public AnimationType animationType;
}

