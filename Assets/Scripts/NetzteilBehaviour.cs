using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        VirenBehaviour viren = other.gameObject.GetComponent<VirenBehaviour>();
        if (viren)
        {
            GameManagerBehaviour.GetInstance().gotHit(viren.getDamage());
        }
    }
}
