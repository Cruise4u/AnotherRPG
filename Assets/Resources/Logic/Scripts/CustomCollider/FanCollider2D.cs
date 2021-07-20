/*
Custom-Primitive-Colliders
Copyright (c) 2018 WestHillApps (Hironari Nishioka)
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/
using UnityEngine;

namespace CustomPrimitiveColliders
{
    [AddComponentMenu("CustomPrimitiveColliders/2D/Fan Collider 2D"), RequireComponent(typeof(PolygonCollider2D))]
    public class FanCollider2D : BaseCustomCollider
    {
        [SerializeField]
        public float radius = 1f;
        [SerializeField, Range(1, 360)]
        public int angle = 135;
        [SerializeField]
        public int vertices = 32;

        private void Awake()
        {
            ReCreate(radius, angle, vertices);
        }

#if UNITY_EDITOR

        private void Reset()
        {
            ReCreate(radius, angle, vertices);
        }

        private void OnValidate()
        {
            ReCreate(radius, angle, vertices);
        }

#endif

        public void ReCreate(float radius, int fanAngle, int numVertices = 32)
        {
            Vector2[] points = CreatePoints(radius, fanAngle, numVertices);

            polygonCollider2d.points = null;
            polygonCollider2d.points = points;
        }

        private Vector2[] CreatePoints(float radius, int fanAngle, int numVertices)
        {
            if (radius <= 0f)
            {
                radius = 0.01f;
            }

            fanAngle = Mathf.Clamp(fanAngle, 1, 360);

            if (numVertices < 4)
            {
                numVertices = 4;
            }

            this.radius = radius;
            this.angle = fanAngle;
            vertices = numVertices;

            Vector2[] points = new Vector2[numVertices + (fanAngle == 360 ? 2 : 1)];

            Quaternion quatStep = Quaternion.Euler(0f, 0f, fanAngle / (float)(fanAngle == 360 ? vertices : (numVertices - 1)));

            points[0] = Vector2.zero;

            for (int i = 1; i <= numVertices; i++)
            {
                if (i == 1)
                {
                    points[i] = new Vector2(radius, 0f);
                }
                else
                {
                    points[i] = quatStep * points[i - 1];
                }
            }

            if (fanAngle == 360)
            {
                points[points.Length - 1] = points[1];
            }

            Vector2 meshForward;
            int centerIndex = Mathf.FloorToInt(numVertices / 2);
            if (numVertices % 2 == 0)
            {
                meshForward = (points[centerIndex] - points[0]) + (points[centerIndex + 1] - points[0]);
            }
            else
            {
                meshForward = points[centerIndex + 1] - points[0];
            }

            Quaternion quat = Quaternion.FromToRotation(meshForward, Vector3.up);
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = quat * points[i];
            }

            return points;
        }
    }
}