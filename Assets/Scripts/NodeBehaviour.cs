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

    public void UpdateShootingDirection(float rotationAngle)
    {
        // Normalisiere den Winkel auf den Bereich [0, 360)
        float normalizedAngle = (transform.eulerAngles.z + rotationAngle) % 360;

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
            ShootingDirection = Vector2.right; // 90 Grad -> nach rechts
        }
        else if (normalizedAngle == 180)
        {
            ShootingDirection = Vector2.down; // 180 Grad -> nach unten
        }
        else if (normalizedAngle == 270)
        {
            ShootingDirection = Vector2.left; // 270 Grad -> nach links
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