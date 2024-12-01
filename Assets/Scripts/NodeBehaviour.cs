using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : TowerBehaviour
{
    private static int Cost = 60;
    [SerializeField] private Vector3 ShootingDirection;
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
    public void UpdateShootingDirection()
    {
        // Normalisiere den Winkel auf den Bereich [0, 360)
        float normalizedAngle = transform.eulerAngles.z % 360;

        // Bestimme die Schussrichtung basierend auf dem Winkel
        if (normalizedAngle < 0)
        {
            normalizedAngle += 360;
        }

        if (normalizedAngle == 0)
        {
            ShootingDirection = Vector2.up; // 0 Grad -> nach oben
        }
        else if (normalizedAngle == 90)
        {
            ShootingDirection = Vector2.left; // 90 Grad -> nach links
        }
        else if (normalizedAngle == 180)
        {
            ShootingDirection = Vector2.down; // 180 Grad -> nach unten
        }
        else if (normalizedAngle == 270)
        {
            ShootingDirection = Vector2.right; // 270 Grad -> nach rechts
        }
        else
        {
            // Für den Fall, dass der Winkel nicht genau 0, 90, 180 oder 270 Grad ist
            ShootingDirection = Quaternion.Euler(0, 0, normalizedAngle) * Vector2.up;
        }
    }

    public override void Shoot()
    {
        Vector3 projSpawn = new Vector3(transform.position.x,transform.position.y,transform.position.z+1);
        if (MaxForm)
        {
            Vector3 difdir = new Vector3(0,0,0);
            if(ShootingDirection == Vector3.down) difdir = Vector2.up;
            else if(ShootingDirection == Vector3.up) difdir = Vector2.down;
            else if(ShootingDirection == Vector3.left) difdir = Vector2.right;
            else if(ShootingDirection == Vector3.right) difdir = Vector2.left;
            GameObject proj2 = Instantiate(ProjectilePrefab, projSpawn, Quaternion.identity);
            proj2.GetComponent<ProjectileBehaviour>().setShootingDirection(difdir);
        }
        GameObject proj = Instantiate(ProjectilePrefab, projSpawn, Quaternion.identity);
        proj.GetComponent<ProjectileBehaviour>().setShootingDirection(ShootingDirection);
        Invoke("Shoot", AttackCooldown);
    }
    
    public override void Sell()
    {
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
                setAttackCooldown(1f);
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
    public static int getCost()
    {
        return Cost;
    }
}