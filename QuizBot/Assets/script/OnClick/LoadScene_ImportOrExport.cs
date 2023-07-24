//This class loads a scene when a button is clicked
//if the given Validator is true
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

public class LoadScene_ImportOrExport : MonoBehaviour
{
    public Button clickedButton; //Button clicked
    //public string sceneName; //Name of the scene to load
    //public Validation_Parent checker; //Used to check input
    public Validation_UserInfoMultiple userInfoChecker;
    public DataManager cleanup; //Saves data before loading
    public GameObject panel;
    public Button close;
    public Button errorClose;
    public ExportData exportData;
    public ImportData importData;
    public GameObject errorPanel;
    public bool showPanel;


    //public bool showExportMessage;

    void Start()
    {
        //Create listener for the button in question
        if (clickedButton.name == "button_Import")
        {
            clickedButton.onClick.AddListener(TaskOnImportClick);
        }
        else if(clickedButton.name == "button_Export")
        {
            clickedButton.onClick.AddListener(() => StartCoroutine(TaskOnExportClick()));
        }
            //clickedButton.onClick.AddListener(TaskOnClick);
        close.onClick.AddListener(closeEvent);
        errorClose.onClick.AddListener(closeEvent);
    }

    protected void closeEvent()
    {
        if (panel != null)
        {
            panel.gameObject.SetActive(false);
        }
        if (errorPanel != null)
        {
            errorPanel.gameObject.SetActive(false);
        }
    }

    protected void TaskOnImportClick()
    {

        cleanup.SceneCleanup();
        if (clickedButton.name == "button_Import")
        {
            if (!userInfoChecker.shouldDisplayDuplicateWarning())
            {
                // display warning
                panel.gameObject.SetActive(true);
            }
            else
            {
                DataManager.childExists = true;
                //ImportData importData = new ImportData();
                StartCoroutine(importData.ImportActions(false, false));
                //cleanup.SceneCleanup();
                //SceneManager.LoadScene("UserInfoMultiple");
                //DataManager.currentScene = "UserInfoMultiple";
                importData.panel.SetActive(true);
            }

        }

    }
    protected IEnumerator TaskOnExportClick()
    {
        cleanup.SceneCleanup();
        /*if (clickedButton.name == "button_Import")
        {
            if (!userInfoChecker.shouldDisplayDuplicateWarning())
            {
                // display warning
                panel.gameObject.SetActive(true);
            }
            else
            {
                DataManager.childExists = true;
                //ImportData importData = new ImportData();
                StartCoroutine(importData.ImportActions(false,false));
                //cleanup.SceneCleanup();
                //SceneManager.LoadScene("UserInfoMultiple");
                //DataManager.currentScene = "UserInfoMultiple";
                importData.panel.SetActive(true);
            }
           
        }*/
        if(clickedButton.name == "button_Export")
        {
            if (!userInfoChecker.shouldDisplayWarning())
            {
                // display warning
                panel.gameObject.SetActive(true);
            }
            else
            {
                DataManager.childFileExists = true;
                //ExportData exportData = new ExportData();
                //exportData.panel = panel;
                if (userInfoChecker.shouldDisplayDuplicateWarning())
                {
                    DataManager.childExists = true;
                    //ImportData importData = new ImportData();
                    SerialData serialData = SaveLoad.getFileData(DataManager.childID);
                    if (serialData.sRecordId != null && serialData.sRecordId != "")
                    {
                        yield return StartCoroutine(importData.ImportActions(false, true));
                        exportData.ExportActions();
                        if (File.Exists(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat")))
                        {
                            File.Delete(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat"));
                        }
                        //cleanup.SceneCleanup();
                        //SceneManager.LoadScene("UserInfoMultiple");
                        //DataManager.currentScene = "UserInfoMultiple";
                        exportData.panel.SetActive(true);
                    }
                    else
                    {
                        serialData.sChildID = serialData.sChildID + "(1)";

                        string fileName = serialData.sChildID + ".dat"; // File for saving, filename will be <childID>.dat
                        string savePath = Path.Combine(Application.persistentDataPath, fileName); // File path for storage with the file name
                        //Debug.Log(fileName);
                        //Debug.Log(savePath);

                        //Create and save file
                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream file = File.Create(savePath);
                        bf.Serialize(file, serialData);
                        file.Close();

                        if (File.Exists(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat")))
                        {
                            File.Delete(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat"));
                        }
                        DataManager.childID = DataManager.childID + "(1)";
                        showPanel = true;
                        //DataManager.childID = DataManager.childID + "dup";
                        exportData.ExportActions();
                        if (File.Exists(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat")))
                        {
                            File.Delete(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat"));
                        }
                        //cleanup.SceneCleanup();
                        //SceneManager.LoadScene("UserInfoMultiple");
                        //DataManager.currentScene = "UserInfoMultiple";
                        errorPanel.SetActive(true);
                        
                    }
                    //cleanup.SceneCleanup();

                }
                else
                {
                    exportData.ExportActions();
                    if (File.Exists(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat")))
                    {
                        File.Delete(Path.Combine(Application.persistentDataPath, DataManager.childID + ".dat"));
                    }
                    //cleanup.SceneCleanup();
                    //SceneManager.LoadScene("UserInfoMultiple");
                    //DataManager.currentScene = "UserInfoMultiple";
                    /*if (showPanel)
                    {
                        errorPanel.SetActive(true);
                        showPanel = false;
                    }
                    else
                    {*/
                        exportData.panel.SetActive(true);
                    //}
                }
            }
        }
    }
}
