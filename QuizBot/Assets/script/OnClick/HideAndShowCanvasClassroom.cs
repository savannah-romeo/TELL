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

public class HideAndShowCanvasClassroom : MonoBehaviour
{
    public Canvas studentCanvas; //Canvas to hide and show
    public Canvas classroomCanvas;

    public static string pdP;

    public Dropdown dropDownClassroomID;
    public Dropdown dropDownClassroomName;

    public Dropdown dropDownStudentID;
    public Dropdown dropDownStudentName;

    public TMP_InputField districtNameField;
    public TMP_InputField districtIDField;

    public TMP_InputField schoolNameField;
    public TMP_InputField schoolIDField;

    public TMP_InputField teacherNameField;
    public TMP_InputField teacherIDField;

    public TMP_InputField classroomNameField;
    public TMP_InputField classroomIDField;

    public TMP_InputField passcode;

    public static List<string> classroomIds;
    public static List<string> classroomNames;

    public Button classroomNextButton;
    public Button backToClassroomButton;

    public TextMeshProUGUI errorText;

    public static Dictionary<string, List<RedCapMasterRecord>> classroomIdVsRecord;
    public static Dictionary<string, List<RedCapMasterRecord>> classroomNameVsRecord;


    // Start is called before the first frame update
    void Start()
    {
        // load the data


        /*if (backToSchoolClicked)
        {
            districtIDField.enabled = false;
            populateDropDown(dropDownDistrictID, districtIds);
            populateDropDown(dropDownDistrictName, districtNames);
        }*/
        //schoolCanvas.gameObject.SetActive(true);

        classroomIDField.enabled = false;
        classroomNameField.enabled = false;

        classroomNameField.gameObject.SetActive(false);
        classroomIDField.gameObject.SetActive(false);

        if (classroomNextButton != null)
        {
            classroomNextButton.onClick.AddListener(classroomNextOnClick);
            classroomNextButton.enabled = true;
        }
        if(backToClassroomButton != null)
        {
            backToClassroomButton.onClick.AddListener(backToClassroom);
        }

        pdP = Application.persistentDataPath;

        dropDownClassroomID.onValueChanged.AddListener(dropDownIDValueChanged);
        dropDownClassroomName.onValueChanged.AddListener(dropDownNameValueChanged);
    }

    void dropDownIDValueChanged(int value)
    {
        // show error if value is empty selected
        classroomNameField.text = "";
        classroomIDField.text = dropDownClassroomID.options[value].text;
        dropDownClassroomName.value = 0;
        //HideAndShowCanvasMainMenu.refID = "ID";
    }

    void dropDownNameValueChanged(int value)
    {
        classroomIDField.text = "";
        classroomNameField.text = dropDownClassroomName.options[value].text;
        dropDownClassroomID.value = 0;
        //HideAndShowCanvasMainMenu.refID = "Name";
    }

