using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float waitTime = 4f;
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float moveValueButton = -0.9f;
    [SerializeField] float moveValueBox = 2f;

    [Header("Shake settings")]
    [SerializeField] float duration = 0.2f;
    [SerializeField] float strength = 1f;
    [SerializeField] int vibration = 60;
    [SerializeField] float randomness = 360f;

    [Header("References to this GameObject components")]
    [SerializeField] CapsuleCollider coll;

    [Header("References to other GameObjects")]
    [SerializeField] GameObject box;

    float startYPosBox;
    float startYPosButton;


    private void Start()
    {
        startYPosBox = box.transform.position.y;
        startYPosButton = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.DOMoveY(moveValueButton, moveTime);
        box.transform.DOMoveY(moveValueBox, moveTime).SetEase(Ease.InExpo);
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeColliderStay();//off collider 
        StartCoroutine(MoveWithTimeDelay(waitTime)); //DoTween with delay   
    }

    IEnumerator MoveWithTimeDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOMoveY(startYPosButton, moveTime).OnComplete(ChangeColliderStay);//меняем состояние коллайдера назад
        box.transform.DOShakePosition(duration, strength, vibration, randomness); //Do Shake Box
        box.transform.DOMoveY(startYPosBox, moveTime).SetEase(Ease.InExpo);
    }

    void ChangeColliderStay()
    {
        coll.enabled = !coll.enabled;
    }

}
