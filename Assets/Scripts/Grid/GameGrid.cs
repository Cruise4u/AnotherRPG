using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public Grid grid;

    public void Check()
    {
        Vector3Int gridCenter = grid.WorldToCell(grid.transform.position);
        Vector3 logicalCenter =  grid.GetCellCenterWorld(gridCenter);
        Debug.Log(gridCenter);
        Debug.Log(logicalCenter);
    }


    public void Start()
    {
        Check();
    }
}
