using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUBehaviour : TowerBehaviour
{
    [SerializeField] private int numberOfProjectiles;
    private float nextAttackTime;

    [SerializeField] private float attackOffset = 1f;

    [SerializeField] private int Cost = -200;

    [SerializeField] private Vector3 direction;
    
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
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float projectileDirXPosition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * MaxRange;
            float projectileDirYPosition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * MaxRange;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, transform.position.z);
            Vector3 projectileMoveDirection = (projectileVector - transform.position).normalized * AttackSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            direction = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            ProjectilePrefab.transform.position += direction * (ProjectileBehaviour.getSpeed() * Time.deltaTime);
            tmpObj.GetComponent<Rigidbody2D>().velocity = direction;

            angle += angleStep;
        }
        
    }

    public override void Sell()
    {
        Destroy(gameObject);
        int newCost = (int) (-Cost * Percent);
        GameManagerBehaviour.GetInstance().updateCurrency(newCost);
    }
}
