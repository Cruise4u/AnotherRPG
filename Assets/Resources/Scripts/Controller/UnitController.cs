using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitController : MonoBehaviour
{
    protected AbilityController abilityController;
    protected NavigationAgent navAgent;
    protected UnitCombat unitCombat;
    protected bool isInputBlocked;

    public abstract void MoveInput();
    public abstract void AimInput();

    public virtual void ToggleInputBlockage(bool condition)
    {
        isInputBlocked = condition;
    }

    public virtual void FetchUnitComponents()
    {        
        abilityController = GetComponent<AbilityController>();
    }

    public virtual void Start()
    {
        navAgent = GetComponent<NavigationAgent>();
        unitCombat = new UnitCombat();
        abilityController = GetComponent<AbilityController>();
        abilityController.BlockInputDelegate += ToggleInputBlockage;
    }

}
