using UnityEngine;
using UnityEngine.UI;

public class RevertingBackTheToggle : MonoBehaviour
{
    public Toggle toggleYes;
    public Toggle toggleNo;
    public Toggle receptiveToggleYes; //Vocab
    public Toggle receptiveToggleNo;
    public Toggle expressiveFlag;
    public Toggle receptiveFlag;
    public Toggle responseFlag;
    public Button clickedButton;

    void Start()
    {
        clickedButton.onClick.AddListener(TaskOnClick);
        /*if (toggleYes != null)
        {
            toggleYes.isOn = false;
        }
        if (toggleNo != null)
        {
            toggleNo.isOn = false;
        }
        if (receptiveToggleYes != null)
        {
            receptiveToggleYes.isOn = false;
        }
        if (receptiveToggleNo != null)
        {
            receptiveToggleNo.isOn = false;
        }
        if (expressiveFlag != null)
        {
            expressiveFlag.isOn = false;
        }
        if (receptiveFlag != null)
        {
            receptiveFlag.isOn = false;
        }
        if (responseFlag != null)
        {
            responseFlag.isOn = false;
        }*/
    }
    protected void TaskOnClick()
    {
        if(toggleYes != null)
        {
            toggleYes.isOn = false;
        }
        if (toggleNo != null)
        {
            toggleNo.isOn = false;
        }
        if (receptiveToggleYes != null)
        {
            receptiveToggleYes.isOn = false;
        }
        if (receptiveToggleNo != null)
        {
            receptiveToggleNo.isOn = false;
        }
        if (expressiveFlag != null)
        {
            expressiveFlag.isOn = false;
        }
        if (receptiveFlag != null)
        {
            receptiveFlag.isOn = false;
        }
        if (responseFlag != null)
        {
            responseFlag.isOn = false;
        }
    }
}
