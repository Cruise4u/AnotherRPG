using System;
using UnityEngine;
using QuestTales.Core.Abilities;

public class PlayerController : UnitController
{
    public float inputForce;
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
                navAgent.Steer(new Vector3(0,1,0) * inputForce);
            }
            if (Input.GetKey(KeyCode.S))
            {
                navAgent.Steer(new Vector3(0, -1, 0) * inputForce);
            }
            if (Input.GetKey(KeyCode.D))
            {
                navAgent.Steer(new Vector3(1, 0, 0) * inputForce);
            }
            if (Input.GetKey(KeyCode.A))
            {
                navAgent.Steer(new Vector3(-1, 0, 0) * inputForce);
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
        if (abilityController.currentAbility != null)
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
