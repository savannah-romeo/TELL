using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// Function responsible for loading user data
public class CheckInternetConnection : MonoBehaviour
{
    // UI Elements
    public Button internetUnavailable; // No Button in Panel
    public Button internetAvailable;// Yes Button in Panel
    public Button startGame;
    public Button takeTest;// Yes Button in Panel
    public Button importOrExport;
    public GameObject panel; // Panel
    public GameObject takeTestsVsImportOrExportflowPanel;
    //public TextMeshProUGUI displayText; // Text display in Panel

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
        takeTestsVsImportOrExportflowPanel.gameObject.SetActive(true);
        //DataManager.currentScene = sceneName;
        //SceneManager.LoadScene(sceneName);
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