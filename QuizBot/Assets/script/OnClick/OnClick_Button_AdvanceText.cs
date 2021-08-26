//This class is used to advance the displayed text
//from a given text array. Used to cycle prompts.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnClick_Button_AdvanceText : MonoBehaviour
{
    public TextMeshProUGUI shownText;
    public string[] textArray = Array_Prompts.prompts;
    public int iterator; //Used to track our position in the array.
    public Button clickedButton;
    public bool complete; //Indicates when iteration is done, viewed by other scripts for scene transition logic

    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        iterator = 0; //Selects the starting text to display
        shownText.text = textArray[iterator]; //Display the first text
        clickedButton.onClick.AddListener(TaskOnClick);
    }

    //Occurs when button is clicked
    void TaskOnClick()
    {
        iterator++;
        if (iterator < textArray.Length-1)
            shownText.text = textArray[iterator];
        else
            complete = true;
    }
}
