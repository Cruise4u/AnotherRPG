using System;
using System.Collections;
using UnityEngine;

public class SlashVFX : VFXBase
{
    public GameObject twirlVFXObject;
    public GameObject flareVFXObject;

    public void ChangeAlphaCutValue(GameObject vfxObject, float min, float max, float interpolation)
    {
        vfxObject.GetComponent<SpriteMask>().enabled = true;
        vfxObject.GetComponent<SpriteMask>().alphaCutoff = max;
        float value = Mathf.Lerp(max, min, interpolation);
        vfxObject.GetComponent<SpriteMask>().alphaCutoff = value;
    }

    public void SetAlphaCut(GameObject vfxObject,float maxValue)
    {
        vfxObject.GetComponent<SpriteMask>().enabled = true;
        vfxObject.GetComponent<SpriteMask>().alphaCutoff = maxValue;
    }

    public void ChangeSpriteMaskEffect(GameObject vfxObject)
    {
        vfxObject.GetComponent<SpriteMask>().alphaCutoff -= Time.deltaTime * 2;
    }

    public void ChangeSpriteOrientation(GameObject vfxObject, bool isAnglePositive)
    {
        if (isAnglePositive == true)
        {
            vfxObject.transform.localRotation = Quaternion.Euler(0.0f, 180, vfxObject.transform.rotation.z);
        }
        else
        {
            vfxObject.transform.localRotation = Quaternion.Euler(0.0f, 0, vfxObject.transform.rotation.z);
        }
    }
    public override void ClearVFX()
    {
        twirlVFXObject.GetComponent<SpriteMask>().enabled = false;
        flareVFXObject.GetComponent<SpriteMask>().enabled = false;
        twirlVFXObject.GetComponent<SpriteMask>().alphaCutoff = 0.9f;
        flareVFXObject.GetComponent<SpriteMask>().alphaCutoff = 0.7f;
        gameObject.SetActive(false);
    }
    public override IEnumerator TriggerVfxRoutine(float time,bool isAnglePositive)
    {
        ChangeSpriteOrientation(twirlVFXObject, isAnglePositive);
        ChangeSpriteOrientation(flareVFXObject, isAnglePositive);
        SetAlphaCut(twirlVFXObject, 0.9f);
        SetAlphaCut(flareVFXObject, 0.9f);
        yield return new WaitForSeconds(time);
        ClearVFX();
    }

    public void Update()
    {
        ChangeSpriteMaskEffect(twirlVFXObject);
        ChangeSpriteMaskEffect(flareVFXObject);
    }

}