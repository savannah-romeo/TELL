using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Load_popUp_Message : MonoBehaviour
{
    // UI Elements
    public Button noBtn; // No Button in Panel
    public Button yesBtn; // Yes Button in Panel
    public Button loadBtn; // Load Button in Panel
    public GameObject panel; // Panel
    public TextMeshProUGUI displayText; // Text display in Panel
    public TextMeshProUGUI warningText;

    // Non-UI Elements
    public DataManager cleanup; //Saves data before loading
    public string sceneName; // Name up upcoming scene after loading data
    SaveLoad loader;

    // Use this for initialization
    void Start()
    {
        sceneName = DataManager.globalGame;
        loader = new SaveLoad();
        loadBtn.onClick.AddListener(loadButtonClick);
        yesBtn.onClick.AddListener(yesButtonClick);
        noBtn.onClick.AddListener(noButtonClick);
    }

    // Occurs when next button is clicked
    void loadButtonClick()
    {
        sceneName = DataManager.globalGame;
            loadBtn.interactable = false;
            string gameName = "";
            int timeaccepted=0;
            if(sceneName == "Instructions"){
                timeaccepted = DataManager.vocabTime;
                gameName = "Vocabulary";
            } else if(sceneName == "BS_Instructions") {
                gameName = "Beginning Sound";
            } else if(sceneName == "LNI_Instructions") {
                gameName = "Letter Name Identification";
            } else if(sceneName == "LSI_Instructions"){
                gameName = "Letter Sound Indentification";
            }
            if(timeaccepted==7 || (int)Char.GetNumericValue(loadBtn.name[loadBtn.name.Length-1]) < timeaccepted){
                loadBtn.enabled = false;
                warningText.text = "Oops! This test has already been taken. Please select the latest test!";
            } else{        
                warningText.text = " ";
                displayText.text = "You have selected the "+gameName+" test, Time "+DataManager.globalTime+". Is that correct?";
                panel.gameObject.SetActive(true);
            }
            
 
    }

    // Occurs when yes button is clicked
    void yesButtonClick()
    {
        loadBtn.interactable = true;
        panel.gameObject.SetActive(false);

        // Load new scene
        cleanup.SceneCleanup();
        DataManager.currentScene = sceneName; //Updates DataManager scene string
        SceneManager.LoadScene(sceneName);
    }


    // Occurs when no button is clicked
    void noButtonClick()
    {
        loadBtn.interactable = true;
        panel.gameObject.SetActive(false);
    }
}
