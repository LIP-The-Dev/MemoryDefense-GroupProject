using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : TowerBehaviour
{
    [SerializeField] private Vector3 ShootingDirection = Vector3.up;
    private float nextAttackTime;

    [SerializeField] private float attackOffset = 1f;
    
    //[SerializeField] private int Cost = -100;
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
        
        GameObject proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(ShootingDirection);
        Invoke("Shoot",attackOffset);
    }
    
    /*public override void Sell()
    {
        Destroy(gameObject);
        int newCost = (int) (-Cost * Percent);
        GameManagerBehaviour.GetInstance().updateCurrency(newCost);
    }
    */
}