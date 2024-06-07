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

public class HideAndShowCanvasSchool : MonoBehaviour
{
    public Canvas teacherCanvas; //Canvas to hide and show
    public Canvas schoolCanvas;

    public static string pdP;

    public Dropdown dropDownSchoolID;
    public Dropdown dropDownSchoolName;

    public Dropdown dropDownTeacherID;
    public Dropdown dropDownTeacherName;

    public TMP_InputField districtNameField;
    public TMP_InputField districtIDField;

    public TMP_InputField schoolNameField;
    public TMP_InputField schoolIDField;

    public TMP_InputField assessorNameField;
    public TMP_InputField assessorIDField;

    public static List<string> schoolIds;
    public static List<string> schoolNames;

    public Button schoolNextButton;
    public Button backToSchoolButton;

    public TextMeshProUGUI errorText;

    public static Dictionary<string, List<RedCapMasterRecord>> schoolIdVsRecord;
    public static Dictionary<string, List<RedCapMasterRecord>> schoolNameVsRecord;


    // Start is called before the first frame update
    void Start()
    {
        // load the data

        schoolIDField.enabled = false;
        schoolNameField.enabled = false;

        schoolNameField.gameObject.SetActive(false);
        schoolIDField.gameObject.SetActive(false);

        /*if (backToSchoolClicked)
        {
            districtIDField.enabled = false;
            populateDropDown(dropDownDistrictID, districtIds);
            populateDropDown(dropDownDistrictName, districtNames);
        }*/
        //schoolCanvas.gameObject.SetActive(true);

        if (schoolNextButton != null)
        {
            schoolNextButton.onClick.AddListener(schoolNextOnClick);
            schoolNextButton.enabled = true;
        }
        if(backToSchoolButton != null)
        {
            backToSchoolButton.onClick.AddListener(backToSchool);
        }

        pdP = Application.persistentDataPath;

        dropDownSchoolID.onValueChanged.AddListener(dropDownIDValueChanged);
        dropDownSchoolName.onValueChanged.AddListener(dropDownNameValueChanged);
    }

    void dropDownIDValueChanged(int value)
    {
        // show error if value is empty selected
        schoolNameField.text = "";
        schoolIDField.text = dropDownSchoolID.options[value].text;
        dropDownSchoolName.value = 0;
        //HideAndShowCanvasMainMenu.refID = "ID";
    }

    void dropDownNameValueChanged(int value)
    {
        schoolIDField.text = "";
        schoolNameField.text = dropDownSchoolName.options[value].text;
        dropDownSchoolID.value = 0;
        //HideAndShowCanvasMainMenu.refID = "Name";
    }

    void backToSchool()
    {
        dropDownSchoolID.enabled = false;
        dropDownSchoolName.enabled = false;

        if (HideAndShowCanvasDistrict.refID == "ID")
        {
            dropDownSchoolID.enabled = true;
        }
        else
        {
            dropDownSchoolName.enabled = true;
        }
        HideAndShowCanvasDistrict.populateDropDown(dropDownSchoolID, schoolIds);
        HideAndShowCanvasDistrict.populateDropDown(dropDownSchoolName, schoolNames);

        schoolIDField.text = "";
        schoolNameField.text = "";

        teacherCanvas.enabled = false;
        teacherCanvas.gameObject.SetActive(false);

        schoolCanvas.enabled = true;
        schoolCanvas.gameObject.SetActive(true);
    }

