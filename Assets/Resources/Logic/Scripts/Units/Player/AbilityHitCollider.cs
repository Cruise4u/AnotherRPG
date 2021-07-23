using System;
using System.Linq;
using UnityEngine;
using CustomPrimitiveColliders;
using System.Collections.Generic;
using System.Collections;

public class AbilityHitCollider : MonoBehaviour
{
    public List<GameObject> hittedTargetsList;

    public void Start()
    {
        hittedTargetsList = new List<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy") && collider != gameObject.GetComponent<Collider2D>() && collider.isTrigger != false)
        {
            hittedTargetsList.Add(collider.gameObject);
            StartCoroutine(CleanListAfterUsingAbility());
            collider.transform.parent.GetComponent<CombatController>().pushDirection = transform.position;
        }
    }

    public IEnumerator CleanListAfterUsingAbility()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Cleaning List!");
        CleanListAfterAbility();
    }

    public void CleanListAfterAbility()
    {
        hittedTargetsList.Clear();
    }

}

