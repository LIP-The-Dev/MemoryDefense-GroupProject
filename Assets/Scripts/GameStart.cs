using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Canvas myCanvas; 
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myCanvas.gameObject.SetActive(false);
        myButton.onClick.AddListener(ButtonNewCanvasPressed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCanvas() { myCanvas.gameObject.SetActive(!myCanvas.gameObject.activeSelf); }
        
    public void ButtonTutorialPressed()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }

    public void ButtonNewCanvasPressed()
    {
        myCanvas.gameObject.SetActive(true);
    }
}
