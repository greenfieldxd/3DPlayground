using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hammer : MonoBehaviour
{
    [SerializeField] Vector3 rotateValue;
    [SerializeField] float duration = 1.5f;
    [SerializeField] float maxRandomValue = 1.5f;

    Sequence mySequence;
    void Start()
    {
        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DORotate(rotateValue, duration).SetEase(Ease.InOutExpo))
            .SetLoops(-1, LoopType.Yoyo)
            .Pause();

        float randomStartTime = Random.Range(0.1f, maxRandomValue);
        StartCoroutine(SetDelay(randomStartTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement.Instance.Die();
    }
    IEnumerator SetDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        mySequence.Play();
    }
}
