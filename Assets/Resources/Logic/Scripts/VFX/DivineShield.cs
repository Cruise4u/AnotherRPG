using System;
using System.Collections;
using UnityEngine;

public class DivineShield : VFXBase
{
    public GameObject starVfx;
    public GameObject bubbleVfx;
    public void SetInitialScale(GameObject vfxObject)
    {
        vfxObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }
    public void ScaleVfxSprite(GameObject vfxObject, float threshold)
    {
        if(vfxObject.transform.localScale.magnitude < threshold)
        {
            vfxObject.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
    }
    public override void ClearVFX(GameObject vfxObject)
    {
        vfxObject.SetActive(false);
    }
    public override IEnumerator TriggerVfxRoutine(float time, bool isAnglePositive)
    {
        SetInitialScale(starVfx);
        SetAlphaCut(starVfx, 0.7f);
        yield return new WaitForSeconds(time);
        ClearVFX(starVfx);
    }
    public IEnumerator StartBubbleRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        bubbleVfx.SetActive(true);
        yield return new WaitForSeconds(time);
    }
    public void Update()
    {
        ScaleVfxSprite(starVfx,1.0f);
        ChangeAlphaCutValue(starVfx);
        //if(bubbleVfx.activeSelf == true)
        //{
        //    ScaleVfxSprite(bubbleVfx,0.5f);
        //}
    }
}