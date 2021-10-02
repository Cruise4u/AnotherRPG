using System;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAgent : MonoBehaviour
{
    public float speed;

    public Vector3 velocity;

    public void SteerAgent(Vector3 newPosition)
    {
        transform.position += newPosition * speed * Time.deltaTime;
        if(velocity.magnitude > speed)
        {
            velocity = velocity.normalized * speed;
        }

    }
}