using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UnitCombat
{
    TweenCallback ArcMeleeAnimationDelegate;
    public bool isHit;
    public bool isInCombat;
    public float attackCooldown;

    public void ResetCooldown()
    {
        attackCooldown = 0.5f;
    }
 
    public float ReduceCooldown(float timeValue)
    {
        attackCooldown -= Time.deltaTime * timeValue;
        float clampedCooldown = Mathf.Clamp(attackCooldown, 0.0f, 1.0f);
        attackCooldown = clampedCooldown;
        return attackCooldown;
    }

    public void MeleeSwingTweening(float arcAngle,GameObject weaponGO,UnitAim unitAim,UnitController controller)
    {
        Sequence sequence = DOTween.Sequence();
        var currentWeaponAngle = unitAim.GetAngleFromRotation();
        var initialAngle = currentWeaponAngle + arcAngle;
        var finalAngle = initialAngle - arcAngle * 2;
        Quaternion initialRotation = Quaternion.Euler(0, 0, -initialAngle);
        Quaternion finalRotation = Quaternion.Euler(0, 0, -finalAngle);
        sequence.Append(weaponGO.transform.DORotate(initialRotation.eulerAngles, 0.2f).SetEase(Ease.Linear));
        sequence.Append(weaponGO.transform.DORotate(finalRotation.eulerAngles, 0.2f).SetEase(Ease.Linear));
        sequence.Play();
    }

    public void StabAnimation(Transform transform,GameObject weapon,float range)
    {
        Sequence sequence = DOTween.Sequence();
        var weaponBasePosition = weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * range;
        var angle = Mathematics.GetAngleIn360(new Vector3(weaponDirection.x,weaponDirection.y,0));
        transform.DOMove(weapon.transform.position + weaponDirection, 0.1f).SetEase(Ease.InOutQuad);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(weapon.transform.position.y + Mathf.Sin(angle), 0.1f);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(weapon.transform.position.y + Mathf.Sin(angle), 0.1f);
        ResetCooldown();
    }

    public IEnumerator SwingTweenAnimationCoroutine(Transform transform, GameObject weapon,float angle)
    {
        var initialAngle = angle + 720;
        Quaternion newRotation = Quaternion.Euler(0, 0, -initialAngle);
        Tween swingTween = weapon.transform.DORotate(newRotation.eulerAngles, 0.1f,RotateMode.FastBeyond360).SetEase(Ease.Linear);
        yield return swingTween.WaitForCompletion();
        weapon.transform.GetChild(0).transform.localPosition = new Vector3(0.1f, 0.5f, 0);
    }

    public IEnumerator StabTweenAnimationCoroutine(Transform transform, GameObject weapon, float range)
    {
        var weaponBasePosition = weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * range;
        var angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x);
        var adjustedWeaponPosition = new Vector3(weapon.transform.position.x, weapon.transform.position.y + 0.5f, 0.0f);
        Tween stabTween = transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.17f).SetEase(Ease.Linear);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(Mathf.Sin(angle), 0.17f).SetEase(Ease.OutCirc);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(0.1f, 0.17f).SetEase(Ease.OutCirc);
        yield return stabTween.WaitForCompletion();
        weapon.transform.GetChild(0).transform.localPosition = new Vector3(0.1f, 0.5f, 0);
    }

    public void PushEnemyOnHit(Transform transform,Vector3 position,float time)
    {
        transform.DOMove(transform.position + position, 0.1f).SetEase(Ease.Linear);
    }
}
