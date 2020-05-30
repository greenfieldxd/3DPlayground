using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] float newPos = -5f;
    [SerializeField] float moveDelay = 1.5f;
    [SerializeField] float checkTime = 1.5f;
    [SerializeField] float moveTime = 2f;
    [SerializeField] float waitTime = 4f;

    [SerializeField]float offset = 0.45f;
    float time;


    private float startPosY;

    private void Start()
    {
        startPosY = transform.position.y;
        
    }

    private void Update()
    {
        time -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(MoveBlockWithDelay(moveDelay));
        time = checkTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (time < 0 && other != null)
        {
            CubeMovement cube = other.GetComponent<CubeMovement>();
            cube.enabled = false;
            other.transform.DOMoveY(newPos + offset, moveTime).SetEase(Ease.InOutExpo).OnComplete(() => cube.Die());

        }
    }



    IEnumerator MoveBlockWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOMoveY(newPos, moveTime).SetEase(Ease.InOutExpo);
        yield return new WaitForSeconds(waitTime);
        transform.DOMoveY(startPosY, moveTime).SetEase(Ease.InExpo);
    }
}
