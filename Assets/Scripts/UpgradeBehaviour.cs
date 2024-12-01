using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBehaviour : MonoBehaviour
{
    private GameObject TowerToUpgrade;

    [SerializeField] private Button UpgradeButton;
    
    [SerializeField] private TMP_Text UpgradeCost;

    // Start is called before the first frame update
    void Start()
    {
        hideUpgradeButton();
        UpgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Default"));

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Node") || hit.collider.gameObject.CompareTag("CPU") || hit.collider.gameObject.CompareTag("RAM"))
                {
                    TowerToUpgrade = hit.collider.gameObject;
                    showUpgradeButton();
                }
                else hideUpgradeButton();
                if(hit.collider.gameObject.CompareTag("Upgrade")) showUpgradeButton();
            }
            else hideUpgradeButton();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Default"));

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Node") || hit.collider.gameObject.CompareTag("CPU") || hit.collider.gameObject.CompareTag("RAM"))
                {
                    hit.collider.gameObject.GetComponent<TowerBehaviour>().Sell();
                }
            }
        }
    }

    void showUpgradeButton()
    {
        if (TowerToUpgrade != null)
        {
            TowerBehaviour towerBehaviour = TowerToUpgrade.GetComponent<TowerBehaviour>();
            if (towerBehaviour)
            {
                if (towerBehaviour.getUpgradeIndex() >= 3) return;
            }
        }

        // Nehmen wir an, dass die Werte -108.6508f und -353f die neuen Positionen innerhalb des Canvas sein sollen
        Vector2 newPosition = new Vector2(-108.6508f, -395f);
    
        // Erhalte die RectTransform des Buttons
        RectTransform rectTransform = UpgradeButton.GetComponent<RectTransform>();
    
        // Setze die Position relativ zum Canvas
        rectTransform.anchoredPosition = newPosition;

        updateText();
    }

    void hideUpgradeButton()
    {
        // Verstecke den Button, indem du ihn außerhalb des sichtbaren Bereichs positionierst
        UpgradeButton.transform.position = new Vector2(10000f, 10000f);
        UpgradeCost.text = "";
    }
    
    void OnUpgradeButtonClicked()
    {
        if (TowerToUpgrade != null)
        {
            TowerBehaviour towerBehaviour = TowerToUpgrade.GetComponent<TowerBehaviour>();
            if (towerBehaviour != null)
            {
                if (towerBehaviour.getUpgradeIndex() < 3)
                {
                    towerBehaviour.upgrade();
                    Debug.Log(towerBehaviour.getUpgradeIndex());
                }
                updateText();
                if(towerBehaviour.getUpgradeIndex() >= 3) hideUpgradeButton();
            }
        }
    }

    void updateText()
    {
        UpgradeCost.text = TowerToUpgrade.GetComponent<TowerBehaviour>().getUpgradeCost().ToString();
    }
}
