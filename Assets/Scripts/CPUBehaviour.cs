using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUBehaviour : TowerBehaviour
{
    [SerializeField] private int numberOfProjectiles;
    private float nextAttackTime;

    [SerializeField] private float attackOffset = 1f;

    public static  int Cost = -200;

    [SerializeField] private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.time + attackOffset; 
        }
    }

    /*public override void Upgrade()
    {
        
    }*/

    public override void Shoot()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {   
            Vector3 projSpawn = new Vector3(transform.position.x,transform.position.y,transform.position.z+1);
            GameObject proj = Instantiate(ProjectilePrefab, projSpawn, Quaternion.identity);
            proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.up);
            proj = Instantiate(ProjectilePrefab, projSpawn, Quaternion.identity);
            proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.right);
            proj = Instantiate(ProjectilePrefab, projSpawn, Quaternion.identity);
            proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.down);
            proj = Instantiate(ProjectilePrefab, projSpawn, Quaternion.identity);
            proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.left);
        }
        
    }

    public override void Sell()
    {
        Destroy(gameObject);
        int newCost = (int) (-Cost * Percent);
        GameManagerBehaviour.GetInstance().updateCurrency(newCost);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name +" is destroyed");
        if (other.gameObject.CompareTag("CPUProjectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
