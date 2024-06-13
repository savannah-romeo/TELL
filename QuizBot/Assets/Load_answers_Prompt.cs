using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Load_answers_Prompt : MonoBehaviour
{
    // UI Elements
    public Button closeBtn;
    public Button answerBtn;
    public GameObject panel;
    public Button nextBtn;

    public TextMeshProUGUI displayText;
    public TextMeshProUGUI shownText;

    // Use this for initialization
    void Start()
    {
        answerBtn.onClick.AddListener(loadButtonClick);
        closeBtn.onClick.AddListener(noButtonClick);
    }

    void loadButtonClick()
    {
        answerBtn.interactable = false;
        nextBtn.interactable=false;
        if (shownText != null)
        {
            string originalText = shownText.text;
            int start = originalText.IndexOf("/");
            int end = originalText.LastIndexOf("/");

            if (start != -1 && end != -1 && end > start)
            {
                originalText = originalText.Substring(0, start) + originalText.Substring(end + 1);
            }

            displayText.text = "This is a "+ (originalText.Trim()).ToLower() + ". What is the first sound you hear in "+ (originalText.Trim()).ToLower()+ "?";
        }
        panel.gameObject.SetActive(true);

    }
 
    void noButtonClick()
    {
        answerBtn.interactable = true;
        nextBtn.interactable=true;
        panel.gameObject.SetActive(false);
    }
}
