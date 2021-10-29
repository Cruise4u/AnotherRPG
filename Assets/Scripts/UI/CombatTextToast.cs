using System;
using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CombatTextToast : MonoBehaviour
{
    TweenCallback tweenCallback;
    private Vector3 initialPosition;
    private bool isTextActive = false;

    public void FloatUpwards()
    {
        transform.DOLocalMoveY(1, 1.0f).OnComplete(tweenCallback);
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    public void ConvertDamageToText(int damage)
    {
        string message = damage.ToString();
        GetComponent<TextMeshProUGUI>().text = message;
    }

    public IEnumerator WaitForTextToBeDestroyed(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ObjectPool.Instance.ReturnToPool(ObjectPoolRef.AnotherObjectPool, gameObject);
    }

    public void DissolveText()
    {
        StartCoroutine(WaitForTextToBeDestroyed(1.05f));
    }

    public void Start()
    {
        tweenCallback += DissolveText;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnEnable()
    {
        if(isTextActive == true)
        {
            Debug.Log("Being called!");
            initialPosition = transform.position;
            GetComponent<TextMeshProUGUI>().enabled = true;
            FloatUpwards();
            DissolveText();
        }
    }

    public void OnDisable()
    {
        Debug.Log("Being called 2!");
        GetComponent<TextMeshProUGUI>().enabled = false;
        ResetPosition();
        isTextActive = true;
    }

}
