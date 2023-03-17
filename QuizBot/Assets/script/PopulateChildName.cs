using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulateChildName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateName();
    }
    
    void UpdateName()
    {
        // Assuming that name has the correct name.
        var textMeshPro = GameObject.Find("text_variable_child").GetComponent<TextMeshProUGUI>();
        textMeshPro.text = DataManager.childID;

        //var dataManager = GameObject.Find("Scripts").GetComponent<PopulateChildName>();
        //this.Name = dataManager.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
