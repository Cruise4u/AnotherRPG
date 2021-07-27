using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class WeaponAnimation
{
    Vector2 weaponOffset;
    Vector2 weaponLocalPosition;

    public void SetAnimationSettings(WeaponAnimationData abilityAnimationData)
    {
        weaponOffset = abilityAnimationData.weaponOffset;
        weaponLocalPosition = abilityAnimationData.weaponLocalPosition;
    }

    public IEnumerator CoroutineSwingTweenAnimation(AbilityController abilityController)
    {
        Sequence sequence = DOTween.Sequence();
        abilityController.BlockInputDelegate.Invoke(true);
        var weaponBasePosition = abilityController.weaponAnimator.weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = abilityController.weaponAnimator.weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * abilityController.currentAbility.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(abilityController.weaponAnimator.weapon.transform.position.x + weaponOffset.x, abilityController.weaponAnimator.weapon.transform.position.y + weaponOffset.y, 0.0f);
        var initialAngle = abilityController.currentAbility.colliderData.angle - 25.0f;
        var finalAngle = abilityController.currentAbility.colliderData.angle + (25.0f * 2.0f);
        if (abilityController.abilityAim.IsAnglePositive(abilityController.abilityAim.GetUnitCircleAimAngle()) != true)
        {
            initialAngle *= -1;
            finalAngle *= -1;
        }
        Quaternion initialRotation = Quaternion.Euler(0, 0, -initialAngle);
        Quaternion finalRotation = Quaternion.Euler(0, 0, -finalAngle);
        Tween forwardLungeTween = abilityController.transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.15f).SetEase(Ease.Linear);
        sequence.Append(abilityController.weaponAnimator.weapon.transform.DOLocalRotate(initialRotation.eulerAngles, 0.15f));
        sequence.Append(abilityController.weaponAnimator.weapon.transform.DOLocalRotate(finalRotation.eulerAngles, 0.15f));
        sequence.Play();
        yield return forwardLungeTween.WaitForCompletion();
        abilityController.BlockInputDelegate.Invoke(false);
    }

    public IEnumerator CoroutineStabTweenAnimation(AbilityController abilityController,float range)
    {
        abilityController.BlockInputDelegate.Invoke(true);
        var weaponBasePosition = abilityController.weaponAnimator.weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = abilityController.weaponAnimator.weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * abilityController.currentAbility.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(abilityController.weaponAnimator.weapon.transform.position.x + weaponOffset.x, abilityController.weaponAnimator.weapon.transform.position.y + weaponOffset.y, 0.0f);
        var angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x);
        Tween forwardLungeTween = abilityController.weaponAnimator.weapon.transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.17f).SetEase(Ease.Linear);
        abilityController.weaponAnimator.weapon.transform.GetChild(0).transform.DOLocalMoveY(Mathf.Sin(angle), 0.17f).SetEase(Ease.OutCirc);
        abilityController.weaponAnimator.weapon.transform.GetChild(0).transform.DOLocalMoveY(0.1f, 0.17f).SetEase(Ease.OutCirc);
        yield return forwardLungeTween.WaitForCompletion();
        abilityController.weaponAnimator.weapon.transform.GetChild(0).transform.localPosition = weaponLocalPosition;
        abilityController.BlockInputDelegate.Invoke(false);
    }

    public IEnumerator CoroutineFullCircleTweenAnimation(AbilityController abilityController)
    {
        abilityController.BlockInputDelegate.Invoke(true);
        var weaponBasePosition = abilityController.weaponAnimator.weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = abilityController.weaponAnimator.weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * abilityController.currentAbility.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(abilityController.weaponAnimator.weapon.transform.position.x + weaponOffset.x, abilityController.weaponAnimator.weapon.transform.position.y + weaponOffset.y, 0.0f);
        Tween forwardLungeTween = abilityController.transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.15f).SetEase(Ease.Linear);
        Vector3 fullRotation;
        if (abilityController.abilityAim.IsAnglePositive(abilityController.abilityAim.GetUnitCircleAimAngle()) != false)
        {
            fullRotation = new Vector3(0, 0, -180);
            abilityController.weaponAnimator.weapon.transform.DORotate(fullRotation, 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
        else
        {
            fullRotation = new Vector3(0, 180, -180);
            abilityController.weaponAnimator.weapon.transform.DORotate(fullRotation, 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
        yield return forwardLungeTween.WaitForCompletion();
        abilityController.weaponAnimator.weapon.transform.GetChild(0).transform.localPosition = weaponLocalPosition;
        abilityController.BlockInputDelegate.Invoke(false);
    }
    
}

