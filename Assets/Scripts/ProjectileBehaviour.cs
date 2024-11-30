using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBehaviour : MonoBehaviour
{
    public static float Speed;

    [SerializeField] protected float ExplosionRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public static float getSpeed()
    {
        return Speed;
    }

    public void OnCollisionEnter(Collision other)
    {
        //TODO
    }
}