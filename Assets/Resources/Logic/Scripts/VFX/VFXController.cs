using System;
using System.Collections;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public Animator vfxAnimator;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            BeginVFXAnimation();
        }
    }

    public void BeginVFXAnimation()
    {
        vfxAnimator.SetTrigger("vfxTrigger");
    }



}
