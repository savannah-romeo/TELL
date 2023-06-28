//This script is used to save the game
//selected when a button is clicked based on
//that button's name.
using UnityEngine;
using UnityEngine.UI;

public class SetGame : MonoBehaviour
{
    public Button gameButton;

    // Start is called before the first frame update
    void Start()
    {
        //Create listener for the button in question
        gameButton.onClick.AddListener(SetOnClick);
    }

    // Update is called once per frame
    void SetOnClick()
    {
        DataManager.globalGame = SaveGame(gameButton.name);
    }
    public static string SaveGame(string btnGame) => btnGame switch
    {
        "buttonVocabulary" => "Instructions",
        "buttonVocabularyNew" => "Instructions_Vocab",
        "buttonLNI" => "LNI_Instructions",
        "buttonLSI" => "LSI_Instructions",
        "buttonBS" => "BS_Instructions_1",
        "buttonCS" => "CS_Instructions",
        "buttonWriting" => "Writing_Instructions",
        "buttonSR" => "SR_Instructions_1",
        "buttonBookSum" => "BookSum_Instructions_1",
        "buttonCOP" => "CAP_Instructions_1",
        _ => "Error: No game found for button!" //Default 'error' case
    };
}
