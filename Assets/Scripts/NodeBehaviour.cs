using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : TowerBehaviour
{
    [SerializeField] private Vector3 ShootingDirection;
    private float nextAttackTime;
    [SerializeField] private float maxRange=2;

    [SerializeField] private float attackOffset = 1f;
    public static int Cost = -100;
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
        Vector3 projSpawn = new Vector3(transform.position.x,transform.position.y,transform.position.z+1);
        GameObject proj = Instantiate(ProjectilePrefab, projSpawn, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(ShootingDirection);
    }
    
    public override void Sell()
    {
        Destroy(gameObject);
        int newCost = (int) (-Cost * Percent);
        GameManagerBehaviour.GetInstance().updateCurrency(newCost);
    }
    
}