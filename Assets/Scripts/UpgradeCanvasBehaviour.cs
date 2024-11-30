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
    
    public void DisableButtons()
    {
        foreach (Transform child in transform)
        {
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                // Unsichtbar machen
                Image buttonImage = button.GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = new Color(0, 0, 0, 0); // Vollständig transparent
                }

                // Interaktivität deaktivieren
                button.interactable = false;
            }
        }
    }

    // Aktiviert alle Buttons (sichtbar und interagierbar)
    public void EnableButtons()
    {
        foreach (Transform child in transform)
        {
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                // Sichtbar machen
                Image buttonImage = button.GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = new Color(1, 1, 1, 1); // Standardfarbe (weiß)
                }

                // Interaktivität aktivieren
                button.interactable = true;
            }
        }
    }
    
}
