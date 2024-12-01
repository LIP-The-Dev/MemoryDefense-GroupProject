using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TowerBehaviour : MonoBehaviour
{
    [SerializeField] protected float AttackCooldown;

    [SerializeField] protected int AttackDamage;

    [SerializeField] protected GameObject ProjectilePrefab;
    
    [SerializeField] protected double Percent;
    
    [SerializeField] protected int UpgradeCost;

    protected int UpgradeIndex = 0;
    [SerializeField] protected Sprite BaseSprite;
    [SerializeField] protected Sprite UpgradeOneSprite;
    [SerializeField] protected Sprite UpgradeTwoSprite;
    [SerializeField] protected Sprite UpgradeFinalSprite;

    protected Sprite CurrentSprite;

    protected bool IsSet = false;

    protected bool MaxForm = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentSprite = BaseSprite;
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public void upgrade()
    {
        if (GameManagerBehaviour.GetInstance().buayble(UpgradeCost * (UpgradeIndex+1)))
        {
            GameManagerBehaviour.GetInstance().subCurrency(UpgradeCost* (UpgradeIndex+1));
            UpgradeIndex++;
            setSprite();
            setUpgrade();
        }
    }

    protected virtual void setUpgrade()
    {
    }

    protected void setSprite()
    {
        switch (UpgradeIndex)
        {
            case 1:
            {
                CurrentSprite = UpgradeOneSprite;
                break;
            }
            case 2:
            {
                CurrentSprite = UpgradeTwoSprite;
                break;
            }
            case 3:
            {
                CurrentSprite = UpgradeFinalSprite;
                break;
            }
            default:
            {
                CurrentSprite = BaseSprite;
                break;
            }
        }
        
        GetComponent<SpriteRenderer>().sprite = CurrentSprite;
    }

    protected void setAttackCooldown(float value)
    {
        AttackCooldown = value;
    }
    
    protected void setAttackDamage(int value)
    {
        AttackDamage = value;
    }
    
    protected void finalUpgrade()
    {
        MaxForm = true;
    }

    public virtual void Shoot()
    {
    }

    public virtual void Sell()
    {
    }

    public int getUpgradeIndex()
    {
        return UpgradeIndex;
    }
    
    public void setFix()
    {
        IsSet = true;
    }

    public bool getFix()
    {
        return IsSet;
    }

    public int getUpgradeCost()
    {
        return UpgradeCost * (UpgradeIndex + 1);
    }
}