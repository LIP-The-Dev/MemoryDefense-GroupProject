using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirenSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject VirenPrefab;
    [SerializeField] private float spawnSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        Instantiate(VirenPrefab, spawnPos, Quaternion.identity);
        Invoke("spawn", spawnSpeed);
    }
}