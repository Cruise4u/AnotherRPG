using System;
using UnityEngine;

public class NavMeshAgentTest : MonoBehaviour
{
    public AIController controller;
    public Camera testCamera;

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePoint = testCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, testCamera.nearClipPlane));
            controller.MoveToDestination(mousePoint);
        }
    }

}
