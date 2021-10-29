using QuestTales.Core.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitController : MonoBehaviour
{
    public bool isInputBlocked;
    protected AbilityController abilityController;
    protected TargetReference combatController;

    public abstract void AimInput();
    public virtual void Init()
    {
        combatController = GetComponent<TargetReference>();
        abilityController = GetComponent<AbilityController>();
        abilityController.Init();
        abilityController.BlockInputDelegate += BlockInput;
    }

    public virtual void FetchUnitComponents()
    {        
        abilityController = GetComponent<AbilityController>();
    }

    public virtual void BlockInput(bool condition)
    {
        isInputBlocked = condition;
    }

}
