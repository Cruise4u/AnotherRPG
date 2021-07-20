using System;
using UnityEngine;
using DG.Tweening;

public class AbilityAim
{
    private Transform transform;
    private GameObject weapon;
    private Vector3 aimDirection;
    public Vector2 offset;

    public AbilityAim(Transform transform,Vector2 offset,GameObject weapon)
    {
        this.transform = transform;
        this.weapon = weapon;
        this.offset = offset;
    }

    public void SetAimDirection(Vector3 direction)
    {
        aimDirection = direction;
    }

    public float GetUnitCircleAimAngle()
    {
        Vector3 normalizedDirection = new Vector3(aimDirection.x - transform.position.x, aimDirection.y - transform.position.y, 0.0f).normalized;
        float angle = Mathematics.GetAngleIn360(normalizedDirection);
        return angle;
    }

    public void AimWeaponTowardsDirection(float angle,Vector2 offset)
    {
        if(angle > 0.0f && angle < 180.0f)
        {
            weapon.transform.position = new Vector3(transform.position.x + offset.x, transform.position.y - offset.y, 0.0f);
            weapon.transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
        else if (angle > 180.0f && angle < 360.0f)
        {
            weapon.transform.position = new Vector3(transform.position.x - offset.x, transform.position.y - offset.y, 0.0f);
            weapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
    }

    public bool IsAnglePositive(float angle)
    {
        bool condition = false;
        if(GetUnitCircleAimAngle() > 0.0f && GetUnitCircleAimAngle() < 180.0f)
        {
            condition = true;
        }
        else if (GetUnitCircleAimAngle() > 180.0f && GetUnitCircleAimAngle() < 360.0f)
        {
            condition = false;
        }
        return condition;
    }
}

