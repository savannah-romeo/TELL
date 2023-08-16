//This class is used to advance the displayed text
//from a given text array. Used to cycle prompts.
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class AdvanceTextBookSum : MonoBehaviour
{
    public TextMeshProUGUI shownText;
    int localTime; //Tracks which "Time"/Week/Unit to use for prompt
    public string[] textArray; //Holds answer prompts at top
    public string[] answerArray;
    public int iterator; //Used to track our position in the array.
    public UnityEngine.UI.Button clickedButton;
    public static bool complete; //Indicates when iteration moves to last element, viewed by other scripts for scene transition logic
    public bool gradeMe; //Seperate bool tracks actual last element, used for data sync purposes with other scripts
    public Array_Prompts prompts; //Holds the list of prompts that the evaluator will be cycling through - select relevant child
    public Array_Prompts_BookSum_Answers promptsAnswers;
    public ToggleGroup toggleGroup;
    public GameObject togglePrefab;

    // Start is called before the first frame update
    public virtual void Start()
    {
        localTime = DataManager.globalTime;
        complete = false;
        gradeMe = true;
        iterator = 0; //Selects the starting text to display
        Debug.Log("game " + DataManager.globalGame);
        if (DataManager.globalGame == "BookSum_Instructions_New_1")
        {
            textArray = PromptSelect1(localTime);
            shownText.text = textArray[iterator];
            int ansItr = (DataManager.question_no < 3) ? DataManager.question_no : DataManager.question_no - 3;
            answerArray = PromptAnswerSelect1(DataManager.globalTime, ansItr+1);
            AddTogglesWithLabelsToGroup();
        }
        clickedButton.onClick.AddListener(TaskOnClick);
    }


        //This function uses an int to select a prompt from Array_Prompts child.
    //The default case "prompts" contains an error message array.
    public virtual string[] PromptSelect1(int selection) => selection switch
    {
        1 => prompts.prompts1,
        2 => prompts.prompts2,
        3 => prompts.prompts3,
        _ => Array_Prompts.prompts
    };

    public virtual string[] PromptAnswerSelect1(int selection, int answerIterator) => selection switch
    {
        1 => promptsAnswers.prompt1Answers[answerIterator],
        2 => promptsAnswers.prompt2Answers[answerIterator],
        3 => promptsAnswers.prompt3Answers[answerIterator]
    };

    private void AddTogglesWithLabelsToGroup()
    {

        if (null != toggleGroup.transform)
        {
            foreach (Transform child in toggleGroup.transform)
            {
                Destroy(child.gameObject);
            }
        }

        for (int i = 0; i < answerArray.Length; i++)
        {
            addToggle(i, answerArray[i]);
        }
        addToggle(answerArray.Length, "None of the above (Incorrect)");
    }


    private void addToggle(int ind, string label)
    {
        GameObject togglePrefabClone = Instantiate(togglePrefab);
        togglePrefabClone.transform.SetParent(toggleGroup.transform);
        Vector3 newPosition = togglePrefabClone.transform.position;
        newPosition.y = newPosition.y + 4;
        newPosition.y = newPosition.y - (ind*0.75f); // Adjust the Y position as needed.
        togglePrefabClone.transform.position = newPosition;
        togglePrefabClone.transform.localScale = new Vector3(0.0375f, 0.0375f, 0.0375f);

        // Access the Toggle component.
        UnityEngine.UI.Toggle toggleComponent = togglePrefabClone.GetComponentInChildren<UnityEngine.UI.Toggle>();
        toggleComponent.group = toggleGroup;
        toggleComponent.isOn = false;

        // Set the Toggle's label.
        SetToggleLabel(toggleComponent, label);

        // Register the Toggle with the Toggle Group.
        toggleGroup.RegisterToggle(toggleComponent);
    }
    private void SetToggleLabel(UnityEngine.UI.Toggle toggle, string label)
    {
        // Find the Text component in the ToggleWithLabel's children.
        Text labelComponent = toggle.GetComponentInChildren<Text>();

        // If the Text component is found, set the label text.
        if (labelComponent != null)
        {
            labelComponent.text = label;
        }
    }
    //Occurs when button is clicked
    public bool validateInput()
    {
        bool isValid = false;
        foreach (Transform child in toggleGroup.transform)
        {
            UnityEngine.UI.Toggle toggleComponent = child.gameObject.GetComponentInChildren<UnityEngine.UI.Toggle>();
            if (toggleComponent.isOn)
            {
                isValid = true;
                break;
            }
        }
        return isValid;
    }

    public bool validScene()
    {
        bool validScene = true;
        

        //Do not advance scene until prompts are done
        if (!complete)
            validScene = false;

        //Invalid if neither expressive is ticked
        if (!validateInput())
        {
            validScene = false;
            
        }
        return validScene;
    }
    protected virtual void TaskOnClick()
    {
        if (validateInput())
        {
        if (iterator < textArray.Length - 1)
            {
                iterator++;
                shownText.text = textArray[iterator];
                int ansIterator = (DataManager.question_no < 3) ? DataManager.question_no : DataManager.question_no - 3;
            answerArray = PromptAnswerSelect1(DataManager.globalTime, ansIterator+1);

            AddTogglesWithLabelsToGroup();

                if (iterator == textArray.Length - 1)
                {
                    complete = true;
                    gradeMe = false;
                }
                else
                {
                    gradeMe = true;
                }
            }
        }
        //else
        //{
            //gradeMe = false;
        //}
    }
}
