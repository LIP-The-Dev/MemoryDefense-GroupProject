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
        if (MaxForm)
        {
            FinalShoot();
            Invoke("Shoot", AttackCooldown);
            return;
        }
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

    void FinalShoot()
    {
        Vector3 projSpawnSide1 = new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z+1);
        Vector3 projSpawnSide2 = new Vector3(transform.position.x,transform.position.y - 0.5f,transform.position.z+1);
        Vector3 projSpawnVert1 = new Vector3(transform.position.x + 0.5f,transform.position.y,transform.position.z+1);
        Vector3 projSpawnVert2 = new Vector3(transform.position.x - 0.5f,transform.position.y,transform.position.z+1);
        GameObject proj = Instantiate(ProjectilePrefab, projSpawnSide1, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.right);
        proj = Instantiate(ProjectilePrefab, projSpawnSide2, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.right);
        
        proj = Instantiate(ProjectilePrefab, projSpawnSide1, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.left);
        proj = Instantiate(ProjectilePrefab, projSpawnSide2, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.left);
        
        proj = Instantiate(ProjectilePrefab, projSpawnVert1, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.down);
        proj = Instantiate(ProjectilePrefab, projSpawnVert2, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.down);
        
        proj = Instantiate(ProjectilePrefab, projSpawnVert1, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.up);
        proj = Instantiate(ProjectilePrefab, projSpawnVert2, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(Vector3.up);
    }

    public override void Sell()
    {
        int x = (int)Math.Round(transform.position.x);
        int y = (int)Math.Round(transform.position.y);
        GameManagerBehaviour.GetInstance().setFree(x,y, true);
        GameManagerBehaviour.GetInstance().setFree(x - 1,y, true);
        GameManagerBehaviour.GetInstance().setFree(x -1,y - 1, true);
        GameManagerBehaviour.GetInstance().setFree(x,y - 1, true);
        Destroy(gameObject);
        int newCost = (int) (Cost * Percent);
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
