using System;
using UnityEngine;
using DG.Tweening;
public class UnitAim
{
    private static RaycastHit2D raycastHit;
    private float currentAngle;
    private Transform transform;
    private GameObject aimGO;
    private GameObject weaponGO;

    public UnitAim(Transform transform, GameObject aimGO,GameObject weaponGO)
    {
        this.transform = transform;
        this.aimGO = aimGO;
        this.weaponGO = weaponGO;
    }

    public float GetAngleFromRotation()
    {
        Vector2 adjustedOrigin = new Vector2(transform.position.x, transform.position.y - 0.7f);
        Vector2 aimPoint = new Vector2(aimGO.transform.position.x, aimGO.transform.position.y);
        Vector2 aimDirection = (aimPoint - adjustedOrigin).normalized;
        float angle = Mathematics.GetAngleIn360(aimDirection);
        return angle;
    }

    public void AimWeaponAtMouseIndicator(Camera camera,SpriteRenderer spriteRenderer)
    {
        aimGO.transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
        var angle = GetAngleFromRotation();
        if(angle >= 20.0f && angle <= 160.0f)
        {
            weaponGO.transform.position = new Vector3(transform.position.x + 0.15f, transform.position.y - 0.5f, 0.0f);
            weaponGO.transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
        else if (angle >= 200.0f && angle <= 340.0f)
        {
            weaponGO.transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y - 0.5f, 0.0f);
            weaponGO.transform.rotation = Quaternion.Euler(0, -180, angle);
        }

    }
}
