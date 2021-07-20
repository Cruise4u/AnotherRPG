using System;
using UnityEngine;
using UnityEngine.AI;
using QuestTales.Core.Abilities;

public class AIController : UnitController
{
    private NavMeshAgent myAgent;
    private GameObject target;
    public SteeringBehaviours sb;
    public bool isActive;

    public void SetupNavMeshAgent()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.updateRotation = false;
        myAgent.updateUpAxis = false;
    }

    public void AimToPlayer()
    {
        var direction = (target.transform.position-transform.position).normalized;
        var newDirection = transform.position + direction;
        abilityController.abilityAim.SetAimDirection(newDirection);
        float angle = abilityController.abilityAim.GetUnitCircleAimAngle();
        abilityController.abilityAim.AimWeaponTowardsDirection(angle,abilityController.offset);
    }

    public override void AimInput()
    {
        AimToPlayer();
    }

    public void MoveToDestination(Vector3 destination)
    {
        myAgent.SetDestination(destination);
    }

    public void ChasePlayer()
    {
        sb.SeekAgent(myAgent, target);
        sb.Wander(myAgent, target);
    }

    public override void Start()
    {
        base.Start();
        SetupNavMeshAgent();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public void CallAbility()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            abilityController.SetCurrentAbility(IdType.HolyStrike);
            if (abilityController.currentAbility != null)
            {
                unitCombat.ReduceCooldown(0.85f);
                if (unitCombat.attackCooldown < 0.1f)
                {
                    abilityController.CastAbility();
                }
            }
        }
    }

    public void Update()
    {
        AimInput();
        CallAbility();
    }
}