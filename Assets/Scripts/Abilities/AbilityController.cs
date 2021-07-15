using System;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public GameObject weapon;
    public AbilityAim abilityAim;
    private AbilityColliderDetector abilityColliderDetector;

    public void Start()
    {
        var camera = FindObjectOfType<CameraManager>().baseCamera;
        abilityAim = new AbilityAim(camera, transform, weapon);
        AbilityFactory.InitAbilityFactory();
        SetCurrentAbility(AbilityName.HolyStrike);
    }

    public void SetCurrentAbility(AbilityName name)
    {
        var currentAbility = AbilityFactory.GetAbilityByName(name);
        AbilityColliderConfigurator.SetCollider(weapon,currentAbility);
    }

    public void CastAbility()
    {
        AbilityColliderConfigurator.EnableCollider(weapon);
        Debug.Log("It's a workin!");
    }

}

