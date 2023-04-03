using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BookSumExtraMarkToggle : MonoBehaviour
{
    public Toggle bookSum;
    void Start()
    {
        Toggle toggleResponseYes = GameObject.Find("toggle_expressive_yes").GetComponent<Toggle>();
        
        toggleResponseYes.onValueChanged.AddListener((value) =>
        {   // you are missing this
            handleCheckbox(value);
        });
     }

    void handleCheckbox(bool value)
    {
        //Toggle toggleBookSum = GameObject.Find("bookSum_ExtraMark_Toggle").GetComponent<Toggle>();
        if (value && DataManager.question_no == 6)
        {
            //GameObject.Find("bookSum_ExtraMark_Toggle").SetActive(true);
            bookSum.gameObject.SetActive(true);
                }
        else if (bookSum.gameObject != null){
                bookSum.gameObject.SetActive(false);
            
            //GameObject.Find("bookSum_ExtraMark_Toggle").SetActive(false);
        }
    }
}
