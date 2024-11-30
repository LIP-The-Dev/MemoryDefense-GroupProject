using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAMBehaviour : TowerBehaviour
{
    [SerializeField] private int Cost;
    [SerializeField] private int UpgradeCost;
    [SerializeField] private float AttackCooldown = 5f;
    [SerializeField] private int AttackDamage = 2;
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
        GameManagerBehaviour.GetInstance().updateCurrency(AttackDamage);
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
                setAttackSpeed(2.5f);
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
}