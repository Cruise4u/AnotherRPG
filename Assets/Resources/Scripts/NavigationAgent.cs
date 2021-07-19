using System;
using UnityEngine;

public class NavigationAgent : MonoBehaviour
{
    public float mass;
    public float maxSpeed;

    [NonSerialized]
    public Vector3 acceleration;
    [NonSerialized]
    public Vector3 steeringForce;
    [NonSerialized]
    public Vector3 position;
    [NonSerialized]
    public Vector3 previousPosition;

    public Vector3 velocity;

    public Vector3 CalculateVelocity()
    {
        Vector3 currentVelocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        return currentVelocity;
    }

    public void Steer(Vector3 newPosition)
    {
        steeringForce = newPosition;
        acceleration = steeringForce / mass;
        velocity = acceleration * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        transform.position += velocity;
    }

}