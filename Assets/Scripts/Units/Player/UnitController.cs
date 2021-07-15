using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Rigidbody2D rb;

    private UnitMovement unitMovement;
    public AbilityController abilityController;
    public UnitCombat unitCombat;

    public void KeyboardInputCallback()
    {
        if (Input.anyKey)
        {
            unitMovement.MoveToDirection();
        }
    }

    public void MouseInputCallback()
    {
        unitCombat.ReduceCooldown(0.85f);
        if (Input.GetMouseButtonDown(0))
        {
            if(unitCombat.attackCooldown < 0.1f)
            {

            }
        }
    }

    public void AimInputCallback()
    {
        abilityController.abilityAim.SetWeaponAimAtMouse();
    }

    public void Start()
    {
        unitMovement = new UnitMovement(transform,rb,3);
        unitCombat = new UnitCombat();
    }

    public void Update()
    {
        KeyboardInputCallback();
        MouseInputCallback();
        AimInputCallback();
    }

}