    bool checkIfSchoolDataIsNotProvided()
    {
        if (String.IsNullOrEmpty(schoolIDField.text) && String.IsNullOrEmpty(schoolNameField.text))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void schoolNextOnClick()
    {
        // validate and proceed
        errorText.enabled = false;
        errorText.gameObject.SetActive(false);

        if (checkIfSchoolDataIsNotProvided())
        {
            errorText.text = "Please fill all the details";
            errorText.enabled = true;
            errorText.gameObject.SetActive(true);
        }
        else
        {

            HideAndShowCanvasTeacher.teacherIds = new List<string>();
            HideAndShowCanvasTeacher.teacherNames = new List<string>();

            dropDownTeacherID.enabled = true;
            dropDownTeacherName.enabled = true;

            assessorIDField.enabled = true;
            assessorNameField.enabled = true;
            assessorIDField.gameObject.SetActive(true);
            assessorNameField.gameObject.SetActive(true);

            if (DataManager.internetAvailable)
            {
                HideAndShowCanvasTeacher.teacherIdVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();
                HideAndShowCanvasTeacher.teacherNameVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();

                if (HideAndShowCanvasDistrict.refID == "ID")
                {
                    
                    getListFromMap(schoolIdVsRecord[schoolIDField.text], HideAndShowCanvasTeacher.teacherIds,
                        HideAndShowCanvasTeacher.teacherNames, HideAndShowCanvasTeacher.teacherIdVsRecord,
                        HideAndShowCanvasTeacher.teacherNameVsRecord);

                    HideAndShowCanvasDistrict.createDataFile(districtIDField.text + "_" + schoolIDField.text + "_ID_teacherFile", HideAndShowCanvasTeacher.teacherIds);
                    dropDownTeacherName.enabled = false;
                    assessorNameField.enabled = false;
                    assessorNameField.gameObject.SetActive(false);

                }
                else
                {
                    getListFromMap(schoolNameVsRecord[schoolNameField.text], HideAndShowCanvasTeacher.teacherIds,
                        HideAndShowCanvasTeacher.teacherNames, HideAndShowCanvasTeacher.teacherIdVsRecord,
                        HideAndShowCanvasTeacher.teacherNameVsRecord);

                    HideAndShowCanvasDistrict.createDataFile(districtNameField.text + "_" + schoolNameField.text + "_Name_teacherFile", HideAndShowCanvasTeacher.teacherNames);
                    dropDownTeacherID.enabled = false;
                    assessorIDField.enabled = false;
                    assessorIDField.gameObject.SetActive(false);
                }


            }
            else
            {
                if (HideAndShowCanvasDistrict.refID == "ID")
                {
                    HideAndShowCanvasTeacher.teacherIds.AddRange(HideAndShowCanvasDistrict.getFileData(districtIDField.text + "_" + schoolIDField.text + "_ID_teacherFile"));
                    dropDownTeacherName.enabled = false;
                    assessorNameField.enabled = false;
                    assessorNameField.gameObject.SetActive(false);
                }
                else
                {
                    HideAndShowCanvasTeacher.teacherNames.AddRange(HideAndShowCanvasDistrict.getFileData(districtNameField.text + "_" + schoolNameField.text + "_Name_teacherFile"));
                    dropDownTeacherID.enabled = false;
                    assessorIDField.enabled = false;
                    assessorIDField.gameObject.SetActive(false);
                }
            }

            HideAndShowCanvasDistrict.populateDropDown(dropDownTeacherID, HideAndShowCanvasTeacher.teacherIds);
            HideAndShowCanvasDistrict.populateDropDown(dropDownTeacherName, HideAndShowCanvasTeacher.teacherNames);

                teacherCanvas.enabled = true;
                teacherCanvas.gameObject.SetActive(true);
                schoolCanvas.enabled = false;
                schoolCanvas.gameObject.SetActive(false);
        }
    }

    void getListFromMap(List<RedCapMasterRecord> list, List<string> teacherIds, List<string> teacherNames, Dictionary<string, 
        List<RedCapMasterRecord>> teacherIdVsList, Dictionary<string, List<RedCapMasterRecord>> teacherNameVsList)
    {

        foreach (RedCapMasterRecord rcmr in list)
        {
            string teacherId = rcmr.teacherID;
            if (!teacherIds.Contains(teacherId))
            {
                teacherIds.Add(teacherId);
            }
            
            if(!teacherIdVsList.ContainsKey(teacherId))
            {
                teacherIdVsList[teacherId] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> idList = teacherIdVsList[teacherId];
            idList.Add(rcmr);

            string teacherName = rcmr.teacherName;
            if (!teacherNames.Contains(teacherName))
            {
                teacherNames.Add(teacherName);
            }
            
            if (!teacherNameVsList.ContainsKey(teacherName))
            {
                teacherNameVsList[teacherName] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> nameList = teacherNameVsList[teacherName];
            nameList.Add(rcmr);
        }

    }

}
