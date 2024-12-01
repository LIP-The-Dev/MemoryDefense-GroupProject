using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class VirenSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject VirenPrefab;
    [SerializeField] private GameObject BossPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private int waveAmount = 5;
    private int waveNumber = 1;
    private int waveDamage = 10;
    private int waveLives = 1;
    private float waveSpeed = 3;
    public TMP_Text waveDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        updateWave();
        StartCoroutine("WaveUI");
        StartCoroutine("spawnWave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        GameObject virus = Instantiate(VirenPrefab, spawnPos, Quaternion.identity);
        virus.GetComponent<VirenBehaviour>().setVirus(waveLives, waveDamage, waveSpeed);
    }

    public void spawnBoss()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        GameObject boss = Instantiate(BossPrefab, spawnPos, Quaternion.identity);
        boss.GetComponent<BossBehaviour>().setVirus(waveLives, waveDamage, waveSpeed);
    }

    //zuerst werden für eine gewisse zeit mit einer gewissen spawnrate viren gespawnt
    //dann wird 10 s gewartet 
    //alle werte werden höher gesetzt
    //repeat 
    
    public IEnumerator spawnWave()
    {
        while (true)
        {
            int currentAmount = 0;
            yield return new WaitForSeconds(2);
            
            while (waveAmount > currentAmount)
            {
                spawn();
                
                yield return new WaitForSeconds(spawnRate);
                currentAmount = currentAmount + 1;
            }
            
            if (waveNumber % 3 == 0)
            {
                spawnBoss();
            }
            
            yield return new WaitForSeconds(10);
            waveNumber++;
            updateWave();
            StartCoroutine("WaveUI");
            waveAmount += 3;
            spawnRate *= 0.9f;
            waveSpeed += waveSpeed*0.01f;
        }
    }

    public void updateWave()
    {
        String wave = "Wave " +waveNumber.ToString();
        waveDisplay.text = wave;
    }
    public IEnumerator WaveUI()
    {
        waveDisplay.enabled = true;
        yield return new WaitForSeconds(2);
        waveDisplay.enabled = false;
        
    }
}
