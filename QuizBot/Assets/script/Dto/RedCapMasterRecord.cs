using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
// Represents a sample record in RedCap across all instruments
public class RedCapMasterRecord
{
    [JsonProperty("record_id", NullValueHandling = NullValueHandling.Ignore)]
    public int? recordID = null;
    [JsonProperty("link_teacher_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherID = null;
    [JsonProperty("link_student_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string studentID = null;
    [JsonProperty("link_classroom_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomID = null;
    [JsonProperty("link_classroom_event", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string classroomEventName = null;
    [JsonProperty("link_district_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string districtID = null;
    [JsonProperty("link_district_token", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string token = null;
    [JsonProperty("link_school_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string schoolID = null;
    [JsonProperty("link_teacher_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherName = null;
    [JsonProperty("link_student_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string studentName = null;
    [JsonProperty("link_classroom_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomName = null;
    [JsonProperty("link_district_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string districtName = null;
    [JsonProperty("link_school_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string schoolName = null;
    [JsonProperty("link_teacher_pw", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string passcode = null;

    [JsonProperty("linking_form_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? complete = null;

    [JsonIgnore]
    public string refID;


    //Seems like the idea here is to create a big list of RedcapRecords
    //that match the db field names so they can be serialized later
    public static RedCapMasterRecord convertToRedCapRecord(SerialMasterData serialMasterData)
    {

        RedCapMasterRecord redCapMasterRecord = new RedCapMasterRecord();

        int? recordID = serialMasterData.sRecordID == null ? int.MaxValue : (serialMasterData.sRecordID);

        redCapMasterRecord.classroomEventName = serialMasterData.sClassroomEventName;
        redCapMasterRecord.token = serialMasterData.sToken;
        redCapMasterRecord.passcode = serialMasterData.sPasscode;

        // Populate fields for Credentials Instrument in RedCap
        redCapMasterRecord.recordID = recordID;
        //if(serialMasterData.refID == "ID") {
            redCapMasterRecord.teacherID = serialMasterData.sTeacherID;
            redCapMasterRecord.studentID = serialMasterData.sStudentID;
            redCapMasterRecord.classroomID = serialMasterData.sClassroomID;
            redCapMasterRecord.districtID = serialMasterData.sDistrictID;
            redCapMasterRecord.schoolID = serialMasterData.sSchoolID;
        //} else{
            redCapMasterRecord.teacherName = serialMasterData.sTeacherName;
            redCapMasterRecord.studentName = serialMasterData.sStudentName;
            redCapMasterRecord.classroomName = serialMasterData.sClassroomName;
            redCapMasterRecord.districtName = serialMasterData.sDistrictName;
            redCapMasterRecord.schoolName = serialMasterData.sSchoolName;

            redCapMasterRecord.refID = serialMasterData.refID;
        //}
        return redCapMasterRecord;
    }

    // Function responsible for returning int truth value
    public static int getBinaryTrueFalse(bool value)
    {
        return value ? 1 : 0;
    }
}

[Serializable]
public class MasterUsersDetails
{
    public List<RedCapMasterRecord> masterUsers = new List<RedCapMasterRecord>();
}