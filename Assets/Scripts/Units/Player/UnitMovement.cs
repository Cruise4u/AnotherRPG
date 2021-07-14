using System;
using UnityEngine;
using DG.Tweening;

public class UnitMovement : IMovable
{
    private Transform transform;
    private float speed;
    private Rigidbody2D rb;

    public UnitMovement(Transform transform,Rigidbody2D rb,float speed)
    {
        this.transform = transform;
        this.rb = rb;
        this.speed = speed;
    }

    public void Move(Vector3 position)
    {
        transform.position += position * Time.deltaTime * speed;
    }

    public void MoveToDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(new Vector3(1, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(new Vector3(-1, 0, 0));
        }
    }

}
