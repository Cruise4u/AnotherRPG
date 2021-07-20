using System;
using UnityEngine;
using QuestTales.Core.Abilities;
using UnityEngine.AI;

public class PlayerController : UnitController
{
    private CameraManager cameraManager;
    private NavigationAgent myAgent;


    public override void Start()
    {
        base.Start();
        cameraManager = FindObjectOfType<CameraManager>();
        myAgent = GetComponent<NavigationAgent>();
    }

    public override void AimInput()
    {
        var direction = cameraManager.baseCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraManager.baseCamera.nearClipPlane));
        abilityController.abilityAim.SetAimDirection(direction);
        float angle = abilityController.abilityAim.GetUnitCircleAimAngle();
        abilityController.abilityAim.AimWeaponTowardsDirection(angle,abilityController.offset);
    }

    public void MoveInput()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myAgent.SteerAgent(new Vector3(0, 1, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                myAgent.SteerAgent(new Vector3(0, -1, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                myAgent.SteerAgent(new Vector3(1, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                myAgent.SteerAgent(new Vector3(-1, 0, 0));
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
                    abilityController.CastAbility();
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
