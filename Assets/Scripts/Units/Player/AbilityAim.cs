using System;
using UnityEngine;
using DG.Tweening;
public class AbilityAim
{
    private Camera camera;
    private Transform transform;
    private GameObject weapon;

    public AbilityAim(Camera camera,Transform transform, GameObject weapon)
    {
        this.camera = camera;
        this.transform = transform;
        this.weapon = weapon;
    }

    public float GetAimAngle(Vector3 mousePosition)
    {
        Vector2 adjustedOrigin = new Vector2(transform.position.x, transform.position.y - 0.7f);
        Vector2 aimPoint = new Vector3(mousePosition.x, mousePosition.y,0.0f);
        Vector2 aimDirection = (aimPoint - adjustedOrigin).normalized;
        float angle = Mathematics.GetAngleIn360(aimDirection);
        return angle;
    }

    public void SetWeaponAimAtMouse()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
        var angle = GetAimAngle(mousePosition);
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
}
