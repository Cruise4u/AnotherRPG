using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Rigidbody2D rb;
    private UnitMovement unitMovement;
    public AbilityController abilityController;
    public UnitCombat unitCombat;

    public void NumericKeyboardInputCallBack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityController.SetCurrentAbility(AbilityName.HolyStrike);
        }
    }

    public void WASDInputCallBack()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                unitMovement.Move(new Vector3(0, 1, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                unitMovement.Move(new Vector3(0, -1, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                unitMovement.Move(new Vector3(1, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                unitMovement.Move(new Vector3(-1, 0, 0));
            }
        }
    }

    public void AbilityInputCallback()
    {
        unitCombat.ReduceCooldown(0.85f);
        if (Input.GetMouseButtonDown(0))
        {
            if(unitCombat.attackCooldown < 0.1f)
            {
                abilityController.CastAbility(abilityController.currentAbility.abilityName);
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
        WASDInputCallBack();
        NumericKeyboardInputCallBack();
        AbilityInputCallback();
        AimInputCallback();
    }

}
