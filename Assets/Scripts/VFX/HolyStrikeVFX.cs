using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HolyStrikeVFX : VFXBase
{
    public GameObject twirlVFXObject;

    public void ChangeSpriteOrientation(GameObject vfxObject, bool isAnglePositive)
    {
        if (isAnglePositive == true)
        {
            vfxObject.transform.localRotation = Quaternion.Euler(0.0f, 180.0f,-35.0f);
        }
        else
        {
            vfxObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -35.0f);
        }
    }  
    public void SetInitialLightIntensity()
    {
        twirlVFXObject.GetComponent<Light2D>().intensity = 0;
    }
    public void ChangeLightIntensity()
    {
        twirlVFXObject.GetComponent<Light2D>().intensity += Time.deltaTime * 3.75f;
    }
    public override void ClearVFX(GameObject vfxObject)
    {
        vfxObject.GetComponent<SpriteMask>().enabled = false;
        vfxObject.GetComponent<SpriteMask>().alphaCutoff = 0.75f;
        gameObject.SetActive(false);
    }
    public override IEnumerator TriggerVfxRoutine(float time, bool isAnglePositive)
    {
        ChangeSpriteOrientation(twirlVFXObject, isAnglePositive);
        SetAlphaCut(twirlVFXObject, 0.1f);
        SetInitialLightIntensity();
        yield return new WaitForSeconds(time);
        ClearVFX(twirlVFXObject);
    }

    public void Update()
    {
        ChangeAlphaCutValue(twirlVFXObject);
        ChangeLightIntensity();
    }

}