    bool checkIfClassroomDataIsNotProvided()
    {
        if (String.IsNullOrEmpty(classroomIDField.text) && String.IsNullOrEmpty(classroomNameField.text))
        {
            return true;
        }
        else if (String.IsNullOrEmpty(passcode.text))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void classroomNextOnClick()
    {
        // validate and proceed
        errorText.enabled = false;
        errorText.gameObject.SetActive(false);

        if (checkIfClassroomDataIsNotProvided())
        {
            errorText.text = "Please fill all the details";
            errorText.enabled = true;
            errorText.gameObject.SetActive(true);
        }
        else
        {
            List<RedCapMasterRecord> rcmrList;
            if (HideAndShowCanvasDistrict.refID == "ID")
            {
                if (!classroomIdVsRecord.ContainsKey(classroomIDField.text)){
                    errorText.text = "Details not available";
                    errorText.enabled = true;
                    errorText.gameObject.SetActive(true);
                    return;
                }
                rcmrList = matchPasscode(classroomIdVsRecord[classroomIDField.text],passcode.text);
            }
            else
            {
                if (!classroomNameVsRecord.ContainsKey(classroomNameField.text)){
                    errorText.text = "Details not available";
                    errorText.enabled = true;
                    errorText.gameObject.SetActive(true);
                    return;
                }
                rcmrList = matchPasscode(classroomNameVsRecord[classroomNameField.text], passcode.text);
            }
            if (rcmrList.Count == 0)
            {
                errorText.text = "Please fill all the details";
                errorText.enabled = true;
                errorText.gameObject.SetActive(true);
            }
            else
            {
                populateRedCapMasterRecord(rcmrList[0]);


                HideAndShowCanvasStudent.studentIds = new List<string>();
                HideAndShowCanvasStudent.studentNames = new List<string>();

                dropDownStudentID.enabled = true;
                dropDownStudentName.enabled = true;

                if (DataManager.internetAvailable)
                {
                    HideAndShowCanvasStudent.studentIdVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();
                    HideAndShowCanvasStudent.studentNameVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();

                    //HideAndShowCanvasStudent.studentIds.Add("New User");
                    //HideAndShowCanvasStudent.studentNames.Add("New User");

                    getListFromMap(rcmrList, HideAndShowCanvasStudent.studentIds,
                            HideAndShowCanvasStudent.studentNames, HideAndShowCanvasStudent.studentIdVsRecord,
                            HideAndShowCanvasStudent.studentNameVsRecord);

                    if (HideAndShowCanvasDistrict.refID == "ID")
                    {

                        HideAndShowCanvasDistrict.createDataFile(districtIDField.text + "_" + schoolIDField.text + "_" + teacherIDField.text + "_" + classroomIDField.text + "_ID_studentFile", HideAndShowCanvasStudent.studentIds);
                        dropDownStudentName.enabled = false;
                    }
                    else
                    {
                        HideAndShowCanvasDistrict.createDataFile(districtNameField.text + "_" + schoolNameField.text + "_" + teacherNameField.text + "_" + classroomNameField.text + "_Name_studentFile", HideAndShowCanvasStudent.studentNames);
                        dropDownStudentID.enabled = false;
                    }

                }
                else
                {
                    if (HideAndShowCanvasDistrict.refID == "ID")
                    {
                        HideAndShowCanvasStudent.studentIds.AddRange(HideAndShowCanvasDistrict.getFileData(districtIDField.text + "_" + schoolIDField.text + "_" + teacherIDField.text + "_" + classroomIDField.text + "_ID_studentFile"));
                        dropDownStudentName.enabled = false;
                    }
                    else
                    {
                        HideAndShowCanvasStudent.studentNames.AddRange(HideAndShowCanvasDistrict.getFileData(districtNameField.text + "_" + schoolNameField.text + "_" + teacherNameField.text + "_" + classroomNameField.text + "_Name_studentFile"));
                        dropDownStudentID.enabled = false;
                    }
                }

                HideAndShowCanvasDistrict.populateDropDown(dropDownStudentID, HideAndShowCanvasStudent.studentIds);
                HideAndShowCanvasDistrict.populateDropDown(dropDownStudentName, HideAndShowCanvasStudent.studentNames);

                DataManager.studentNameList = HideAndShowCanvasStudent.studentNames;
                DataManager.studentIdList = HideAndShowCanvasStudent.studentIds;

                studentCanvas.enabled = true;
                studentCanvas.gameObject.SetActive(true);
                classroomCanvas.enabled = false;
                classroomCanvas.gameObject.SetActive(false);
            }
        }
    }

    void backToClassroom()
    {
        dropDownClassroomID.enabled = false;
        dropDownClassroomName.enabled = false;

        if (HideAndShowCanvasDistrict.refID == "ID")
        {
            dropDownClassroomID.enabled = true;
        }
        else
        {
            dropDownClassroomName.enabled = true;
        }
        HideAndShowCanvasDistrict.populateDropDown(dropDownClassroomID, HideAndShowCanvasClassroom.classroomIds);
        HideAndShowCanvasDistrict.populateDropDown(dropDownClassroomName, HideAndShowCanvasClassroom.classroomNames);

        classroomIDField.text = "";
        classroomNameField.text = "";

        studentCanvas.enabled = false;
        studentCanvas.gameObject.SetActive(false);

        classroomCanvas.enabled = true;
        classroomCanvas.gameObject.SetActive(true);
    }

    void populateRedCapMasterRecord(RedCapMasterRecord rcmr)
    {
        RedCapMasterRecord redCapMasterRecord = new RedCapMasterRecord();
        redCapMasterRecord.classroomEventName = rcmr.classroomEventName;
        redCapMasterRecord.passcode = rcmr.passcode;
        redCapMasterRecord.schoolName = rcmr.schoolName;
        redCapMasterRecord.classroomName = rcmr.classroomName;
        redCapMasterRecord.districtName = rcmr.districtName;
        redCapMasterRecord.teacherName = rcmr.teacherName;
        redCapMasterRecord.classroomID = rcmr.classroomID;
        redCapMasterRecord.schoolID = rcmr.schoolID;
        redCapMasterRecord.recordID = rcmr.recordID;
        redCapMasterRecord.districtID = rcmr.districtID;
        redCapMasterRecord.teacherID = rcmr.teacherID;
        redCapMasterRecord.token = rcmr.token;
        redCapMasterRecord.refID = HideAndShowCanvasDistrict.refID;

        DataManager.redCapMasterRecord = redCapMasterRecord;
    }
    List<RedCapMasterRecord> matchPasscode(List<RedCapMasterRecord> list, string passcode)
    {
        List<RedCapMasterRecord> result = new List<RedCapMasterRecord>();

        foreach(RedCapMasterRecord rcmr in list)
        {
            if(rcmr.passcode == passcode)
            {
                result.Add(rcmr);
            }
        }
        return result;
    }

    void getListFromMap(List<RedCapMasterRecord> list, List<string> studentIds, List<string> studentNames, Dictionary<string, 
        List<RedCapMasterRecord>> studentIdVsList, Dictionary<string, List<RedCapMasterRecord>> studentNameVsList)
    {

        foreach (RedCapMasterRecord rcmr in list)
        {
            string studentId = rcmr.studentID;
            if (!studentIds.Contains(studentId))
            {
                studentIds.Add(studentId);
            }
            
            if(!studentIdVsList.ContainsKey(studentId))
            {
                studentIdVsList[studentId] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> idList = studentIdVsList[studentId];
            idList.Add(rcmr);

            string studentName = rcmr.studentName;
            if (!studentNames.Contains(studentName))
            {
                studentNames.Add(studentName);
            }
            
            if (!studentNameVsList.ContainsKey(studentName))
            {
                studentNameVsList[studentName] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> nameList = studentNameVsList[studentName];
            nameList.Add(rcmr);
        }

    }

}
