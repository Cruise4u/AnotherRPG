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
            if(collider.gameObject.CompareTag("Enemy") && collider != gameObject.GetComponent<Collider2D>() && collider.isTrigger != false)
            {
                Debug.Log("Ability Working! Hit Enemy!");
                //ability.ProcessAbility(collider.gameObject);
                //collider.transform.parent.GetComponent<UnitPhysiology>().pushDirection = transform.position;
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            if (collider.gameObject.CompareTag("Player") && collider != gameObject.GetComponent<Collider2D>() && collider.isTrigger != false)
            {
                ability.ProcessAbility(collider.gameObject);
            }
        }
    }

}

