using System;
using UnityEngine;

public class VFXAnimation : MonoBehaviour
{
    public GameObject[] vfxObjects;

    public void CallNextVFXObject(int index)
    {
        vfxObjects[index].SetActive(true);
        vfxObjects[index].GetComponent<Animator>().SetTrigger("vfxTrigger");
    }



}