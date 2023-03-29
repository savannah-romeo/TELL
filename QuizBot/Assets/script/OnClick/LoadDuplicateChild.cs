using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// Function responsible for loading user data
public class LoadDuplicateChild : MonoBehaviour
{
    // UI Elements
    public Button noBtn; // No Button in Panel
    public Button yesBtn; // Yes Button in Panel
    public GameObject panel; // Panel
    public TextMeshProUGUI displayText; // Text display in Panel

    // Non-UI Elements
    public string sceneName; // Name up upcoming scene after loading data
    public DataManager cleanup; //Saves data before loading

    // Use this for initialization
    void Start()
    {
        if(DataManager.childExists){
            panel.gameObject.SetActive(true); 
        }
        yesBtn.onClick.AddListener(yesButtonClick);
        noBtn.onClick.AddListener(logoutButtonClick);
    }

    // Occurs when logout button is clicked
    void yesButtonClick()
    {
        panel.gameObject.SetActive(false);
        DataManager.childExists = false;
        DataManager.childFileExists = false;
    }


    // Occurs when logout button is clicked
    void logoutButtonClick()
    {
        panel.gameObject.SetActive(false);
        DataManager.childExists = false;
        DataManager.childFileExists = false;
        // Load new scene
        cleanup.SceneCleanup();
        DataManager.currentScene = "UserInfo"; //Updates DataManager scene string
        SceneManager.LoadScene("UserInfo");
    }
}