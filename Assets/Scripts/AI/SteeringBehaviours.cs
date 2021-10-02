using System;
using UnityEngine;
using UnityEngine.AI;

namespace QuestTales.Core.AI.SteeringBehaviours
{
    public static class SteeringBehaviours
    {
        public static void SeekAgent(NavMeshAgent agent, GameObject target)
        {
            if (target.CompareTag("Player"))
            {
                var distance = Vector3.Distance(agent.transform.position, target.transform.position);
                if (distance > 1.5f)
                {
                    var targetAgent = target.GetComponent<NavigationAgent>();
                    Vector3 desiredVelocity = (targetAgent.transform.position - agent.transform.position).normalized * agent.speed;
                    Vector3 steeringForce = agent.transform.position + (desiredVelocity - agent.velocity);
                    agent.SetDestination(steeringForce);
                }

            }
        }

        public static void Wander(NavMeshAgent agent, GameObject target)
        {
            Vector3 newPosition = Mathematics.GeneratePointOnCircle(target.transform.position, 1.0f);
            Vector3 desiredVelocity = (target.transform.position - agent.transform.position).normalized * agent.speed;
            Vector3 steeringForce = newPosition - (agent.transform.position + (desiredVelocity - agent.velocity));
            agent.SetDestination(steeringForce);
        }

        public static void SeekAndFeintTarget(NavMeshAgent agent, GameObject target, float threshold)
        {
            var distance = Vector3.Distance(agent.transform.position, target.transform.position);
            if (distance > threshold)
            {
                Vector3 newPosition = Mathematics.GeneratePointOnCircle(target.transform.position, 3.0f);
                Vector3 desiredVelocity = (target.transform.position - agent.transform.position).normalized * agent.speed;
                Vector3 steeringForce = newPosition - (agent.transform.position + (desiredVelocity - agent.velocity));
                agent.SetDestination(steeringForce);
            }
        }

        public static void StopSteering(NavMeshAgent agent)
        {
            agent.isStopped = true;
        }

        public static void ContinueSteering(NavMeshAgent agent)
        {
            agent.isStopped = false;
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
    }
}
