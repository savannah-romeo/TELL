using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Load_logout_export_popUpMessage : MonoBehaviour
{
    // UI Elements
    public Button onlyLogoutBtn; // No Button in Panel
    public Button exportLogoutBtn; // Yes Button in Panel
    public Button loadBtn; // Load Button in Panel
    public GameObject panel; // Panel

    // Non-UI Elements
    public DataManager cleanup; //Saves data before loading
    public string sceneName; // Name up upcoming scene after loading data
    SaveLoad loader;

    // Use this for initialization
    void Start()
    {
        loader = new SaveLoad();
        loadBtn.onClick.AddListener(loadButtonClick);
        onlyLogoutBtn.onClick.AddListener(logoutButtonClick);
        // exportLogoutBtn.onClick.AddListener(exportLogoutButtonClick);
    }

    // Occurs when next button is clicked
    void loadButtonClick()
    {
        panel.gameObject.SetActive(true);

    }

    // Occurs when yes button is clicked
    void logoutButtonClick()
    {
        loadBtn.interactable = true;
        panel.gameObject.SetActive(false);
        // Load new scene
        cleanup.SceneCleanup();
        DataManager.currentScene = sceneName; //Updates DataManager scene string
        SceneManager.LoadScene(sceneName);
    }
}