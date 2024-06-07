//This class is used to hold data when it is transferred from app cache memory to local data files
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class SerialMasterData
{
    public int? sRecordID;
    public string sToken = null;
    public string sTeacherID = null;
    public string sStudentID = null;
    public string sClassroomID = null;
    public string sDistrictID = null;
    public string sSchoolID = null;
    public string sTeacherName = null;
    public string sStudentName = null;
    public string sClassroomName = null;
    public string sDistrictName = null;
    public string sSchoolName = null;
    public string sPasscode = null;
    public string sClassroomEventName = null;
    public string refID;

    public static SerialMasterData convertToSerialMasterData(RedCapMasterRecord redCapMasterRecord)
    {
        SerialMasterData serialMasterData = new SerialMasterData();

        //foreach (var redCapRecord in usersDetails.users)
        //{
            if (redCapMasterRecord.recordID != null && redCapMasterRecord.recordID != 0)
                serialMasterData.sRecordID = redCapMasterRecord.recordID;
                serialMasterData.sClassroomEventName = redCapMasterRecord.classroomEventName;
                serialMasterData.sPasscode = redCapMasterRecord.passcode;
                serialMasterData.sToken = redCapMasterRecord.token;
                serialMasterData.refID = redCapMasterRecord.refID;

            //if (redCapMasterRecord.refID == "ID")
            //{
            // serialData.sExportImportRef = "ID";
        if (!string.IsNullOrEmpty(redCapMasterRecord.teacherID))
                    serialMasterData.sTeacherID = redCapMasterRecord.teacherID;
                if (!string.IsNullOrEmpty(redCapMasterRecord.studentID))
                    serialMasterData.sStudentID = redCapMasterRecord.studentID;
                if (!string.IsNullOrEmpty(redCapMasterRecord.districtID))
                    serialMasterData.sDistrictID = redCapMasterRecord.districtID;
                if (!string.IsNullOrEmpty(redCapMasterRecord.classroomID))
                    serialMasterData.sClassroomID = redCapMasterRecord.classroomID;
                if (!string.IsNullOrEmpty(redCapMasterRecord.schoolID))
                    serialMasterData.sSchoolID = redCapMasterRecord.schoolID;
            //}
            //else
            //{
                if (!string.IsNullOrEmpty(redCapMasterRecord.teacherName))
                    serialMasterData.sTeacherName = redCapMasterRecord.teacherName;
                if (!string.IsNullOrEmpty(redCapMasterRecord.studentName))
                    serialMasterData.sStudentName = redCapMasterRecord.studentName;
                if (!string.IsNullOrEmpty(redCapMasterRecord.districtName))
                    serialMasterData.sDistrictName = redCapMasterRecord.districtName;
                if (!string.IsNullOrEmpty(redCapMasterRecord.classroomName))
                    serialMasterData.sClassroomName = redCapMasterRecord.classroomName;
                if (!string.IsNullOrEmpty(redCapMasterRecord.schoolName))
                    serialMasterData.sSchoolName = redCapMasterRecord.schoolName;
            //}
        return serialMasterData;
        }
    }
