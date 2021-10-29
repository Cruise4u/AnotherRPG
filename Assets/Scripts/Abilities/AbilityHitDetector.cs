using System;
using UnityEngine;
using CustomPrimitiveColliders;
using System.Collections.Generic;
using System.Collections;
using QuestTales.Core.Abilities;

public class AbilityHitDetector : MonoBehaviour
{
    public Ability ability;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.CompareTag("Player"))
        {
            if(collider.CompareTag("Enemy") && collider != gameObject.GetComponent<Collider2D>() && collider.isTrigger != false)
            {
                Debug.Log("hitted enemy!");
                collider.transform.parent.GetComponent<TargetReference>().pushDirection = transform.position;
                ability.Execute(collider.gameObject.GetComponent<TargetReference>());
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            if (collider.gameObject.CompareTag("Player") && collider != gameObject.GetComponent<Collider2D>() && collider.isTrigger != false)
            {
                ability.ProcessAbility(collider.gameObject);
                collider.transform.parent.GetComponent<TargetReference>().pushDirection = transform.position;
            }
        }
    }


}

