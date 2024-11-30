using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : TowerBehaviour
{
    [SerializeField] private Vector3 ShootingDirection;
    [SerializeField] private float AttackCooldown = 5f;
     private int Cost = -100;
     private int UpgradeCost = -200;
    [SerializeField] private int AttackDamage = 1;
    [SerializeField] private int UpgradeAttackCooldown = 10;
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
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(ShootingDirection);
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
                setAttackSpeed(UpgradeAttackCooldown);
                break;
            }
            case 2:
            {
                setAttackDamage(3);
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