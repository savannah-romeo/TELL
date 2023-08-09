using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Responsible for importing data into RedCap
public class ReminderScreen : MonoBehaviour
{
    public Button adminTestsButton; //Button clicked
    public Button proceedBtn; // Load Button in Panel
    public GameObject panel; // Panel

    void Start()
    {
        adminTestsButton.onClick.AddListener(enablePanel);
        proceedBtn.onClick.AddListener(disablePanel);
    }

    public void enablePanel()
    {
        panel.gameObject.SetActive(true);
    }

    public void disablePanel()
    {
        panel.gameObject.SetActive(false);
    }
   
}