using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ImageTransparencyController : MonoBehaviour
{
    public Image img;
    public float waitDuration = 8.0f;
    //public float duration = 0.5f;
    private float targetAlpha = 1.0f;
    public TMP_Text retryScreen;
    

    void Start()
    {
        if (img == null)
        {
            img = GetComponent<Image>();
        }
        StartCoroutine(DelayedStart());
    }

    private void Update()
    {
        if (Input.anyKeyDown && img.color.a >= 0.8) { LoadScene(); }
    }

    
    void LoadScene() { SceneManager.LoadScene("FINALscene 1"); }
    
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3);
        
        float elapsedTime = 0.0f;
        Color color = img.color;
        Color text = retryScreen.color;

        while (elapsedTime < waitDuration)
        {
            elapsedTime += Time.deltaTime/15;
            float elapsedTime2 = Time.deltaTime / 30;
            color.a = Mathf.Lerp(color.a, targetAlpha, elapsedTime / waitDuration);
            img.color = color;
            retryScreen.color = text;
            text.a = Mathf.Lerp(text.a, targetAlpha, elapsedTime2 / waitDuration);
            yield return null; 
        }

        
        color.a = targetAlpha;
        img.color = color;
        text.a = targetAlpha;
        retryScreen.color = text;
    }

    public void ChangeTransparency(float alpha)
    {
        targetAlpha = Mathf.Clamp01(alpha);
        StartCoroutine(DelayedStart());
    }
}