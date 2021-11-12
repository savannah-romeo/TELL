//This script is used to save the "Time"/week/unit
//selected when a button is clicked based on
//that button's name.
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour
{
    public Button timeButton;

    // Start is called before the first frame update
    void Start()
    {
        //Create listener for the button in question
        timeButton.onClick.AddListener(SetOnClick);
    }

    // Update is called once per frame
    void SetOnClick()
    {
        DataManager.globalTime = SaveTime(timeButton.name);
    }
    public static int SaveTime(string btnTime) => btnTime switch
    {
        "button1" => 1,
        "button2" => 2,
        "button3" => 3,
        "button4" => 4,
        "button5" => 5,
        "button6" => 6,
        _ => -1 //Default 'error' case
    };
}
