//This class is used to store and load data.
//Useful for scene transitions, data exports, and local saves.
//By using static variables we keep a persistent location in memory.
//Note: Use doubles to store all numbers to avoid expensive casting
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    //User info
    //Note ID can be name or an ID #
    public static string teacherID;
    public static string assessorID;
    public static string childID;

    //Per-game scored answers
    public static double score_expressive;
    public static double score_receptive;
    public static double score_total;

    //List of answers given
    //Will need a string array once using multiple
    public static List<string> responses;

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
    public TextMeshProUGUI childText;
    public TextMeshProUGUI expressiveText;
    public TextMeshProUGUI receptiveText;
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI expressivePercent;
    public TextMeshProUGUI receptivePercent;
    public TextMeshProUGUI totalPercent;
    //Responses
    public TextMeshProUGUI responsesText1;
    public TextMeshProUGUI responsesText2;
    public TextMeshProUGUI responsesText3;
    public TextMeshProUGUI responsesText4;
    public TextMeshProUGUI responsesText5;
    public TextMeshProUGUI responsesText6;

    //Long-term grades
    public static double vocabularyTotalQuestions; //How many vocab questions are asked per unit?
    public static double grade_vocabularyExpressive;
    public static double grade_vocabularyReceptive;
    public static double grade_vocabularyTotal;

    // Start is called before the first frame update
    void Start()
    {
        vocabularyTotalQuestions = 6;

        //Initializes currentScene
        if(currentScene == null)
            currentScene = "UserInfo";

        //Fill saved UserInfo
        if(currentScene == "UserInfo")
        {
            teacherField.text = teacherID;
            assessorField.text = assessorID;
            childIDField.text = childID;
        }

        //Reset scores and wipe responses
        if(currentScene == "Evaluator")
        {
            score_expressive = 0;
            score_receptive = 0;
            score_total = 0;
            responses = new List<string>();
        }

        //Display all our data!
        if (currentScene == "Grader")
        {
            responsesText1.text = responses[0];
            responsesText2.text = responses[1];
            responsesText3.text = responses[2];
            responsesText4.text = responses[3];
            responsesText5.text = responses[4];
            responsesText6.text = responses[5];
            expressiveText.text = score_expressive.ToString();
            receptiveText.text = score_receptive.ToString();

            totalText.text = score_total.ToString();
        }
        if (currentScene ==  "Grader" || currentScene == "Results")
        {
            childText.text = childID;            
            expressivePercent.text = grade_vocabularyExpressive.ToString("0") + '%'; //Parameter ensures two decimal points
            receptivePercent.text = grade_vocabularyReceptive.ToString("0") + '%';
            totalPercent.text = grade_vocabularyTotal.ToString("0") + '%';
        }
    }

    //This function can be called to grade a current question
    //and adjust scores accordingly
    public void GradeQuestion()
    {
        //Calculate scores based on toggles
        if (currentScene == "Evaluator")
        {
            if (expressiveToggle.isOn)
            {
                score_expressive++;
                score_receptive++;
            }
            if (receptiveToggle.isOn) //Only visible if expressive is off
                score_receptive++;

            responses.Add(responseField.text);
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

        //Grade final question and calculate results before moving on
        if (currentScene == "Evaluator")
        {
            GradeQuestion();
            //*100 for percentile
            grade_vocabularyExpressive = (score_expressive / vocabularyTotalQuestions) * 100;
            grade_vocabularyReceptive = (score_receptive / vocabularyTotalQuestions) * 100;
            score_total = score_expressive + score_receptive;
            grade_vocabularyTotal = (score_total / (vocabularyTotalQuestions * 2)) * 100;
        }
    }

}
