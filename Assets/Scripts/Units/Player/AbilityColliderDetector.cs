using CustomPrimitiveColliders;
using System;
using UnityEngine;

public class AbilityColliderDetector : MonoBehaviour
{
    public BaseCustomCollider abilityCustomCollider;
    public UnitCombat unitCombat;

    public void Start()
    {
        unitCombat = new UnitCombat();
    }

    public void SetCollider(Ability ability)
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hitted enemy with weapon!");
            var enemy = collider.gameObject;
            var direction = (enemy.transform.position - transform.position).normalized * 1.15f;
            unitCombat.PushEnemyOnHit(enemy.transform, direction,0.1f);
        }
    }
}

public class AbilityColliderData
{
    private int radius;
    private int angle;

    public AbilityColliderData(int radius,int angle)
    {
        this.radius = radius;
        this.angle = angle;
    }
}