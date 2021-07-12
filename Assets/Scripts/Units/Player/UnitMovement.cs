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

}
