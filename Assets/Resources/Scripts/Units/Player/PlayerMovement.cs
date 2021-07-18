using System;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : IMovable
{
    private Transform transform;
    private float speed;
    private Rigidbody2D rb;
    private Vector3 velocity;
    private Vector3 previousPosition;

    public PlayerMovement(Transform transform,Rigidbody2D rb,float speed)
    {
        this.transform = transform;
        this.rb = rb;
        this.speed = speed;
    }

    public void Move(Vector3 position)
    {
        transform.position += position * speed * Time.deltaTime;
        CalculateVelocity();
    }

    public Vector3 CalculateVelocity()
    {
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        return velocity;
    }

}
