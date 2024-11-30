using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TowerBehaviour : MonoBehaviour
{
    [SerializeField] protected float AttackSpeed;

    [SerializeField] protected int AttackDamage;

    [SerializeField] protected GameObject ProjectilePrefab;

    [SerializeField] protected float MaxRange;

    [SerializeField] protected int Cost;
    
    [SerializeField] protected double Percent = 0.45;
    
    [SerializeField] protected int UpgradeCost;
    
    [SerializeField] protected Canvas UpgradeCanvas;

    [SerializeField] protected Button ButtonPrefab;
    
    [SerializeField] protected Canvas MainCanvas;
    
    [SerializeField] protected Canvas ShopCanvas;
    
    protected Button SelectTowerButton;

    protected int UpgradeIndex = 0;
    
    [SerializeField] protected Sprite BaseSprite;
    [SerializeField] protected Sprite UpgradeOneSprite;
    [SerializeField] protected Sprite UpgradeTwoSprite;
    [SerializeField] protected Sprite UpgradeFinalSprite;

    protected Sprite CurrentSprite;
    // Start is called before the first frame update
    void Start()
    {
        UpgradeCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSprite = BaseSprite;
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

    protected virtual void setAttackSpeed(float value)
    {
        AttackSpeed = value;
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

    public virtual int getCost()
    {
        return Cost;
    }

    public virtual void setFix()
    {
        if(!SelectTowerButton) SelectTowerButton = Instantiate(ButtonPrefab, transform.position, Quaternion.identity);
        SelectTowerButton.transform.SetParent(MainCanvas.transform);
        SelectTowerButton.onClick.AddListener(ButtonPressed);
    }

    protected virtual void ButtonPressed()
    {
        UpgradeCanvas.enabled = true;
        UpgradeCanvas.GetComponent<UpgradeCanvasBehaviour>().setTower(gameObject);
        ShopCanvas.enabled = false;
    }

    public int getUpgradeIndex()
    {
        return UpgradeIndex;
    }
}