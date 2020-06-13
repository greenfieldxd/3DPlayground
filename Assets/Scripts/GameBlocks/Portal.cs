using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Portal : MonoBehaviour
{
    [Header("FX portal")]
    [SerializeField] GameObject portalFX;

    [Header("Settings")]
    [SerializeField] Vector3 teleportPosition;
    [SerializeField] Vector3 newScale;
    [SerializeField] Vector3 lastScale;
    [SerializeField] float timeScale = 1f;
    [SerializeField] float timeMove = 0.1f;

    GameObject newPortal;
    Sequence mySequence;

    void Start()
    {
        newPortal = Instantiate(portalFX, transform.position,portalFX.transform.rotation);

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(newPortal);

        mySequence = DOTween.Sequence();
        mySequence.AppendCallback(() => newPortal = Instantiate(portalFX, new Vector3(teleportPosition.x, teleportPosition.y - 0.35f, teleportPosition.z), portalFX.transform.rotation))
            .Append(other.gameObject.transform.DOScale(newScale, timeScale))
            .Append(other.gameObject.transform.DOMove(teleportPosition, timeMove))
            .Append(other.gameObject.transform.DOScale(lastScale, timeScale))
            .AppendCallback(() => Destroy(newPortal));

    }
}
