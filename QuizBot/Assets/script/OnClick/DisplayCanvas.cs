//This class displays a canvas when a toggle is toggled on
//Used to display conditional data entry fields
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCanvas : MonoBehaviour
{
    public Toggle clickedToggle; //Toggle to watch
    public Canvas displayCanvas; //Canvas to display

    void Start()
    {
        //Hide canvas now that we've saved it to the script
        displayCanvas.enabled = false;

        //Create listener for the toggle
        clickedToggle.onValueChanged.AddListener(delegate 
        {
            ToggleValueChanged();
        });
    }

    //Triggered by listener
    //Toggles canvas active state based on toggle state
    void ToggleValueChanged()
    {
        if(clickedToggle.isOn) //if input is invalid
            displayCanvas.enabled = true;
        else
            displayCanvas.enabled = false;
    }
}

