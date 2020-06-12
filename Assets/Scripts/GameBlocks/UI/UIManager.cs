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
    [SerializeField] Slider effectsSlider;

    public void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        menu.alpha = 0;
        menu.DOFade(1, fadeDuration).SetUpdate(true);

        Time.timeScale = 0;

        musicSlider.value = AudioManager.Instance.GetMusicVolume() * musicSlider.maxValue;
        effectsSlider.value = AudioManager.Instance.GetEffectsVolume() * effectsSlider.maxValue;
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
        //делим на maxValue для того чтобы совпадало значение в слайдере от 1 до 10, а в AudioManager от 0.1 до 1
        AudioManager.Instance.SetMusicVolume(musicSlider.value / musicSlider.maxValue);
    }

    public void EffectsVolumeChanged()
    {
        //делим на maxValue для того чтобы совпадало значение в слайдере от 1 до 10, а в AudioManager от 0.1 до 1

        AudioManager.Instance.SetEffectsVolume(effectsSlider.value / effectsSlider.maxValue);
    }
}
