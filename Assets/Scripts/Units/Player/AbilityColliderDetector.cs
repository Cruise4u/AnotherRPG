using System;
using System.Linq;
using UnityEngine;
using CustomPrimitiveColliders;

public class AbilityColliderDetector : MonoBehaviour
{
    public GameObject weaponSlot;


    public void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hitted enemy with weapon!");
            var enemy = collider.gameObject;
            var direction = (enemy.transform.position - transform.position).normalized * 1.15f;
            //unitCombat.PushEnemyOnHit(enemy.transform, direction,0.1f);
        }
    }
}

