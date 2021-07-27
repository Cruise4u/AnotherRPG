using System;
using System.Linq;
using UnityEngine;
using CustomPrimitiveColliders;
using System.Collections.Generic;
using System.Collections;

public class AbilityHitHandler : MonoBehaviour
{
    public List<GameObject> hittedTargetsList;

    public void Start()
    {
        hittedTargetsList = new List<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.CompareTag("Player"))
        {
            if(collider.gameObject.CompareTag("Enemy") && collider != gameObject.GetComponent<Collider2D>() && collider.isTrigger != false)
            {
                MarkTarget(collider.gameObject);
                StartCoroutine(CleanListAfterUsingAbility());
                collider.transform.parent.GetComponent<UnitPhysiology>().pushDirection = transform.position;
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            if (collider.gameObject.CompareTag("Player") && collider != gameObject.GetComponent<Collider2D>() && collider.isTrigger != false)
            {
                MarkTarget(collider.gameObject);
                StartCoroutine(CleanListAfterUsingAbility());
                collider.transform.parent.GetComponent<UnitPhysiology>().pushDirection = transform.position;
            }
        }
    }

    public void MarkTarget(GameObject target)
    {
        if(!hittedTargetsList.Contains(target))
        {
            hittedTargetsList.Add(target);
            Debug.Log("It doesn't contain the target");
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

