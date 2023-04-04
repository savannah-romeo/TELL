using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Load_answers_pop_up_for_BS : MonoBehaviour
{
    // UI Elements
    public Button closeBtn;
    public Button answerBtn;
    public GameObject panel;
    public TextMeshProUGUI displayText;

    // Non-UI Elements
    //public DataManager cleanup; //Saves data before loading
    //public string sceneName; // Name up upcoming scene after loading data
    public Array_Prompts prompts;
    public string[] textArray;
    //public int iterator;
    //SaveLoad loader;

    // Use this for initialization
    void Start()
    {
        
        //iterator = 0;
        textArray = PromptSelect1(DataManager.globalTime);
        answerBtn.onClick.AddListener(loadButtonClick);
        closeBtn.onClick.AddListener(noButtonClick);
    }

    public virtual string[] PromptSelect1(int selection) => selection switch
    {
        1 => prompts.prompts1,
        2 => prompts.prompts2,
        3 => prompts.prompts3,
        _ => Array_Prompts.prompts
    };

    void loadButtonClick()
    {
        //sceneName = DataManager.globalGame;
        answerBtn.interactable = false;
        //warningText.text = " ";
        int iterator = (DataManager.question_no<3)?DataManager.question_no:DataManager.question_no-3;
        displayText.text = textArray[iterator];
        
        panel.gameObject.SetActive(true);

    }

 
    void noButtonClick()
    {
        answerBtn.interactable = true;
        panel.gameObject.SetActive(false);
    }
}
