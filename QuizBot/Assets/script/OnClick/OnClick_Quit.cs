//This class is used to exit the app when a button is clicked
using UnityEngine;
using UnityEngine.UI;

public class OnClick_Quit : MonoBehaviour
{
    public Button quitButton; //Button clicked

    void Start()
    {
        //Create listener for the button in question
        quitButton.onClick.AddListener(QuitOnClick);

    }

    void QuitOnClick()
    {
        Application.Quit();
    }
}
