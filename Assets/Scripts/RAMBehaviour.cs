using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAMBehaviour : TowerBehaviour
{
    private static int Cost= -80;
    private int UpgradeCost;
    private float AttackCooldown = 5f;
    private int AttackDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    public static int getCost()
    {
        return Cost;
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
                setAttackCooldown(2.5f);
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