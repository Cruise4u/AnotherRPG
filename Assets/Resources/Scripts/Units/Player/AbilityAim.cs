using System;
using UnityEngine;
using DG.Tweening;
public class AbilityAim
{
    private Transform transform;
    private GameObject weapon;

    public AbilityAim(Transform transform, GameObject weapon)
    {
        this.transform = transform;
        this.weapon = weapon;
    }

    public Vector3 aimDirection;

    public void SetAimDirection(Vector3 direction)
    {
        aimDirection = direction;
    }

    public float GetAimAngle()
    {
        Vector2 adjustedOrigin = new Vector2(transform.position.x, transform.position.y - 0.7f);
        Vector3 normalizedDirection = new Vector3(aimDirection.x - adjustedOrigin.x, aimDirection.y - adjustedOrigin.y, 0.0f).normalized;
        float angle = Mathematics.GetAngleIn360(normalizedDirection);
        return angle;
    }

    public void AimWeaponTowardsDirection()
    {
        var angle = GetAimAngle();
        if(angle >= 20.0f && angle <= 160.0f)
        {
            weapon.transform.position = new Vector3(transform.position.x + 0.15f, transform.position.y - 0.5f, 0.0f);
            weapon.transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
        else if (angle >= 200.0f && angle <= 340.0f)
        {
            weapon.transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y - 0.5f, 0.0f);
            weapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
    }

    public bool IsAnglePositive()
    {
        bool condition = false;
        if(GetAimAngle() > 0.0f && GetAimAngle() < 180.0f)
        {
            condition = true;
        }
        else if (GetAimAngle() > 180.0f && GetAimAngle() < 360.0f)
        {
            condition = false;
        }
        return condition;
    }
}

