using System;
using UnityEngine;
using UnityEngine.AI;
using QuestTales.Core.Abilities;

public class AIController : UnitController
{
    public NavMeshAgent myAgent;
    public GameObject target;
    public AIDetection detection;
    public bool isChasingPlayer;

    public override void Init()
    {
        base.Init();
        SetupNavMeshAgent();
        target = GameObject.FindGameObjectWithTag("Player");
        detection.Init();
    }
    public override void AimInput()
    {
        AimToPlayer();
    }
    public void SetupNavMeshAgent()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.enabled = true;
        myAgent.updateRotation = false;
        myAgent.updateUpAxis = false;
    }
    public void AimToPlayer()
    {
        var direction = (target.transform.position-transform.position).normalized;
        var newDirection = transform.position + direction;
        abilityController.abilityAim.SetAimDirection(newDirection);
        float angle = abilityController.abilityAim.GetAimAngle();
        abilityController.abilityAim.AimWeaponTowardsDirection(angle,abilityController.offset);
    }
}