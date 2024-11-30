using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            nodeBehaviour.UpdateShootingDirection();
        }
    }

    void PlaceTower()
    {
        Vector3 position = currentTower.transform.position;
        GameManagerBehaviour gameManager = GameManagerBehaviour.GetInstance();
        if (currentTower.tag == "Node")
        {
            int x = (int) Math.Floor(position.x);
            int y = (int) Math.Floor(position.y);
            Debug.Log("Node");
            if (gameManager.isFree(x,y))
            {
                gameManager.setFree(x,y,false);
                isPlacingTower = false;
                SnapToGrid(x,y);
                currentTower.GetComponent<TowerBehaviour>().enabled = true;
                currentTower.GetComponent<TowerBehaviour>().setFix();
                currentTower = null;
            }
        }
        else
        {
            if (currentTower.tag == "CPU")
            {
                int x = (int) Math.Round(position.x);
                int y = (int) Math.Round(position.y);
                Debug.Log("CPU");
                if (gameManager.isFree(x,y)&&gameManager.isFree(x,y-1)&&gameManager.isFree(x-1,y-1)&&gameManager.isFree(x-1,y))
                {
                    gameManager.setFree(x,y,false);
                    gameManager.setFree(x,y-1,false);
                    gameManager.setFree(x-1,y-1,false);
                    gameManager.setFree(x-1,y,false);

                    isPlacingTower = false;
                    SnapToGridCPU();
                    currentTower.GetComponent<TowerBehaviour>().enabled = true;
                    currentTower.GetComponent<TowerBehaviour>().setFix();
                    currentTower = null;
                }
            }
            else
            {
                if (currentTower.tag == "RAM")
                {
                    int x = (int) Math.Floor(position.x);
                    int y = (int) Math.Floor(position.y);
                    Debug.Log("RAM");
                    if (gameManager.isFree(x, y) && gameManager.isFree(x-1, y) && gameManager.isFree(x + 1, y))
                    {
                        gameManager.setFree(x,y,false);
                        gameManager.setFree(x-1,y,false);
                        gameManager.setFree(x+1,y,false);

                        isPlacingTower = false;
                        SnapToGrid(x,y);
                        currentTower.GetComponent<TowerBehaviour>().enabled = true;
                        currentTower.GetComponent<TowerBehaviour>().setFix();
                        currentTower = null;
                    }

                }

            }
        }
        
        
    }

    void SnapToGrid(int x, int y)
    {   
        Debug.Log(x + ", " + y);
        Vector3 position = new Vector3(x, y, 0);
        position.x += 0.5f;
        position.y += 0.5f;
        currentTower.transform.position = position;
    }
    void SnapToGridCPU()
    {
        Vector3 position = currentTower.transform.position;
        int x = (int) Math.Round(position.x);
        int y = (int) Math.Round(position.y);
        position.x = x;
        position.y = y;
        currentTower.transform.position = position;
    }
    
    void OnButtonRAMClick()
    {
        if (!isPlacingTower)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
            currentTower = Instantiate(RAMPrefab, mousePosition, Quaternion.identity);
            currentTower.GetComponent<TowerBehaviour>().enabled = false;
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
            currentTower.GetComponent<TowerBehaviour>().enabled = false;
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
            currentTower.GetComponent<TowerBehaviour>().enabled = false;
            isPlacingTower = true;
        }
    }
}
