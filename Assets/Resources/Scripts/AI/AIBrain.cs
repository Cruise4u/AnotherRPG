using System;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    GameObject target;
    public Vector3 DesiredVelocity { get; set; }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    //public void Seek()
    //{
    //    Vector3 targetDirection = (target.transform.position - transform.position);
    //    DesiredVelocity = targetDirection.normalized * target.GetComponent<Rigidbody2D>().velocity.magnitude;
    //    Vector3 steeringForce = desiredVelocity - targetAgent.velocity;
    //    myAgent.SetDestination(steeringForce);
    //    Debug.Log("Agent Moving!");
    //}


    public void GetCurrentSteeringBehaviourValues()
    {

    }



}
