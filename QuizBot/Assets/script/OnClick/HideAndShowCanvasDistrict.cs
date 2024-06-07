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

public class HideAndShowCanvasDistrict : MonoBehaviour
{
    public Canvas schoolCanvas; //Canvas to hide and show
    public Canvas districtCanvas;

    public static string pdP;

    public Dropdown dropDownDistrictID;
    public Dropdown dropDownDistrictName;

    public Dropdown dropDownSchoolID;
    public Dropdown dropDownSchoolName;

    public TMP_InputField districtNameField;
    public TMP_InputField districtIDField;

    public static List<string> districtIds;
    public static List<string> districtNames;

    public Button districtNextButton;
    public Button backToDistrictButton;

    public TextMeshProUGUI errorText;

    public static string refID;

    public static Dictionary<string, List<RedCapMasterRecord>> districtIdVsRecord;
    public static Dictionary<string, List<RedCapMasterRecord>> districtNameVsRecord;


    // Start is called before the first frame update
    void Start()
    {
        // load the data
        pdP = Application.persistentDataPath;

        districtIDField.enabled = false;
        districtNameField.enabled = false;

        districtNameField.gameObject.SetActive(false);
        districtIDField.gameObject.SetActive(false);

        if (CheckInternetConnection.populateDistrict)
        {
            pdP = Application.persistentDataPath;
            populateDistrictWhenLoaded();
            CheckInternetConnection.populateDistrict = false;
        }

        //populateDropDown(dropDownDistrictID, districtIds);
        //populateDropDown(dropDownDistrictName, districtNames);
        //districtCanvas.gameObject.SetActive(true);

        if(districtNextButton != null)
        {
            districtNextButton.onClick.AddListener(districtNextOnClick);
            districtNextButton.enabled = true;
        }
        if(backToDistrictButton != null)
        {
            backToDistrictButton.onClick.AddListener(backToDistrict);
        }

        dropDownDistrictID.onValueChanged.AddListener(dropDownIDValueChanged);
        dropDownDistrictName.onValueChanged.AddListener(dropDownNameValueChanged);
    }

    public void populateDistrictWhenLoaded()
    {
        if (DataManager.internetAvailable)
        {
            fetchAllRecords();
        }
        else
        {
            districtIds = getFileData("DistrictIds");
            districtNames = getFileData("DistrictNames");
        }
        populateDropDown(dropDownDistrictID, districtIds);
        populateDropDown(dropDownDistrictName, districtNames);
        districtCanvas.gameObject.SetActive(true);
    }
    public bool fetchAllRecords()
    {
        RedCapRequest redCapRequestForRecordIDs = new RedCapRequest();
        redCapRequestForRecordIDs.token = "E4AD7BF92764C0935F61EE7013E4F759";
        //redCapRequestForRecordIDs.token = "31E01A3558EFAD66A9769F0A6F338BDF"; // This is Akshay's creds, to be replaced!
        redCapRequestForRecordIDs.content = "record";
        redCapRequestForRecordIDs.action = "export";
        redCapRequestForRecordIDs.format = "json";
        redCapRequestForRecordIDs.type = "flat";
        redCapRequestForRecordIDs.returnFormat = "json";


        MasterUsersDetails masterUserDetails = RedCapService.Instance.getAllMasterRecords(redCapRequestForRecordIDs);

        if (masterUserDetails != null)
        {
            districtIds = new List<string>();
            districtNames = new List<string>();
            
            districtIdVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();
            districtNameVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();
            
            foreach (RedCapMasterRecord redCapMasterRecord in masterUserDetails.masterUsers)
            {
                string districtId = redCapMasterRecord.districtID;
                
                if(!districtIdVsRecord.ContainsKey(districtId))
                {
                    districtIdVsRecord[districtId] = new List<RedCapMasterRecord>();
                }
                List<RedCapMasterRecord> redCapList = districtIdVsRecord[districtId];

                redCapList.Add(redCapMasterRecord);

                string districtName = redCapMasterRecord.districtName;
                
                if (!districtNameVsRecord.ContainsKey(districtName))
                {
                    districtNameVsRecord[districtName] = new List<RedCapMasterRecord>();
                }
                List<RedCapMasterRecord> redCapNameList = districtNameVsRecord[districtName];
                redCapNameList.Add(redCapMasterRecord);

                if (!districtIds.Contains(districtId))
                {
                    districtIds.Add(districtId);
                }

                if (!districtNames.Contains(districtName))
                {
                    districtNames.Add(districtName);
                }
            }

            createDataFile("DistrictIds", districtIds);
            createDataFile("DistrictNames", districtNames);

            return true;
        }
        return false;

    }

    void dropDownIDValueChanged(int value)
    {
        // show error if value is empty selected
        districtNameField.text = "";
        districtIDField.text = dropDownDistrictID.options[value].text;
        dropDownDistrictName.value = 0;
        HideAndShowCanvasDistrict.refID = "ID";
    }

    void dropDownNameValueChanged(int value)
    {
        districtIDField.text = "";
        districtNameField.text = dropDownDistrictName.options[value].text;
        dropDownDistrictID.value = 0;
        HideAndShowCanvasDistrict.refID = "Name";
    }

    void backToDistrict()
    {
        dropDownDistrictID.enabled = true;
        dropDownDistrictName.enabled = true;
        refID = "";

        populateDropDown(dropDownDistrictID, districtIds);
        populateDropDown(dropDownDistrictName, districtNames);

        districtIDField.text = "";
        districtNameField.text = "";

        schoolCanvas.enabled = false;
        schoolCanvas.gameObject.SetActive(false);

        districtCanvas.enabled = true;
        districtCanvas.gameObject.SetActive(true);
    }

