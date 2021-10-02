using System;
using UnityEngine;
using DG.Tweening;


public class RangedProjectile : MonoBehaviour
{
    public void SetProjectileNewDirection(GameObject weapon,float range,float time)
    {
        var weaponBasePosition = weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = transform.position + (weaponTipPosition - weaponBasePosition).normalized * range;
        transform.DOMove(weaponDirection, time);
    }

    public void SetProjectileDirection(Vector3 direction,float range,float time)
    {
        Vector3 newDirection = transform.position + (transform.position - direction).normalized * range;
        transform.DOMove(newDirection, time);
    }

    public void SetProjectileOrientation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void RotateProjectileOverTime()
    {

    }
}
