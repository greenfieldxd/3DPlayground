using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSound;
    [SerializeField] float rotateTime = 2f;
    [SerializeField] Vector3 rotateVector;


    private void Start()
    {
        LevelManager.Instance.NewCoin();

        Sequence rotate = DOTween.Sequence();
        rotate.Append(transform.DORotate(rotateVector, rotateTime, RotateMode.FastBeyond360))
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        LevelManager.Instance.AddScore();
        AudioManager.Instance.PlaySound(coinSound);
        Destroy(gameObject);
    }
}
