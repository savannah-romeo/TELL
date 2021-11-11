//This class is used to save data when a button is clicked.
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Save : MonoBehaviour
{
    public Button saveButton;
    SaveLoad saver;

    // Start is called before the first frame update
    void Start()
    {
        saveButton.onClick.AddListener(TaskOnClick);
        saver = new SaveLoad();
    }

    //Occurs when button is clicked
    void TaskOnClick()
    {
        saver.Save();
    }
}
