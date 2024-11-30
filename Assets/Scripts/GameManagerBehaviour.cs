using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    private int Lives = 100;
    private int Currency;
    private float TimeInGame;
    private int Level;
    private int Score;
    [SerializeField] private GameObject Netzteil;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject Pfad;
    [SerializeField] private GameObject VirenSpawner;
    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private TMP_Text StatsText;
    [SerializeField] private Canvas Main;
    private static GameManagerBehaviour Instance;

    private bool[,] FelderFree;
    // Start is called before the first frame update    

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        

        Instance = this;
    }

    public static GameManagerBehaviour GetInstance()
    {
        return Instance;
    }
    void Start()
    {
        updateStats();
        FelderFree = new bool[32,18];
        blockUi();
        blockPath();
    }

    void blockUi()
    {
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                FelderFree[i, j] = true;
            }
        }
        for (int i = 23; i < 32; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                FelderFree[i, j] = false;
            }
        }
        for (int i = 28; i < 32; i++)
        {
            for (int j = 5; j < 18; j++)
            {
                FelderFree[i, j] = false;
            }
        }
        for (int i = 22; i < 28; i++)
        {
            for (int j = 15; j < 18; j++)
            {
                FelderFree[i, j] = false;
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 12; j < 18; j++)
            {
                FelderFree[i, j] = false;
            }
        }
    }

    void blockPath()
    {
        for (int i = 0; i < 6; i++)
        {
            FelderFree[i, 10] = false;
        }
        for (int i = 6; i < 10; i++)
        {
            FelderFree[5, i] = false;
        }
        for (int i = 3; i < 5; i++)
        {
            FelderFree[i, 6] = false;
        }
        for (int i = 3; i < 6; i++)
        {
            FelderFree[3, i] = false;
        }
        for (int i = 4; i < 11; i++)
        {
            FelderFree[i, 3] = false;
        }
        for (int i = 4; i < 13; i++)
        {
            FelderFree[10, i] = false;
        }
        for (int i = 11; i < 18; i++)
        {
            FelderFree[i, 12] = false;
        }
        for (int i = 6; i < 12; i++)
        {
            FelderFree[17, i] = false;
        }
        for (int i = 18; i < 21; i++)
        {
            FelderFree[i, 6] = false;
        }
        for (int i = 7; i < 10; i++)
        {
            FelderFree[20, i] = false;
        }
        for (int i = 21; i < 24; i++)
        {
            FelderFree[i, 9] = false;
        }
        for (int i = 5; i < 10; i++)
        {
            FelderFree[24, i] = false;
        }
    }

    public bool isFree(int x ,int y)
    {
        return FelderFree[x,y];
    }
    // Update is called once per frame
    void Update()
    {
        TimeInGame += Time.deltaTime;
        updateTime();
    }

    public void gotHit(int damage)
    {
        if (Lives >= damage) Lives -= damage;
        else Lives = 0;
        if(Lives < 1) SceneManager.LoadScene("Scene GameOver");
        updateStats();
    }

    public void updateCurrency(int value)
    {
        if(Currency + value >= 0) Currency += value;
        updateStats();
    }

    public bool buayble(int value)
    {
        if (Currency + value >= 0) return true;
        else return false;
    }

    public void addToScore(int value)
    {
        Score += value;
        updateStats();
    }

    void updateStats()
    {
        StatsText.text = "Power: " + Lives + "%\nMemory: " + Currency + "\nScore: " + Score;
    }

    void updateTime()
    {
        String min = ((int)TimeInGame / 60).ToString("D2");
        if (min.Equals("60")) min = "0";
        String sec = ((int)TimeInGame % 60).ToString("D2");
        String hours = ((int)TimeInGame / 3600).ToString("D2");
        if(hours.Equals("24")) hours = "0";
        TimeText.text = "Time: \n" + hours + ":" + min + ":" + sec;
    }

    public GameObject getShop()
    {
        return Shop;
    }

    public Canvas getMain()
    {
        return Main;
    }
}
