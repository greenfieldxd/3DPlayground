using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup menu;
    [SerializeField] float fadeDuration = 1f;

   public void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        menu.alpha = 0;

        menu.DOFade(1, fadeDuration);
    }

    public void HideMenu()
    {
        menu.DOFade(0, fadeDuration).OnComplete(() => menu.gameObject.SetActive(false));
    }
}
