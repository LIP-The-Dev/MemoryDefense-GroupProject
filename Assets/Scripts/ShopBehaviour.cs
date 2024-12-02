using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopBehaviour : MonoBehaviour
{
    [SerializeField] private Button ButtonRAM;

    [SerializeField] private Button ButtonCPU;

    [SerializeField] private Button ButtonNode;

    [SerializeField] private GameObject RAMPrefab;

    [SerializeField] private GameObject CPUPrefab;

    [SerializeField] private GameObject NodePrefab;

    [SerializeField] private AudioSource audioSource;

    private GameObject currentTower;
    
    private static bool isPlacingTower = false;

    [SerializeField] private TMP_Text RAMCosts;
    [SerializeField] private TMP_Text NodeCosts;
    [SerializeField] private TMP_Text CPUCosts;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        
        ButtonRAM.onClick.AddListener(OnButtonRAMClick);
        ButtonCPU.onClick.AddListener(OnButtonCPUClick);
        ButtonNode.onClick.AddListener(OnButtonNodeClick);
        RAMCosts.text = RAMBehaviour.getCost().ToString();
        NodeCosts.text = NodeBehaviour.getCost().ToString();
        CPUCosts.text = CPUBehaviour.getCost().ToString();
        audioSource = GetComponent<AudioSource>();
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
        if (currentTower.tag == "Node")
        {
            int x = (int) Math.Floor(position.x);
            int y = (int) Math.Floor(position.y);
            Debug.Log("Node");
            if (GameManagerBehaviour.GetInstance().isFree(x,y))
            {
                GameManagerBehaviour.GetInstance().setFree(x,y,false);
                isPlacingTower = false;
                PlayAudio();
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
                if (GameManagerBehaviour.GetInstance().isFree(x,y)&&GameManagerBehaviour.GetInstance().isFree(x,y-1)&&GameManagerBehaviour.GetInstance().isFree(x-1,y-1)&&GameManagerBehaviour.GetInstance().isFree(x-1,y))
                {
                    GameManagerBehaviour.GetInstance().setFree(x,y,false);
                    GameManagerBehaviour.GetInstance().setFree(x,y-1,false);
                    GameManagerBehaviour.GetInstance().setFree(x-1,y-1,false);
                    GameManagerBehaviour.GetInstance().setFree(x-1,y,false);

                    isPlacingTower = false;
                    PlayAudio();
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
                    if (GameManagerBehaviour.GetInstance().isFree(x, y) && GameManagerBehaviour.GetInstance().isFree(x-1, y) && GameManagerBehaviour.GetInstance().isFree(x + 1, y))
                    {
                        GameManagerBehaviour.GetInstance().setFree(x,y,false);
                        GameManagerBehaviour.GetInstance().setFree(x-1,y,false);
                        GameManagerBehaviour.GetInstance().setFree(x+1,y,false);

                        isPlacingTower = false;
                        PlayAudio();
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
        if (GameManagerBehaviour.GetInstance().buayble(RAMBehaviour.getCost())&&!isPlacingTower)
        {
            GameManagerBehaviour.GetInstance().subCurrency(RAMBehaviour.getCost());
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
                currentTower = Instantiate(RAMPrefab, mousePosition, Quaternion.identity);
                currentTower.GetComponent<TowerBehaviour>().enabled = false;
                isPlacingTower = true;
        }
    }
    
    void OnButtonCPUClick()
    {
        if (GameManagerBehaviour.GetInstance().buayble(CPUBehaviour.getCost())&&!isPlacingTower)
        {
            GameManagerBehaviour.GetInstance().subCurrency(CPUBehaviour.getCost());
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
            currentTower = Instantiate(CPUPrefab, mousePosition, Quaternion.identity);
            currentTower.GetComponent<TowerBehaviour>().enabled = false;
            isPlacingTower = true;
        }
    }
    
    void OnButtonNodeClick()
    {
        if (GameManagerBehaviour.GetInstance().buayble(NodeBehaviour.getCost())&&!isPlacingTower)
        {
            GameManagerBehaviour.GetInstance().subCurrency(NodeBehaviour.getCost());
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Setze die Z-Position auf 0 für 2D
            currentTower = Instantiate(NodePrefab, mousePosition, Quaternion.identity);
            currentTower.GetComponent<TowerBehaviour>().enabled = false;
            isPlacingTower = true;
        }
    }
    
    public void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public static bool getIsPlacingTower()
    {
        return isPlacingTower;
    }
}
