//This class is used to advance the displayed text
//from a given text array. Used to cycle prompts.
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvanceText : MonoBehaviour
{
    public TextMeshProUGUI shownText;
    int localTime; //Tracks which "Time"/Week/Unit to use for prompt
    public string[] textArray; //Holds answer prompts at top
    public int iterator; //Used to track our position in the array.
    public Button clickedButton;
    public bool complete; //Indicates when iteration moves to last element, viewed by other scripts for scene transition logic
    public bool gradeMe; //Seperate bool tracks actual last element, used for data sync purposes with other scripts
    public Validation_Evaluator checker; //Used to check for valid answer before proceeding

    // Start is called before the first frame update
    void Start()
    {
        localTime = DataManager.globalTime;
        textArray = promptSelect(localTime);
        complete = false;
        gradeMe = true;
        iterator = 0; //Selects the starting text to display
        shownText.text = textArray[iterator]; //Display the first text
        clickedButton.onClick.AddListener(TaskOnClick);
    }

    //This function uses an int to select a prompt from Array_Prompts.
    //The default case "prompts" contains an error message array.
    public static string[] promptSelect(int selection) => selection switch
    {
        1 => Array_Prompts.prompts1,
        2 => Array_Prompts.prompts2,
        3 => Array_Prompts.prompts3,
        4 => Array_Prompts.prompts4,
        5 => Array_Prompts.prompts5,
        6 => Array_Prompts.prompts6,
        _ => Array_Prompts.prompts
    };

    //Occurs when button is clicked
    void TaskOnClick()
    {
        checker.Validator();
        if (checker.GetValidInput())
        {
            if (iterator < textArray.Length - 1)
            {
                iterator++;
                shownText.text = textArray[iterator];

                //On last question display, mark completed
                if (iterator == textArray.Length - 1)
                    complete = true;
            }
            //Last element
            else
                gradeMe = false;
        }
    }
}
