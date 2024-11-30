using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehaviour : MonoBehaviour
{
    [SerializeField] private Button ButtonRAM;

    [SerializeField] private Button ButtonCPU;

    [SerializeField] private Button ButtonNode;

    [SerializeField] private GameObject RAMPrefab;

    [SerializeField] private GameObject CPUPrefab;

    [SerializeField] private GameObject NodePrefab;

    private GameObject currentTower;
    

    public GameObject getCurrentTower()
    {
        return currentTower;
    }
    
    
    // Start is called before the first frame update
    void Start()
    { 
        ButtonRAM.onClick.AddListener(BuyRAM);
        ButtonCPU.onClick.AddListener(BuyCPU);
        ButtonNode.onClick.AddListener(BuyNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuyRAM()
    {
        bool placed = false;
        if (currentTower == null)
        {
            currentTower = Instantiate(RAMPrefab);
            currentTower.AddComponent<DragAndDropBehavior>();
            placed = true;
        }

        if (placed)
        {
            GameManagerBehaviour.GetInstance().updateCurrency(RAMBehaviour.Cost);
        }
    }
    
    void BuyCPU()
    {
        bool placed = false;
        if (currentTower == null)
        {
            currentTower = Instantiate(CPUPrefab);
            currentTower.AddComponent<DragAndDropBehavior>();
            placed = true;
        }
        
        if (placed)
        {
            GameManagerBehaviour.GetInstance().updateCurrency(CPUBehaviour.Cost);
        }
    }
    
    void BuyNode()
    {
        bool placed = false;
        if (currentTower == null)
        {
            currentTower = Instantiate(NodePrefab);
            currentTower.AddComponent<DragAndDropBehavior>();
            placed = true;
        }
        
        if (placed)
        {
            GameManagerBehaviour.GetInstance().updateCurrency(NodeBehaviour.Cost);
        }
    }
}
