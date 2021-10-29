using System;
using UnityEngine;
using DG.Tweening;

public class AbilityAim
{
    private Vector3 aimDirection;
    private Transform transform;
    public Vector2 offset;
    public GameObject weapon;
    public AbilityAim(Transform transform,Vector2 offset,GameObject weapon)
    {
        this.transform = transform;
        this.offset = offset;
        this.weapon = weapon;
    }

    public void SetAimDirection(Vector3 direction)
    {
        aimDirection = direction;
    }

    public float GetAimAngle()
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
            weapon.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (angle > 180.0f && angle < 360.0f)
        {
            weapon.transform.position = new Vector3(transform.position.x - offset.x, transform.position.y - offset.y, 0.0f);
            weapon.transform.rotation = Quaternion.Euler(0, 0, -angle);
            weapon.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public bool IsAnglePositive(float angle)
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

