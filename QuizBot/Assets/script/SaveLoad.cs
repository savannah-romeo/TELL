using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad
{
	public SerialData staging;
	public static string pdP = Application.persistentDataPath;

	//When called, load data from file if no active childID
	public SaveLoad()
    {
		staging = new SerialData();
	}

	// Creates a file and saves data currently in DataManager (current user)
	// 1. Data is stored in a file -> <child_id>.dat
	// 2. Only data of current user is stored
	public void Save()
	{
		//Prepare data
		staging.sRecordId = DataManager.recordID;
		staging.sAssessorID = DataManager.assessorID;
		staging.sChildID = DataManager.childID;
		staging.sTeacherID = DataManager.teacherID;
		staging.sClassroomID = DataManager.classroomID;

		if (staging.sClassroomID == null || staging.sChildID == null)
		{
			Debug.LogError("Missing childID or classroomId, unable to save data");
			return;
		}

		// Storing vocab game data
		staging.sGradeVocabExp = DataManager.grade_vocabularyExpressive;
		staging.sGradeVocabRec = DataManager.grade_vocabularyReceptive;
		staging.sGradeVocabTotal = DataManager.grade_vocabularyTotal;
		if (DataManager.globalTime > 0)
		{
			staging.sIndividualExpressiveList = DataManager.individual_vocabularyExpressive;
			staging.sIndividualExpressiveFlagList = DataManager.individual_vocabularyExpressiveFlag;
			staging.sIndividualReceptiveList = DataManager.individual_vocabularyReceptive;
			staging.sIndividualReceptiveFlagList = DataManager.individual_vocabularyReceptiveFlag;
			staging.sIndividualResponses = DataManager.individual_vocabularyResponses;
			staging.sIndividualCSResponseList = DataManager.individual_csResponse;
			staging.sIndividualWritingScoreList = DataManager.individual_writing_score;
			staging.sIndividualSRQuestionsList = DataManager.individual_srQuestions;
			staging.sIndividualSRResponseList = DataManager.individual_srResponse;
			staging.sIndividualBookSumQuestionsList = DataManager.individual_bookSumQuestions;
			staging.sIndividualBookSumResponseList = DataManager.individual_bookSumResponse;

			staging.sAssessorIdVocabList = DataManager.assessorIdVocabReponses;
			staging.sTeacherIdVocabList = DataManager.teacherIdVocabResponses;
			staging.sClassroomIdVocabList = DataManager.classroomIdVocabResponses;
			staging.sAssessorNameVocabList = DataManager.assessorNameVocabReponses;
			staging.sTeacherNameVocabList = DataManager.teacherNameVocabResponses;
			staging.sClassroomNameVocabList = DataManager.classroomNameVocabResponses;

			staging.sAssessorIdLniList = DataManager.assessorIdLniReponses;
			staging.sTeacherIdLniList = DataManager.teacherIdLniResponses;
			staging.sClassroomIdLniList = DataManager.classroomIdLniResponses;
			staging.sAssessorNameLniList = DataManager.assessorNameLniReponses;
			staging.sTeacherNameLniList = DataManager.teacherNameLniResponses;
			staging.sClassroomNameLniList = DataManager.classroomNameLniResponses;

			staging.sAssessorIdLsiList = DataManager.assessorIdLsiReponses;
			staging.sTeacherIdLsiList = DataManager.teacherIdLsiResponses;
			staging.sClassroomIdLsiList = DataManager.classroomIdLsiResponses;
			staging.sAssessorNameLsiList = DataManager.assessorNameLsiReponses;
			staging.sTeacherNameLsiList = DataManager.teacherNameLsiResponses;
			staging.sClassroomNameLsiList = DataManager.classroomNameLsiResponses;

			staging.sAssessorIdCSList = DataManager.assessorIdCSReponses;
			staging.sTeacherIdCSList = DataManager.teacherIdCSResponses;
			staging.sClassroomIdCSList = DataManager.classroomIdCSResponses;
			staging.sAssessorNameCSList = DataManager.assessorNameCSReponses;
			staging.sTeacherNameCSList = DataManager.teacherNameCSResponses;
			staging.sClassroomNameCSList = DataManager.classroomNameCSResponses;

			staging.sAssessorIdSRList = DataManager.assessorIdSRReponses;
			staging.sTeacherIdSRList = DataManager.teacherIdSRResponses;
			staging.sClassroomIdSRList = DataManager.classroomIdSRResponses;
			staging.sAssessorNameSRList = DataManager.assessorNameSRReponses;
			staging.sTeacherNameSRList = DataManager.teacherNameSRResponses;
			staging.sClassroomNameSRList = DataManager.classroomNameSRResponses;

			staging.sAssessorIdBookSumList = DataManager.assessorIdBookSumReponses;
			staging.sTeacherIdBookSumList = DataManager.teacherIdBookSumResponses;
			staging.sClassroomIdBookSumList = DataManager.classroomIdBookSumResponses;
			staging.sAssessorNameBookSumList = DataManager.assessorNameBookSumReponses;
			staging.sTeacherNameBookSumList = DataManager.teacherNameBookSumResponses;
			staging.sClassroomNameBookSumList = DataManager.classroomNameBookSumResponses;

			staging.sAssessorIdWritingList = DataManager.assessorIdWritingReponses;
			staging.sTeacherIdWritingList = DataManager.teacherIdWritingResponses;
			staging.sClassroomIdWritingList = DataManager.classroomIdWritingResponses;
			staging.sAssessorNameWritingList = DataManager.assessorNameWritingReponses;
			staging.sTeacherNameWritingList = DataManager.teacherNameWritingResponses;
			staging.sClassroomNameWritingList = DataManager.classroomNameWritingResponses;
		}
		staging.sGradeCSTotal = DataManager.grade_csTotal;
		staging.sGradeSRTotal = DataManager.grade_srTotal;
		staging.sGradeBookSumTotal = DataManager.grade_bookSumTotal;

		//Storing LNI data
		staging.sLearnedLetterNamesLNI = DataManager.learnedLetterNamesLNI;
		staging.sIndividual_LNI = DataManager.individual_LNI;
		

		//Storing LSI data
		staging.sLearnedLetterNamesLSI = DataManager.learnedLetterNamesLSI;
		staging.sIndividual_LSI = DataManager.individual_LSI;


		//Storing BS data
		staging.sIndividual_BS = DataManager.individual_BS;
		staging.sIndividual_BSChildResponse = DataManager.individual_BSChildResponse;
		staging.final_BSscores = DataManager.final_BSscores;
		staging.sAssessorIdBsList = DataManager.assessorIdBsReponses;
		staging.sTeacherIdBsList = DataManager.teacherIdBsResponses;
		staging.sClassroomIdBsList = DataManager.classroomIdBsResponses;
		staging.sAssessorNameBsList = DataManager.assessorNameBsReponses;
		staging.sTeacherNameBsList = DataManager.teacherNameBsResponses;
		staging.sClassroomNameBsList = DataManager.classroomNameBsResponses;

		staging.sIndividual_CAP = DataManager.individual_CAP;
		staging.final_CAPscores = DataManager.final_CAPscores;
		staging.sAssessorIdCAPList = DataManager.assessorIdCAPReponses;
		staging.sTeacherIdCAPList = DataManager.teacherIdCAPResponses;
		staging.sClassroomIdCAPList = DataManager.classroomIdCAPResponses;
		staging.sAssessorNameCAPList = DataManager.assessorNameCAPReponses;
		staging.sTeacherNameCAPList = DataManager.teacherNameCAPResponses;
		staging.sClassroomNameCAPList = DataManager.classroomNameCAPResponses;

		staging.sCompleteWriting = DataManager.completeWriting;
		staging.sCompleteVocabulary= DataManager.completeVocabulary;
		staging.sCompleteSR = DataManager.completeSR;
		staging.sCompleteLSI = DataManager.completeLSI;
		staging.sCompleteLNI = DataManager.completeLNI;
		staging.sCompleteCS = DataManager.completeCS;
		staging.sCompleteCAP = DataManager.completeCAP;
		staging.sCompleteBS = DataManager.completeBS;
		staging.sCompleteBookSum = DataManager.completeBookSum;

		staging.sVocabDateTimeField = DataManager.vocabDateTimeField;
		staging.sDateTimeFieldWriting = DataManager.writingDateTimeField;
		staging.sDateTimeFieldSR = DataManager.srDateTimeField;
		staging.sDateTimeFieldBookSum = DataManager.bookSumDateTimeField;
		staging.sDateTimeFieldBS = DataManager.bsDateTimeField;
		staging.sDateTimeFieldLNI = DataManager.lniDateTimeField;
		staging.sDateTimeFieldLSI = DataManager.lsiDateTimeField;
		staging.sDateTimeFieldCAP = DataManager.capDateTimeField;
		staging.sDateTimeFieldCS = DataManager.csDateTimeField;



		string fileName = staging.sChildID + ".dat"; // File for saving, filename will be <childID>.dat
		Debug.Log(fileName);
		string savePath = Path.Combine(pdP, fileName); // File path for storage with the file name
		Debug.Log(savePath);

		//Create and save file
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(savePath);
		bf.Serialize(file, staging);
		file.Close();
	}

	// Loads data from a file into DataManager
	// 1. Data is stored in a file -> <child_id>.dat
	// 2. Data of user is loaded in DataManager
	public void Load(string childId, string classroomId)
	{
		if (childId == String.Empty || classroomId == String.Empty)
		{
			Debug.LogError("Missing childID/classroomId, unable to load data");
			return;
		}
		
		// Obtain the filePath for loading
		string fileName = childId + ".dat";
		string loadPath = Path.Combine(pdP, fileName);

		// Open file and load data
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(loadPath, FileMode.Open);
		staging = (SerialData)bf.Deserialize(file);
		file.Close();

		//Load serializable into Datamanager
		DataManager.recordID = staging.sRecordId;
		DataManager.assessorID = staging.sAssessorID;
		DataManager.childID = staging.sChildID;
		DataManager.teacherID = staging.sTeacherID;
		DataManager.classroomID = staging.sClassroomID;
		DataManager.grade_vocabularyExpressive = staging.sGradeVocabExp;
		DataManager.grade_vocabularyReceptive = staging.sGradeVocabRec;
		DataManager.grade_vocabularyTotal = staging.sGradeVocabTotal;
		DataManager.individual_vocabularyExpressive = staging.sIndividualExpressiveList;
		DataManager.individual_vocabularyExpressiveFlag = staging.sIndividualExpressiveFlagList;
		DataManager.individual_vocabularyReceptive = staging.sIndividualReceptiveList;
		DataManager.individual_vocabularyReceptiveFlag = staging.sIndividualReceptiveFlagList;
		DataManager.individual_vocabularyResponses = staging.sIndividualResponses;
		DataManager.individual_csResponse = staging.sIndividualCSResponseList;
		DataManager.grade_csTotal = staging.sGradeCSTotal;
		DataManager.individual_writing_score = staging.sIndividualWritingScoreList;
		DataManager.individual_srResponse = staging.sIndividualSRResponseList;
		DataManager.individual_srQuestions = staging.sIndividualSRQuestionsList;
		DataManager.individual_bookSumResponse = staging.sIndividualBookSumResponseList;
		DataManager.individual_bookSumQuestions = staging.sIndividualBookSumQuestionsList;
		DataManager.grade_srTotal = staging.sGradeSRTotal;
		DataManager.grade_bookSumTotal = staging.sGradeBookSumTotal;

		DataManager.completeWriting = staging.sCompleteWriting;
		DataManager.completeVocabulary = staging.sCompleteVocabulary;
		DataManager.completeSR = staging.sCompleteSR;
		DataManager.completeLSI = staging.sCompleteLSI;
		DataManager.completeLNI = staging.sCompleteLNI;
		DataManager.completeCS = staging.sCompleteCS;
		DataManager.completeCAP = staging.sCompleteCAP;
		DataManager.completeBS = staging.sCompleteBS;
		DataManager.completeBookSum = staging.sCompleteBookSum;

		DataManager.vocabDateTimeField = staging.sVocabDateTimeField;
		DataManager.writingDateTimeField = staging.sDateTimeFieldWriting;
		DataManager.srDateTimeField = staging.sDateTimeFieldSR;
		DataManager.bookSumDateTimeField = staging.sDateTimeFieldBookSum;
		DataManager.bsDateTimeField = staging.sDateTimeFieldBS;
		DataManager.lniDateTimeField = staging.sDateTimeFieldLNI;
		DataManager.lsiDateTimeField = staging.sDateTimeFieldLSI;
		DataManager.capDateTimeField = staging.sDateTimeFieldCAP;
		DataManager.csDateTimeField = staging.sDateTimeFieldCS;

		DataManager.learnedLetterNamesLNI = staging.sLearnedLetterNamesLNI;
        DataManager.individual_LNI = staging.sIndividual_LNI;
        DataManager.learnedLetterNamesLSI = staging.sLearnedLetterNamesLSI;
        DataManager.individual_LSI = staging.sIndividual_LSI;
        DataManager.individual_BS = staging.sIndividual_BS;
		DataManager.individual_CAP = staging.sIndividual_CAP;
		DataManager.individual_BSChildResponse = staging.sIndividual_BSChildResponse;
        DataManager.final_BSscores = staging.final_BSscores;
		DataManager.final_CAPscores = staging.final_CAPscores;

		DataManager.assessorIdVocabReponses = staging.sAssessorIdVocabList;
		DataManager.teacherIdVocabResponses = staging.sTeacherIdVocabList;
		DataManager.classroomIdVocabResponses = staging.sClassroomIdVocabList;
		DataManager.assessorNameVocabReponses = staging.sAssessorNameVocabList;
		DataManager.teacherNameVocabResponses = staging.sTeacherNameVocabList;
		DataManager.classroomNameVocabResponses = staging.sClassroomNameVocabList;

		DataManager.assessorIdBsReponses = staging.sAssessorIdBsList;
		DataManager.teacherIdBsResponses = staging.sTeacherIdBsList;
		DataManager.classroomIdBsResponses = staging.sClassroomIdBsList;
		DataManager.assessorNameBsReponses = staging.sAssessorNameBsList;
		DataManager.teacherNameBsResponses = staging.sTeacherNameBsList;
		DataManager.classroomNameBsResponses = staging.sClassroomNameBsList;

		DataManager.assessorIdCAPReponses = staging.sAssessorIdCAPList;
		DataManager.teacherIdCAPResponses = staging.sTeacherIdCAPList;
		DataManager.classroomIdCAPResponses = staging.sClassroomIdCAPList;
		DataManager.assessorNameCAPReponses = staging.sAssessorNameCAPList;
		DataManager.teacherNameCAPResponses = staging.sTeacherNameCAPList;
		DataManager.classroomNameCAPResponses = staging.sClassroomNameCAPList;

		DataManager.assessorIdLniReponses = staging.sAssessorIdLniList;
		DataManager.teacherIdLniResponses = staging.sTeacherIdLniList;
		DataManager.classroomIdLniResponses = staging.sClassroomIdLniList;
		DataManager.assessorNameLniReponses = staging.sAssessorNameLniList;
		DataManager.teacherNameLniResponses = staging.sTeacherNameLniList;
		DataManager.classroomNameLniResponses = staging.sClassroomNameLniList;

		DataManager.assessorIdLsiReponses = staging.sAssessorIdLsiList;
		DataManager.teacherIdLsiResponses = staging.sTeacherIdLsiList;
		DataManager.classroomIdLsiResponses = staging.sClassroomIdLsiList;
		DataManager.assessorNameLsiReponses = staging.sAssessorNameLsiList;
		DataManager.teacherNameLsiResponses = staging.sTeacherNameLsiList;
		DataManager.classroomNameLsiResponses = staging.sClassroomNameLsiList;

		DataManager.assessorIdCSReponses = staging.sAssessorIdCSList;
		DataManager.teacherIdCSResponses = staging.sTeacherIdCSList;
		DataManager.classroomIdCSResponses = staging.sClassroomIdCSList;
		DataManager.assessorNameCSReponses = staging.sAssessorNameCSList;
		DataManager.teacherNameCSResponses = staging.sTeacherNameCSList;
		DataManager.classroomNameCSResponses = staging.sClassroomNameCSList;

		DataManager.assessorIdSRReponses = staging.sAssessorIdSRList;
		DataManager.teacherIdSRResponses = staging.sTeacherIdSRList;
		DataManager.classroomIdSRResponses = staging.sClassroomIdSRList;
		DataManager.assessorNameSRReponses = staging.sAssessorNameSRList;
		DataManager.teacherNameSRResponses = staging.sTeacherNameSRList;
		DataManager.classroomNameSRResponses = staging.sClassroomNameSRList;

		DataManager.assessorIdBookSumReponses = staging.sAssessorIdBookSumList;
		DataManager.teacherIdBookSumResponses = staging.sTeacherIdBookSumList;
		DataManager.classroomIdBookSumResponses = staging.sClassroomIdBookSumList;
		DataManager.assessorNameBookSumReponses = staging.sAssessorNameBookSumList;
		DataManager.teacherNameBookSumResponses = staging.sTeacherNameBookSumList;
		DataManager.classroomNameBookSumResponses = staging.sClassroomNameBookSumList;

		DataManager.assessorIdWritingReponses = staging.sAssessorIdWritingList;
		DataManager.teacherIdWritingResponses = staging.sTeacherIdWritingList;
		DataManager.classroomIdWritingResponses = staging.sClassroomIdWritingList;
		DataManager.assessorNameWritingReponses = staging.sAssessorNameWritingList;
		DataManager.teacherNameWritingResponses = staging.sTeacherNameWritingList;
		DataManager.classroomNameWritingResponses = staging.sClassroomNameWritingList;

		if(DataManager.grade_vocabularyTotal != null) {
		for(int i=0; i<DataManager.grade_vocabularyTotal.Length;i++){
			if(DataManager.grade_vocabularyTotal[i] == -1){
				DataManager.vocabTime = i+1;
				break;
			}
			DataManager.vocabTime = 7;
		}}

		if(DataManager.grade_csTotal != null) {
		for(int i=0; i<DataManager.grade_csTotal.Length;i++){
			if(DataManager.grade_csTotal[i] == -1){
				DataManager.CSTime = i+1;
				break;
			}
			DataManager.CSTime = 7;
		}}

		if(DataManager.grade_srTotal != null) {
		for(int i=0; i<DataManager.grade_srTotal.Length;i++){
			if(DataManager.grade_srTotal[i] == -1){
				DataManager.SRTime = i+1;
				break;
			}
			DataManager.SRTime = 7;
		}}

		if(DataManager.grade_srTotal != null) {
		for(int i=0; i<DataManager.grade_srTotal.Length;i++){
			if(DataManager.grade_srTotal[i] == -1){
				DataManager.SRTime = i+1;
				break;
			}
			DataManager.SRTime = 7;
		}}

		if(DataManager.grade_bookSumTotal != null) {
		for(int i=0; i<DataManager.grade_bookSumTotal.Length;i++){
			if(DataManager.grade_bookSumTotal[i] == -1){
				DataManager.bookSumTime = i+1;
				break;
			}
			DataManager.bookSumTime = 7;
		}}

	}
	
	// Creates files and saves data passed as parameter
	// 1. Data is stored in a file -> <child_id>.dat
	// 2. Only data of current user is stored
	public void Save(UsersDetails usersDetails)
	{
		if (usersDetails == null || usersDetails.users == null)
			return;
		
		SerialData staging = SerialData.convertToSerialData(usersDetails);
			
		if (staging.sClassroomID == null || staging.sChildID == null)
		{
			Debug.LogError("Missing childID or classroomId, unable to save data");
			return;
		}
		
		string fileName = staging.sChildID + ".dat"; // File for saving, filename will be <childID>.dat
		string savePath = Path.Combine(pdP, fileName); // File path for storage with the file name
		Debug.Log(fileName);
		Debug.Log(savePath);

		//Create and save file
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(savePath);
		bf.Serialize(file, staging);
		file.Close();
	}
}
