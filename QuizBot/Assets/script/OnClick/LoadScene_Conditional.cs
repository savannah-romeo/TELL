//This class loads a scene when a button is clicked
//if the given Validator is true
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene_Conditional : MonoBehaviour
{
    public Button clickedButton; //Button clicked
    public string sceneName; //Name of the scene to load
    public Validation_Parent checker; //Used to check input
    public DataManager cleanup; //Saves data before loading

    public bool showExportMessage;

    void Start()
    {
        //Create listener for the button in question
        clickedButton.onClick.AddListener(TaskOnClick);
    }

    protected void TaskOnClick()
    {
        if(clickedButton.name == "button_exit" && sceneName== "MainMenu"){
            DataManager.currentScene = sceneName; //Updates DataManager scene string
            SceneManager.LoadScene(sceneName);
        }
        else if(!showExportMessage && checker.Validator()) //if input is invalid
        {  
            cleanup.SceneCleanup();
            DataManager.currentScene = sceneName; //Updates DataManager scene string
            if(DataManager.continuation_flag){
                DataManager.continuation_flag = false;
                SceneManager.LoadScene(DataManager.continuation_scene);
            } else{
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
