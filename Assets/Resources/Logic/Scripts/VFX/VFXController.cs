using System;
using System.Collections;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public GameObject[] vfxObjectArray;
    public void CallVfx(int index, bool isAnglePositive)
    {
        vfxObjectArray[index].SetActive(true);
        StartCoroutine(vfxObjectArray[index].GetComponent<VFXBase>().TriggerVfxRoutine(0.7f, isAnglePositive));
    }
}

