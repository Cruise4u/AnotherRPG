using System;
using System.Collections;
using UnityEngine;

public class DivineShield : VFXBase
{
    public GameObject starVfx;
    public GameObject bubbleVfx;
    public void SetInitialScale(GameObject vfxObject, float scale)
    {
        vfxObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void ScaleVfxSprite(GameObject vfxObject, float threshold, float amount)
    {
        if(vfxObject.transform.localScale.magnitude < threshold)
        {
            vfxObject.transform.localScale += new Vector3(amount, amount, amount);
        }
    }
    public override void ClearVFX(GameObject vfxObject)
    {
        vfxObject.SetActive(false);
    }
    public override IEnumerator TriggerVfxRoutine(float time, bool isAnglePositive)
    {
        SetInitialScale(starVfx,0.3f);
        SetAlphaCut(starVfx, 0.7f);
        yield return new WaitForSeconds(time);
        ClearVFX(starVfx);
    }
    
    public IEnumerator TriggerStarRoutine()
    {
        SetInitialScale(starVfx,0.3f);
        yield return new WaitForSeconds(1.0f);
    }

    public IEnumerator StartBubbleRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        bubbleVfx.SetActive(true);
        yield return new WaitForSeconds(time);
    }

    public void Update()
    {
        ScaleVfxSprite(starVfx,1.0f,Time.deltaTime);
        ChangeAlphaCutValue(starVfx);
        //if(bubbleVfx.activeSelf == true)
        //{
        //    ScaleVfxSprite(bubbleVfx,0.5f);
        //}
    }
}