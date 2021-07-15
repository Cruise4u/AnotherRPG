using System;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public GameObject weapon;
    public AbilityAim abilityAim;
    public Ability currentAbility;
    private AbilityColliderDetector abilityColliderDetector;

    public void Start()
    {
        var camera = FindObjectOfType<CameraManager>().baseCamera;
        abilityAim = new AbilityAim(camera, transform, weapon);
        AbilityFactory.InitAbilityFactory();
    }

    public void SetCurrentAbility(AbilityName name)
    {
        currentAbility = AbilityFactory.GetAbilityByName(name);
        AbilityColliderConfigurator.SetCollider(weapon,currentAbility);
    }

    public void CastAbility(AbilityName name)
    {
        AbilityColliderConfigurator.EnableCollider(weapon);
        AnimateAbility(currentAbility);
        currentAbility.ProcessAbility();
    }

    public void AnimateAbility(Ability ability)
    {
        switch(ability.animationType)
        {
            case AnimationType.Swing:
                var data = ability.colliderData;
                StartCoroutine(AbilityTweenAnimator.CoroutineFullCircleTweenAnimation(transform, weapon, abilityAim.IsAnglePositive(),data.angle, data.radius));
                break;
        }
    }

}

