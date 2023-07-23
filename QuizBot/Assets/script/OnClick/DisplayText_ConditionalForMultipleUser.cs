//This script displays a parameter element when the object is clicked based on the game state.
//Used to display input validation text.
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayText_ConditionalForMultipleUser : MonoBehaviour
{
    public Button clickedButton; //Button clicked
    public TextMeshProUGUI displayText; //Text that might be displayed
    public Validation_Parent checker; //Used to check game state
    public Button logOutButton;
    public DataManager cleanup;


    void Start()
    {
        //Create listener for the button in question
        clickedButton.onClick.AddListener(TaskOnClick);
        logOutButton.onClick.AddListener(logOutClick);
    }

    void logOutClick()
    {
        cleanup.SceneCleanup();
        SceneManager.LoadScene("StartGame");
        DataManager.currentScene = "StartGame";
    }
    void TaskOnClick()
    {
        //Make text opaque based on condition
        if (!checker.Validator()) //if input is invalid
            displayText.alpha = 255;
        //Hide if condition is no longer met
        else
        {
            displayText.alpha = 0;
        }
    }
}