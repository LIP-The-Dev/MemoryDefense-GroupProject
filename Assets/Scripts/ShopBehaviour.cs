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
    
    private bool isPlacingTower = false;
    

    
    
    
    // Start is called before the first frame update
    void Start()
    { 
        ButtonRAM.onClick.AddListener(OnButtonRAMClick);
        ButtonCPU.onClick.AddListener(OnButtonCPUClick);
        ButtonNode.onClick.AddListener(OnButtonNodeClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingTower)
        {
            FollowMouse();
            if (Input.GetMouseButtonDown(0)) // Linke Maustaste zum Platzieren
            {
                PlaceTower();
            }
            if (currentTower != null && currentTower.CompareTag("Node") && Input.mouseScrollDelta.y != 0) // Mausrad zum Drehen
            {
                RotateTower(Input.mouseScrollDelta.y);
            }
        }
    }
    
    void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
        currentTower.transform.position = mousePosition;
    }
    
    void RotateTower(float scrollDelta)
    {
        float rotationAngle = scrollDelta > 0 ? -90 : 90; // Drehe um 90 Grad je nach Scrollrichtung
        currentTower.transform.Rotate(0, 0, rotationAngle);

        // Aktualisiere die Schussrichtung
        NodeBehaviour nodeBehaviour = currentTower.GetComponent<NodeBehaviour>();
        if (nodeBehaviour != null)
        {
            nodeBehaviour.UpdateShootingDirection(rotationAngle);
        }
    }

    void PlaceTower()
    {
        isPlacingTower = false;
        SnapToGrid();
        currentTower = null;
    }

    void SnapToGrid()
    {
        Vector3 position = currentTower.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        currentTower.transform.position = position;
    }
    
    void OnButtonRAMClick()
    {
        if (!isPlacingTower)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
            currentTower = Instantiate(RAMPrefab, mousePosition, Quaternion.identity);
            isPlacingTower = true;
        }
    }
    
    void OnButtonCPUClick()
    {
        if (!isPlacingTower)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
            currentTower = Instantiate(CPUPrefab, mousePosition, Quaternion.identity);
            isPlacingTower = true;
        }
    }
    
    void OnButtonNodeClick()
    {
        if (!isPlacingTower)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
            currentTower = Instantiate(NodePrefab, mousePosition, Quaternion.identity);
            isPlacingTower = true;
        }
    }
}
