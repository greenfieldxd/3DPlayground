using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    #endregion

    [Header("Settings")]
    [SerializeField] GameObject finish;
    [SerializeField] int levelCoins;

    public static int score { get; private set; }
    
    void Start()
    {
        score = 0;
    }

    public void AddCoin(int plusScore)
    {
        score += plusScore;
        CheckCoins();
    }

    void CheckCoins()
    {
        if (score == levelCoins)
        {
            finish.SetActive(true);
        }
    }



}
