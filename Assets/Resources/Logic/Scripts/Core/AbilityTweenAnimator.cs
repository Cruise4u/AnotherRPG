using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public static class AbilityTweenAnimator
{
    public static IEnumerator CoroutineSwingTweenAnimation(AbilityController abilityController)
    {
        abilityController.BlockInputDelegate.Invoke(true);
        var weaponBasePosition = abilityController.weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = abilityController.weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * abilityController.currentAbility.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(abilityController.weapon.transform.position.x, abilityController.weapon.transform.position.y + 0.5f, 0.0f);
        var initialAngle = abilityController.currentAbility.colliderData.angle - 10.0f;
        var finalAngle = abilityController.currentAbility.colliderData.angle + (10.0f * 2.0f);
        Sequence sequence = DOTween.Sequence();
        Quaternion initialRotation = Quaternion.Euler(0, 0, -initialAngle);
        Quaternion finalRotation = Quaternion.Euler(0, 0, -finalAngle);
        Tween forwardLungeTween = abilityController.transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.15f).SetEase(Ease.Linear);
        sequence.Append(abilityController.weapon.transform.DOLocalRotate(initialRotation.eulerAngles, 0.1f));
        sequence.Append(abilityController.weapon.transform.DOLocalRotate(finalRotation.eulerAngles, 0.2f));
        sequence.Play();
        yield return forwardLungeTween.WaitForCompletion();
        abilityController.BlockInputDelegate.Invoke(false);
    }

    public static IEnumerator CoroutineStabTweenAnimation(Transform transform, GameObject weapon, float range)
    {
        var weaponBasePosition = weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * range;
        var angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x);
        var adjustedWeaponPosition = new Vector3(weapon.transform.position.x, weapon.transform.position.y + 0.5f, 0.0f);
        Tween forwardLungeTween = transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.17f).SetEase(Ease.Linear);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(Mathf.Sin(angle), 0.17f).SetEase(Ease.OutCirc);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(0.1f, 0.17f).SetEase(Ease.OutCirc);
        yield return forwardLungeTween.WaitForCompletion();
        weapon.transform.GetChild(0).transform.localPosition = new Vector3(0.1f, 0.5f, 0);
    }

    public static IEnumerator CoroutineFullCircleTweenAnimation(AbilityController abilityController)
    {
        var weaponBasePosition = abilityController.weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = abilityController.weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * abilityController.currentAbility.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(abilityController.weapon.transform.position.x, abilityController.weapon.transform.position.y + 0.5f, 0.0f);
        Tween forwardLungeTween = abilityController.transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.15f).SetEase(Ease.Linear);
        Vector3 fullRotation;
        if (abilityController.abilityAim.IsAnglePositive(abilityController.abilityAim.GetUnitCircleAimAngle()) != false)
        {
            fullRotation = new Vector3(0, 0, -180);
            abilityController.weapon.transform.DORotate(fullRotation, 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
        else
        {
            fullRotation = new Vector3(0, 180, -180);
            abilityController.weapon.transform.DORotate(fullRotation, 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
        yield return forwardLungeTween.WaitForCompletion();
        abilityController.weapon.transform.GetChild(0).transform.localPosition = new Vector3(0.1f, 0.5f, 0);
        Debug.Log("Finished Animation!");
    }
}
