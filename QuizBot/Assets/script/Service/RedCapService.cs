using System;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

// This class is responsible for creating and executing all requests (API calls) for RedCap Database. 
public class RedCapService : MonoBehaviour
{
    private static RedCapService _instance;
    public static string pdP;
    public static bool dataLoaded = false;
    public static bool error = false;
     public static IEnumerator import_data;

    private void Awake()
    {
        pdP = Application.persistentDataPath;
    }

    // Create a singleton
    public static RedCapService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RedCapService>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(RedCapService).Name;
                    _instance = go.AddComponent<RedCapService>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }


    // Responsible for executing API call for importing data from RedCap to local file system. 
    // Files created with the file name -> <child_id>.dat
    public IEnumerator ImportAllData(System.Action<UsersDetails> callBack, RedCapRequest redCapRequest){
        
        WWWForm form = new WWWForm();
        
        if (!String.IsNullOrEmpty(redCapRequest.token))
            form.AddField("token", redCapRequest.token);
        
        if (!String.IsNullOrEmpty(redCapRequest.content))
            form.AddField("content", redCapRequest.content);
        
        if (!String.IsNullOrEmpty(redCapRequest.action))
            form.AddField("action", redCapRequest.action);
        
        if (!String.IsNullOrEmpty(redCapRequest.format))
            form.AddField("format", redCapRequest.format);
        
        if (!String.IsNullOrEmpty(redCapRequest.type))
            form.AddField("type", redCapRequest.type);
        
        if (!String.IsNullOrEmpty(redCapRequest.returnContent))
            form.AddField("returnFormat", redCapRequest.returnContent);  
        
        if (!String.IsNullOrEmpty(redCapRequest.fields_0))
            form.AddField("fields[0]", "record_id");
        
        if (!String.IsNullOrEmpty(redCapRequest.form_0))
            form.AddField("forms[0]", redCapRequest.form_0);
        
        if (redCapRequest.records_0 != 0)
            form.AddField("records[0]", redCapRequest.records_0);

        if (!String.IsNullOrEmpty(redCapRequest.filterLogic))
            form.AddField("filterLogic", redCapRequest.filterLogic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://redcap.rc.asu.edu/api/", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string response = www.downloadHandler.text;
                UsersDetails root = JsonConvert.DeserializeObject<UsersDetails>("{\"users\":" + response + "}");
                callBack(root);
            }
        }
    }

    public void CheckIfDataExists(RedCapRequest redCapRequest,String childID,String childName){
        import_data = CheckIfDataExists_req(redCapRequest, childID, childName);
     }

    public bool WaitOnData(RedCapRequest redCapRequest,String childID,String childName)
    {
        if (!dataLoaded) CheckIfDataExists(redCapRequest, childID, childName); 
        while (import_data.MoveNext())
        {
            Debug.Log("Waiting for data to be validated!");
        }
        return error;
    }
      

    // Responsible for executing API call for importing data from RedCap to local file system. 
    // Files created with the file name -> <child_id>.dat
    public IEnumerator CheckIfDataExists_req(RedCapRequest redCapRequest,String childID,String childName){
        
        WWWForm form = new WWWForm();
        
        if (!String.IsNullOrEmpty(redCapRequest.token))
            form.AddField("token", redCapRequest.token);
        
        if (!String.IsNullOrEmpty(redCapRequest.content))
            form.AddField("content", redCapRequest.content);
        
        if (!String.IsNullOrEmpty(redCapRequest.action))
            form.AddField("action", redCapRequest.action);
        
        if (!String.IsNullOrEmpty(redCapRequest.format))
            form.AddField("format", redCapRequest.format);
        
        if (!String.IsNullOrEmpty(redCapRequest.type))
            form.AddField("type", redCapRequest.type);
        
        if (!String.IsNullOrEmpty(redCapRequest.returnContent))
            form.AddField("returnFormat", redCapRequest.returnContent);  
        
        if (!String.IsNullOrEmpty(redCapRequest.fields_0))
            form.AddField("fields[0]", "record_id");
        
        if (!String.IsNullOrEmpty(redCapRequest.form_0))
            form.AddField("forms[0]", redCapRequest.form_0);
        
        if (redCapRequest.records_0 != 0)
            form.AddField("records[0]", redCapRequest.records_0);

        if (!String.IsNullOrEmpty(redCapRequest.filterLogic))
            form.AddField("filterLogic", redCapRequest.filterLogic);

        using (UnityWebRequest www = UnityWebRequest.Post("https://redcap.rc.asu.edu/api/", form))
        {
            yield return www.SendWebRequest();

            while (!www.isDone)
            {
                yield return true;
            }

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                if(www.error != null){
                    error = false;
                    dataLoaded = true;
                }
            }
            else
            {
                string response = www.downloadHandler.text;
                
                UsersDetails usersDetails = JsonConvert.DeserializeObject<UsersDetails>("{\"users\":" + response + "}");
                for (int index = usersDetails.users.Count - 1; index >= 0; index--){
                    RedCapRecord redCapRecord = usersDetails.users[index];
                    if (redCapRecord.recordID == null || redCapRecord.recordID == 0)
                    {
                        error = false;
                        dataLoaded = true;
                        usersDetails.users.RemoveAt(index);
                        Debug.Log("Record obtained from RedCap is corrupted, missing record_id");
                    }
                    else if((childID != "" && redCapRecord.childID == childID) || (childName != "" && redCapRecord.childName == childName))
                    {
                        error = true;
                        dataLoaded = true;
                    }
                }
            }           
        }
    }
    
    // Responsible for executing API call for importing data from local file system to RedCap. 
    public IEnumerator ExportCredentials(RedCapRequest redCapRequest, String fileName)
    {
        WWWForm form = new WWWForm();
        
        if (!String.IsNullOrEmpty(redCapRequest.token))
            form.AddField("token", redCapRequest.token);
        
        if (!String.IsNullOrEmpty(redCapRequest.content))
            form.AddField("content", redCapRequest.content);
        
        if (!String.IsNullOrEmpty(redCapRequest.action))
            form.AddField("action", redCapRequest.action);
        
        if (!String.IsNullOrEmpty(redCapRequest.format))
            form.AddField("format", redCapRequest.format);
        
        if (!String.IsNullOrEmpty(redCapRequest.type))
            form.AddField("type", redCapRequest.type);
        
        if (!String.IsNullOrEmpty(redCapRequest.overwriteBehavior))
            form.AddField("overwriteBehavior", redCapRequest.overwriteBehavior);
        
        if (!String.IsNullOrEmpty(redCapRequest.forceAutoNumber))
            form.AddField("forceAutoNumber", redCapRequest.forceAutoNumber);
        
        if (!String.IsNullOrEmpty(redCapRequest.data))
            form.AddField("data", redCapRequest.data);
        
        if (!String.IsNullOrEmpty(redCapRequest.returnContent))
            form.AddField("returnContent", redCapRequest.returnContent);

        using (UnityWebRequest www = UnityWebRequest.Post("https://redcap.rc.asu.edu/api/", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if(File.Exists(fileName)){
                    File.Delete(fileName);
                }
                Debug.Log("Data Exported");
            }
        }
    }
}