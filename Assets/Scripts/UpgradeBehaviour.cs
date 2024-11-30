using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBehaviour : MonoBehaviour
{
    private GameObject TowerToUpgrade;

    [SerializeField] private Button UpgradeButton;

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
                    showUpgradeButton();
                }
                else hideUpgradeButton();
            }
        }
    }

    void showUpgradeButton()
    {
        // Nehmen wir an, dass die Werte -108.6508f und -353f die neuen Positionen innerhalb des Canvas sein sollen
        Vector2 newPosition = new Vector2(-108.6508f, -353f);
    
        // Erhalte die RectTransform des Buttons
        RectTransform rectTransform = UpgradeButton.GetComponent<RectTransform>();
    
        // Setze die Position relativ zum Canvas
        rectTransform.anchoredPosition = newPosition;
    }

    void hideUpgradeButton()
    {
        // Verstecke den Button, indem du ihn außerhalb des sichtbaren Bereichs positionierst
        UpgradeButton.transform.position = new Vector2(10000f, 10000f);
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
                if (towerBehaviour.getUpgradeIndex() >= 3)
                {
                    UpgradeButton.enabled = false;
                }
            }
        }
    }
}
