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

public class HideAndShowCanvasTeacher : MonoBehaviour
{
    public Canvas classroomCanvas; //Canvas to hide and show
    public Canvas teacherCanvas;

    public static string pdP;

    public Dropdown dropDownTeacherID;
    public Dropdown dropDownTeacherName;

    public Dropdown dropDownClassroomID;
    public Dropdown dropDownClassroomName;

    public TMP_InputField districtNameField;
    public TMP_InputField districtIDField;

    public TMP_InputField schoolNameField;
    public TMP_InputField schoolIDField;

    public TMP_InputField teacherNameField;
    public TMP_InputField teacherIDField;

    public TMP_InputField assessorNameField;
    public TMP_InputField assessorIDField;

    public static List<string> teacherIds;
    public static List<string> teacherNames;

    public Button teacherNextButton;
    public Button backToTeacherButton;

    public TextMeshProUGUI errorText;

    public static Dictionary<string, List<RedCapMasterRecord>> teacherIdVsRecord;
    public static Dictionary<string, List<RedCapMasterRecord>> teacherNameVsRecord;


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

        teacherIDField.enabled = false;
        teacherNameField.enabled = false;

        teacherNameField.gameObject.SetActive(false);
        teacherIDField.gameObject.SetActive(false);

        if (teacherNextButton != null)
        {
            teacherNextButton.onClick.AddListener(teacherNextOnClick);
            teacherNextButton.enabled = true;
        }
        if(backToTeacherButton != null)
        {
            backToTeacherButton.onClick.AddListener(backToTeacher);
        }

        pdP = Application.persistentDataPath;

