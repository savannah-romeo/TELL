using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Responsible for importing data into RedCap
public class ReminderScreenFirstQues : MonoBehaviour
{
    public Button nextButton; //Button clicked
    public Button nextDummyBtn; // Load Button in Panel
    public GameObject panel; // Panel
    int globalIterator;
    Transform nextButtonParent;
    public TMP_Text buttonNextText;
    float oldWidth;

    void Start()
    {
        globalIterator = 0;
        nextDummyBtn.onClick.AddListener(enablePanel);
        nextButton.onClick.AddListener(disablePanel);
        nextButtonParent = nextButton.transform.parent;
        nextButton.transform.SetParent(panel.transform);
        nextButton.enabled = false;
        RectTransform buttonRectTransform = nextButton.GetComponent<RectTransform>();
        oldWidth = buttonRectTransform.sizeDelta.x;
        buttonRectTransform.sizeDelta = new Vector2(250, buttonRectTransform.sizeDelta.y);
    }

    public void enablePanel()
    {
        if (globalIterator == 0)
        {
            buttonNextText.SetText("Got it. Proceed");
            nextButton.enabled = true;
            panel.gameObject.SetActive(true);
        }
    }

    public void disablePanel()
    {
        if (globalIterator == 0)
        {
            globalIterator++;
            panel.gameObject.SetActive(false);
            nextDummyBtn.enabled = false;
            nextDummyBtn.gameObject.SetActive(false);
            buttonNextText.SetText("NEXT");
            RectTransform buttonRectTransform = nextButton.GetComponent<RectTransform>();
            buttonRectTransform.sizeDelta = new Vector2(oldWidth, buttonRectTransform.sizeDelta.y);
            nextButton.transform.SetParent(nextButtonParent);
        }
    }
   
}