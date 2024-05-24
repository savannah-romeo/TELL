using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Responsible for exporting data into RedCap
public class ExportDataAndLogout : MonoBehaviour
{
    public Button clickedButton; //Button clicked
    public static string pdP; // persistentDataPath, this contains the local storage path
    public Button doneBtn; // Load Button in Panel
    // public Button logoutBtn; // Load Button in Panel
    public GameObject panelForDone; // Panel
    public GameObject panelForLogout;
    public TMP_Text popUpText; // Value for childId
    public TMP_Text buttonExportText;


    // Non-UI Elements
    public string sceneName; // Name up upcoming scene after loading data
    public DataManager cleanup; //Saves data before loading
    SaveLoad loader;

    void Start()
    {
        if (DataManager.internetAvailable)
        {
            clickedButton.onClick.AddListener(() => ExportActions());
            doneBtn.onClick.AddListener(doneButtonClick);
        }
        else
        {
            if (buttonExportText != null)
            {
                buttonExportText.SetText("Save the data locally. I will export all new test data ASAP.");
            }
            clickedButton.onClick.AddListener(() => goBackToMainMenu());
        }
        pdP = Application.persistentDataPath;
        // logoutBtn.onClick.AddListener(yesButtonClick);
    }
    void goBackToMainMenu()
    {
        cleanup.SceneCleanup();
        DataManager.currentScene = sceneName; //Updates DataManager scene string
        SceneManager.LoadScene(sceneName);
    }
    // Function that is responsible for exporting data into RedCap, triggered after button click.
    void ExportActions()
    {
        // Preparing export request
        RedCapRequest outboundRequest = new RedCapRequest();
        outboundRequest.token = DataManager.tokenSelected;
        //outboundRequest.token = "31E01A3558EFAD66A9769F0A6F338BDF"; // This is Akshay's creds, to be replaced!
        outboundRequest.content = "record";
        outboundRequest.action = "import";
        outboundRequest.format = "json";
        outboundRequest.type = "flat";
        outboundRequest.overwriteBehavior = "overwrite";
        outboundRequest.returnContent = "ids";
        
        BinaryFormatter bf = new BinaryFormatter();
        DirectoryInfo directory = new DirectoryInfo(pdP);
        FileInfo[] filesInDirectory = directory.GetFiles("*.dat");

        // Iterating over all ".dat" files in directory
        foreach (FileInfo fileInDirectory in filesInDirectory)
        {
            string fileName = fileInDirectory.FullName;
            string[] splits = fileInDirectory.Name.Split('_');

            // Only pick files in directory that belong to same class
            if (splits.Length == 0 || splits[0] != (DataManager.childID + ".dat"))
                continue;

            // Read data in file and convert it into RedCap records
            FileStream file = File.Open(fileName, FileMode.Open);
            SerialData serialData = (SerialData) bf.Deserialize(file);
            List<RedCapRecord> redCapRecords = RedCapRecord.convertToRedCapRecord(serialData);
            file.Close();

            string data = JsonConvert.SerializeObject(redCapRecords);
            // string data = JsonUtility.ToJson(redCapRecords);
            outboundRequest.forceAutoNumber = redCapRecords[0].recordID == int.MaxValue ? "true" : "false";
            outboundRequest.data = data;

            // Execute export request
            RedCapService.Instance.ExportCredentials(outboundRequest, fileName, redCapRecords[0].recordID);
            //StartCoroutine(RedCapService.Instance.ExportCredentials(outboundRequest, fileName, redCapRecords[0].recordID));
        }
        panelForLogout.gameObject.SetActive(false);
        cleanup.SceneCleanup();
        DataManager.currentScene = sceneName; //Updates DataManager scene string
        SceneManager.LoadScene(sceneName);
        panelForDone.gameObject.SetActive(true);
    }
    void doneButtonClick()
    {
        panelForDone.gameObject.SetActive(false);
    }

    // // Occurs when yes button is clicked
    // void yesButtonClick()
    // {
    //     clickedButton.interactable = true;
    //     panel.gameObject.SetActive(false);
    //     loader.Load("", "");

    //     // Load new scene
    //     cleanup.SceneCleanup();
    //     DataManager.currentScene = sceneName; //Updates DataManager scene string
    //     SceneManager.LoadScene(sceneName);
    // }
}