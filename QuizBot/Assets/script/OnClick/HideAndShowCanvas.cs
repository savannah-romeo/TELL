//This script hides a canvas on click
//and shows it when a certain button is clicked 
//Used for prompt displays for each question
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HideAndShowCanvas : MonoBehaviour
{
    public Canvas hnsCanvas; //Canvas to hide and show
    public GameObject background; //BG image to hide and show (separate renderer)
    public Button showButton; //Button that shows canvas
    public AdvanceTextBookSum advanceTextBookSum;
    //public Button viewImageButton;
    public Button nextButton;
    public Button showPromptButton;

    // Start is called before the first frame update
    void Start()
    {
        //Call ShowOnClick when showButton is clicked
        showButton.onClick.AddListener(ShowOnClick);
        showButton.enabled = false; //Only enable button when canvas is hidden
        /*if (viewImageButton != null)
        {
            viewImageButton.onClick.AddListener(viewImage);
            viewImageButton.enabled = false;
        }*/
        if(nextButton != null)
        {
            nextButton.onClick.AddListener(nextOnClick);
            nextButton.enabled = true;
        }
        if(showPromptButton != null)
        {
            showPromptButton.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Hide canvas on click if currently displayed
        if (DataManager.globalGame != "BS_Instructions_1")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hnsCanvas.enabled == true)
                {
                    if (DataManager.globalGame == "Instructions_Vocab")
                    {
                        Thread.Sleep(1000);
                    }
                    hnsCanvas.enabled = false;
                    background.SetActive(false);
                    showButton.enabled = true;
                    if (advanceTextBookSum != null)
                    {
                        advanceTextBookSum.toggleGroup.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    void nextOnClick()
    {
        if (hnsCanvas.enabled == true)
        {
            hnsCanvas.enabled = false;
            background.SetActive(false);
            showButton.enabled = true;
            nextButton.enabled = false;
            showPromptButton.enabled = false;
        }
    }

    //Show canvas if not shown and not in the middle of a click
    void ShowOnClick()
    {
        if (hnsCanvas.enabled == false)
        {
            hnsCanvas.enabled = true;
            background.SetActive(true);
            showButton.enabled = false;
            if(advanceTextBookSum != null)
            {
                advanceTextBookSum.toggleGroup.gameObject.SetActive(false);
            }
            if(nextButton != null)
            {
                nextButton.enabled = true;
            }
            if (showPromptButton != null)
            {
                showPromptButton.enabled = true;
            }
        }
    }
}
