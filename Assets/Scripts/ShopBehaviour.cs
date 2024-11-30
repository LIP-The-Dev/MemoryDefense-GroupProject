using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehaviour : MonoBehaviour
{
    [SerializeField] private Button ButtonRAM;

    [SerializeField] private Button ButtonCPU;

    [SerializeField] private Button ButtonNode;

    public GameObject RAMPrefab;

    public GameObject CPUPrefab;

    public static GameObject NodePrefab;

    [SerializeField] private GameObject currentTower;

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
        if (currentTower == null)
        {
            currentTower = Instantiate(RAMPrefab);
            currentTower.AddComponent<DragAndDropBehavior>();
        }
    }
    
    void BuyCPU()
    {
        if (currentTower == null)
        {
            currentTower = Instantiate(CPUPrefab);
            currentTower.AddComponent<DragAndDropBehavior>();
        }
    }
    
    void BuyNode()
    {
        if (currentTower == null)
        {
            currentTower = Instantiate(NodePrefab);
            currentTower.AddComponent<DragAndDropBehavior>();
        }
    }
}
