using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CombatController : MonoBehaviour,IDamagable,IDefeatable
{
    public BaseStats stats;
    public Vector3 pushDirection { get => PushDirection; set => PushDirection = value; }
    private Vector3 PushDirection;

    public void Start()
    {
        stats = GetComponent<BaseStats>();
    }

    public void Push(Vector3 direction)
    {
        PushDirection = transform.position + (transform.position - direction).normalized * 1.1f;
        transform.DOMove(PushDirection, 0.1f);
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("I " + gameObject.name + " Took Damage!");
        Push(PushDirection);
        //stats.currentHealth -= damage;
        //if(stats.currentHealth < 1)
        //{
        //    DeathTriggerDelegate.Invoke();
        //}
    }

    public void Defeat()
    {
        Destroy(gameObject);
    }

}
