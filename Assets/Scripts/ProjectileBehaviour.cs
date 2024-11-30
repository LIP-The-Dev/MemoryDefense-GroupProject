using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private Vector3 ShootingDirection = Vector3.up;

    [SerializeField] protected float ExplosionRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void OnCollisionEnter(Collision other)
    {
        //TODO
    }
    void Update()
    {
        transform.Translate( ShootingDirection * (Speed * Time.deltaTime));
    }

    public void setShootingDirection(Vector3 dir)
    {
        ShootingDirection = dir;
    }
}