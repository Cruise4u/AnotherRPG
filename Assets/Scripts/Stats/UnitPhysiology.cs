using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UnitPhysiology : MonoBehaviour,IDamagable,IDefeatable,IPushable,IStunnable,IProtectable
{
    public BaseStats stats;
    public UnitUIHandler unitUIHandler;
    public Vector3 pushDirection { get => PushDirection; set => PushDirection = value; }
    private Vector3 PushDirection;

    public void Init()
    {
        stats = GetComponent<BaseStats>();
        unitUIHandler.UpdateHealthValue(stats);
    }

    public void TakeDamage(int damage)
    {
        if(stats.currentHealth >= 1)
        {
            stats.currentHealth -= damage;
            unitUIHandler.DisplayFloatingText("TextPool", damage);
            unitUIHandler.UpdateHealthValue(stats);
        }
    }

    public bool IsAlive()
    {
        if(stats.currentHealth > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Defeat()
    {
        Destroy(gameObject);
    }

    public void Push(Vector3 pushDirection)
    {
        Vector3 direction = transform.position + (transform.position - pushDirection).normalized * 1.2f;
        transform.DOMove(direction, 0.1f);
    }

    public void GetStunned()
    {
        Debug.Log("Stun target!");
    }

    public void GetProtected(int protection)
    {
        stats.armor += protection;
    }
}
