using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LNIToggleCheck : MonoBehaviour
{
    // UI Elements
    public Toggle toggleYes;
    public Toggle toggleNo;
    public GameObject panel;
    public AdvanceTextAlphabet advanceTextAlphabet;
    public Button yesProceed;
    public Button noEnd;
    public Button next;
    //public bool end;

    // Use this for initialization
    void Start()
    {
        //end = true;
        yesProceed.onClick.AddListener(yesProceedOnClick);
        noEnd.onClick.AddListener(noEndOnClick);
        toggleYes.onValueChanged.AddListener(delegate { toggleChanged(toggleYes); });
        toggleNo.onValueChanged.AddListener(delegate { toggleChanged(toggleNo); });
    }


    public void toggleChanged(Toggle toggleObj)
    {
        if (DataManager.globalGame == "LNI_Instructions" && toggleObj.isOn)
        {
            int part1 = 6 - 1;
            if (advanceTextAlphabet.iterator == part1) //ok, we've hit 6
            {
                int wrongos = 0;
                //if we can find 3+ incorrect answers, it's time to stop
                for (int index = 0; index < DataManager.individual_LNI.GetLength(0); index++)
                {
                    if (DataManager.individual_LNI[index, DataManager.globalTime - 1] == AdaptiveResponse.Incorrect)
                        wrongos++;
                }
                if (toggleNo.isOn)
                {
                    wrongos++;
                }
                Debug.Log("console output " + wrongos);
                if (wrongos >= 5)
                {
                    panel.gameObject.SetActive(true);
                }
                /*else
                {
                    advanceTextAlphabet.complete = false;
                }*/
            }
        }
    }
    void yesProceedOnClick()
    {
        panel.gameObject.SetActive(false);
        //advanceTextAlphabet.complete = false;
        next.onClick.Invoke();
        //end = false;

    }
 
    void noEndOnClick()
    {
        panel.gameObject.SetActive(false);
        advanceTextAlphabet.complete = true;
        next.onClick.Invoke();
        //end = true;
    }
}
