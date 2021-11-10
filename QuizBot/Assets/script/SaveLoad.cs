using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad
{
	public SerialData staging;

    // Start is called before the first frame update
    public SaveLoad()
    {
		Load();
    }

	//Creates save file out of datamanager class called LocalSave.dat
	public void Save()
	{
		//Prepare data
		staging.sAssessorID = DataManager.assessorID;
		staging.sChildID = DataManager.childID;
		staging.sTeacherID = DataManager.teacherID;

		//Create and save file
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath
					 + "/LocalSave.dat");
		bf.Serialize(file, staging);
		file.Close();
		Debug.Log("Game data saved!");
	}

	//Attempts to load LocalSave.dat into current DataManager
	//Static members for datamanager allows data to persist through entire app
	public void Load()
	{
		//Load file into serializable
		if (File.Exists(Application.persistentDataPath
					   + "/LocalSave.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file =
					   File.Open(Application.persistentDataPath
					   + "/LocalSave.dat", FileMode.Open);
			staging = (SerialData)bf.Deserialize(file);
			file.Close();
			Debug.Log("Game data loaded!");
		}
		else
			Debug.LogError("There is no save data!");

		//Load serializable into Datamanager
		DataManager.assessorID = staging.sAssessorID;
		DataManager.childID = staging.sChildID;
		DataManager.teacherID = staging.sTeacherID;
	}
}