        dropDownTeacherID.onValueChanged.AddListener(dropDownIDValueChanged);
        dropDownTeacherName.onValueChanged.AddListener(dropDownNameValueChanged);
    }

    void dropDownIDValueChanged(int value)
    {
        // show error if value is empty selected
        teacherNameField.text = "";
        teacherIDField.text = dropDownTeacherID.options[value].text;
        dropDownTeacherName.value = 0;
        //HideAndShowCanvasMainMenu.refID = "ID";
    }

    void dropDownNameValueChanged(int value)
    {
        teacherIDField.text = "";
        teacherNameField.text = dropDownTeacherName.options[value].text;
        dropDownTeacherID.value = 0;
        //HideAndShowCanvasMainMenu.refID = "Name";
    }

    bool checkIfTeacherDataIsNotProvided()
    {
        if (String.IsNullOrEmpty(teacherIDField.text) && String.IsNullOrEmpty(teacherNameField.text))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void createClassroomWithRecordDataFile(string fileName, Dictionary<string, List<RedCapMasterRecord>> dataMap)
    {

        if (File.Exists(Path.Combine(pdP, fileName + ".dat")))
        {
            File.Delete(Path.Combine(pdP, fileName + ".dat"));
        }

        string savePath = Path.Combine(pdP, fileName + ".dat"); // File path for storage with the file name
        Debug.Log(fileName);
        Debug.Log(savePath);

        //Create and save file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, dataMap);
        file.Close();
    }

    void teacherNextOnClick()
    {
        // validate and proceed
        errorText.enabled = false;
        errorText.gameObject.SetActive(false);

        if (checkIfTeacherDataIsNotProvided())
        {
            errorText.text = "Please fill all the details";
            errorText.enabled = true;
            errorText.gameObject.SetActive(true);
        }
        else
        {

            HideAndShowCanvasClassroom.classroomIds = new List<string>();
            HideAndShowCanvasClassroom.classroomNames = new List<string>();

            dropDownClassroomID.enabled = true;
            dropDownClassroomName.enabled = true;

            if (DataManager.internetAvailable)
            {
                HideAndShowCanvasClassroom.classroomIdVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();
                HideAndShowCanvasClassroom.classroomNameVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();

                if (HideAndShowCanvasDistrict.refID == "ID")
                {
                    
                    getListFromMap(teacherIdVsRecord[teacherIDField.text], HideAndShowCanvasClassroom.classroomIds,
                        HideAndShowCanvasClassroom.classroomNames, HideAndShowCanvasClassroom.classroomIdVsRecord,
                        HideAndShowCanvasClassroom.classroomNameVsRecord);

                    HideAndShowCanvasDistrict.createDataFile(districtIDField.text + "_" + schoolIDField.text + "_" + teacherIDField.text + "_ID_classroomFile", HideAndShowCanvasClassroom.classroomIds);

                    createClassroomWithRecordDataFile(districtIDField.text + "_" + schoolIDField.text + "_" + teacherIDField.text + "_ID_classroomWithRecordFile", HideAndShowCanvasClassroom.classroomIdVsRecord);

                    dropDownClassroomName.enabled = false;
                }
                else
                {
                    getListFromMap(teacherNameVsRecord[teacherNameField.text], HideAndShowCanvasClassroom.classroomIds,
                        HideAndShowCanvasClassroom.classroomNames, HideAndShowCanvasClassroom.classroomIdVsRecord,
                        HideAndShowCanvasClassroom.classroomNameVsRecord);

                    HideAndShowCanvasDistrict.createDataFile(districtNameField.text + "_" + schoolNameField.text + "_" + teacherNameField.text + "_Name_classroomFile", HideAndShowCanvasClassroom.classroomNames);

                    createClassroomWithRecordDataFile(districtNameField.text + "_" + schoolNameField.text + "_" + teacherNameField.text + "_Name_classroomWithRecordFile", HideAndShowCanvasClassroom.classroomNameVsRecord);

                    dropDownClassroomID.enabled = false;
                }

            }
            else
            {
                if (HideAndShowCanvasDistrict.refID == "ID")
                {
                    HideAndShowCanvasClassroom.classroomIds.AddRange(
                        HideAndShowCanvasDistrict.getFileData(districtIDField.text + "_" + schoolIDField.text + "_" + teacherIDField.text + "_ID_classroomFile"));

                    HideAndShowCanvasClassroom.classroomIdVsRecord =
                        getFileData(districtIDField.text + "_" + schoolIDField.text + "_" + teacherIDField.text + "_ID_classroomWithRecordFile");

                    dropDownClassroomName.enabled = false;

                }
                else
                {
                    HideAndShowCanvasClassroom.classroomNames.AddRange(
                        HideAndShowCanvasDistrict.getFileData(districtNameField.text + "_" + schoolNameField.text + "_" + teacherNameField.text + "_Name_classroomFile"));

                    HideAndShowCanvasClassroom.classroomNameVsRecord =
                        getFileData(districtNameField.text + "_" + schoolNameField.text + "_" + teacherNameField.text + "_Name_classroomWithRecordFile");

                    dropDownClassroomID.enabled = false;
                }
            }

            HideAndShowCanvasDistrict.populateDropDown(dropDownClassroomID, HideAndShowCanvasClassroom.classroomIds);
            HideAndShowCanvasDistrict.populateDropDown(dropDownClassroomName, HideAndShowCanvasClassroom.classroomNames);

                classroomCanvas.enabled = true;
                classroomCanvas.gameObject.SetActive(true);
                teacherCanvas.enabled = false;
                teacherCanvas.gameObject.SetActive(false);
        }
    }

    Dictionary<string,List<RedCapMasterRecord>> getFileData(string fileName)
    {
        if (File.Exists(Path.Combine(pdP, fileName + ".dat")))
        {
            BinaryFormatter bf = new BinaryFormatter();
            string loadPath = Path.Combine(pdP, fileName + ".dat");
            FileStream file = File.Open(loadPath, FileMode.Open);

            Dictionary<string, List<RedCapMasterRecord>> loadData = (Dictionary<string, List<RedCapMasterRecord>>)bf.Deserialize(file);
            return loadData;

        }
        return new Dictionary<string, List<RedCapMasterRecord>>();

    }

    void backToTeacher()
    {
        dropDownTeacherID.enabled = false;
        dropDownTeacherName.enabled = false;

        assessorIDField.enabled = false;
        assessorIDField.gameObject.SetActive(false);
        assessorNameField.enabled = false;
        assessorNameField.gameObject.SetActive(false);

        if (HideAndShowCanvasDistrict.refID == "ID")
        {
            dropDownTeacherID.enabled = true;
            assessorIDField.enabled = true;
            assessorIDField.gameObject.SetActive(true);
        }
        else
        {
            dropDownTeacherName.enabled = true;
            assessorNameField.enabled = true;
            assessorNameField.gameObject.SetActive(true);
        }
        HideAndShowCanvasDistrict.populateDropDown(dropDownTeacherID, teacherIds);
        HideAndShowCanvasDistrict.populateDropDown(dropDownTeacherName, teacherNames);

        teacherIDField.text = "";
        teacherNameField.text = "";

        assessorIDField.text = "";
        assessorNameField.text = "";

        classroomCanvas.enabled = false;
        classroomCanvas.gameObject.SetActive(false);

        teacherCanvas.enabled = true;
        teacherCanvas.gameObject.SetActive(true);
    }

    void getListFromMap(List<RedCapMasterRecord> list, List<string> classroomIds, List<string> classroomNames, Dictionary<string, 
        List<RedCapMasterRecord>> classroomIdVsList, Dictionary<string, List<RedCapMasterRecord>> classroomNameVsList)
    {

        foreach (RedCapMasterRecord rcmr in list)
        {
            string classroomId = rcmr.classroomID;
            if (!classroomIds.Contains(classroomId))
            {
                classroomIds.Add(classroomId);
            }
            
            if(!classroomIdVsList.ContainsKey(classroomId))
            {
                classroomIdVsList[classroomId] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> idList = classroomIdVsList[classroomId];
            idList.Add(rcmr);

            string classroomName = rcmr.classroomName;
            if (!classroomNames.Contains(classroomName))
            {
                classroomNames.Add(classroomName);
            }
            
            if (!classroomNameVsList.ContainsKey(classroomName))
            {
                classroomNameVsList[classroomName] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> nameList = classroomNameVsList[classroomName];
            nameList.Add(rcmr);
        }

    }

}