    public static void populateDropDown(Dropdown dropDown, List<String> dropDownValues)
    {
        dropDown.ClearOptions();
        List<Dropdown.OptionData> dropDownData = new List<Dropdown.OptionData>();

        Dropdown.OptionData emptyData = new Dropdown.OptionData();
        emptyData.text = "";
        dropDownData.Add(emptyData);

        foreach (string entry in dropDownValues)
        {
            Dropdown.OptionData newData = new Dropdown.OptionData();
            newData.text = entry;
            dropDownData.Add(newData);

            // do something with entry.Value or entry.Key
        }

        dropDown.AddOptions(dropDownData);
    }

    public static List<string> getFileData(string fileName)
    {
        if (File.Exists(Path.Combine(pdP, fileName+".dat"))) {
            BinaryFormatter bf = new BinaryFormatter();
            string loadPath = Path.Combine(pdP, fileName+".dat");
            FileStream file = File.Open(loadPath, FileMode.Open);

            List<string> loadData = (List<string>)bf.Deserialize(file);
            return loadData;

        }
        return new List<string>();

    }
 
    public static void createDataFile(string fileName, List<string> dataList)
    {

        if (File.Exists(Path.Combine(pdP, fileName + ".dat")))
        {
            File.Delete(Path.Combine(pdP, fileName + ".dat"));
        }

        string savePath = Path.Combine(pdP, fileName+".dat"); // File path for storage with the file name
        Debug.Log(fileName);
        Debug.Log(savePath);

        //Create and save file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, dataList);
        file.Close();
    }

    bool checkIfDistrictDataIsNotProvided()
    {
        if (String.IsNullOrEmpty(districtIDField.text) && String.IsNullOrEmpty(districtNameField.text))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void districtNextOnClick()
    {
        // validate and proceed
        errorText.enabled = false;
        errorText.gameObject.SetActive(false);

        if (checkIfDistrictDataIsNotProvided())
        {
            errorText.text = "Please fill all the details";
            errorText.enabled = true;
            errorText.gameObject.SetActive(true);
        }
        else
        {

            HideAndShowCanvasSchool.schoolIds = new List<string>();
            HideAndShowCanvasSchool.schoolNames = new List<string>();

            dropDownSchoolID.enabled = true;
            dropDownSchoolName.enabled = true;

            if (DataManager.internetAvailable)
            {
                HideAndShowCanvasSchool.schoolIdVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();
                HideAndShowCanvasSchool.schoolNameVsRecord = new Dictionary<string, List<RedCapMasterRecord>>();

                if (HideAndShowCanvasDistrict.refID == "ID")
                {
                    
                    getListFromMap(districtIdVsRecord[districtIDField.text], HideAndShowCanvasSchool.schoolIds,
                        HideAndShowCanvasSchool.schoolNames, HideAndShowCanvasSchool.schoolIdVsRecord,
                        HideAndShowCanvasSchool.schoolNameVsRecord);

                    createDataFile(districtIDField.text + "_ID_schoolFile", HideAndShowCanvasSchool.schoolIds);
                    dropDownSchoolName.enabled = false;

                }
                else
                {
                    getListFromMap(districtNameVsRecord[districtNameField.text], HideAndShowCanvasSchool.schoolIds,
                        HideAndShowCanvasSchool.schoolNames, HideAndShowCanvasSchool.schoolIdVsRecord,
                        HideAndShowCanvasSchool.schoolNameVsRecord);

                    createDataFile(districtNameField.text + "_Name_schoolFile", HideAndShowCanvasSchool.schoolNames);
                    dropDownSchoolID.enabled = false;

                }


            }
            else
            {
                if (HideAndShowCanvasDistrict.refID == "ID")
                {
                    HideAndShowCanvasSchool.schoolIds.AddRange(getFileData(districtIDField.text + "_ID_schoolFile"));
                    dropDownSchoolName.enabled = false;
                }
                else
                {
                    HideAndShowCanvasSchool.schoolNames.AddRange(getFileData(districtNameField.text + "_Name_schoolFile"));
                    dropDownSchoolID.enabled = false;
                }
            }

                populateDropDown(dropDownSchoolID,
                    HideAndShowCanvasSchool.schoolIds);
                populateDropDown(dropDownSchoolName, HideAndShowCanvasSchool.schoolNames);

                schoolCanvas.enabled = true;
                    schoolCanvas.gameObject.SetActive(true);
                    districtCanvas.enabled = false;
                    districtCanvas.gameObject.SetActive(false);
        }
    }

    void getListFromMap(List<RedCapMasterRecord> list, List<string> schoolIds, List<string> schoolNames, Dictionary<string, 
        List<RedCapMasterRecord>> schooldIdVsList, Dictionary<string, List<RedCapMasterRecord>> schoolNameVsList)
    {

        foreach (RedCapMasterRecord rcmr in list)
        {
            string schoolId = rcmr.schoolID;
            if (!schoolIds.Contains(schoolId))
            {
                schoolIds.Add(schoolId);
            }
            
            if(!schooldIdVsList.ContainsKey(schoolId))
            {
                schooldIdVsList[schoolId] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> idList = schooldIdVsList[schoolId];
            idList.Add(rcmr);

            string schoolName = rcmr.schoolName;
            if (!schoolNames.Contains(schoolName))
            {
                schoolNames.Add(schoolName);
            }
            
            if (!schoolNameVsList.ContainsKey(schoolName))
            {
                schoolNameVsList[schoolName] = new List<RedCapMasterRecord>();
            }
            List<RedCapMasterRecord> nameList = schoolNameVsList[schoolName];
            nameList.Add(rcmr);
        }

    }

}
