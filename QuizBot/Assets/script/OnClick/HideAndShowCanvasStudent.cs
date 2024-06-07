//This script hides a canvas on click
//and shows it when a certain button is clicked 
//Used for prompt displays for each question
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HideAndShowCanvasStudent : MonoBehaviour
{
    public Canvas studentCanvas; //Canvas to hide and show
    public Canvas classroomCanvas;

    public Canvas districtCanvas;

    public static string pdP;

    public Dropdown dropDownStudentID;
    public Dropdown dropDownStudentName;

    //public TMP_InputField passcode;

    public static List<string> studentIds;
    public static List<string> studentNames;

    //public Button classroomNextButton;
    //public Button backButton;

    public TextMeshProUGUI errorText;

    public TMP_InputField childNameField;
    public TMP_InputField childIDField;

    public TextMeshProUGUI childLabel;

    public static bool backClicked;

    public TMP_InputField teacherNameField;
    //public TMP_InputField studentNameField;
    public TMP_InputField classroomNameField;
    public TMP_InputField districtNameField;
    public TMP_InputField schoolNameField;
    public TMP_InputField assessorNameField;

    public TMP_InputField teacherIDField;
    //public TMP_InputField studentIDField;
    public TMP_InputField classroomIDField;
    public TMP_InputField districtIDField;
    public TMP_InputField schoolIDField;
    public TMP_InputField assessorIDField;

    public static Dictionary<string, List<RedCapMasterRecord>> studentIdVsRecord;
    public static Dictionary<string, List<RedCapMasterRecord>> studentNameVsRecord;


    // Start is called before the first frame update
    void Start()
    {
        // load the data

        childIDField.enabled = false;
        childNameField.enabled = false;
        childNameField.gameObject.SetActive(false);
        childIDField.gameObject.SetActive(false);
        childLabel.enabled = false;

        if (backClicked)
        {
            studentCanvas.gameObject.SetActive(true);
            studentCanvas.enabled = true;
            districtCanvas.gameObject.SetActive(false);
            districtCanvas.enabled = false;
            if (HideAndShowCanvasDistrict.refID == "ID")
            {
                teacherIDField.text = DataManager.teacherID;
                assessorIDField.text = DataManager.assessorID;
                classroomIDField.text = DataManager.classroomID;
                schoolIDField.text = DataManager.schoolID;
                districtIDField.text = DataManager.districtID;
                dropDownStudentName.enabled = false;
            }
            else
            {
                teacherNameField.text = DataManager.teacherID;
                assessorNameField.text = DataManager.assessorID;
                classroomNameField.text = DataManager.classroomID;
                schoolNameField.text = DataManager.schoolID;
                districtNameField.text = DataManager.districtID;
                dropDownStudentID.enabled = false;
            }
            HideAndShowCanvasDistrict.populateDropDown(dropDownStudentID, DataManager.studentIdList);
            HideAndShowCanvasDistrict.populateDropDown(dropDownStudentName, DataManager.studentNameList);
            backClicked = false;
        }
        /*if (backToSchoolClicked)
        {
            districtIDField.enabled = false;
            populateDropDown(dropDownDistrictID, districtIds);
            populateDropDown(dropDownDistrictName, districtNames);
        }*/
        //schoolCanvas.gameObject.SetActive(true);

        /*if(classroomNextButton != null)
        {
            classroomNextButton.onClick.AddListener(classroomNextOnClick);
            classroomNextButton.enabled = true;
        }*/
        /*if(backButton != null)
        {
            backButton.onClick.AddListener(backOnClick);
        }*/

        pdP = Application.persistentDataPath;

        dropDownStudentID.onValueChanged.AddListener(dropDownValueChanged);
        dropDownStudentName.onValueChanged.AddListener(dropDownValueChanged);
    }

    void dropDownValueChanged(int value)
    {
        // show error if value is empty selected

        if (HideAndShowCanvasDistrict.refID == "ID")
        {
            if (dropDownStudentID.options[value].text == "New User")
            {
                childNameField.text = "";
                childIDField.text = "";
                childIDField.enabled = true;

                childIDField.gameObject.SetActive(true);

                childLabel.enabled = true;
            }
            else
            {
                childNameField.text = "";
                childIDField.enabled = false;
                childLabel.enabled = false;

                childIDField.gameObject.SetActive(false);

                childIDField.text = dropDownStudentID.options[value].text;
            }
        }
        else
        {
            if (dropDownStudentName.options[value].text == "New User")
            {
                childIDField.text = "";
                childNameField.text = "";
                childNameField.enabled = true;

                childNameField.gameObject.SetActive(true);

                childLabel.enabled = true;
            }
            else
            {
                childIDField.text = "";
                childNameField.enabled = false;
                childNameField.gameObject.SetActive(false);
                childLabel.enabled = false;
                childNameField.text = dropDownStudentName.options[value].text;
            }
        }
    }
}
