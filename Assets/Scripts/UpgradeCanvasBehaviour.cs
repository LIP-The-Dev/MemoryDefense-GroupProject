using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCanvasBehaviour : MonoBehaviour
{
    private GameObject Tower;

    [SerializeField] private Button ButtonUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        ButtonUpgrade.onClick.AddListener(ButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTower(GameObject tower)
    {
        Tower = tower;
    }

    void ButtonPressed()
    {
        Tower.GetComponent<TowerBehaviour>().upgrade();
        if(Tower.GetComponent<TowerBehaviour>().getUpgradeIndex() == 3) ButtonUpgrade.enabled = false;
    }
    
    
}
