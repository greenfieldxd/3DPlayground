using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Singleton
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

        score = 0;
        levelCoins = 0;

    }

    [Header("Settings")]
    [SerializeField] GameObject finish;


    public int score { get; private set; }
    public int levelCoins { get; private set; }
    

    public void AddScore()
    {
        score ++;
        CheckCoins();
    }

    public void NewCoin()
    {
        levelCoins ++;
    }

    

    void CheckCoins()
    {
        if (score == levelCoins)
        {
            finish.SetActive(true);
        }
    }



}
