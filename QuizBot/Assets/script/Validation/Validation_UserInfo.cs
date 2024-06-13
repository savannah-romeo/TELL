//This class is used to validate input when entering user info
//before saving and moving to the next scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Validation_UserInfo : Validation_Parent
{
    //Expected fields to check in the scene
    public TMP_InputField teacherName;
    public TMP_InputField teacherID;
    public TMP_InputField assessorName;
    public TMP_InputField assessorID;
    public TMP_InputField childName;
    public TMP_InputField childID;
    public TMP_InputField classRoomName;
    public TMP_InputField classRoomId;
    public static string persistentDataPath;
    public Nullable<bool> displayWarning;
    public Nullable<bool> duplicateWarning;

    void Awake()
    {
        persistentDataPath = Application.persistentDataPath + "/";
    }

    //Time to validate!
    //Requires one of each teacher, assessor, child and classroom field filled
    public override bool Validator()
    {
        string empty = ""; //Used to more clearly indicate null strings
        bool valid = true;

        if (teacherName.text == empty && teacherID.text == empty)
            valid = false;
        /*if (assessorName.text == empty && assessorID.text == empty)
            valid = false;*/
        if(childName.text == empty && childID.text == empty)
            valid = false;
        if(classRoomName.text == empty && classRoomId.text == empty)
            valid = false;

        displayWarning = shouldDisplayWarning();
        duplicateWarning = shouldDisplayDuplicateWarning();

        return valid && !displayWarning.Value && !duplicateWarning.Value;
    }

    // This function is responsible for evaluating if a file can be loaded into application or not, displays
    // a warning if it is not possible to load file (missing either child or classroom information)
    public bool shouldDisplayWarning()
    {
        string fileName = DataManager.childFileName + ".dat";
        //string fileName = DataManager.childID + ".dat";
        string loadPath = persistentDataPath + fileName;
        if (File.Exists(loadPath))
        {
            return true;
        }
        return false;
    }

    public bool shouldDisplayDuplicateWarning()
    {            
        RedCapRequest redCapRequestForRecordIDs = new RedCapRequest();
        //redCapRequestForRecordIDs.token = DataManager.tokenSelected;
        redCapRequestForRecordIDs.token = DataManager.redCapMasterRecord.token;
        redCapRequestForRecordIDs.redCapEventName = DataManager.redCapMasterRecord.classroomEventName;
        redCapRequestForRecordIDs.arm = DataManager.redCapMasterRecord.teacherID;
        //redCapRequestForRecordIDs.token = "31E01A3558EFAD66A9769F0A6F338BDF"; // This is Akshay's creds, to be replaced!
        redCapRequestForRecordIDs.content = "record";
        redCapRequestForRecordIDs.action = "export";
        redCapRequestForRecordIDs.format = "json";
        redCapRequestForRecordIDs.type = "flat";
        redCapRequestForRecordIDs.returnFormat = "json";
        if (childID.text != String.Empty && childName.text == String.Empty) {
            redCapRequestForRecordIDs.filterLogic = "[child_id]=" + "\"" + DataManager.childID + "\"";
        }
        else if (childID.text == String.Empty && childName.text != String.Empty){
            redCapRequestForRecordIDs.filterLogic = "[child_name]=" + "\"" + DataManager.childID + "\"";
            }

        if (childName.text != String.Empty)
        {
            childName.text = childName.text.ToLower();
        }
        if (childID.text != String.Empty)
        {
            childID.text = childID.text.ToLower();
        }

        return RedCapService.Instance.WaitOnData(redCapRequestForRecordIDs, childID.text, childName.text);
            
    }
}