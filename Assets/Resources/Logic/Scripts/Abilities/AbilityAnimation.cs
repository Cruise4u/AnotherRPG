using System;
using System.Collections;
using DG.Tweening;
using QuestTales.Core.Abilities;
using UnityEngine;

public class AbilityAnimation
{
    private Transform transform;
    Vector2 weaponOffset;
    Vector2 weaponLocalPosition;

    public AbilityAnimation(AbilityAnimationData animationData,Transform transform)
    {
        this.transform = transform;
        weaponOffset = animationData.weaponOffset;
        weaponLocalPosition = animationData.weaponLocalPosition;
    }

    public void SetAnimationSettings(AbilityAnimationData abilityAnimationData)
    {

    }

    public IEnumerator SwingAnimationRoutine(Ability ability,GameObject weapon,bool isAnglePositive,Action<bool> inputBlockDelegate)
    {
        Sequence sequence = DOTween.Sequence();
        inputBlockDelegate.Invoke(true);
        var weaponBasePosition = weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * ability.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(weapon.transform.position.x + weaponOffset.x, weapon.transform.position.y + weaponOffset.y, 0.0f);
        var initialAngle = ability.colliderData.angle - 25.0f;
        var finalAngle = ability.colliderData.angle + (25.0f * 2.0f);
        if(isAnglePositive != true)
        {
            initialAngle *= -1;
            finalAngle *= -1;
        }
        Quaternion initialRotation = Quaternion.Euler(0, 0, -initialAngle);
        Quaternion finalRotation = Quaternion.Euler(0, 0, -finalAngle);
        Tween forwardLungeTween = transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.15f).SetEase(Ease.Linear);
        sequence.Append(weapon.transform.DOLocalRotate(initialRotation.eulerAngles, 0.15f));
        sequence.Append(weapon.transform.DOLocalRotate(finalRotation.eulerAngles, 0.15f));
        sequence.Play();
        yield return forwardLungeTween.WaitForCompletion();
        inputBlockDelegate.Invoke(false);
    }

    public IEnumerator StabAnimationRoutine(Ability ability, GameObject weapon,Action<bool> inputBlockDelegate)
    {
        inputBlockDelegate.Invoke(true);
        var weaponBasePosition = weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponTipPosition = weapon.transform.GetChild(0).GetChild(1).transform.position;
        var weaponDirection = (weaponTipPosition - weaponBasePosition).normalized * ability.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(weapon.transform.position.x + weaponOffset.x, weapon.transform.position.y + weaponOffset.y, 0.0f);
        var angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x);
        Tween forwardLungeTween = weapon.transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.17f).SetEase(Ease.Linear);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(Mathf.Sin(angle), 0.17f).SetEase(Ease.OutCirc);
        weapon.transform.GetChild(0).transform.DOLocalMoveY(0.1f, 0.17f).SetEase(Ease.OutCirc);
        yield return forwardLungeTween.WaitForCompletion();
        weapon.transform.GetChild(0).transform.localPosition = weaponLocalPosition;
        inputBlockDelegate.Invoke(false);
    }

    public IEnumerator ThreeSixtyAnimationRoutine(Ability ability, GameObject weapon, bool isAnglePositive, Action<bool> inputBlockDelegate)
    {
        inputBlockDelegate.Invoke(true);
        var weaponTipPosition = weapon.transform.GetChild(0).GetChild(0).transform.position;
        var weaponDirection = (weaponTipPosition - transform.position).normalized * ability.colliderData.radius;
        var adjustedWeaponPosition = new Vector3(weapon.transform.position.x + weaponOffset.x, weapon.transform.position.y + weaponOffset.y, 0.0f);
        Tween forwardLungeTween = transform.DOMove(adjustedWeaponPosition + weaponDirection, 0.15f).SetEase(Ease.Linear);
        Vector3 fullRotation;
        if(isAnglePositive != false)
        {
            fullRotation = new Vector3(0, 0, -180);
            weapon.transform.DORotate(fullRotation, 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
        else
        {
            fullRotation = new Vector3(0, 180, -180);
            weapon.transform.DORotate(fullRotation, 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
        yield return forwardLungeTween.WaitForCompletion();
        weapon.transform.GetChild(0).transform.localPosition = weaponLocalPosition;
        inputBlockDelegate.Invoke(false);
    }
    
}

