﻿using System;
using UnityEngine;

public static class Mathematics
{
    public static float GetAngleIn360(Vector2 point)
    {
        float angle = (Mathf.Atan2(point.x, point.y) / Mathf.PI) * 180f;
        if (angle < 0.0f)
        {
            angle += 360f;
        }
        return angle;
    }

    public static Vector3 GetVectorRotatedPosition(Vector3 vector, float angle)
    {
        float xAngle = vector.x * Mathf.Cos(angle * Mathf.Deg2Rad) - vector.y * Mathf.Sin(angle * Mathf.Deg2Rad);
        float yAngle = vector.x * Mathf.Sin(angle * Mathf.Deg2Rad) + vector.y * Mathf.Cos(angle * Mathf.Deg2Rad);
        return new Vector3(xAngle, yAngle, 0.0f);
    }







}
