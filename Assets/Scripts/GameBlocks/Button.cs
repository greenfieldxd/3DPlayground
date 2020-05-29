﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
    [SerializeField] float waitTime = 4f;
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float moveValueButton = -0.9f;
    [SerializeField] float moveValueBox = 2f;

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
        StartCoroutine(TimeDelay(waitTime)); //DoTween with delay   
    }

    IEnumerator TimeDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOMoveY(startYPosButton, moveTime);
        box.transform.DOShakePosition(0.2f, 1f, 60, 360f, false); //Do Shake Box
        box.transform.DOMoveY(startYPosBox, moveTime).SetEase(Ease.InExpo);
    }

}
