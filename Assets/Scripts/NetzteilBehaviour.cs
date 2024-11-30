using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NetzteilBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        VirenBehaviour viren = other.gameObject.GetComponent<VirenBehaviour>();
        if (viren)
        {
            GameManagerBehaviour.GetInstance().gotHit(viren.getDamage());
            GetComponent<VideoPlayer>().Play();
            Destroy(other.gameObject);
        }
    }
}
