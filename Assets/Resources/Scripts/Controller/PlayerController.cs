using System;
using UnityEngine;
using QuestTales.Core.Abilities;

public class PlayerController : UnitController
{
    private CameraManager cameraManager;

    public override void Start()
    {
        base.Start();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    public override void AimInput()
    {
        abilityController.abilityAim.aimDirection = cameraManager.baseCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraManager.baseCamera.nearClipPlane));
        abilityController.abilityAim.AimWeaponTowardsDirection();
    }

    public override void MoveInput()
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

    public void NumericKeyboardInputCallBack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityController.SetCurrentAbility(IdType.HolyStrike);
        }
    }

    public void AbilityInputCallback()
    {
        unitCombat.ReduceCooldown(0.85f);
        if (Input.GetMouseButtonDown(0))
        {
            if (unitCombat.attackCooldown < 0.1f)
            {
                abilityController.CastAbility(abilityController.currentAbility.abilityName);
            }
        }
    }


    public void Update()
    {
        if (isInputBlocked != true)
        {
            MoveInput();
            NumericKeyboardInputCallBack();
            AbilityInputCallback();
            AimInput();
        }
    }
}
