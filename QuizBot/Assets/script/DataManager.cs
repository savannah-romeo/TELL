//This class is used to store and load data.
//Useful for scene transitions, data exports, and local saves.
//By using static variables we keep a persistent location in memory.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    //User info
    //Note ID can be name or an ID #
    public static string teacherID;
    public static string assessorID;
    public static string childID;

    //Scored answers
    public static int score_expressive;
    public static int score_receptive;

    //List of answers given
    //Will need a string array once using multiple
    public static string responses;

    public static string currentScene; //used to determine what logic to use

    //UserInfo Fields
    public TMP_InputField teacherField;
    public TMP_InputField assessorField;
    public TMP_InputField childNameField;
    public TMP_InputField childIDField;

    //Evaluator Fields
    public TMP_InputField responseField;
    public Toggle expressiveToggle;
    public Toggle receptiveToggle;

    //Grader Fields
    public TextMeshProUGUI teacherText;
    public TextMeshProUGUI assessorText;
    public TextMeshProUGUI childText;
    public TextMeshProUGUI expressiveText;
    public TextMeshProUGUI receptiveText;
    public TextMeshProUGUI responsesText;

    // Start is called before the first frame update
    void Start()
    {
        //Initializes currentScene
        if(currentScene == null)
            currentScene = "UserInfo";

        //Fill saved UserInfo
        if(currentScene == "UserInfo")
        {
            Debug.Log("UserInfo Start!");
            teacherField.text = teacherID;
            assessorField.text = assessorID;
            childIDField.text = childID;
        }

        //Reset scores and wipe responses
        if(currentScene == "Evaluator")
        {
            Debug.Log("Evaluator Start!");
            score_expressive = 0;
            score_receptive = 0;
            responses = "";
        }

        //Display all our data!
        if(currentScene ==  "Grader")
        {
            teacherText.text = teacherID;
            assessorText.text = assessorID;
            childText.text = childID;
            expressiveText.text = score_expressive.ToString();
            receptiveText.text = score_receptive.ToString();
            responsesText.text = responses;
        }
    }

    //General-purpose function
    //that can be called to store data before scene transitions
    public void SceneCleanup()
    {
        //Save UserInfo
        if(currentScene == "UserInfo")
        {
            teacherID = teacherField.text;
            assessorID = assessorField.text;
            
            //Save child name or ID, with ID taking precedence
            childID = childNameField.text;
            if(childIDField.text != "")
                childID = childIDField.text;
        }

        //Calculate scores based on toggles
        if(currentScene == "Evaluator")
        {
            if(expressiveToggle.isOn)
            {
                score_expressive++;
                score_receptive++;
            }
            if(receptiveToggle.isOn) //Only visible if expressive is off
                score_receptive++;

            responses = responseField.text;
        }

        //Nothing to save in Grader
    }

}
