using System;
using UnityEngine;

public class NavigationAgent : MonoBehaviour
{
    public float mass;
    public float maxSpeed;

    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 desiredVelocity;
    public Vector3 steeringForce;
    public Vector3 position;

    public void Steer()
    {
        velocity += acceleration * Time.deltaTime;
        if(velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
    }


    //public void MoveTowardsDirection()
    //{
    //    position += position * maxSpeed;
    //    velocity = position;
    //}




    //public void Move(Vector3 position)
    //{
    //    position += position * maxSpeed;
    //}



    //public void CalculateSteer(NavigationAgent targetAgent)
    //{
    //    desiredVelocity = (targetAgent.position - position).normalized * maxSpeed;
    //    steeringForce = desiredVelocity - targetAgent.velocity;
    //}



    //public void BaseValueStep()
    //{
    //    acceleration = (steeringForce / mass);
    //    velocity = Vector3.zero;

    //}

}