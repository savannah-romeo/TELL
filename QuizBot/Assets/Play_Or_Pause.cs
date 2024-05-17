using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Play_Or_Pause : MonoBehaviour
{
    // UI Elements
    public Button resumeBtn;
    public Button pauseBtn;
    public GameObject panel;

    // Use this for initialization
    void Start()
    {
        resumeBtn.onClick.AddListener(resumeBtnOnClick);
        pauseBtn.onClick.AddListener(pauseBtnOnClick);
    }

    void resumeBtnOnClick()
    {
        panel.gameObject.SetActive(false);

    }
 
    void pauseBtnOnClick()
    {
        panel.gameObject.SetActive(true);
    }
}
