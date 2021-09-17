//This class is used to advance the displayed text
//from a given text array. Used to cycle prompts.
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnClick_Button_AdvanceText : MonoBehaviour
{
    public TextMeshProUGUI shownText;
    public string[] textArray = Array_Prompts.prompts;
    public int iterator; //Used to track our position in the array.
    public Button clickedButton;
    public bool complete; //Indicates when iteration moves to last element, viewed by other scripts for scene transition logic
    public bool gradeMe; //Seperate bool tracks actual last element, used for data sync purposes with other scripts
    public Validation_Evaluator checker; //Used to check for valid answer before proceeding

    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        gradeMe = true;
        iterator = 0; //Selects the starting text to display
        shownText.text = textArray[iterator]; //Display the first text
        clickedButton.onClick.AddListener(TaskOnClick);
    }

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
