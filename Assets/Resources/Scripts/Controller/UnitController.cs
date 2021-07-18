using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitController : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    protected AbilityController abilityController;
    protected PlayerMovement unitMovement;
    protected UnitCombat unitCombat;
    protected bool isInputBlocked;

    public virtual void FetchUnitComponents()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        abilityController = GetComponent<AbilityController>();
        unitMovement = GetComponent<PlayerMovement>();
    }

    public virtual void ToggleInputBlockage(bool condition)
    {
        isInputBlocked = condition;
    }

    public abstract void MoveInput();

    public abstract void AimInput();

    public virtual void Start()
    {
        unitMovement = new PlayerMovement(transform, rigidBody, 3);
        unitCombat = new UnitCombat();
        abilityController = GetComponent<AbilityController>();
        abilityController.BlockInputDelegate += ToggleInputBlockage;
    }

}
