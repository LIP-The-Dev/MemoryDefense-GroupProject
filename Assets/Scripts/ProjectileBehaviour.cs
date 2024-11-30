using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private Vector3 ShootingDirection = Vector3.up;
    private int damage = 1;

    [SerializeField] protected float ExplosionRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Virus"))
        {
            other.gameObject.GetComponent<VirenBehaviour>().looseLife(damage);
        }
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