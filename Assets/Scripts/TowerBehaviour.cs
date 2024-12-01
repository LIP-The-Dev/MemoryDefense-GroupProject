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
    // Start is called before the first frame update
    void Start()
    {
        CurrentSprite = BaseSprite;
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public virtual void upgrade()
    {
        if (GameManagerBehaviour.GetInstance().buayble(UpgradeCost))
        {
            GameManagerBehaviour.GetInstance().updateCurrency(UpgradeCost);
            UpgradeIndex++;
            setSprite();
            setUpgrade();
        }
    }

    protected virtual void setUpgrade()
    {
    }

    protected virtual void setSprite()
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
    }

    protected virtual void setAttackCooldown(float value)
    {
        AttackCooldown = value;
    }
    
    protected virtual void setAttackDamage(int value)
    {
        AttackDamage = value;
    }
    
    protected virtual void finalUpgrade()
    {
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
    
}