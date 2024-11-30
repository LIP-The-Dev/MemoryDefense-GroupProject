using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBehaviour : MonoBehaviour
{
    [SerializeField] protected float AttackSpeed;

    [SerializeField] protected int AttackDamage;

    [SerializeField] protected GameObject ProjectilePrefab;

    [SerializeField] protected float MaxRange;

    [SerializeField] protected int Cost;
    
    [SerializeField] protected double Percent = 0.45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public virtual void upgrade()
    {
        //TODO
    }

    public virtual void Shoot()
    {
    }

    public virtual void Sell()
    {
    }
    
}