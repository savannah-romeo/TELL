//This class loads a scene when a button is clicked
//if the given Validator is true
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClick_Button_LoadScene_Conditional : MonoBehaviour
{
    public Button clickedButton; //Button clicked
    public string sceneName; //Name of the scene to load
    public Validation_Parent checker; //Used to check input

    void Start()
    {
        //Create listener for the button in question
        clickedButton.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        //Make text opaque based on condition
        if(checker.Validator()) //if input is invalid
            SceneManager.LoadScene(sceneName);
    }
}
