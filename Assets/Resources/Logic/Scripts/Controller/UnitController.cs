using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitController : MonoBehaviour
{
    protected AbilityController abilityController;
    protected UnitCombat unitCombat;
    protected bool isInputBlocked;

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
        unitCombat = new UnitCombat();
        abilityController = GetComponent<AbilityController>();
        abilityController.BlockInputDelegate += ToggleInputBlockage;
    }

}
