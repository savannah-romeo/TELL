using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;

// Responsible for exporting data into RedCap
public class ExportMasterData
{
    public static void exportTeacherStudentData()
    {
        RedCapRequest outboundRequest = new RedCapRequest();
        outboundRequest.token = "E4AD7BF92764C0935F61EE7013E4F759";
        //outboundRequest.token = "31E01A3558EFAD66A9769F0A6F338BDF"; // This is Akshay's creds, to be replaced!
        outboundRequest.content = "record";
        outboundRequest.action = "import";
        outboundRequest.format = "json";
        outboundRequest.type = "flat";
        outboundRequest.overwriteBehavior = "overwrite";
        outboundRequest.returnContent = "ids";

        string fileName = DataManager.teacherID + "_" + DataManager.schoolID + "_" +
            DataManager.classroomID + "_" + DataManager.districtID;

        BinaryFormatter bf = new BinaryFormatter();
        string loadPath = Path.Combine(Application.persistentDataPath, fileName);
        FileStream file = File.Open(loadPath + ".dat", FileMode.Open);

        SerialMasterData serialMasterData = (SerialMasterData)bf.Deserialize(file);
        file.Close();

        RedCapMasterRecord redCapMasterRecord = RedCapMasterRecord.convertToRedCapRecord(serialMasterData);
        if (serialMasterData.refID == "ID") {
            redCapMasterRecord.studentID = DataManager.childID;
            DataManager.studentIdList.Add(DataManager.childID);
        }
        else
        {
            redCapMasterRecord.studentName = DataManager.childID;
            DataManager.studentNameList.Add(DataManager.childID);
        }
        redCapMasterRecord.recordID = int.MaxValue;
        redCapMasterRecord.complete = 2;

        List<RedCapMasterRecord> redCapMasterRecordList = new List<RedCapMasterRecord> ();
        redCapMasterRecordList.Add(redCapMasterRecord);

        string data = JsonConvert.SerializeObject(redCapMasterRecordList);

        // string data = JsonUtility.ToJson(redCapRecords);
        outboundRequest.forceAutoNumber = "true";
        outboundRequest.data = data;
        RedCapService.Instance.ExportCredentials(outboundRequest, fileName, redCapMasterRecord.recordID, false);
    }
}