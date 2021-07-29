using System;
using UnityEngine;
using QuestTales.Core.Abilities;
using UnityEngine.AI;

public class PlayerController : UnitController
{
    private CameraHandler cameraManager;
    private NavigationAgent myAgent;

    public override void Init()
    {
        base.Init();
        cameraManager = FindObjectOfType<CameraHandler>();
        myAgent = GetComponent<NavigationAgent>();
    }

    public override void AimInput()
    {
        var direction = cameraManager.baseCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraManager.baseCamera.nearClipPlane));
        abilityController.abilityAim.SetAimDirection(direction);
        float angle = abilityController.abilityAim.GetAimAngle();
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
        if (abilityController.abilityArrayIndex < abilityController.abilityBookData.abilityIdList.Count)
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityController.abilityArrayIndex = 0;
            abilityController.cooldownController.lastSelectedId = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilityController.abilityArrayIndex = 1;
            abilityController.cooldownController.lastSelectedId = 1;
        }
    }

    public void AbilityInput()
    {
        if(Input.GetMouseButtonDown(0) && abilityController.abilityArrayIndex != -1)
        {
            abilityController.CallAbilityLogic(abilityController.abilityBookData.abilityIdList[abilityController.abilityArrayIndex],abilityController.abilityAim.weapon.transform.position);
        }
    }

    public void UpdatePlayerController()
    {
        if (isInputBlocked != true)
        {
            MoveInput();
            NumericKeyboardInputCallBack();
            AimInput();
            AbilityInput();
        }
    }
}
