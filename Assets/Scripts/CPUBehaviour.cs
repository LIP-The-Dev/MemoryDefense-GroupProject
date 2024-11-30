using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUBehaviour : TowerBehaviour
{
    [SerializeField] private int numberOfProjectiles;

    [SerializeField] private float AttackCooldown = 2f;
    [SerializeField] private int AttackDamage = 1;

    [SerializeField] private int Cost = -200;
    [SerializeField] private int UpgradeCost = -350;

    [SerializeField] private Vector3 direction;
    
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

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name +" is destroyed");
        if (other.gameObject.CompareTag("CPUProjectile"))
        {
            Destroy(other.gameObject);
        }
    }
    
    protected override void setUpgrade()
    {
        switch (UpgradeIndex)
        {
            case 1:
            {
                setAttackCooldown(1);
                break;
            }
            case 2:
            {
                setAttackDamage(2);
                break;
            }
            case 3:
            {
                finalUpgrade();
                break;
            }
        }
    }
}
