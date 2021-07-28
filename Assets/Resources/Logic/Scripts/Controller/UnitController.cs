using QuestTales.Core.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitController : MonoBehaviour
{
    protected AbilityController abilityController;
    protected UnitPhysiology combatController;
    protected bool isInputBlocked;

    public abstract void AimInput();

    public virtual void FetchUnitComponents()
    {        
        abilityController = GetComponent<AbilityController>();
    }

    public virtual void BlockInput(bool condition)
    {
        isInputBlocked = condition;
    }

    public virtual void Init()
    {
        combatController = GetComponent<UnitPhysiology>();
        abilityController = GetComponent<AbilityController>();
        abilityController.Init();
        abilityController.BlockInputDelegate += BlockInput;
    }
}
