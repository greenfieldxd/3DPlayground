using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingBlock : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float newPos = -5f;
    [SerializeField] float moveDelay = 1.5f;
    [SerializeField] float moveTime = 2f;

    [Header("Offset between platform and cube")]
    [SerializeField]float offset = 0.45f;

    [Header("References to this gameobject components")]
    [SerializeField] BoxCollider coll;

    Sequence sequenceMoveBlock;

    CubeMovement cube;

    private float startPosY;
    private bool isCubeHere; //check cube on MovingBlock or not

    private void Start()
    {
        startPosY = transform.position.y;

        sequenceMoveBlock = DOTween.Sequence();
        sequenceMoveBlock.AppendInterval(moveDelay)//Задержка перед движением и проверками
            .AppendCallback(CheckCubeOnBlock)//Проверяем наличие блока на платформе 
            .Append(transform.DOMoveY(newPos, moveTime).SetEase(Ease.InOutExpo))//Двигаем платформу вниз
            .AppendCallback(ChangeColliderStay)//Включаем коллайдер
            .Append(transform.DOMoveY(startPosY, moveTime).SetEase(Ease.InExpo)).OnComplete(() => sequenceMoveBlock.Rewind());//Поднимаем платформу вверх и перематываем Sequence
        sequenceMoveBlock.Pause();
        sequenceMoveBlock.SetAutoKill(false);

       
    }


    private void OnTriggerEnter(Collider other)
    {
        cube = other.GetComponent<CubeMovement>();
        isCubeHere = true;
        sequenceMoveBlock.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        isCubeHere = false;
        ChangeColliderStay();//Выключаем коллайдер если куб выпрыгнул
    }

    

    void CheckCubeOnBlock()
    {
        if (isCubeHere)
        {
            cube.transform.DOMoveY(newPos + offset, moveTime).SetEase(Ease.InOutExpo).OnComplete(() => cube.Die());
            cube.enabled = false;

        }
    }

    void ChangeColliderStay()
    {
        coll.enabled = !coll.enabled;
    }
}
