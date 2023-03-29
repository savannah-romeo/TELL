using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.IO;

// Responsible for importing data into RedCap
public class ChildDataAlreadyExistsLogin  : MonoBehaviour
{
    public Button clickedButton; //Button clicked
    public GameObject panel; // Panel
    public TextMeshProUGUI popUpText; // Value for childId

    public static string persistentDataPath;


    void Start()
    {
        persistentDataPath = Application.persistentDataPath + "/";
        clickedButton.onClick.AddListener(dataExistsButtonClick);
    }


    void dataExistsButtonClick(){
        
        if (DataManager.childFileExists) {
            panel.gameObject.SetActive(false);
        } else {
            popUpText.gameObject.SetActive(true);
        }
    }
}