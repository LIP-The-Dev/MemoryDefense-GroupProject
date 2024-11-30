using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : TowerBehaviour
{
    [SerializeField] private Vector3 ShootingDirection;
    private float nextAttackTime;
    [SerializeField] private float AttackSpeed = 1f;
    [SerializeField] private int Cost = -100;
    [SerializeField] private int UpgradeCost = -200;
    [SerializeField] private int AttackDamage = 1;
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
        Invoke("Shoot", AttackSpeed);
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
                setAttackSpeed(0.5f);
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