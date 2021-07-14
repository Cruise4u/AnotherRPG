using System;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability currentAbility;
    public AbilityAim abilityAim;
    public AbilityColliderDetector abilityColliderDetector;

    public void SetCurrentAbility(AbilityName name)
    {
        currentAbility = AbilityFactory.GetAbilityByName(name);

    }

    public void CastAbility()
    {

    }


}

