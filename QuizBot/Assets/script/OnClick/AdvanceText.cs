//This class is used to advance the displayed text
//from a given text array. Used to cycle prompts.
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class AdvanceText : MonoBehaviour
{
    public TextMeshProUGUI shownText;
    int localTime; //Tracks which "Time"/Week/Unit to use for prompt
    public string[] textArray; //Holds answer prompts at top
    public int iterator; //Used to track our position in the array.
    public Button clickedButton;
    public bool complete; //Indicates when iteration moves to last element, viewed by other scripts for scene transition logic
    public bool gradeMe; //Seperate bool tracks actual last element, used for data sync purposes with other scripts
    public Validation_Games checker; //Used to check for valid answer before proceeding
    public Array_Prompts prompts; //Holds the list of prompts that the evaluator will be cycling through - select relevant child
    public Dictionary<string, string> alphabet_pronounciation = new Dictionary<string, string>(){
        {"A","/a/"},{"B","/b/"},{"C","/c/"},{"D","/d/"},{"E","/e/"},{"F","/f/"},{"G","/g/"},{"H","/h/"},{"I","/i/"},
        {"J","/j/"},{"K","/k/"},{"L","/l/"},{"M","/m/"},{"N","/n/"},{"O","/o/"},{"P","/p/"},{"Q","/q/"},{"R","/r/"},
        {"S","/s/"},{"T","/t/"},{"U","/u/"},{"V","/v/"},{"W","/w/"},{"X","/x/"},{"Y","/y/"},{"Z","/z/"}
        };
    public static string sep = "    ";

    // Start is called before the first frame update
    public virtual void Start()
    {
        localTime = DataManager.globalTime;
        complete = false;
        gradeMe = true;
        iterator = 0; //Selects the starting text to display
        Debug.Log("game " + DataManager.globalGame);
        if (DataManager.globalGame == "SR_Instructions" || DataManager.globalGame == "BookSum_Instructions"){
            textArray = PromptSelect1(localTime);
        }
        if (DataManager.globalGame != "Writing_Instructions"){
            textArray = PromptSelect(localTime);
            if (DataManager.globalGame == "LNI_Instructions") {
             shownText.text = textArray[iterator] + sep + alphabet_pronounciation[textArray[iterator]]; //Display the first text
            } else{
                shownText.text = textArray[iterator]; //Display the first text
            }
        }
        clickedButton.onClick.AddListener(TaskOnClick);
    }

    //This function uses an int to select a prompt from Array_Prompts child.
    //The default case "prompts" contains an error message array.
    public virtual string[] PromptSelect(int selection) => selection switch
    {
        1 => prompts.prompts1,
        2 => prompts.prompts2,
        3 => prompts.prompts3,
        4 => prompts.prompts4,
        5 => prompts.prompts5,
        6 => prompts.prompts6,
        _ => Array_Prompts.prompts
    };

        //This function uses an int to select a prompt from Array_Prompts child.
    //The default case "prompts" contains an error message array.
    public virtual string[] PromptSelect1(int selection) => selection switch
    {
        1 => prompts.prompts1,
        2 => prompts.prompts2,
        3 => prompts.prompts3,
        _ => Array_Prompts.prompts
    };

    //Occurs when button is clicked
    protected virtual void TaskOnClick()
    {
        checker.Validator();
        if (checker.GetValidInput())
        {
            if (DataManager.globalGame == "Writing_Instructions"){
                complete = true;
            }else if (iterator < textArray.Length - 1)
            {
                iterator++;
                if (DataManager.globalGame == "LNI_Instructions")
                {
                    shownText.text = textArray[iterator] + sep + alphabet_pronounciation[textArray[iterator]]; //Display the first text
                } else{
                    shownText.text = textArray[iterator];
                }
                //On last question display, mark completed
                if (iterator == textArray.Length - 1)
                    complete = true;
            }
            //Last element
            else
            {
                gradeMe = false;
            }
        }
    }
}
