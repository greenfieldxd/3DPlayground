using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup menu;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] Slider musicSlider;

    public void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        menu.alpha = 0;
        menu.DOFade(1, fadeDuration).SetUpdate(true);

        Time.timeScale = 0;

        musicSlider.value = AudioManager.Instance.GetMusicVolume() * musicSlider.maxValue;
    }

    public void HideMenu()
    {
        menu.DOFade(0, fadeDuration).SetUpdate(true).OnComplete(() =>
            {
                menu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        );

    }

    public void MusicVolumeChanged()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value / musicSlider.maxValue);
    }
}
