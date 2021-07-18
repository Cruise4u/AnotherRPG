using System;
using UnityEngine;

[CreateAssetMenu]
public class ColliderData : ScriptableObject
{
    public Vector3 size;
    public Vector3 offset;
    public float radius;
    public float length;
    public int angle;
    public int vertices;
}