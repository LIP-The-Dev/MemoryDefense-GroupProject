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

    private float boundY = 18f;
    private float boundNegY = -1f;
    private float boundX = 32f;
    private float boundNegX = -1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Virus"))
        {
            other.gameObject.GetComponent<VirenBehaviour>().looseLife(damage);
            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        transform.Translate( ShootingDirection * (Speed * Time.deltaTime));
        if(transform.position.y < boundNegY || transform.position.y > boundY || transform.position.x < boundNegX || transform.position.x > boundX) Destroy(gameObject);
    }

    public void setShootingDirection(Vector3 dir)
    {
        ShootingDirection = dir;
    }
}