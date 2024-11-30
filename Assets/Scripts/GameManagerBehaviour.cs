using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    private int Lives;
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
    private static GameManagerBehaviour Instance;
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
        if(Lives < 1) SceneManager.LoadScene("GameOver");
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

    void updateStats()
    {
        StatsText.text = "Lives: " + Lives + "\nMemory: " + Currency + "\nScore: " + Score;
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
}
