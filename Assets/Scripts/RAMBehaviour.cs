using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAMBehaviour : TowerBehaviour
{
    [SerializeField] private int Cost = -300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    
    /*public override void Upgrade()
    {

    }*/

    public override void Shoot()
    {
        GameManagerBehaviour.GetInstance().updateCurrency(AttackDamage);
    }
    
    public override void Sell()
    {
        Destroy(gameObject);
        int newCost = (int) (-Cost * Percent);
        GameManagerBehaviour.GetInstance().updateCurrency(newCost);
    }
}