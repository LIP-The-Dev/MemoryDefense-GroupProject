using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirenSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject VirenPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private int waveTime = 5;
    private int amountOfWaves = 1;
    private float pauseTime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnWave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        Instantiate(VirenPrefab, spawnPos, Quaternion.identity);
    }

    //zuerst werden für eine gewisse zeit mit einer gewissen spawnrate viren gespawnt
    //dann wird 10 s gewartet 
    //alle werte werden höher gesetzt
    //repeat 
    
    public IEnumerator spawnWave()
    {
        while (true)
        {
            float currentTime = 0.0f;

            while (waveTime > currentTime)
            {
                spawn();
                yield return new WaitForSeconds(spawnRate);
                currentTime = currentTime+ spawnRate;
            }
            yield return new WaitForSeconds(10);
            amountOfWaves++;
            waveTime = amountOfWaves * 2;
            spawnRate -= 0.01f;
        }
    }
}
