using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

// Function responsible for loading user data
public class CheckInternetConnection : MonoBehaviour
{
    // UI Elements
    public Button internetUnavailable; // No Button in Panel
    public Button internetAvailable;// Yes Button in Panel
    public Button startGame;
    public Button takeTest;// Yes Button in Panel
    public Button importOrExport;
    public Button backButton;
    public Button backTokenButton;
    public Button nextTokenButton;
    public GameObject panel; // Panel
    public GameObject takeTestsVsImportOrExportflowPanel;
    public GameObject tokenPanel;
    public Dropdown dropDownSchool;
    public TextMeshProUGUI textError;
    public TextMeshProUGUI invalidPasscodeError;
    public TMP_InputField passcode; // Text display in Panel

    // Non-UI Elements
    public string sceneName; // Name up upcoming scene after loading data
    //public DataManager cleanup; //Saves data before loading

    // Use this for initialization
    void Start()
    {
        startGame.onClick.AddListener(startGameButtonClick);
        internetAvailable.onClick.AddListener(yesButtonClick);
        internetUnavailable.onClick.AddListener(noButtonClick);
        takeTest.onClick.AddListener(takeTestClick);
        importOrExport.onClick.AddListener(importOrExportClick);
        backButton.onClick.AddListener(backClick);
        backTokenButton.onClick.AddListener(buttonBackToken);
        nextTokenButton.onClick.AddListener(buttonProceedToken);
    }
    void startGameButtonClick()
    {
        panel.gameObject.SetActive(true);
    }
    // Occurs when logout button is clicked
    void yesButtonClick()
    {
        panel.gameObject.SetActive(false);
        DataManager.internetAvailable = true;
        populateDropDown();
        tokenPanel.gameObject.SetActive(true);
        //takeTestsVsImportOrExportflowPanel.gameObject.SetActive(true);
        //DataManager.currentScene = sceneName;
        //SceneManager.LoadScene(sceneName);
    }
    void populateDropDown()
    {
        List<Dropdown.OptionData> dropDownValues = new List<Dropdown.OptionData>();

        //Dropdown.OptionData emptyData = new Dropdown.OptionData();
        //emptyData.text = "";
        //dropDownValues.Add(emptyData);

        foreach (KeyValuePair<string, string> entry in DataManager.schoolVsToken)
        {
            string schoolName = entry.Key;
            Dropdown.OptionData newData = new Dropdown.OptionData();
            newData.text = schoolName;
            dropDownValues.Add(newData);

            // do something with entry.Value or entry.Key
        }

        dropDownSchool.AddOptions(dropDownValues);
    }

    void emptyDropDown()
    {
        while(dropDownSchool.options.Count > 1)
        {
            dropDownSchool.options.RemoveAt(1);
        }
    }

    void buttonProceedToken()
    {
        if (dropDownSchool.options[dropDownSchool.value].text == "")
        {
            //textError.enabled = true;
            textError.alpha = 255;
            invalidPasscodeError.alpha = 0;
        }
        else if(passcode.text.Trim() == "")
        {
            invalidPasscodeError.alpha = 255;
            textError.alpha = 0;
        }
        else if(dropDownSchool.options[dropDownSchool.value].text != "" && passcode.text.Trim() != "" && 
            passcode.text.Trim() != DataManager.schoolVsPasscode[dropDownSchool.options[dropDownSchool.value].text])
        {
            invalidPasscodeError.alpha = 255;
            textError.alpha = 0;
        }
        else
        {
            // Maintain a map
            // Show a dropdown
            // check if the token is selected 
            // and if everything is done then add token and proceed
            DataManager.tokenSelected = DataManager.schoolVsToken[dropDownSchool.options[dropDownSchool.value].text];
            tokenPanel.gameObject.SetActive(false);
            takeTestsVsImportOrExportflowPanel.gameObject.SetActive(true);
            emptyDropDown();
            //textError.enabled = false;
            textError.alpha = 0;
            invalidPasscodeError.alpha = 0;
            passcode.text = "";
        }
    }
    void buttonBackToken()
    {
        tokenPanel.gameObject.SetActive(false);
    }
    void backClick()
    {
        takeTestsVsImportOrExportflowPanel.gameObject.SetActive(false);
    }

    void takeTestClick()
    {
        takeTestsVsImportOrExportflowPanel.gameObject.SetActive(false);
        DataManager.currentScene = "UserInfo";
        SceneManager.LoadScene("UserInfo");
    }

    void importOrExportClick()
    {
        takeTestsVsImportOrExportflowPanel.gameObject.SetActive(false);
        DataManager.currentScene = "UserInfoMultiple";
        SceneManager.LoadScene("UserInfoMultiple");
    }


    // Occurs when logout button is clicked
    void noButtonClick()
    {
        panel.gameObject.SetActive(false);
        DataManager.internetAvailable = false;
        DataManager.currentScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }
}