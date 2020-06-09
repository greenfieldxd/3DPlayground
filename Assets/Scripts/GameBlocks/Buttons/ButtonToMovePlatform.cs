using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonToMovePlatform : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float waitTime = 4f;
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float moveValueButton = -0.9f;
    [SerializeField] float moveValuePlatform = 2f;



    [Header("References to this GameObject components")]
    [SerializeField] CapsuleCollider coll;

    [Header("Reference Moving GameObject")]
    [SerializeField] GameObject[] platforms;




    private void OnTriggerEnter(Collider other)
    {
        transform.DOMoveY(moveValueButton, moveTime);
        foreach (var item in platforms)
        {
            item.transform.DOMoveZ(moveValuePlatform, moveTime).SetEase(Ease.InExpo);
        }
        ChangeColliderStay();
    }


    void ChangeColliderStay()
    {
        coll.enabled = !coll.enabled;
    }
}
