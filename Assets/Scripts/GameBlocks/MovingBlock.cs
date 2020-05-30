using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] float newPos = -5f;
    [SerializeField] float moveDelay = 1.5f;
    [SerializeField] float moveTime = 2f;
    [SerializeField] float waitTime = 4f;

    private float startPosY;

    private void Start()
    {
        startPosY = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(MoveBlockWithDelay(moveDelay));
    }



    IEnumerator MoveBlockWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOMoveY(newPos, moveTime).SetEase(Ease.InOutExpo);
        yield return new WaitForSeconds(waitTime);
        transform.DOMoveY(startPosY, moveTime).SetEase(Ease.InExpo);
    }
}
