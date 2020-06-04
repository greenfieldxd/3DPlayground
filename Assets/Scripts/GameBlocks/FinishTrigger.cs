using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishTrigger : MonoBehaviour
{
    [Header("FX Settings")]
    [SerializeField] GameObject coolFX;
    [SerializeField] GameObject finishFX;

    [Header("Config")]
    [SerializeField] float delayFX = 1f;
    [SerializeField] float waitTime = 1f;
    [SerializeField] float moveTime = 1.5f;
    [SerializeField] float maxValue = 2f;

    Sequence mySequence;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFX(delayFX));

        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveY(maxValue, moveTime));
        mySequence.AppendInterval(waitTime);
        mySequence.SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.enabled = false;

        Instantiate(finishFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        ScenesLoader.Instance.LoadNextLevel(2f);
    }

    IEnumerator SpawnFX(float delay)
    {
        while (true)
        {
            Instantiate(coolFX, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
