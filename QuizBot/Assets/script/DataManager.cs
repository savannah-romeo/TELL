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

    public static string currentScene; //used to determine what logic to use

    public static int globalTime; //Var used to store which 'Time'/unit/week we are on

    //Per-game scored answers
    //These lists hold each answer's result
    public static List<bool> individual_expressive;
    public static List<bool> individual_receptive;
    public static List<int> individual_total;
    //These hold the total score for the game
    public static double score_expressive;
    public static double score_receptive;
    public static double score_total;
    public static List<string> responses; //List of answers given
    

    //UserInfo Fields
    public TMP_InputField teacherNameField;
    public TMP_InputField assessorNameField;
    public TMP_InputField childNameField;
    public TMP_InputField teacherIDField;
    public TMP_InputField assessorIDField;
    public TMP_InputField childIDField;

    //Evaluator Fields
    public TMP_InputField responseField;
    public Toggle expressiveToggle;
    public Toggle receptiveToggle;

    //Grader Fields
    public TextMeshProUGUI childText; //Displays child ID
    public TextMeshProUGUI[] promptText;
    public TextMeshProUGUI[] responsesText; //Displays child answers
    public TextMeshProUGUI[] expressiveText;
    public TextMeshProUGUI[] receptiveText;
    public TextMeshProUGUI[] totalText;

    //Results Fields
    public TextMeshProUGUI[] expressivePercent;
    public TextMeshProUGUI[] receptivePercent;
    public TextMeshProUGUI[] totalPercent;

    //Long-Term Grades
    public static double vocabularyTotalQuestions; //How many vocab questions are asked per unit?
    public static double[] grade_vocabularyExpressive;
    public static double[] grade_vocabularyReceptive;
    public static double[] grade_vocabularyTotal;
    

    // Start is called before the first frame update
    void Start()
    {
        vocabularyTotalQuestions = 6;

        //Instantializes arrays if brand new
        if (grade_vocabularyExpressive == null)
        {
            grade_vocabularyExpressive = new double[6] { -1, -1, -1, -1, -1, -1 };
            grade_vocabularyReceptive = new double[6] { -1, -1, -1, -1, -1, -1 };
            grade_vocabularyTotal = new double[6] { -1, -1, -1, -1, -1, -1 };
        }

        //Initializes currentScene
        if(currentScene == null)
            currentScene = "UserInfo";

        //Fill saved UserInfo
        if(currentScene == "UserInfo")
        {
            teacherIDField.text = teacherID;
            assessorIDField.text = assessorID;
            childIDField.text = childID;
        }

        //Reset scores and wipe responses
        if(currentScene == "Evaluator")
        {
            individual_expressive = new List<bool>();
            individual_receptive = new List<bool>();
            individual_total = new List<int>();
            score_expressive = 0;
            score_receptive = 0;
            score_total = 0;
            responses = new List<string>();
        }

        //Display all our data!
        if (currentScene == "Grader")
        {
            childText.text = childID;
            //Temp storage
            string[] promptStorage = AdvanceText.promptSelect(globalTime);
            //Loop populates table textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for (int wheel = 0; wheel < 6; wheel++)
            {
                promptText[wheel].text = promptStorage[wheel];
                responsesText[wheel].text = responses[wheel];
                expressiveText[wheel].text = individual_expressive[wheel].ToString();
                receptiveText[wheel].text = individual_receptive[wheel].ToString();
                totalText[wheel].text = individual_total[wheel].ToString();
            }            
        }

        //Report card - show all times
        if (currentScene == "Results")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for(int loop = 0; loop < 6; loop++) 
            {
                expressivePercent[loop].text = grade_vocabularyExpressive[loop].ToString("0") + '%'; //Parameter ensures two decimal points
                receptivePercent[loop].text = grade_vocabularyReceptive[loop].ToString("0") + '%';
                totalPercent[loop].text = grade_vocabularyTotal[loop].ToString("0") + '%';
            }
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
                individual_expressive.Add(true);
                individual_receptive.Add(true);
                individual_total.Add(2);
                score_expressive++;
                score_receptive++;
            }
            else if (receptiveToggle.isOn) //Only visible if expressive is off
            {
                individual_expressive.Add(false);
                individual_receptive.Add(true);
                individual_total.Add(1);
                score_receptive++;
            }
            else
            {
                individual_expressive.Add(false);
                individual_receptive.Add(false);
                individual_total.Add(0);
            }

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
            //Save child name or ID, with ID taking precedence
            teacherID = teacherNameField.text;
            if (teacherIDField.text != "")
                teacherID = teacherIDField.text;
            assessorID = assessorNameField.text;
            if (assessorIDField.text != "")
                assessorID = assessorIDField.text;
            childID = childNameField.text;
            if(childIDField.text != "")
                childID = childIDField.text;
        }

        //Grade final question and calculate results before moving on
        if (currentScene == "Evaluator")
        {
            GradeQuestion();
            int timeIndex = globalTime - 1; //Global Time starts at 1 instead of 0
            //*100 for percentile
            grade_vocabularyExpressive[timeIndex] = (score_expressive / vocabularyTotalQuestions) * 100;
            grade_vocabularyReceptive[timeIndex] = (score_receptive / vocabularyTotalQuestions) * 100;
            score_total = score_expressive + score_receptive;
            grade_vocabularyTotal[timeIndex] = (score_total / (vocabularyTotalQuestions * 2)) * 100;
        }
    }

}
