using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUBehaviour : TowerBehaviour
{
    [SerializeField] private int numberOfProjectiles;
    private float nextAttackTime;

    [SerializeField] private float attackOffset = 1f;

    //[SerializeField] private int Cost = -200;

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
            GameObject proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Vector3 ShootingDirection = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            
            proj.GetComponent<ProjectileBehaviour>().setShootingDirection(ShootingDirection);
            Invoke("Shoot",attackOffset);
        }
        
    }
/*
    public override void Sell()
    {
        Destroy(gameObject);
        int newCost = (int) (-Cost * Percent);
        GameManagerBehaviour.GetInstance().updateCurrency(newCost);
    }
    */
}
