//This class is used to save data when a button is clicked.
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Save : MonoBehaviour
{
    public Button saveButton;
    SaveLoad saver;

    //Use Awake to ensure data is ready via SaveLoad Load() before rest of program starts
    //Awake and start are 'unused' by other classes but 
    //are called and function just by existing like a constructor, ignore intellisense
    void Awake()
    {
        saver = new SaveLoad();
    }

    void Start()
    {
        saveButton.onClick.AddListener(TaskOnClick);
    }

    //Occurs when button is clicked
    void TaskOnClick()
    {
        saver.Save();
    }
}
