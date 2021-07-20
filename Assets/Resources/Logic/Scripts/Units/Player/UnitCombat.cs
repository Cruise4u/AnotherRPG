using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UnitCombat : IDamagable
{
    public bool isHit;
    public bool isInCombat;
    public float attackCooldown;

    public void ResetCooldown()
    {
        attackCooldown = 1.0f;
    }
 
    public float ReduceCooldown(float timeValue)
    {
        attackCooldown -= Time.deltaTime * timeValue;
        float clampedCooldown = Mathf.Clamp(attackCooldown, 0.0f, 1.0f);
        attackCooldown = clampedCooldown;
        return attackCooldown;
    }

    public void PushEnemyOnHit(Transform transform,Vector3 position,float time)
    {
        transform.DOMove(transform.position + position, 0.1f).SetEase(Ease.Linear);
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
