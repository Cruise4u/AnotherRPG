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
    public void CallAbility()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            abilityController.SetCurrentAbility(IdType.Bash);
            if (abilityController.abilityBook.currentAbility != null)
            {
                unitCombat.ReduceCooldown(0.85f);
                if (unitCombat.attackCooldown < 0.1f)
                {
                    abilityController.CastAbility();
                }
            }
        }
    }

    //public void Update()
    //{
    //    AimInput();
    //    CallAbility();
    //    detection.UpdateDetection(gameObject);
    //}
}