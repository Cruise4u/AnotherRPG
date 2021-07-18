using System;
using UnityEngine;

public class AIController : UnitController
{
    private GameObject target;

    public override void AimInput()
    {
        abilityController.abilityAim.aimDirection = target.transform.position-transform.position;
        abilityController.abilityAim.AimWeaponTowardsDirection();
    }

    public override void MoveInput()
    {
        var direction = (target.transform.position - transform.position).normalized;
        unitMovement.Move(direction);
    }
}