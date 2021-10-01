using System;
using System.Collections;
using UnityEngine;

public abstract class VFXBase : MonoBehaviour
{
    public abstract IEnumerator TriggerVfxRoutine(float time, bool isAnglePositive);
    public abstract void ClearVFX(GameObject vfxObject);
    public virtual void SetAlphaCut(GameObject vfxObject, float maxValue)
    {
        vfxObject.GetComponent<SpriteMask>().enabled = true;
        vfxObject.GetComponent<SpriteMask>().alphaCutoff = maxValue;
    }
    public virtual void ChangeAlphaCutValue(GameObject vfxObject)
    {
        vfxObject.GetComponent<SpriteMask>().alphaCutoff -= Time.deltaTime;
    }


}
