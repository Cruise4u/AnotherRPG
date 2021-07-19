using System;
using UnityEngine;

public class AIController : UnitController
{
    private GameObject target;

    public override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public override void AimInput()
    {
        abilityController.abilityAim.aimDirection = target.transform.position-transform.position;
        abilityController.abilityAim.AimWeaponTowardsDirection();
    }

    public override void MoveInput()
    {
        throw new NotImplementedException();
    }
}