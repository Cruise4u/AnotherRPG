using System;
using UnityEngine;

public class AIDetection : MonoBehaviour
{
    public LayerMask detectionMask;
    public GameObject detectionProbeGO;
    public bool isThereTarget;
    private Vector2[] detectionalVectors;
    private int angle;

    public void Init()
    {
        angle = 6;
        int numberOfRays = (360 / angle);
        detectionalVectors = new Vector2[numberOfRays - 1];
    }

    public void UpdateDetection(GameObject self)
    {
        Vector3 detectionDirection = (detectionProbeGO.transform.position - self.transform.position);
        for (int i = 0; i < detectionalVectors.Length; i++)
        {
            var temporaryAngle = angle * i;
            detectionalVectors[i] = Mathematics.GetVectorRotatedPosition(detectionDirection, temporaryAngle);
            SendDetectionRaycastAroundUnit(self,detectionalVectors[i],detectionalVectors[i].magnitude);
        }
    }

    public void SendDetectionRaycastAroundUnit(GameObject self, Vector3 direction,float distance)
    {
        RaycastHit2D castHit = Physics2D.Raycast(self.transform.position, direction, distance, detectionMask);
        if(castHit.collider != null && castHit.collider.gameObject != gameObject)
        {
            if (castHit.collider.gameObject.CompareTag("Player"))
            {
                isThereTarget = true;
            }
        }
    }

}
