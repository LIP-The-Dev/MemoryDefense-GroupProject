using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUBehaviour : TowerBehaviour
{
    [SerializeField] private int numberOfProjectiles;

    [SerializeField] private Vector3 direction;

    private static int Cost = 350;
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public override void Upgrade()
    {
        
    }*/

    public override void Shoot()
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
            Invoke("Shoot", AttackCooldown);
        
    }

    public override void Sell()
    {
        Destroy(gameObject);
        int newCost = (int) (-Cost * Percent);
        GameManagerBehaviour.GetInstance().updateCurrency(newCost);
    }
    
    protected override void setUpgrade()
    {
        switch (UpgradeIndex)
        {
            case 1:
            {
                setAttackCooldown(0.5f);
                break;
            }
            case 2:
            {
                setAttackDamage(5);
                break;
            }
            case 3:
            {
                finalUpgrade();
                break;
            }
        }
    }
    
    public static int getCost()
    {
        return Cost;
    }
}
