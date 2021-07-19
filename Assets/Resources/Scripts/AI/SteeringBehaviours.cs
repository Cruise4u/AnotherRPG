using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavigationAgent))]
public class SteeringBehaviours : MonoBehaviour
{
    public GameObject target;
    public NavigationAgent agent;



    public void Seek(NavigationAgent targetAgent)
    {
        Vector3 desiredVelocity = (targetAgent.position - agent.position).normalized * targetAgent.maxSpeed;
        agent.steeringForce = desiredVelocity - targetAgent.velocity;
        agent.Steer(agent.steeringForce);
    }



    //public void FleeFromTarget(Vector3 targetPosition)
    //{
    //    Vector3 desiredVelocity = (transform.position - targetPosition).normalized * myAgent.speed;
    //    Vector3 steeringForce = desiredVelocity - myAgent.velocity;
    //    myAgent.SetDestination(steeringForce);
    //}

    //public void ArriveLocation(Transform targetTransform)
    //{
    //    Vector3 desiredVelocity = (targetTransform.position - transform.position);

    //    Vector3 steeringForce = new Vector3();

    //    float distance = targetTransform.position.magnitude;

    //    myAgent.SetDestination(targetTransform.position);

    //    if (distance < 3.0f)
    //    {
    //        desiredVelocity = targetTransform.position.normalized * myAgent.speed * distance / 3.0f;
    //        steeringForce = desiredVelocity - myAgent.velocity;
    //    }

    //    myAgent.SetDestination(steeringForce);
    //}

    //public void PursuitTarget(Transform targetTransform,Transform target, NavMeshAgent targetAgent)
    //{
    //    Vector3 newPos = targetTransform.position - targetTransform.position;

    //    Vector3 steeringForce = new Vector3();

    //    float relativeHeading = Vector3.Dot(targetTransform.forward.normalized, targetTransform.forward.normalized);

    //    if (relativeHeading > 0.0f)
    //    {
    //        steeringForce = targetTransform.position;
    //        myAgent.SetDestination(steeringForce);
    //    }
    //    else
    //    {
    //        float lookAheadofTime = newPos.magnitude / (myAgent.speed + targetAgent.speed);

    //        Vector3 getFuturePosition = targetTransform.position + targetAgent.velocity * lookAheadofTime;

    //        steeringForce = getFuturePosition;
    //    }

    //    myAgent.SetDestination(steeringForce);
    //}

    //public void EvadeTarget(Transform targetTransform, NavMeshAgent targetAgent)
    //{
    //    Vector3 newPos = transform.position - targetTransform.position;
    //    Vector3 steeringForce = new Vector3();

    //    float lookAheadOfTime = newPos.magnitude / (myAgent.speed * targetAgent.speed);
    //    Vector3 getFuturePosition = targetTransform.position + targetAgent.velocity * lookAheadOfTime;

    //    steeringForce = getFuturePosition;

    //    myAgent.SetDestination(steeringForce);
    //}

    //public void FaceTarget(Transform targetTransform)
    //{
    //    Vector3 direction = (targetTransform.position - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 0.25f);
    //}

    //public void Wander()
    //{

    //}
}