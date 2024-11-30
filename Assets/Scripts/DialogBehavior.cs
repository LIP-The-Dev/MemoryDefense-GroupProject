using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBehavior : MonoBehaviour
{
    public TMP_Text[] dialogTexts; // Array von TMP_Text Objekten
    public Button nextButton; // Der Button zum Weiterschalten

    private int currentTextIndex = 0;

    void Start()
    {
        // Verstecke alle Texte außer dem ersten
        for (int i = 1; i < dialogTexts.Length; i++)
        {
            dialogTexts[i].gameObject.SetActive(false);
        }

        // Füge den Button-Listener hinzu
        nextButton.onClick.AddListener(SwitchToNextText);
    }

    void SwitchToNextText()
    {
        Debug.Log("sdf");
        // Verstecke den aktuellen Text
        dialogTexts[currentTextIndex].gameObject.SetActive(false);

        // Erhöhe den Index und setze ihn zurück, wenn das Ende erreicht ist
        currentTextIndex = (currentTextIndex + 1) % dialogTexts.Length;

        // Zeige den nächsten Text
        dialogTexts[currentTextIndex].gameObject.SetActive(true);
    }
}
