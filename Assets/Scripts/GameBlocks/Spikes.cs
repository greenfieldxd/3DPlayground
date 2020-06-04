using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float maxValue = 0.1f;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float waitTime = 1f;


    void Start()
    {
        //another way of moving
        //StartCoroutine(Movement());

        /* 
         * analogue of the method below
         * 
        Sequence movementSequence = DOTween.Sequence();

        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(maxValue, moveTime));
        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(0, moveTime));
        movementSequence.SetLoops(-1);
        */

        Sequence moveSequence = DOTween.Sequence();

        moveSequence.AppendInterval(waitTime/2)
            .Append(transform.DOMoveY(maxValue, moveTime).SetEase(Ease.InExpo))
            .AppendInterval(waitTime/2)
            .SetLoops(-1, LoopType.Yoyo);
    }

    IEnumerator Movement()
    {
        while (true)
        {
            transform.DOMoveY(maxValue, moveTime);
            yield return new WaitForSeconds(waitTime + moveTime);
            transform.DOMoveY(0, moveTime);
            yield return new WaitForSeconds(waitTime + moveTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Die();
    }
}
