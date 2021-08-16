using System;
using System.Collections;
using UnityEngine;

public abstract class VFXBase : MonoBehaviour
{
    public abstract IEnumerator TriggerVfxRoutine(float time,bool isAnglePositive);
    public abstract void ClearVFX();
}
