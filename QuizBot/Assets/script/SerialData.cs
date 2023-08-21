//This class is used to hold data when it is transferred from app cache memory to local data files
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class SerialData
{
    public string sRecordId;
    public string sTeacherID;
    public string sAssessorID;
    public string sChildID;
    public string sClassroomID;

    public string sExportImportRef = DataManager.exportImportRef=="ID" ? "ID" : "Name";

    //Vocab storage
    public double[] sGradeVocabExp;
    public double[] sGradeVocabRec;
    public double[] sGradeVocabTotal;
    public List<string> sAssessorIdVocabList;
    public List<string> sTeacherIdVocabList;
    public List<string> sClassroomIdVocabList;
    public List<string> sAssessorNameVocabList;
    public List<string> sTeacherNameVocabList;
    public List<string> sClassroomNameVocabList;
    public List<List<bool>> sIndividualExpressiveList;
    public List<List<bool>> sIndividualExpressiveFlagList;
    public List<List<bool>> sIndividualReceptiveList;
    public List<List<bool>> sIndividualReceptiveFlagList;
    public List<List<string>> sIndividualResponses;
    public List<int> sCompleteVocabulary;
    public List<string> sVocabDateTimeField;

    //Clapping Syllable storage
    public int[] sGradeCSTotal;
    public List<string> sAssessorIdCSList;
    public List<string> sTeacherIdCSList;
    public List<string> sClassroomIdCSList;
    public List<string> sAssessorNameCSList;
    public List<string> sTeacherNameCSList;
    public List<string> sClassroomNameCSList;
    public List<List<bool>> sIndividualCSResponseList;
    public List<string> sDateTimeFieldCS;
    public List<int> sCompleteCS;

    //Writing Syllable storage
    public List<List<int>> sIndividualWritingScoreList;
    public List<string> sIndividualWritingImageList;
    public List<string> sAssessorIdWritingList;
    public List<string> sTeacherIdWritingList;
    public List<string> sClassroomIdWritingList;
    public List<string> sAssessorNameWritingList;
    public List<string> sTeacherNameWritingList;
    public List<string> sClassroomNameWritingList;
    public List<string> sDateTimeFieldWriting;
    public List<int> sCompleteWriting;


    //LNI Storage
    [FormerlySerializedAs("sLearnedLetterNames")] public bool[] sLearnedLetterNamesLNI;
    public AdaptiveResponse[,] sIndividual_LNI;
    public List<string> sAssessorIdLniList = new List<string>{"", "", "", "", "", ""};
    public List<string> sTeacherIdLniList = new List<string>{"", "", "", "", "", ""};
    public List<string> sClassroomIdLniList = new List<string>{"", "", "", "", "", ""};
    public List<string> sAssessorNameLniList = new List<string>{"", "", "", "", "", ""};
    public List<string> sTeacherNameLniList = new List<string>{"", "", "", "", "", ""};
    public List<string> sClassroomNameLniList = new List<string>{"", "", "", "", "", ""};
    public List<string> sDateTimeFieldLNI;
    public List<int> sCompleteLNI;

    //LSI Storage
    public bool[] sLearnedLetterNamesLSI;
    public AdaptiveResponse[,] sIndividual_LSI;
    public List<string> sAssessorIdLsiList;
    public List<string> sTeacherIdLsiList;
    public List<string> sClassroomIdLsiList;
    public List<string> sAssessorNameLsiList;
    public List<string> sTeacherNameLsiList;
    public List<string> sClassroomNameLsiList;
    public List<string> sDateTimeFieldLSI;
    public List<int> sCompleteLSI;

    //BS Storage
    public List<string> sAssessorIdBsList;
    public List<string> sTeacherIdBsList;
    public List<string> sClassroomIdBsList;
    public List<string> sAssessorNameBsList;
    public List<string> sTeacherNameBsList;
    public List<string> sClassroomNameBsList;
    public AdaptiveResponse[,] sIndividual_BS; //answer array with preset of 36 sounds, see bs_items.json
    public string[,] sIndividual_BSChildResponse; //[index, globaltime-1] holds child response to every question
    public Tuple<double, double>[] final_BSscores; //This tuple holds eap_estimation_value and standard_error
    public List<string> sDateTimeFieldBS;
    public List<int> sCompleteBS;

    //CAP Storage
    public List<string> sAssessorIdCAPList;
    public List<string> sTeacherIdCAPList;
    public List<string> sClassroomIdCAPList;
    public List<string> sAssessorNameCAPList;
    public List<string> sTeacherNameCAPList;
    public List<string> sClassroomNameCAPList;
    public AdaptiveResponse[,] sIndividual_CAP; //answer array with preset of 36 sounds, see bs_items.json
    public Tuple<double, double>[] final_CAPscores; //This tuple holds eap_estimation_value and standard_error
    public List<string> sDateTimeFieldCAP;
    public List<int> sCompleteCAP;

    //SR
    public int[] sGradeSRTotal;
    public List<string> sAssessorIdSRList;
    public List<string> sTeacherIdSRList;
    public List<string> sClassroomIdSRList;
    public List<string> sAssessorNameSRList;
    public List<string> sTeacherNameSRList;
    public List<string> sClassroomNameSRList;
    public List<List<bool>> sIndividualSRResponseList;
    public List<List<string>> sIndividualSRQuestionsList;
    public List<string> sDateTimeFieldSR;
    public List<int> sCompleteSR;

    //Book Summary
    public int[] sGradeBookSumTotal;
    public List<string> sAssessorIdBookSumList;
    public List<string> sTeacherIdBookSumList;
    public List<string> sClassroomIdBookSumList;
    public List<string> sAssessorNameBookSumList;
    public List<string> sTeacherNameBookSumList;
    public List<string> sClassroomNameBookSumList;
    public List<List<bool>> sIndividualBookSumResponseList;
    public List<List<string>> sIndividualBookSumQuestionsList;
    public List<List<string>> sIndividualBookSumChildResponseList;
    public List<string> sDateTimeFieldBookSum;
    public List<int> sCompleteBookSum;

    public static SerialData convertToSerialData(UsersDetails usersDetails)
    {
        SerialData serialData = new SerialData();

        serialData.sVocabDateTimeField = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldBookSum = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldBS = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldCAP = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldCS = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldLNI = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldLSI = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldSR = new List<string> { "", "", "", "", "", "" };
        serialData.sDateTimeFieldWriting = new List<string> { "", "", "", "", "", "" };

        List<List<bool>> expressiveList = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };// { Capacity = 6};;
        List<string> assessors_vocab_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_vocab_list = new List<string>(){Capacity = 6};;
        List<string> teachers_vocab_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_vocab_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_vocab_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_vocab_list = new List<string>(){Capacity = 6};;
        serialData.sCompleteVocabulary = new List<int>() { -1, -1, -1, -1, -1, -1 };

        List<string> assessors_bs_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_bs_list = new List<string>(){Capacity = 6};;
        List<string> teachers_bs_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_bs_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_bs_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_bs_list = new List<string>(){Capacity = 6};;
        serialData.final_BSscores = new Tuple<double, double>[6];
        serialData.sIndividual_BS = new AdaptiveResponse[36, 6];
        serialData.sIndividual_BSChildResponse = new string[36, 6];
        serialData.sCompleteBS = new List<int> { -1, -1, -1, -1, -1, -1 };

        List<string> assessors_CAP_list = new List<string>() { Capacity = 6 }; ;
        List<string> classrooms_CAP_list = new List<string>() { Capacity = 6 }; ;
        List<string> teachers_CAP_list = new List<string>() { Capacity = 6 }; ;
        List<string> assessors_name_CAP_list = new List<string>() { Capacity = 6 }; ;
        List<string> classrooms_name_CAP_list = new List<string>() { Capacity = 6 }; ;
        List<string> teachers_name_CAP_list = new List<string>() { Capacity = 6 }; ;
        serialData.final_CAPscores = new Tuple<double, double>[6];
        serialData.sIndividual_CAP = new AdaptiveResponse[13, 6];
        serialData.sCompleteCAP = new List<int> { -1, -1, -1, -1, -1, -1 };

        List<string> assessors_lni_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_lni_list = new List<string>(){Capacity = 6};;
        List<string> teachers_lni_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_lni_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_lni_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_lni_list = new List<string>(){Capacity = 6};;
        serialData.sLearnedLetterNamesLNI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false, false, false, false};
        serialData.sIndividual_LNI = new AdaptiveResponse[26, 6];
        serialData.sCompleteLNI = new List<int> { -1, -1, -1, -1, -1, -1 };

        List<string> assessors_lsi_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_lsi_list = new List<string>(){Capacity = 6};;
        List<string> teachers_lsi_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_lsi_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_lsi_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_lsi_list = new List<string>(){Capacity = 6};;
        serialData.sLearnedLetterNamesLSI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false, false, false, false};
        serialData.sIndividual_LSI = new AdaptiveResponse[26, 6];
        serialData.sCompleteLSI = new List<int> { -1, -1, -1, -1, -1, -1 };

        List<string> assessors_cs_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_cs_list = new List<string>(){Capacity = 6};;
        List<string> teachers_cs_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_cs_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_cs_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_cs_list = new List<string>(){Capacity = 6};;
        serialData.sCompleteCS = new List<int> { -1, -1, -1, -1, -1, -1 };

        List<string> assessors_writing_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_writing_list = new List<string>(){Capacity = 6};;
        List<string> teachers_writing_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_writing_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_writing_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_writing_list = new List<string>(){Capacity = 6};;
        serialData.sCompleteWriting = new List<int> { -1, -1, -1, -1, -1, -1 };

        List<string> assessors_sr_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_sr_list = new List<string>(){Capacity = 6};;
        List<string> teachers_sr_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_sr_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_sr_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_sr_list = new List<string>(){Capacity = 6};;
        serialData.sGradeSRTotal = new int[3];
        serialData.sCompleteSR = new List<int> { -1, -1, -1 };

        List<string> assessors_booksum_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_booksum_list = new List<string>(){Capacity = 6};;
        List<string> teachers_booksum_list = new List<string>(){Capacity = 6};;
        List<string> assessors_name_booksum_list = new List<string>(){Capacity = 6};;
        List<string> classrooms_name_booksum_list = new List<string>(){Capacity = 6};;
        List<string> teachers_name_booksum_list = new List<string>(){Capacity = 6};;
        serialData.sGradeBookSumTotal = new int[3];
        serialData.sCompleteBookSum = new List<int> { -1, -1, -1 };

        List<List<bool>> expressiveFlagList = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };//{ Capacity = 6};;
        List<List<bool>> receptiveList = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };// { Capacity = 6};;
        List<List<bool>> receptiveFlagList = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };// { Capacity = 6};;
        List<List<string>> individualResponses = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>() };// { Capacity = 6};;
        List<List<bool>> csResponseList = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };//{Capacity = 6};;
        List<List<bool>> srResponseList = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>() };//{ Capacity = 3};;
        List<List<string>> srQuestionsList = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>()}; //{Capacity = 3};;
        List<List<bool>> booksumResponseList = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>() };//{ Capacity = 3};;
        List<List<string>> booksumQuestionsList = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>() };//{ Capacity = 3};;
        List<List<string>> booksumChildResponseList = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>() };//{ Capacity = 3};;

        List<List<int>> writingScoreList = new List<List<int>>() { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>() };// { Capacity = 6};;
        List<string> imageDataList = new List<string>() { "", "", "", "", "", "" };
        // List<int> writingSentenceScoreList = new List<int>(){Capacity = 6};;
        
        foreach (var redCapRecord in usersDetails.users)
        {
            if (redCapRecord.recordID != null && redCapRecord.recordID != 0)
                serialData.sRecordId = redCapRecord.recordID.ToString();

            if(DataManager.exportImportRef == "ID"){
                // serialData.sExportImportRef = "ID";
                if (!string.IsNullOrEmpty(redCapRecord.assessorID))
                    serialData.sAssessorID = redCapRecord.assessorID;
                if (!string.IsNullOrEmpty(redCapRecord.childID))
                    serialData.sChildID = redCapRecord.childID;
                if (!string.IsNullOrEmpty(redCapRecord.classroomID))
                    serialData.sClassroomID = redCapRecord.classroomID;
                if (!string.IsNullOrEmpty(redCapRecord.teacherID))
                serialData.sTeacherID = redCapRecord.teacherID;
            }
            else{
                // serialData.sExportImportRef = "Name";
                if (!string.IsNullOrEmpty(redCapRecord.assessorName))
                    serialData.sAssessorID = redCapRecord.assessorName;
                if (!string.IsNullOrEmpty(redCapRecord.childName))
                    serialData.sChildID = redCapRecord.childName;
                if (!string.IsNullOrEmpty(redCapRecord.classroomName))
                    serialData.sClassroomID = redCapRecord.classroomName;
                if (!string.IsNullOrEmpty(redCapRecord.teacherName))
                    serialData.sTeacherID = redCapRecord.teacherName;
            }

            // Responsible for storing vocab related data
            if (redCapRecord.vocabSession != null && redCapRecord.vocabSession != 0)
            {
                List<bool> sessionExpressiveList = new List<bool>{false, false, false, false, false, false};
                List<bool> sessionExpressiveFlagList = new List<bool>{false, false, false, false, false, false};
                List<bool> sessionReceptiveList = new List<bool>{false, false, false, false, false, false};
                List<bool> sessionReceptiveFlagList = new List<bool>{false, false, false, false, false, false};
                List<string> sessionIndividualResponses = new List<string>{"", "", "", "", "", ""};
                String sessionAssesorIdResponse = "";
                String sessionClassroomIdResponse = "";
                String sessionTeacherIdResponse = "";
                String sessionAssesorNameResponse = "";
                String sessionClassroomNameResponse = "";
                String sessionTeacherNameResponse = "";
                if (serialData.sGradeVocabExp == null)
                    serialData.sGradeVocabExp = new double[6] { -1, -1, -1, -1, -1, -1 };
                if (serialData.sGradeVocabRec == null)
                    serialData.sGradeVocabRec = new double[6] { -1, -1, -1, -1, -1, -1 };
                if (serialData.sGradeVocabTotal == null)
                    serialData.sGradeVocabTotal = new double[6] { -1, -1, -1, -1, -1, -1 };
                 
                if (redCapRecord.q1Expressive != null)
                    sessionExpressiveList[0] = getTrueFalse(redCapRecord.q1Expressive);
                if (redCapRecord.q2Expressive != null)
                    sessionExpressiveList[1] = getTrueFalse(redCapRecord.q2Expressive);
                if (redCapRecord.q3Expressive != null)
                    sessionExpressiveList[2] = getTrueFalse(redCapRecord.q3Expressive);
                if (redCapRecord.q4Expressive != null)
                    sessionExpressiveList[3] = getTrueFalse(redCapRecord.q4Expressive);
                if (redCapRecord.q5Expressive != null)
                    sessionExpressiveList[4] = getTrueFalse(redCapRecord.q5Expressive);
                if (redCapRecord.q6Expressive != null)
                    sessionExpressiveList[5] = getTrueFalse(redCapRecord.q6Expressive);
                
                if (redCapRecord.q1Receptive != null)
                    sessionReceptiveList[0] = getTrueFalse(redCapRecord.q1Receptive);
                if (redCapRecord.q2Receptive != null)
                    sessionReceptiveList[1] = getTrueFalse(redCapRecord.q2Receptive);
                if (redCapRecord.q3Receptive != null)
                    sessionReceptiveList[2] = getTrueFalse(redCapRecord.q3Receptive);
                if (redCapRecord.q4Receptive != null)
                    sessionReceptiveList[3] = getTrueFalse(redCapRecord.q4Receptive);
                if (redCapRecord.q5Receptive != null)
                    sessionReceptiveList[4] = getTrueFalse(redCapRecord.q5Receptive);
                if (redCapRecord.q6Receptive != null)
                    sessionReceptiveList[5] = getTrueFalse(redCapRecord.q6Receptive);
                
                if (redCapRecord.q1ExpressiveFlag != null)
                    sessionExpressiveFlagList[0] = getTrueFalse(redCapRecord.q1ExpressiveFlag);
                if (redCapRecord.q2ExpressiveFlag != null)
                    sessionExpressiveFlagList[1] = getTrueFalse(redCapRecord.q2ExpressiveFlag);
                if (redCapRecord.q3ExpressiveFlag != null)
                    sessionExpressiveFlagList[2] = getTrueFalse(redCapRecord.q3ExpressiveFlag);
                if (redCapRecord.q4ExpressiveFlag != null)
                    sessionExpressiveFlagList[3] = getTrueFalse(redCapRecord.q4ExpressiveFlag);
                if (redCapRecord.q5ExpressiveFlag != null)
                    sessionExpressiveFlagList[4] = getTrueFalse(redCapRecord.q5ExpressiveFlag);
                if (redCapRecord.q6ExpressiveFlag != null)
                    sessionExpressiveFlagList[5] = getTrueFalse(redCapRecord.q6ExpressiveFlag);
                
                if (redCapRecord.q1ReceptiveFlag != null)
                    sessionReceptiveFlagList[0] = getTrueFalse(redCapRecord.q1ReceptiveFlag);
                if (redCapRecord.q2ReceptiveFlag != null)
                    sessionReceptiveFlagList[1] = getTrueFalse(redCapRecord.q2ReceptiveFlag);
                if (redCapRecord.q3ReceptiveFlag != null)
                    sessionReceptiveFlagList[2] = getTrueFalse(redCapRecord.q3ReceptiveFlag);
                if (redCapRecord.q4ReceptiveFlag != null)
                    sessionReceptiveFlagList[3] = getTrueFalse(redCapRecord.q4ReceptiveFlag);
                if (redCapRecord.q5ReceptiveFlag != null)
                    sessionReceptiveFlagList[4] = getTrueFalse(redCapRecord.q5ReceptiveFlag);
                if (redCapRecord.q6ReceptiveFlag != null)
                    sessionReceptiveFlagList[5] = getTrueFalse(redCapRecord.q6ReceptiveFlag);
                
                if (!string.IsNullOrEmpty(redCapRecord.q1Solution))
                    sessionIndividualResponses[0] = redCapRecord.q1Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q2Solution))
                    sessionIndividualResponses[1] = redCapRecord.q2Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q3Solution))
                    sessionIndividualResponses[2] = redCapRecord.q3Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q4Solution))
                    sessionIndividualResponses[3] = redCapRecord.q4Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q5Solution))
                    sessionIndividualResponses[4] = redCapRecord.q5Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q6Solution))
                    sessionIndividualResponses[5] = redCapRecord.q6Solution;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdVocab))
                    sessionAssesorIdResponse = redCapRecord.assessorIdVocab;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdVocab))
                    sessionClassroomIdResponse = redCapRecord.classroomIdVocab;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdVocab))
                    sessionTeacherIdResponse = redCapRecord.teacherIdVocab;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameVocab))
                    sessionAssesorNameResponse = redCapRecord.assessorNameVocab;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameVocab))
                    sessionClassroomNameResponse = redCapRecord.classroomNameVocab;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameVocab))
                    sessionTeacherNameResponse = redCapRecord.teacherNameVocab;

                while (expressiveList.Count < redCapRecord.vocabSession)
                    expressiveList.Add(new List<bool>());
                expressiveList[redCapRecord.vocabSession.Value-1] = sessionExpressiveList;
                
                while (receptiveList.Count < redCapRecord.vocabSession)
                    receptiveList.Add(new List<bool>());
                receptiveList[redCapRecord.vocabSession.Value-1] = sessionReceptiveList;
                
                while (expressiveFlagList.Count < redCapRecord.vocabSession)
                    expressiveFlagList.Add(new List<bool>());
                expressiveFlagList[redCapRecord.vocabSession.Value-1] = sessionExpressiveFlagList;
                
                while (receptiveFlagList.Count < redCapRecord.vocabSession)
                    receptiveFlagList.Add(new List<bool>());
                receptiveFlagList[redCapRecord.vocabSession.Value-1] = sessionReceptiveFlagList;
                
                while (individualResponses.Count < redCapRecord.vocabSession)
                    individualResponses.Add(new List<string>());
                individualResponses[redCapRecord.vocabSession.Value-1] = sessionIndividualResponses;

                while (assessors_vocab_list.Count < redCapRecord.vocabSession)
                    assessors_vocab_list.Add(sessionAssesorIdResponse);
                
                while (classrooms_vocab_list.Count < redCapRecord.vocabSession)
                    classrooms_vocab_list.Add(sessionClassroomIdResponse);

                while (teachers_vocab_list.Count < redCapRecord.vocabSession)
                    teachers_vocab_list.Add(sessionTeacherIdResponse);

                while (assessors_name_vocab_list.Count < redCapRecord.vocabSession)
                    assessors_name_vocab_list.Add(sessionAssesorNameResponse);
                
                while (classrooms_name_vocab_list.Count < redCapRecord.vocabSession)
                    classrooms_name_vocab_list.Add(sessionClassroomNameResponse);

                while (teachers_name_vocab_list.Count < redCapRecord.vocabSession)
                    teachers_name_vocab_list.Add(sessionTeacherNameResponse);
                
                addExpressiveAndReceptiveScore(sessionExpressiveList, 
                                               sessionReceptiveList, 
                                               redCapRecord.vocabSession.Value, 
                                               serialData);
                serialData.sCompleteVocabulary[redCapRecord.vocabSession.Value-1] = redCapRecord.vocabularyComplete.Value;
                serialData.sVocabDateTimeField[redCapRecord.vocabSession.Value - 1] = redCapRecord.vocabDateTimeField.ToString();
            }

            // Responsible for storing clapping syllables related data
            if (redCapRecord.csSession != null && redCapRecord.csSession != 0)
            {
                List<bool> sessionResponseList = new List<bool>{false, false, false};
                String sessionCSAssesorIdResponse = "";
                String sessionCSClassroomIdResponse = "";
                String sessionCSTeacherIdResponse = "";
                String sessionCSAssesorNameResponse = "";
                String sessionCSClassroomNameResponse = "";
                String sessionCSTeacherNameResponse = "";
                if (serialData.sGradeCSTotal == null)
                    serialData.sGradeCSTotal = new int[6] { -1, -1, -1, -1, -1, -1};
                 
                if (redCapRecord.popcornResponse != null)
                    sessionResponseList[0] = getTrueFalse(redCapRecord.popcornResponse);
                if (redCapRecord.teacherResponse != null)
                    sessionResponseList[1] = getTrueFalse(redCapRecord.teacherResponse);
                if (redCapRecord.umbrellaResponse != null)
                    sessionResponseList[2] = getTrueFalse(redCapRecord.umbrellaResponse);

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdCS))
                    sessionCSAssesorIdResponse = redCapRecord.assessorIdCS;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdCS))
                    sessionCSClassroomIdResponse = redCapRecord.classroomIdCS;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdCS))
                    sessionCSTeacherIdResponse = redCapRecord.teacherIdCS;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameCS))
                    sessionCSAssesorNameResponse = redCapRecord.assessorNameCS;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameCS))
                    sessionCSClassroomNameResponse = redCapRecord.classroomNameCS;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameCS))
                    sessionCSTeacherNameResponse = redCapRecord.teacherNameCS;

                while (csResponseList.Count < redCapRecord.csSession)
                    csResponseList.Add(new List<bool>());
                csResponseList[redCapRecord.csSession.Value-1] = sessionResponseList;
                
                while (assessors_cs_list.Count < redCapRecord.csSession)
                    assessors_cs_list.Add(sessionCSAssesorIdResponse);
                
                while (classrooms_cs_list.Count < redCapRecord.csSession)
                    classrooms_cs_list.Add(sessionCSClassroomIdResponse);

                while (teachers_cs_list.Count < redCapRecord.csSession)
                    teachers_cs_list.Add(sessionCSTeacherIdResponse);

                while (assessors_name_cs_list.Count < redCapRecord.csSession)
                    assessors_name_cs_list.Add(sessionCSAssesorNameResponse);
                
                while (classrooms_name_cs_list.Count < redCapRecord.csSession)
                    classrooms_name_cs_list.Add(sessionCSClassroomNameResponse);

                while (teachers_name_cs_list.Count < redCapRecord.csSession)
                    teachers_name_cs_list.Add(sessionCSTeacherNameResponse);
                
                int index = redCapRecord.csSession.Value - 1;
                int score_cs = sessionResponseList.Count(item => item);
                serialData.sGradeCSTotal[index] = score_cs;
                serialData.sCompleteCS[redCapRecord.csSession.Value-1] = redCapRecord.clappingSyllablesComplete.Value;
                serialData.sDateTimeFieldCS[redCapRecord.csSession.Value - 1] = redCapRecord.csDateTimeField.ToString();
            }

            // Responsible for storing Writing related data
            if (redCapRecord.writingSessionNo != null && redCapRecord.writingSessionNo != 0)
            {
                List<int> sessionWiritngScoreList = new List<int>{-999,-999};
                
                String sessionWritingAssesorIdResponse = "";
                String sessionWritingClassroomIdResponse = "";
                String sessionWritingTeacherIdResponse = "";
                String sessionWritingAssesorNameResponse = "";
                String sessionWritingClassroomNameResponse = "";
                String sessionWritingTeacherNameResponse = "";

                if (redCapRecord.nameWritingScore != null)
                    sessionWiritngScoreList[0] = (int)redCapRecord.nameWritingScore;
                if (redCapRecord.sentenceWritingScore != null)
                    sessionWiritngScoreList[1] = (int)redCapRecord.sentenceWritingScore;

                string imageData = redCapRecord.imageWriting;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdWriting))
                    sessionWritingAssesorIdResponse = redCapRecord.assessorIdWriting;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdWriting))
                    sessionWritingClassroomIdResponse = redCapRecord.classroomIdWriting;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdWriting))
                    sessionWritingTeacherIdResponse = redCapRecord.teacherIdWriting;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameWriting))
                    sessionWritingAssesorNameResponse = redCapRecord.assessorNameWriting;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameWriting))
                    sessionWritingClassroomNameResponse = redCapRecord.classroomNameWriting;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameWriting))
                    sessionWritingTeacherNameResponse = redCapRecord.teacherNameWriting;

                while (writingScoreList.Count < redCapRecord.writingSessionNo)
                    writingScoreList.Add(new List<int>());
                
                while (assessors_writing_list.Count < redCapRecord.writingSessionNo)
                    assessors_writing_list.Add(sessionWritingAssesorIdResponse);
                
                while (classrooms_writing_list.Count < redCapRecord.writingSessionNo)
                    classrooms_writing_list.Add(sessionWritingClassroomIdResponse);

                while (teachers_writing_list.Count < redCapRecord.writingSessionNo)
                    teachers_writing_list.Add(sessionWritingTeacherIdResponse);

                while (assessors_name_writing_list.Count < redCapRecord.writingSessionNo)
                    assessors_name_writing_list.Add(sessionWritingAssesorNameResponse);
                
                while (classrooms_name_writing_list.Count < redCapRecord.writingSessionNo)
                    classrooms_name_writing_list.Add(sessionWritingClassroomNameResponse);

                while (teachers_name_writing_list.Count < redCapRecord.writingSessionNo)
                    teachers_name_writing_list.Add(sessionWritingTeacherNameResponse);

                writingScoreList[redCapRecord.writingSessionNo.Value-1] = sessionWiritngScoreList;
                imageDataList[redCapRecord.writingSessionNo.Value - 1] = imageData;
                serialData.sCompleteWriting[redCapRecord.writingSessionNo.Value - 1] = redCapRecord.writingComplete.Value;
                serialData.sDateTimeFieldWriting[redCapRecord.writingSessionNo.Value - 1] = redCapRecord.writingDateTimeField.ToString();
            }

            //Populate Story Retell
            //serialData.sGradeSRTotal = new int[3];
            //serialData.sIndividualSRResponseList = new List<List<bool>>();
            //serialData.sIndividualSRQuestionsList = new List<List<string>>();
            // Responsible for storing Story retell syllables related data
            if (redCapRecord.srSession != null && redCapRecord.srSession != 0)
            {
                String sessionSRAssesorIdResponse = "";
                String sessionSRClassroomIdResponse = "";
                String sessionSRTeacherIdResponse = "";
                String sessionSRAssesorNameResponse = "";
                String sessionSRClassroomNameResponse = "";
                String sessionSRTeacherNameResponse = "";
                if (redCapRecord.srTotal != null)
                    serialData.sGradeSRTotal[redCapRecord.srSession.Value - 1] = (int)redCapRecord.srTotal;

                List<bool> sessionResultList = new List<bool>{false, false, false, false, false, false, false, false, 
                false, false, false, false, false, false, false, false};
                List<string> sessionIndividualQuestions = new List<string>{"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};

                 
                if (redCapRecord.srQs1result != null)
                    sessionResultList[0] = getTrueFalse(redCapRecord.srQs1result);
                if (redCapRecord.srQs2result != null)
                    sessionResultList[1] = getTrueFalse(redCapRecord.srQs2result);
                if (redCapRecord.srQs2result != null)
                    sessionResultList[2] = getTrueFalse(redCapRecord.srQs3result);
                if (redCapRecord.srQs4result != null)
                    sessionResultList[3] = getTrueFalse(redCapRecord.srQs4result);
                if (redCapRecord.srQs5result != null)
                    sessionResultList[4] = getTrueFalse(redCapRecord.srQs5result);
                if (redCapRecord.srQs6result != null)
                    sessionResultList[5] = getTrueFalse(redCapRecord.srQs6result);
                if (redCapRecord.srQs7result != null)
                    sessionResultList[6] = getTrueFalse(redCapRecord.srQs7result);
                if (redCapRecord.srQs8result != null)
                    sessionResultList[7] = getTrueFalse(redCapRecord.srQs8result);
                if (redCapRecord.srQs9result != null)
                    sessionResultList[8] = getTrueFalse(redCapRecord.srQs9result);
                if (redCapRecord.srQs10result != null)
                    sessionResultList[9] = getTrueFalse(redCapRecord.srQs10result);
                if (redCapRecord.srQs11result != null)
                    sessionResultList[10] = getTrueFalse(redCapRecord.srQs11result);
                if (redCapRecord.srQs12result != null)
                    sessionResultList[11] = getTrueFalse(redCapRecord.srQs12result);
                if (redCapRecord.srQs13result != null)
                    sessionResultList[12] = getTrueFalse(redCapRecord.srQs13result);
                if (redCapRecord.srQs14result != null)
                    sessionResultList[13] = getTrueFalse(redCapRecord.srQs14result);
                if (redCapRecord.srQs15result != null)
                    sessionResultList[14] = getTrueFalse(redCapRecord.srQs15result);
                if (redCapRecord.srQs16result != null)
                    sessionResultList[15] = getTrueFalse(redCapRecord.srQs16result);

                if (!string.IsNullOrEmpty(redCapRecord.srQuestion1))
                    sessionIndividualQuestions[0] = redCapRecord.srQuestion1;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion2))
                    sessionIndividualQuestions[1] = redCapRecord.srQuestion2;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion3))
                    sessionIndividualQuestions[2] = redCapRecord.srQuestion3;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion4))
                    sessionIndividualQuestions[3] = redCapRecord.srQuestion4;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion5))
                    sessionIndividualQuestions[4] = redCapRecord.srQuestion5;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion6))
                    sessionIndividualQuestions[5] = redCapRecord.srQuestion6;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion7))
                    sessionIndividualQuestions[6] = redCapRecord.srQuestion7;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion8))
                    sessionIndividualQuestions[7] = redCapRecord.srQuestion8;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion9))
                    sessionIndividualQuestions[8] = redCapRecord.srQuestion9;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion10))
                    sessionIndividualQuestions[9] = redCapRecord.srQuestion10;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion11))
                    sessionIndividualQuestions[10] = redCapRecord.srQuestion11;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion12))
                    sessionIndividualQuestions[11] = redCapRecord.srQuestion12;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion13))
                    sessionIndividualQuestions[12] = redCapRecord.srQuestion13;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion14))
                    sessionIndividualQuestions[13] = redCapRecord.srQuestion14;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion15))
                    sessionIndividualQuestions[14] = redCapRecord.srQuestion15;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion16))
                    sessionIndividualQuestions[15] = redCapRecord.srQuestion16;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdSR))
                    sessionSRAssesorIdResponse = redCapRecord.assessorIdSR;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdCS))
                    sessionSRClassroomIdResponse = redCapRecord.classroomIdSR;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdSR))
                    sessionSRTeacherIdResponse = redCapRecord.teacherIdSR;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameSR))
                    sessionSRAssesorNameResponse = redCapRecord.assessorNameSR;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameSR))
                    sessionSRClassroomNameResponse = redCapRecord.classroomNameSR;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameSR))
                    sessionSRTeacherNameResponse = redCapRecord.teacherNameSR;

                while (srResponseList.Count < redCapRecord.srSession)
                    srResponseList.Add(new List<bool>());
                srResponseList[redCapRecord.srSession.Value-1] = sessionResultList;
                
                while (srQuestionsList.Count < redCapRecord.srSession)
                    srQuestionsList.Add(new List<string>());
                srQuestionsList[redCapRecord.srSession.Value-1] = sessionIndividualQuestions;
                
                while (assessors_sr_list.Count < redCapRecord.srSession)
                    assessors_sr_list.Add(sessionSRAssesorIdResponse);
                
                while (classrooms_sr_list.Count < redCapRecord.srSession)
                    classrooms_sr_list.Add(sessionSRClassroomIdResponse);

                while (teachers_sr_list.Count < redCapRecord.srSession)
                    teachers_sr_list.Add(sessionSRTeacherIdResponse);

                while (assessors_name_sr_list.Count < redCapRecord.srSession)
                    assessors_name_sr_list.Add(sessionSRAssesorNameResponse);
                
                while (classrooms_name_sr_list.Count < redCapRecord.srSession)
                    classrooms_name_sr_list.Add(sessionSRClassroomNameResponse);

                while (teachers_name_sr_list.Count < redCapRecord.srSession)
                    teachers_name_sr_list.Add(sessionSRTeacherNameResponse);

                serialData.sCompleteSR[redCapRecord.srSession.Value - 1] = redCapRecord.storyRetellComplete.Value;
                serialData.sDateTimeFieldSR[redCapRecord.srSession.Value - 1] = redCapRecord.srDateTimeField.ToString();

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // while (sGradeSRTotal.Count < redCapRecord.srSession)
                //     serialData.sGradeSRTotal[index] = score_sr;

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // serialData.sGradeSRTotal[index] = score_sr;
            }

            //Populate Book Summary
            //serialData.sGradeBookSumTotal = new int[3];
            //serialData.sIndividualBookSumResponseList = new List<List<bool>>();
            //serialData.sIndividualBookSumQuestionsList = new List<List<string>>();
            // Responsible for storing Story retell syllables related data
            if (redCapRecord.bookSumSession != null && redCapRecord.bookSumSession != 0)
            {
                String sessionBookSumAssesorIdResponse = "";
                String sessionBookSumClassroomIdResponse = "";
                String sessionBookSumTeacherIdResponse = "";
                String sessionBookSumAssesorNameResponse = "";
                String sessionBookSumClassroomNameResponse = "";
                String sessionBookSumTeacherNameResponse = "";
                if (serialData.sGradeBookSumTotal != null)
                    serialData.sGradeBookSumTotal[redCapRecord.bookSumSession.Value - 1] = (int)redCapRecord.bookSumTotal;

                List<bool> sessionResultList = new List<bool>{false, false, false, false, false, false, false, false, 
                false, false, false};
                List<string> sessionIndividualQuestions = new List<string>{"", "", "", "", "", "", "", "", "", "", ""};
                List<string> sessionChildResponse = new List<string> { "", "", "", "", "", "", "", "", "", "", "" };


                if (redCapRecord.booksumQs1result != null)
                {
                    sessionResultList[0] = getTrueFalse(redCapRecord.booksumQs1result);
                    sessionChildResponse[0] = redCapRecord.booksumQuestion1Response;
                }
                if (redCapRecord.booksumQs2result != null)
                {
                    sessionResultList[1] = getTrueFalse(redCapRecord.booksumQs2result);
                    sessionChildResponse[1] = redCapRecord.booksumQuestion2Response;
                }
                if (redCapRecord.booksumQs3result != null)
                {
                    sessionResultList[2] = getTrueFalse(redCapRecord.booksumQs3result);
                    sessionChildResponse[2] = redCapRecord.booksumQuestion3Response;
                }
                if (redCapRecord.booksumQs4result != null)
                {
                    sessionResultList[3] = getTrueFalse(redCapRecord.booksumQs4result);
                    sessionChildResponse[3] = redCapRecord.booksumQuestion4Response;
                }
                if (redCapRecord.booksumQs5result != null)
                {
                    sessionResultList[4] = getTrueFalse(redCapRecord.booksumQs5result);
                    sessionChildResponse[4] = redCapRecord.booksumQuestion5Response;
                }
                if (redCapRecord.booksumQs6result != null)
                {
                    sessionResultList[5] = getTrueFalse(redCapRecord.booksumQs6result);
                    sessionChildResponse[5] = redCapRecord.booksumQuestion6Response;
                }
                if (redCapRecord.booksumQs7result != null)
                {
                    sessionResultList[6] = getTrueFalse(redCapRecord.booksumQs7result);
                    sessionChildResponse[6] = redCapRecord.booksumQuestion7Response;
                }
                if (redCapRecord.booksumQs8result != null)
                {
                    sessionResultList[7] = getTrueFalse(redCapRecord.booksumQs8result);
                    sessionChildResponse[7] = redCapRecord.booksumQuestion8Response;
                }
                if (redCapRecord.booksumQs9result != null)
                {
                    sessionResultList[8] = getTrueFalse(redCapRecord.booksumQs9result);
                    sessionChildResponse[8] = redCapRecord.booksumQuestion9Response;
                }
                if (redCapRecord.booksumQs10result != null)
                {
                    sessionResultList[9] = getTrueFalse(redCapRecord.booksumQs10result);
                    sessionChildResponse[9] = redCapRecord.booksumQuestion10Response;
                }
                if (redCapRecord.booksumQs11result != null)
                {
                    sessionResultList[10] = getTrueFalse(redCapRecord.booksumQs11result);
                    sessionChildResponse[10] = redCapRecord.booksumQuestion11Response;
                }

                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion1))
                    sessionIndividualQuestions[0] = redCapRecord.booksumQuestion1;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion2))
                    sessionIndividualQuestions[1] = redCapRecord.booksumQuestion2;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion3))
                    sessionIndividualQuestions[2] = redCapRecord.booksumQuestion3;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion4))
                    sessionIndividualQuestions[3] = redCapRecord.booksumQuestion4;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion5))
                    sessionIndividualQuestions[4] = redCapRecord.booksumQuestion5;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion6))
                    sessionIndividualQuestions[5] = redCapRecord.booksumQuestion6;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion7))
                    sessionIndividualQuestions[6] = redCapRecord.booksumQuestion7;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion8))
                    sessionIndividualQuestions[7] = redCapRecord.booksumQuestion8;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion9))
                    sessionIndividualQuestions[8] = redCapRecord.booksumQuestion9;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion10))
                    sessionIndividualQuestions[9] = redCapRecord.booksumQuestion10;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion11))
                    sessionIndividualQuestions[10] = redCapRecord.booksumQuestion11;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdBookSum))
                    sessionBookSumAssesorIdResponse = redCapRecord.assessorIdBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdBookSum))
                    sessionBookSumClassroomIdResponse = redCapRecord.classroomIdBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdBookSum))
                    sessionBookSumTeacherIdResponse = redCapRecord.teacherIdBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameSR))
                    sessionBookSumAssesorNameResponse = redCapRecord.assessorNameBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameBookSum))
                    sessionBookSumClassroomNameResponse = redCapRecord.classroomNameBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameBookSum))
                    sessionBookSumTeacherNameResponse = redCapRecord.teacherNameBookSum;

                while (booksumResponseList.Count < redCapRecord.bookSumSession)
                    booksumResponseList.Add(new List<bool>());
                booksumResponseList[redCapRecord.bookSumSession.Value-1] = sessionResultList;
                
                while (booksumQuestionsList.Count < redCapRecord.bookSumSession)
                    booksumQuestionsList.Add(new List<string>());
                booksumQuestionsList[redCapRecord.bookSumSession.Value-1] = sessionIndividualQuestions;

                while (booksumChildResponseList.Count < redCapRecord.bookSumSession)
                    booksumChildResponseList.Add(new List<string>());
                booksumChildResponseList[redCapRecord.bookSumSession.Value - 1] = sessionChildResponse;


                while (assessors_booksum_list.Count < redCapRecord.bookSumSession)
                    assessors_booksum_list.Add(sessionBookSumAssesorIdResponse);
                
                while (classrooms_booksum_list.Count < redCapRecord.bookSumSession)
                    classrooms_booksum_list.Add(sessionBookSumClassroomIdResponse);

                while (teachers_booksum_list.Count < redCapRecord.bookSumSession)
                    teachers_booksum_list.Add(sessionBookSumTeacherIdResponse);

                while (assessors_name_booksum_list.Count < redCapRecord.bookSumSession)
                    assessors_name_booksum_list.Add(sessionBookSumAssesorNameResponse);
                
                while (classrooms_name_booksum_list.Count < redCapRecord.bookSumSession)
                    classrooms_name_booksum_list.Add(sessionBookSumClassroomNameResponse);

                while (teachers_name_booksum_list.Count < redCapRecord.bookSumSession)
                    teachers_name_booksum_list.Add(sessionBookSumTeacherNameResponse);

                serialData.sCompleteBookSum[redCapRecord.bookSumSession.Value - 1] = redCapRecord.bookSummaryComplete.Value;
                serialData.sDateTimeFieldBookSum[redCapRecord.bookSumSession.Value - 1] = redCapRecord.bookSumDateTimeField;

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // while (sGradeSRTotal.Count < redCapRecord.srSession)
                //     serialData.sGradeSRTotal[index] = score_sr;

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // serialData.sGradeSRTotal[index] = score_sr;
            }

            //Populate sLearnedLetterNames
            //serialData.sLearnedLetterNamesLNI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
            //    false, false, false, false, false, false, false, false, false, false, false, false, false};
            if (redCapRecord.LNI_A != null)
                serialData.sLearnedLetterNamesLNI[0] = getTrueFalse(redCapRecord.LNI_A);
            if (redCapRecord.LNI_B != null)
                serialData.sLearnedLetterNamesLNI[1] = getTrueFalse(redCapRecord.LNI_B);
            if (redCapRecord.LNI_C != null)
                serialData.sLearnedLetterNamesLNI[2] = getTrueFalse(redCapRecord.LNI_C);
            if (redCapRecord.LNI_D != null)
                serialData.sLearnedLetterNamesLNI[3] = getTrueFalse(redCapRecord.LNI_D);
            if (redCapRecord.LNI_E != null)
                serialData.sLearnedLetterNamesLNI[4] = getTrueFalse(redCapRecord.LNI_E);
            if (redCapRecord.LNI_F != null)
                serialData.sLearnedLetterNamesLNI[5] = getTrueFalse(redCapRecord.LNI_F);
            if (redCapRecord.LNI_G != null)
                serialData.sLearnedLetterNamesLNI[6] = getTrueFalse(redCapRecord.LNI_G);
            if (redCapRecord.LNI_H != null)
                serialData.sLearnedLetterNamesLNI[7] = getTrueFalse(redCapRecord.LNI_H);
            if (redCapRecord.LNI_I != null)
                serialData.sLearnedLetterNamesLNI[8] = getTrueFalse(redCapRecord.LNI_I);
            if (redCapRecord.LNI_J != null)
                serialData.sLearnedLetterNamesLNI[9] = getTrueFalse(redCapRecord.LNI_J);
            if (redCapRecord.LNI_K != null)
                serialData.sLearnedLetterNamesLNI[10] = getTrueFalse(redCapRecord.LNI_K);
            if (redCapRecord.LNI_L != null)
                serialData.sLearnedLetterNamesLNI[11] = getTrueFalse(redCapRecord.LNI_L);
            if (redCapRecord.LNI_M != null)
                serialData.sLearnedLetterNamesLNI[12] = getTrueFalse(redCapRecord.LNI_M);
            if (redCapRecord.LNI_N != null)
                serialData.sLearnedLetterNamesLNI[13] = getTrueFalse(redCapRecord.LNI_N);
            if (redCapRecord.LNI_O != null)
                serialData.sLearnedLetterNamesLNI[14] = getTrueFalse(redCapRecord.LNI_O);
            if (redCapRecord.LNI_P != null)
                serialData.sLearnedLetterNamesLNI[15] = getTrueFalse(redCapRecord.LNI_P);
            if (redCapRecord.LNI_Q != null)
                serialData.sLearnedLetterNamesLNI[16] = getTrueFalse(redCapRecord.LNI_Q);
            if (redCapRecord.LNI_R != null)
                serialData.sLearnedLetterNamesLNI[17] = getTrueFalse(redCapRecord.LNI_R);
            if (redCapRecord.LNI_S != null)
                serialData.sLearnedLetterNamesLNI[18] = getTrueFalse(redCapRecord.LNI_S);
            if (redCapRecord.LNI_T != null)
                serialData.sLearnedLetterNamesLNI[19] = getTrueFalse(redCapRecord.LNI_T);
            if (redCapRecord.LNI_U != null)
                serialData.sLearnedLetterNamesLNI[20] = getTrueFalse(redCapRecord.LNI_U);
            if (redCapRecord.LNI_V != null)
                serialData.sLearnedLetterNamesLNI[21] = getTrueFalse(redCapRecord.LNI_V);
            if (redCapRecord.LNI_W != null)
                serialData.sLearnedLetterNamesLNI[22] = getTrueFalse(redCapRecord.LNI_W);
            if (redCapRecord.LNI_X != null)
                serialData.sLearnedLetterNamesLNI[23] = getTrueFalse(redCapRecord.LNI_X);
            if (redCapRecord.LNI_Y != null)
                serialData.sLearnedLetterNamesLNI[24] = getTrueFalse(redCapRecord.LNI_Y);
            if (redCapRecord.LNI_Z != null)
                serialData.sLearnedLetterNamesLNI[25] = getTrueFalse(redCapRecord.LNI_Z);


            //Populate sIndividual_LNI
            //serialData.sIndividual_LNI = new AdaptiveResponse[26,6];
            if (redCapRecord.lnirSessionNumber != null && redCapRecord.lnirSessionNumber != 0)
            {
                int lniTime = (int)redCapRecord.lnirSessionNumber-1;

                String sessionAssesorIdResponseLni = "";
                String sessionClassroomIdResponseLni = "";
                String sessionTeacherIdResponseLni = "";
                String sessionAssesorNameResponseLni = "";
                String sessionClassroomNameResponseLni = "";
                String sessionTeacherNameResponseLni = "";

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdLni))
                    sessionAssesorIdResponseLni = redCapRecord.assessorIdLni;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdLni))
                    sessionClassroomIdResponseLni = redCapRecord.classroomIdLni;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdLni))
                    sessionTeacherIdResponseLni = redCapRecord.teacherIdLni;

                if (!string.IsNullOrEmpty(redCapRecord.assessorNameLni))
                    sessionAssesorNameResponseLni = redCapRecord.assessorNameLni;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameLni))
                    sessionClassroomNameResponseLni = redCapRecord.classroomNameLni;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameLni))
                    sessionTeacherNameResponseLni = redCapRecord.teacherNameLni;

                if (redCapRecord.rLNI_A != null)
                    serialData.sIndividual_LNI[0, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_A;
                if (redCapRecord.rLNI_B != null)
                    serialData.sIndividual_LNI[1, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_B;
                if (redCapRecord.rLNI_C != null)
                    serialData.sIndividual_LNI[2, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_C;
                if (redCapRecord.rLNI_D != null)
                    serialData.sIndividual_LNI[3, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_D;
                if (redCapRecord.rLNI_E != null)
                    serialData.sIndividual_LNI[4, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_E;
                if (redCapRecord.rLNI_F != null)
                    serialData.sIndividual_LNI[5, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_F;
                if (redCapRecord.rLNI_G != null)
                    serialData.sIndividual_LNI[6, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_G;
                if (redCapRecord.rLNI_H != null)
                    serialData.sIndividual_LNI[7, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_H;
                if (redCapRecord.rLNI_I != null)
                    serialData.sIndividual_LNI[8, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_I;
                if (redCapRecord.rLNI_J != null)
                    serialData.sIndividual_LNI[9, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_J;
                if (redCapRecord.rLNI_K != null)
                    serialData.sIndividual_LNI[10, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_K;
                if (redCapRecord.rLNI_L != null)
                    serialData.sIndividual_LNI[11, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_L;
                if (redCapRecord.rLNI_M != null)
                    serialData.sIndividual_LNI[12, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_M;
                if (redCapRecord.rLNI_N != null)
                    serialData.sIndividual_LNI[13, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_N;
                if (redCapRecord.rLNI_O != null)
                    serialData.sIndividual_LNI[14, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_O;
                if (redCapRecord.rLNI_P != null)
                    serialData.sIndividual_LNI[15, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_P;
                if (redCapRecord.rLNI_Q != null)
                    serialData.sIndividual_LNI[16, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_Q;
                if (redCapRecord.rLNI_R != null)
                    serialData.sIndividual_LNI[17, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_R;
                if (redCapRecord.rLNI_S != null)
                    serialData.sIndividual_LNI[18, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_S;
                if (redCapRecord.rLNI_T != null)
                    serialData.sIndividual_LNI[19, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_T;
                if (redCapRecord.rLNI_U != null)
                    serialData.sIndividual_LNI[20, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_U;
                if (redCapRecord.rLNI_V != null)
                    serialData.sIndividual_LNI[21, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_V;
                if (redCapRecord.rLNI_W != null)
                    serialData.sIndividual_LNI[22, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_W;
                if (redCapRecord.rLNI_X != null)
                    serialData.sIndividual_LNI[23, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_X;
                if (redCapRecord.rLNI_Y != null)
                    serialData.sIndividual_LNI[24, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_Y;
                if (redCapRecord.rLNI_Z != null)
                    serialData.sIndividual_LNI[25, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_Z;

                while (assessors_lni_list.Count < lniTime+1)
                    assessors_lni_list.Add(sessionAssesorIdResponseLni);
                
                while (classrooms_lni_list.Count < lniTime+1)
                    classrooms_lni_list.Add(sessionClassroomIdResponseLni);

                while (teachers_lni_list.Count < lniTime+1)
                    teachers_lni_list.Add(sessionTeacherIdResponseLni);

                while (assessors_name_lni_list.Count < lniTime+1)
                    assessors_name_lni_list.Add(sessionAssesorNameResponseLni);
                
                while (classrooms_name_lni_list.Count < lniTime+1)
                    classrooms_name_lni_list.Add(sessionClassroomNameResponseLni);

                while (teachers_name_lni_list.Count < lniTime+1)
                    teachers_name_lni_list.Add(sessionTeacherNameResponseLni);

                serialData.sCompleteLNI[redCapRecord.lnirSessionNumber.Value - 1] = redCapRecord.LNIResultsComplete.Value;
                serialData.sDateTimeFieldLNI[redCapRecord.lnirSessionNumber.Value - 1] = redCapRecord.lniDateTimeField.ToString();
            }
            
            
            //---------
            
            //Populate sLearnedLetterNames
            //serialData.sLearnedLetterNamesLSI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
            //    false, false, false, false, false, false, false, false, false, false, false, false, false};
            if (redCapRecord.LSI_A != null)
                serialData.sLearnedLetterNamesLSI[0] = getTrueFalse(redCapRecord.LSI_A);
            if (redCapRecord.LSI_B != null)
                serialData.sLearnedLetterNamesLSI[1] = getTrueFalse(redCapRecord.LSI_B);
            if (redCapRecord.LSI_C != null)
                serialData.sLearnedLetterNamesLSI[2] = getTrueFalse(redCapRecord.LSI_C);
            if (redCapRecord.LSI_D != null)
                serialData.sLearnedLetterNamesLSI[3] = getTrueFalse(redCapRecord.LSI_D);
            if (redCapRecord.LSI_E != null)
                serialData.sLearnedLetterNamesLSI[4] = getTrueFalse(redCapRecord.LSI_E);
            if (redCapRecord.LSI_F != null)
                serialData.sLearnedLetterNamesLSI[5] = getTrueFalse(redCapRecord.LSI_F);
            if (redCapRecord.LSI_G != null)
                serialData.sLearnedLetterNamesLSI[6] = getTrueFalse(redCapRecord.LSI_G);
            if (redCapRecord.LSI_H != null)
                serialData.sLearnedLetterNamesLSI[7] = getTrueFalse(redCapRecord.LSI_H);
            if (redCapRecord.LSI_I != null)
                serialData.sLearnedLetterNamesLSI[8] = getTrueFalse(redCapRecord.LSI_I);
            if (redCapRecord.LSI_J != null)
                serialData.sLearnedLetterNamesLSI[9] = getTrueFalse(redCapRecord.LSI_J);
            if (redCapRecord.LSI_K != null)
                serialData.sLearnedLetterNamesLSI[10] = getTrueFalse(redCapRecord.LSI_K);
            if (redCapRecord.LSI_L != null)
                serialData.sLearnedLetterNamesLSI[11] = getTrueFalse(redCapRecord.LSI_L);
            if (redCapRecord.LSI_M != null)
                serialData.sLearnedLetterNamesLSI[12] = getTrueFalse(redCapRecord.LSI_M);
            if (redCapRecord.LSI_N != null)
                serialData.sLearnedLetterNamesLSI[13] = getTrueFalse(redCapRecord.LSI_N);
            if (redCapRecord.LSI_O != null)
                serialData.sLearnedLetterNamesLSI[14] = getTrueFalse(redCapRecord.LSI_O);
            if (redCapRecord.LSI_P != null)
                serialData.sLearnedLetterNamesLSI[15] = getTrueFalse(redCapRecord.LSI_P);
            if (redCapRecord.LSI_Q != null)
                serialData.sLearnedLetterNamesLSI[16] = getTrueFalse(redCapRecord.LSI_Q);
            if (redCapRecord.LSI_R != null)
                serialData.sLearnedLetterNamesLSI[17] = getTrueFalse(redCapRecord.LSI_R);
            if (redCapRecord.LSI_S != null)
                serialData.sLearnedLetterNamesLSI[18] = getTrueFalse(redCapRecord.LSI_S);
            if (redCapRecord.LSI_T != null)
                serialData.sLearnedLetterNamesLSI[19] = getTrueFalse(redCapRecord.LSI_T);
            if (redCapRecord.LSI_U != null)
                serialData.sLearnedLetterNamesLSI[20] = getTrueFalse(redCapRecord.LSI_U);
            if (redCapRecord.LSI_V != null)
                serialData.sLearnedLetterNamesLSI[21] = getTrueFalse(redCapRecord.LSI_V);
            if (redCapRecord.LSI_W != null)
                serialData.sLearnedLetterNamesLSI[22] = getTrueFalse(redCapRecord.LSI_W);
            if (redCapRecord.LSI_X != null)
                serialData.sLearnedLetterNamesLSI[23] = getTrueFalse(redCapRecord.LSI_X);
            if (redCapRecord.LSI_Y != null)
                serialData.sLearnedLetterNamesLSI[24] = getTrueFalse(redCapRecord.LSI_Y);
            if (redCapRecord.LSI_Z != null)
                serialData.sLearnedLetterNamesLSI[25] = getTrueFalse(redCapRecord.LSI_Z);


            //Populate sIndividual_LSI
            //serialData.sIndividual_LSI = new AdaptiveResponse[26,6];
            if (redCapRecord.lsirSessionNumber != null && redCapRecord.lsirSessionNumber != 0)
            {
                int lsiTime = (int)redCapRecord.lsirSessionNumber-1;

                String sessionAssesorIdResponseLsi = "";
                String sessionClassroomIdResponseLsi = "";
                String sessionTeacherIdResponseLsi = "";
                String sessionAssesorNameResponseLsi = "";
                String sessionClassroomNameResponseLsi = "";
                String sessionTeacherNameResponseLsi = "";
                if (!string.IsNullOrEmpty(redCapRecord.assessorIdLsi))
                    sessionAssesorIdResponseLsi = redCapRecord.assessorIdLsi;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdLsi))
                    sessionClassroomIdResponseLsi = redCapRecord.classroomIdLsi;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdLsi))
                    sessionTeacherIdResponseLsi = redCapRecord.teacherIdLsi;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameLsi))
                    sessionAssesorNameResponseLsi = redCapRecord.assessorNameLsi;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameLsi))
                    sessionClassroomNameResponseLsi = redCapRecord.classroomNameLsi;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameLsi))
                    sessionTeacherNameResponseLsi = redCapRecord.teacherNameLsi;

                if (redCapRecord.rLSI_A != null)
                    serialData.sIndividual_LSI[0, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_A;
                if (redCapRecord.rLSI_B != null)
                    serialData.sIndividual_LSI[1, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_B;
                if (redCapRecord.rLSI_C != null)
                    serialData.sIndividual_LSI[2, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_C;
                if (redCapRecord.rLSI_D != null)
                    serialData.sIndividual_LSI[3, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_D;
                if (redCapRecord.rLSI_E != null)
                    serialData.sIndividual_LSI[4, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_E;
                if (redCapRecord.rLSI_F != null)
                    serialData.sIndividual_LSI[5, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_F;
                if (redCapRecord.rLSI_G != null)
                    serialData.sIndividual_LSI[6, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_G;
                if (redCapRecord.rLSI_H != null)
                    serialData.sIndividual_LSI[7, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_H;
                if (redCapRecord.rLSI_I != null)
                    serialData.sIndividual_LSI[8, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_I;
                if (redCapRecord.rLSI_J != null)
                    serialData.sIndividual_LSI[9, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_J;
                if (redCapRecord.rLSI_K != null)
                    serialData.sIndividual_LSI[10, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_K;
                if (redCapRecord.rLSI_L != null)
                    serialData.sIndividual_LSI[11, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_L;
                if (redCapRecord.rLSI_M != null)
                    serialData.sIndividual_LSI[12, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_M;
                if (redCapRecord.rLSI_N != null)
                    serialData.sIndividual_LSI[13, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_N;
                if (redCapRecord.rLSI_O != null)
                    serialData.sIndividual_LSI[14, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_O;
                if (redCapRecord.rLSI_P != null)
                    serialData.sIndividual_LSI[15, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_P;
                if (redCapRecord.rLSI_Q != null)
                    serialData.sIndividual_LSI[16, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_Q;
                if (redCapRecord.rLSI_R != null)
                    serialData.sIndividual_LSI[17, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_R;
                if (redCapRecord.rLSI_S != null)
                    serialData.sIndividual_LSI[18, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_S;
                if (redCapRecord.rLSI_T != null)
                    serialData.sIndividual_LSI[19, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_T;
                if (redCapRecord.rLSI_U != null)
                    serialData.sIndividual_LSI[20, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_U;
                if (redCapRecord.rLSI_V != null)
                    serialData.sIndividual_LSI[21, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_V;
                if (redCapRecord.rLSI_W != null)
                    serialData.sIndividual_LSI[22, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_W;
                if (redCapRecord.rLSI_X != null)
                    serialData.sIndividual_LSI[23, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_X;
                if (redCapRecord.rLSI_Y != null)
                    serialData.sIndividual_LSI[24, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_Y;
                if (redCapRecord.rLSI_Z != null)
                    serialData.sIndividual_LSI[25, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_Z;

                while (assessors_lsi_list.Count < lsiTime+1)
                    assessors_lsi_list.Add(sessionAssesorIdResponseLsi);
                
                while (classrooms_lsi_list.Count < lsiTime+1)
                    classrooms_lsi_list.Add(sessionClassroomIdResponseLsi);

                while (teachers_lsi_list.Count < lsiTime+1)
                    teachers_lsi_list.Add(sessionTeacherIdResponseLsi);

                while (assessors_name_lsi_list.Count < lsiTime+1)
                    assessors_name_lsi_list.Add(sessionAssesorNameResponseLsi);
                
                while (classrooms_name_lsi_list.Count < lsiTime+1)
                    classrooms_name_lsi_list.Add(sessionClassroomNameResponseLsi);

                while (teachers_name_lsi_list.Count < lsiTime+1)
                    teachers_name_lsi_list.Add(sessionTeacherNameResponseLsi);

                serialData.sCompleteLSI[redCapRecord.lsirSessionNumber.Value - 1] = redCapRecord.LSIResultsComplete.Value;
                serialData.sDateTimeFieldLSI[redCapRecord.lsirSessionNumber.Value - 1] = redCapRecord.lsiDateTimeField.ToString();
            }

            //Populate Beginning Sounds
            //serialData.final_BSscores = new Tuple<double, double>[6];
            //serialData.sIndividual_BS = new AdaptiveResponse[36, 6];
            //serialData.sIndividual_BSChildResponse = new string[36, 6];
            if (redCapRecord.bsSessionNumber != null && redCapRecord.bsSessionNumber != 0)
            {
                int bsTime = (int)redCapRecord.bsSessionNumber - 1; //offset for zero array
                String sessionAssesorIdResponseBs = "";
                String sessionClassroomIdResponseBs = "";
                String sessionTeacherIdResponseBs = "";
                String sessionAssesorNameResponseBs = "";
                String sessionClassroomNameResponseBs = "";
                String sessionTeacherNameResponseBs = "";
                if (redCapRecord.bsEAP != null && redCapRecord.bsStdError != null)
                {
                    serialData.final_BSscores[bsTime] = new Tuple<double, double>((double)redCapRecord.bsEAP, (double)redCapRecord.bsStdError);
                }

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdBs))
                    sessionAssesorIdResponseBs = redCapRecord.assessorIdBs;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdBs))
                    sessionClassroomIdResponseBs = redCapRecord.classroomIdBs;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdBs))
                    sessionTeacherIdResponseBs = redCapRecord.teacherIdBs;

                if (!string.IsNullOrEmpty(redCapRecord.assessorNameBs))
                    sessionAssesorNameResponseBs = redCapRecord.assessorNameBs;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameBs))
                    sessionClassroomNameResponseBs = redCapRecord.classroomNameBs;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameBs))
                    sessionTeacherNameResponseBs = redCapRecord.teacherNameBs;

                //store the scores
                //Refer to bs_items.json for reesponse list
                if(redCapRecord.bsHand != null)
                    serialData.sIndividual_BS[0, bsTime] = (AdaptiveResponse)redCapRecord.bsHand;
                if(redCapRecord.bsMoon != null)serialData.sIndividual_BS[1, bsTime]= (AdaptiveResponse)redCapRecord.bsMoon;
                if(redCapRecord.bsSun != null)serialData.sIndividual_BS[2, bsTime]= (AdaptiveResponse)redCapRecord.bsSun;
                if(redCapRecord.bsDoor != null)serialData.sIndividual_BS[3, bsTime]= (AdaptiveResponse)redCapRecord.bsDoor;
                if(redCapRecord.bsMouse != null)serialData.sIndividual_BS[4, bsTime]= (AdaptiveResponse)redCapRecord.bsMouse;
                if(redCapRecord.bsCar != null)serialData.sIndividual_BS[5, bsTime]= (AdaptiveResponse)redCapRecord.bsCar;
                if(redCapRecord.bsFan != null)serialData.sIndividual_BS[6, bsTime]= (AdaptiveResponse)redCapRecord.bsFan;
                if(redCapRecord.bsPot != null)serialData.sIndividual_BS[7, bsTime]= (AdaptiveResponse)redCapRecord.bsPot;
                if(redCapRecord.bsHat != null)serialData.sIndividual_BS[8, bsTime]= (AdaptiveResponse)redCapRecord.bsHat;
                if(redCapRecord.bsBall != null)serialData.sIndividual_BS[9, bsTime]= (AdaptiveResponse)redCapRecord.bsBall;
                if(redCapRecord.bsDuck != null)serialData.sIndividual_BS[10, bsTime]= (AdaptiveResponse)redCapRecord.bsDuck;
                if(redCapRecord.bsVan != null)serialData.sIndividual_BS[11, bsTime]= (AdaptiveResponse)redCapRecord.bsVan;
                if(redCapRecord.bsDog != null)serialData.sIndividual_BS[12, bsTime]= (AdaptiveResponse)redCapRecord.bsDog;
                if(redCapRecord.bsCake != null)serialData.sIndividual_BS[13, bsTime]= (AdaptiveResponse)redCapRecord.bsCake;
                if (redCapRecord.bsLeaf != null) serialData.sIndividual_BS[14, bsTime] = (AdaptiveResponse)redCapRecord.bsLeaf;
                if(redCapRecord.bsHeart != null)serialData.sIndividual_BS[15, bsTime]= (AdaptiveResponse)redCapRecord.bsHeart;
                if(redCapRecord.bsFour != null)serialData.sIndividual_BS[16, bsTime]= (AdaptiveResponse)redCapRecord.bsFour;
                if(redCapRecord.bsMilk != null)serialData.sIndividual_BS[17, bsTime]= (AdaptiveResponse)redCapRecord.bsMilk;
                if(redCapRecord.bsNut != null)serialData.sIndividual_BS[18, bsTime]= (AdaptiveResponse)redCapRecord.bsNut;
                if(redCapRecord.bsNest != null)serialData.sIndividual_BS[19, bsTime]= (AdaptiveResponse)redCapRecord.bsNest;
                if(redCapRecord.bsBook != null)serialData.sIndividual_BS[20, bsTime]= (AdaptiveResponse)redCapRecord.bsBook;
                if(redCapRecord.bsSock != null)serialData.sIndividual_BS[21, bsTime]= (AdaptiveResponse)redCapRecord.bsSock;
                if(redCapRecord.bsBird != null)serialData.sIndividual_BS[22, bsTime]= (AdaptiveResponse)redCapRecord.bsBird;
                if(redCapRecord.bsFox != null)serialData.sIndividual_BS[23, bsTime]= (AdaptiveResponse)redCapRecord.bsFox;
                if(redCapRecord.bsCup != null)serialData.sIndividual_BS[24, bsTime]= (AdaptiveResponse)redCapRecord.bsCup;
                if(redCapRecord.bsPants != null)serialData.sIndividual_BS[25, bsTime]= (AdaptiveResponse)redCapRecord.bsPants;
                if(redCapRecord.bsChalk != null)serialData.sIndividual_BS[26, bsTime]= (AdaptiveResponse)redCapRecord.bsChalk;
                if(redCapRecord.bsNose != null)serialData.sIndividual_BS[27, bsTime]= (AdaptiveResponse)redCapRecord.bsNose;
                if(redCapRecord.bsChin != null)serialData.sIndividual_BS[28, bsTime]= (AdaptiveResponse)redCapRecord.bsChin;
                if(redCapRecord.bsChair != null)serialData.sIndividual_BS[29, bsTime]= (AdaptiveResponse)redCapRecord.bsChair;
                if(redCapRecord.bsLeg != null)serialData.sIndividual_BS[30, bsTime]= (AdaptiveResponse)redCapRecord.bsLeg;
                if(redCapRecord.bsNet != null)serialData.sIndividual_BS[31, bsTime]= (AdaptiveResponse)redCapRecord.bsNet;
                if(redCapRecord.bsFish != null)serialData.sIndividual_BS[32, bsTime]= (AdaptiveResponse)redCapRecord.bsFish;
                if(redCapRecord.bsCat != null)serialData.sIndividual_BS[33, bsTime]= (AdaptiveResponse)redCapRecord.bsCat;
                if(redCapRecord.bsLamp != null)serialData.sIndividual_BS[34, bsTime]= (AdaptiveResponse)redCapRecord.bsLamp;
                if(redCapRecord.bsCheese != null)serialData.sIndividual_BS[35, bsTime]= (AdaptiveResponse)redCapRecord.bsCheese;

                //Now that the scores are out of the way,
                //Let's also store the child responses
                if (redCapRecord.bsResHand != null)
                    serialData.sIndividual_BSChildResponse[0,bsTime] = redCapRecord.bsResHand;
                if (redCapRecord.bsResMoon != null) serialData.sIndividual_BSChildResponse[1, bsTime] = redCapRecord.bsResMoon;
                if (redCapRecord.bsResSun != null) serialData.sIndividual_BSChildResponse[2, bsTime] = redCapRecord.bsResSun;
                if (redCapRecord.bsResDoor != null) serialData.sIndividual_BSChildResponse[3, bsTime] = redCapRecord.bsResDoor;
                if (redCapRecord.bsResMouse != null) serialData.sIndividual_BSChildResponse[4, bsTime] = redCapRecord.bsResMouse;
                if (redCapRecord.bsResCar != null) serialData.sIndividual_BSChildResponse[5, bsTime] = redCapRecord.bsResCar;
                if (redCapRecord.bsResFan != null) serialData.sIndividual_BSChildResponse[6, bsTime] = redCapRecord.bsResFan;
                if (redCapRecord.bsResPot != null) serialData.sIndividual_BSChildResponse[7, bsTime] = redCapRecord.bsResPot;
                if (redCapRecord.bsResHat != null) serialData.sIndividual_BSChildResponse[8, bsTime] = redCapRecord.bsResHat;
                if (redCapRecord.bsResBall != null) serialData.sIndividual_BSChildResponse[9, bsTime] = redCapRecord.bsResBall;
                if (redCapRecord.bsResDuck != null) serialData.sIndividual_BSChildResponse[10, bsTime] = redCapRecord.bsResDuck;
                if (redCapRecord.bsResVan != null) serialData.sIndividual_BSChildResponse[11, bsTime] = redCapRecord.bsResVan;
                if (redCapRecord.bsResDog != null) serialData.sIndividual_BSChildResponse[12, bsTime] = redCapRecord.bsResDog;
                if (redCapRecord.bsResCake != null) serialData.sIndividual_BSChildResponse[13, bsTime] = redCapRecord.bsResCake;
                if (redCapRecord.bsResLeaf != null) serialData.sIndividual_BSChildResponse[14, bsTime] = redCapRecord.bsResLeaf;
                if (redCapRecord.bsResHeart != null) serialData.sIndividual_BSChildResponse[15, bsTime] = redCapRecord.bsResHeart;
                if (redCapRecord.bsResFour != null) serialData.sIndividual_BSChildResponse[16, bsTime] = redCapRecord.bsResFour;
                if (redCapRecord.bsResMilk != null) serialData.sIndividual_BSChildResponse[17, bsTime] = redCapRecord.bsResMilk;
                if (redCapRecord.bsResNut != null) serialData.sIndividual_BSChildResponse[18, bsTime] = redCapRecord.bsResNut;
                if (redCapRecord.bsResNest != null) serialData.sIndividual_BSChildResponse[19, bsTime] = redCapRecord.bsResNest;
                if (redCapRecord.bsResBook != null) serialData.sIndividual_BSChildResponse[20, bsTime] = redCapRecord.bsResBook;
                if (redCapRecord.bsResSock != null) serialData.sIndividual_BSChildResponse[21, bsTime] = redCapRecord.bsResSock;
                if (redCapRecord.bsResBird != null) serialData.sIndividual_BSChildResponse[22, bsTime] = redCapRecord.bsResBird;
                if (redCapRecord.bsResFox != null) serialData.sIndividual_BSChildResponse[23, bsTime] = redCapRecord.bsResFox;
                if (redCapRecord.bsResCup != null) serialData.sIndividual_BSChildResponse[24, bsTime] = redCapRecord.bsResCup;
                if (redCapRecord.bsResPants != null) serialData.sIndividual_BSChildResponse[25, bsTime] = redCapRecord.bsResPants;
                if (redCapRecord.bsResChalk != null) serialData.sIndividual_BSChildResponse[26, bsTime] = redCapRecord.bsResChalk;
                if (redCapRecord.bsResNose != null) serialData.sIndividual_BSChildResponse[27, bsTime] = redCapRecord.bsResNose;
                if (redCapRecord.bsResChin != null) serialData.sIndividual_BSChildResponse[28, bsTime] = redCapRecord.bsResChin;
                if (redCapRecord.bsResChair != null) serialData.sIndividual_BSChildResponse[29, bsTime] = redCapRecord.bsResChair;
                if (redCapRecord.bsResLeg != null) serialData.sIndividual_BSChildResponse[30, bsTime] = redCapRecord.bsResLeg;
                if (redCapRecord.bsResNet != null) serialData.sIndividual_BSChildResponse[31, bsTime] = redCapRecord.bsResNet;
                if (redCapRecord.bsResFish != null) serialData.sIndividual_BSChildResponse[32, bsTime] = redCapRecord.bsResFish;
                if (redCapRecord.bsResCat != null) serialData.sIndividual_BSChildResponse[33, bsTime] = redCapRecord.bsResCat;
                if (redCapRecord.bsResLamp != null) serialData.sIndividual_BSChildResponse[34, bsTime] = redCapRecord.bsResLamp;
                if (redCapRecord.bsResCheese != null) serialData.sIndividual_BSChildResponse[35, bsTime] = redCapRecord.bsResCheese;

                while (assessors_bs_list.Count < redCapRecord.bsSessionNumber)
                    assessors_bs_list.Add(sessionAssesorIdResponseBs);
                
                while (classrooms_bs_list.Count < redCapRecord.bsSessionNumber)
                    classrooms_bs_list.Add(sessionClassroomIdResponseBs);

                while (teachers_bs_list.Count < redCapRecord.bsSessionNumber)
                    teachers_bs_list.Add(sessionTeacherIdResponseBs);

                while (assessors_name_bs_list.Count < redCapRecord.bsSessionNumber)
                    assessors_name_bs_list.Add(sessionAssesorNameResponseBs);
                
                while (classrooms_name_bs_list.Count < redCapRecord.bsSessionNumber)
                    classrooms_name_bs_list.Add(sessionClassroomNameResponseBs);

                while (teachers_name_bs_list.Count < redCapRecord.bsSessionNumber)
                    teachers_name_bs_list.Add(sessionTeacherNameResponseBs);

                serialData.sCompleteBS[redCapRecord.bsSessionNumber.Value - 1] = redCapRecord.beginningSoundsComplete.Value;
                serialData.sDateTimeFieldBS[redCapRecord.bsSessionNumber.Value - 1] = redCapRecord.bsDateTimeField.ToString();
            }

            //serialData.final_CAPscores = new Tuple<double, double>[6];
            //serialData.sIndividual_CAP = new AdaptiveResponse[13, 6];
            if (redCapRecord.CAPSessionNumber != null && redCapRecord.CAPSessionNumber != 0)
            {
                int CAPTime = (int)redCapRecord.CAPSessionNumber - 1; //offset for zero array
                String sessionAssesorIdResponseCAP = "";
                String sessionClassroomIdResponseCAP = "";
                String sessionTeacherIdResponseCAP = "";
                String sessionAssesorNameResponseCAP = "";
                String sessionClassroomNameResponseCAP = "";
                String sessionTeacherNameResponseCAP = "";
                if (redCapRecord.CAPEAP != null && redCapRecord.CAPStdError != null)
                {
                    serialData.final_CAPscores[CAPTime] = new Tuple<double, double>((double)redCapRecord.CAPEAP, (double)redCapRecord.CAPStdError);
                }

                if (redCapRecord.CAPQs1result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion1))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion1]),
                        CAPTime] = redCapRecord.CAPQs1result == 1?AdaptiveResponse.Correct:AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs2result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion2))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion2]),
                        CAPTime] = redCapRecord.CAPQs2result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs3result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion3))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion3]),
                        CAPTime] = redCapRecord.CAPQs3result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs4result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion4))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion4]),
                        CAPTime] = redCapRecord.CAPQs4result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs5result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion5))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion5]),
                        CAPTime] = redCapRecord.CAPQs5result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs6result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion6))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion6]),
                        CAPTime] = redCapRecord.CAPQs6result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs7result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion7))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion7]),
                        CAPTime] = redCapRecord.CAPQs7result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs8result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion8))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion8]),
                        CAPTime] = redCapRecord.CAPQs8result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs9result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion9))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion9]),
                        CAPTime] = redCapRecord.CAPQs9result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs10result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion10))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion10]),
                        CAPTime] = redCapRecord.CAPQs10result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs11result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion11))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion11]),
                        CAPTime] = redCapRecord.CAPQs11result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs12result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion12))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion12]),
                        CAPTime] = redCapRecord.CAPQs12result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                        

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdCAP))
                    sessionAssesorIdResponseCAP = redCapRecord.assessorIdCAP;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdCAP))
                    sessionClassroomIdResponseCAP = redCapRecord.classroomIdCAP;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdCAP))
                    sessionTeacherIdResponseCAP = redCapRecord.teacherIdCAP;

                if (!string.IsNullOrEmpty(redCapRecord.assessorNameCAP))
                    sessionAssesorNameResponseCAP = redCapRecord.assessorNameCAP;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameCAP))
                    sessionClassroomNameResponseCAP = redCapRecord.classroomNameCAP;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameCAP))
                    sessionTeacherNameResponseCAP = redCapRecord.teacherNameCAP;

                
                while (assessors_CAP_list.Count < redCapRecord.CAPSessionNumber)
                    assessors_CAP_list.Add(sessionAssesorIdResponseCAP);

                while (classrooms_CAP_list.Count < redCapRecord.CAPSessionNumber)
                    classrooms_CAP_list.Add(sessionClassroomIdResponseCAP);

                while (teachers_CAP_list.Count < redCapRecord.CAPSessionNumber)
                    teachers_CAP_list.Add(sessionTeacherIdResponseCAP);

                while (assessors_name_CAP_list.Count < redCapRecord.CAPSessionNumber)
                    assessors_name_CAP_list.Add(sessionAssesorNameResponseCAP);

                while (classrooms_name_CAP_list.Count < redCapRecord.CAPSessionNumber)
                    classrooms_name_CAP_list.Add(sessionClassroomNameResponseCAP);

                while (teachers_name_CAP_list.Count < redCapRecord.CAPSessionNumber)
                    teachers_name_CAP_list.Add(sessionTeacherNameResponseCAP);

                serialData.sCompleteCAP[redCapRecord.CAPSessionNumber.Value - 1] = redCapRecord.CAPComplete.Value;
                serialData.sDateTimeFieldCAP[redCapRecord.CAPSessionNumber.Value - 1] = redCapRecord.capDateTimeField.ToString();
            }
    }

        serialData.sIndividualExpressiveList = expressiveList;
        serialData.sIndividualExpressiveFlagList = expressiveFlagList;
        serialData.sIndividualReceptiveList = receptiveList;
        serialData.sIndividualReceptiveFlagList = receptiveFlagList;
        serialData.sIndividualResponses = individualResponses;
        serialData.sIndividualCSResponseList = csResponseList;
        serialData.sIndividualWritingScoreList = writingScoreList;
        serialData.sIndividualWritingImageList = imageDataList;
        serialData.sIndividualSRResponseList = srResponseList;
        serialData.sIndividualSRQuestionsList = srQuestionsList;

        serialData.sAssessorIdVocabList = assessors_vocab_list;
        serialData.sClassroomIdVocabList = classrooms_vocab_list;
        serialData.sTeacherIdVocabList = teachers_vocab_list;
        serialData.sAssessorNameVocabList = assessors_name_vocab_list;
        serialData.sClassroomNameVocabList = classrooms_name_vocab_list;
        serialData.sTeacherNameVocabList = teachers_name_vocab_list;

        serialData.sAssessorIdBsList = assessors_bs_list;
        serialData.sClassroomIdBsList = classrooms_bs_list;
        serialData.sTeacherIdBsList = teachers_bs_list;
        serialData.sAssessorNameBsList = assessors_name_bs_list;
        serialData.sClassroomNameBsList = classrooms_name_bs_list;
        serialData.sTeacherNameBsList = teachers_name_bs_list;

        serialData.sAssessorIdCAPList = assessors_CAP_list;
        serialData.sClassroomIdCAPList = classrooms_CAP_list;
        serialData.sTeacherIdCAPList = teachers_CAP_list;
        serialData.sAssessorNameCAPList = assessors_name_CAP_list;
        serialData.sClassroomNameCAPList = classrooms_name_CAP_list;
        serialData.sTeacherNameCAPList = teachers_name_CAP_list;

        serialData.sAssessorIdLniList = assessors_lni_list;
        serialData.sClassroomIdLniList = classrooms_lni_list;
        serialData.sTeacherIdLniList = teachers_lni_list;
        serialData.sAssessorNameLniList = assessors_name_lni_list;
        serialData.sClassroomNameLniList = classrooms_name_lni_list;
        serialData.sTeacherNameLniList = teachers_name_lni_list;

        serialData.sAssessorIdLsiList = assessors_lsi_list;
        serialData.sClassroomIdLsiList = classrooms_lsi_list;
        serialData.sTeacherIdLsiList = teachers_lsi_list;
        serialData.sAssessorNameLsiList = assessors_name_lsi_list;
        serialData.sClassroomNameLsiList = classrooms_name_lsi_list;
        serialData.sTeacherNameLsiList = teachers_name_lsi_list;

        serialData.sAssessorIdCSList = assessors_cs_list;
        serialData.sClassroomIdCSList = classrooms_cs_list;
        serialData.sTeacherIdCSList = teachers_cs_list;
        serialData.sAssessorNameCSList = assessors_name_cs_list;
        serialData.sClassroomNameCSList = classrooms_name_cs_list;
        serialData.sTeacherNameCSList = teachers_name_cs_list;

        serialData.sAssessorIdWritingList = assessors_writing_list;
        serialData.sClassroomIdWritingList = classrooms_writing_list;
        serialData.sTeacherIdWritingList = teachers_writing_list;
        serialData.sAssessorNameWritingList = assessors_name_writing_list;
        serialData.sClassroomNameWritingList = classrooms_name_writing_list;
        serialData.sTeacherNameWritingList = teachers_name_writing_list;

        serialData.sAssessorIdSRList = assessors_sr_list;
        serialData.sClassroomIdSRList = classrooms_sr_list;
        serialData.sTeacherIdSRList = teachers_sr_list;
        serialData.sAssessorNameSRList = assessors_name_sr_list;
        serialData.sClassroomNameSRList = classrooms_name_sr_list;
        serialData.sTeacherNameSRList = teachers_name_sr_list;

        serialData.sAssessorIdBookSumList = assessors_booksum_list;
        serialData.sClassroomIdBookSumList = classrooms_booksum_list;
        serialData.sTeacherIdBookSumList = teachers_booksum_list;
        serialData.sAssessorNameBookSumList = assessors_name_booksum_list;
        serialData.sClassroomNameBookSumList = classrooms_name_booksum_list;
        serialData.sTeacherNameBookSumList = teachers_name_booksum_list;

        serialData.sIndividualBookSumResponseList = booksumResponseList;
        serialData.sIndividualBookSumQuestionsList = booksumQuestionsList;
        serialData.sIndividualBookSumChildResponseList = booksumChildResponseList;

        return serialData;
    }


    public static SerialData convertToSerialDataCompareWithFile(UsersDetails usersDetails, SerialData serialData)
    {                                                                                                                                        // List<int> writingSentenceScoreList = new List<int>(){Capacity = 6};;

        foreach (var redCapRecord in usersDetails.users)
        {
            if (redCapRecord.recordID != null && redCapRecord.recordID != 0)
                serialData.sRecordId = redCapRecord.recordID.ToString();

            // Responsible for storing vocab related data
            if (redCapRecord.vocabSession != null && redCapRecord.vocabSession != 0 && redCapRecord.vocabDateTimeField != null && 
                serialData.sVocabDateTimeField[redCapRecord.vocabSession.Value - 1].CompareTo(redCapRecord.vocabDateTimeField)<0)
            {
                List<bool> sessionExpressiveList = new List<bool> { false, false, false, false, false, false };
                List<bool> sessionExpressiveFlagList = new List<bool> { false, false, false, false, false, false };
                List<bool> sessionReceptiveList = new List<bool> { false, false, false, false, false, false };
                List<bool> sessionReceptiveFlagList = new List<bool> { false, false, false, false, false, false };
                List<string> sessionIndividualResponses = new List<string> { "", "", "", "", "", "" };
                String sessionAssesorIdResponse = "";
                String sessionClassroomIdResponse = "";
                String sessionTeacherIdResponse = "";
                String sessionAssesorNameResponse = "";
                String sessionClassroomNameResponse = "";
                String sessionTeacherNameResponse = "";
                if (serialData.sGradeVocabExp == null)
                    serialData.sGradeVocabExp = new double[6] { -1, -1, -1, -1, -1, -1 };
                if (serialData.sGradeVocabRec == null)
                    serialData.sGradeVocabRec = new double[6] { -1, -1, -1, -1, -1, -1 };
                if (serialData.sGradeVocabTotal == null)
                    serialData.sGradeVocabTotal = new double[6] { -1, -1, -1, -1, -1, -1 };

                if (redCapRecord.q1Expressive != null)
                    sessionExpressiveList[0] = getTrueFalse(redCapRecord.q1Expressive);
                if (redCapRecord.q2Expressive != null)
                    sessionExpressiveList[1] = getTrueFalse(redCapRecord.q2Expressive);
                if (redCapRecord.q3Expressive != null)
                    sessionExpressiveList[2] = getTrueFalse(redCapRecord.q3Expressive);
                if (redCapRecord.q4Expressive != null)
                    sessionExpressiveList[3] = getTrueFalse(redCapRecord.q4Expressive);
                if (redCapRecord.q5Expressive != null)
                    sessionExpressiveList[4] = getTrueFalse(redCapRecord.q5Expressive);
                if (redCapRecord.q6Expressive != null)
                    sessionExpressiveList[5] = getTrueFalse(redCapRecord.q6Expressive);

                if (redCapRecord.q1Receptive != null)
                    sessionReceptiveList[0] = getTrueFalse(redCapRecord.q1Receptive);
                if (redCapRecord.q2Receptive != null)
                    sessionReceptiveList[1] = getTrueFalse(redCapRecord.q2Receptive);
                if (redCapRecord.q3Receptive != null)
                    sessionReceptiveList[2] = getTrueFalse(redCapRecord.q3Receptive);
                if (redCapRecord.q4Receptive != null)
                    sessionReceptiveList[3] = getTrueFalse(redCapRecord.q4Receptive);
                if (redCapRecord.q5Receptive != null)
                    sessionReceptiveList[4] = getTrueFalse(redCapRecord.q5Receptive);
                if (redCapRecord.q6Receptive != null)
                    sessionReceptiveList[5] = getTrueFalse(redCapRecord.q6Receptive);

                if (redCapRecord.q1ExpressiveFlag != null)
                    sessionExpressiveFlagList[0] = getTrueFalse(redCapRecord.q1ExpressiveFlag);
                if (redCapRecord.q2ExpressiveFlag != null)
                    sessionExpressiveFlagList[1] = getTrueFalse(redCapRecord.q2ExpressiveFlag);
                if (redCapRecord.q3ExpressiveFlag != null)
                    sessionExpressiveFlagList[2] = getTrueFalse(redCapRecord.q3ExpressiveFlag);
                if (redCapRecord.q4ExpressiveFlag != null)
                    sessionExpressiveFlagList[3] = getTrueFalse(redCapRecord.q4ExpressiveFlag);
                if (redCapRecord.q5ExpressiveFlag != null)
                    sessionExpressiveFlagList[4] = getTrueFalse(redCapRecord.q5ExpressiveFlag);
                if (redCapRecord.q6ExpressiveFlag != null)
                    sessionExpressiveFlagList[5] = getTrueFalse(redCapRecord.q6ExpressiveFlag);

                if (redCapRecord.q1ReceptiveFlag != null)
                    sessionReceptiveFlagList[0] = getTrueFalse(redCapRecord.q1ReceptiveFlag);
                if (redCapRecord.q2ReceptiveFlag != null)
                    sessionReceptiveFlagList[1] = getTrueFalse(redCapRecord.q2ReceptiveFlag);
                if (redCapRecord.q3ReceptiveFlag != null)
                    sessionReceptiveFlagList[2] = getTrueFalse(redCapRecord.q3ReceptiveFlag);
                if (redCapRecord.q4ReceptiveFlag != null)
                    sessionReceptiveFlagList[3] = getTrueFalse(redCapRecord.q4ReceptiveFlag);
                if (redCapRecord.q5ReceptiveFlag != null)
                    sessionReceptiveFlagList[4] = getTrueFalse(redCapRecord.q5ReceptiveFlag);
                if (redCapRecord.q6ReceptiveFlag != null)
                    sessionReceptiveFlagList[5] = getTrueFalse(redCapRecord.q6ReceptiveFlag);

                if (!string.IsNullOrEmpty(redCapRecord.q1Solution))
                    sessionIndividualResponses[0] = redCapRecord.q1Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q2Solution))
                    sessionIndividualResponses[1] = redCapRecord.q2Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q3Solution))
                    sessionIndividualResponses[2] = redCapRecord.q3Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q4Solution))
                    sessionIndividualResponses[3] = redCapRecord.q4Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q5Solution))
                    sessionIndividualResponses[4] = redCapRecord.q5Solution;
                if (!string.IsNullOrEmpty(redCapRecord.q6Solution))
                    sessionIndividualResponses[5] = redCapRecord.q6Solution;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdVocab))
                    sessionAssesorIdResponse = redCapRecord.assessorIdVocab;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdVocab))
                    sessionClassroomIdResponse = redCapRecord.classroomIdVocab;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdVocab))
                    sessionTeacherIdResponse = redCapRecord.teacherIdVocab;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameVocab))
                    sessionAssesorNameResponse = redCapRecord.assessorNameVocab;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameVocab))
                    sessionClassroomNameResponse = redCapRecord.classroomNameVocab;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameVocab))
                    sessionTeacherNameResponse = redCapRecord.teacherNameVocab;

                serialData.sIndividualExpressiveList[redCapRecord.vocabSession.Value - 1] = sessionExpressiveList;
                serialData.sIndividualReceptiveList[redCapRecord.vocabSession.Value - 1] = sessionReceptiveList;
                serialData.sIndividualExpressiveFlagList[redCapRecord.vocabSession.Value - 1] = sessionExpressiveFlagList;
                serialData.sIndividualReceptiveFlagList[redCapRecord.vocabSession.Value - 1] = sessionReceptiveFlagList;
                serialData.sIndividualResponses[redCapRecord.vocabSession.Value - 1] = sessionIndividualResponses;
                serialData.sAssessorIdVocabList[redCapRecord.vocabSession.Value - 1] = sessionAssesorIdResponse;
                serialData.sClassroomIdVocabList[redCapRecord.vocabSession.Value - 1] = sessionClassroomIdResponse;
                serialData.sTeacherIdVocabList[redCapRecord.vocabSession.Value - 1] = sessionTeacherIdResponse;
                serialData.sAssessorNameVocabList[redCapRecord.vocabSession.Value - 1] = sessionAssesorNameResponse;
                serialData.sClassroomNameVocabList[redCapRecord.vocabSession.Value - 1] = sessionClassroomNameResponse;
                serialData.sTeacherNameVocabList[redCapRecord.vocabSession.Value - 1] = sessionTeacherNameResponse;


                addExpressiveAndReceptiveScore(sessionExpressiveList,
                                               sessionReceptiveList,
                                               redCapRecord.vocabSession.Value,
                                               serialData);
                serialData.sCompleteVocabulary[redCapRecord.vocabSession.Value - 1] = redCapRecord.vocabularyComplete.Value;
                serialData.sVocabDateTimeField[redCapRecord.vocabSession.Value - 1] = redCapRecord.vocabDateTimeField.ToString();
            }

            // Responsible for storing clapping syllables related data
            if (redCapRecord.csSession != null && redCapRecord.csSession != 0 && serialData.sDateTimeFieldCS[redCapRecord.csSession.Value - 1].CompareTo(redCapRecord.csDateTimeField) < 0)
            {
                List<bool> sessionResponseList = new List<bool> { false, false, false };
                String sessionCSAssesorIdResponse = "";
                String sessionCSClassroomIdResponse = "";
                String sessionCSTeacherIdResponse = "";
                String sessionCSAssesorNameResponse = "";
                String sessionCSClassroomNameResponse = "";
                String sessionCSTeacherNameResponse = "";
                if (serialData.sGradeCSTotal == null)
                    serialData.sGradeCSTotal = new int[6] { -1, -1, -1, -1, -1, -1 };

                if (redCapRecord.popcornResponse != null)
                    sessionResponseList[0] = getTrueFalse(redCapRecord.popcornResponse);
                if (redCapRecord.teacherResponse != null)
                    sessionResponseList[1] = getTrueFalse(redCapRecord.teacherResponse);
                if (redCapRecord.umbrellaResponse != null)
                    sessionResponseList[2] = getTrueFalse(redCapRecord.umbrellaResponse);

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdCS))
                    sessionCSAssesorIdResponse = redCapRecord.assessorIdCS;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdCS))
                    sessionCSClassroomIdResponse = redCapRecord.classroomIdCS;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdCS))
                    sessionCSTeacherIdResponse = redCapRecord.teacherIdCS;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameCS))
                    sessionCSAssesorNameResponse = redCapRecord.assessorNameCS;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameCS))
                    sessionCSClassroomNameResponse = redCapRecord.classroomNameCS;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameCS))
                    sessionCSTeacherNameResponse = redCapRecord.teacherNameCS;

                serialData.sIndividualCSResponseList[redCapRecord.csSession.Value - 1] = sessionResponseList;
                serialData.sAssessorIdCSList[redCapRecord.csSession.Value - 1] = sessionCSAssesorIdResponse;
                serialData.sClassroomIdCSList[redCapRecord.csSession.Value - 1] = sessionCSClassroomIdResponse;
                serialData.sTeacherIdCSList[redCapRecord.csSession.Value - 1] = sessionCSTeacherIdResponse;
                serialData.sAssessorNameCSList[redCapRecord.csSession.Value - 1] = sessionCSAssesorNameResponse;
                serialData.sClassroomNameCSList[redCapRecord.csSession.Value - 1] = sessionCSClassroomNameResponse;
                serialData.sTeacherNameCSList[redCapRecord.csSession.Value - 1] = sessionCSTeacherNameResponse;

                int index = redCapRecord.csSession.Value - 1;
                int score_cs = sessionResponseList.Count(item => item);
                serialData.sGradeCSTotal[index] = score_cs;
                serialData.sCompleteCS[redCapRecord.csSession.Value - 1] = redCapRecord.clappingSyllablesComplete.Value;
                serialData.sDateTimeFieldCS[redCapRecord.csSession.Value - 1] = redCapRecord.csDateTimeField.ToString();
            }

            // Responsible for storing Writing related data
            if (redCapRecord.writingSessionNo != null && redCapRecord.writingSessionNo != 0 && serialData.sDateTimeFieldWriting[redCapRecord.writingSessionNo.Value - 1].CompareTo(redCapRecord.writingDateTimeField) < 0)
            {
                List<int> sessionWiritngScoreList = new List<int> { -999, -999 };

                String sessionWritingAssesorIdResponse = "";
                String sessionWritingClassroomIdResponse = "";
                String sessionWritingTeacherIdResponse = "";
                String sessionWritingAssesorNameResponse = "";
                String sessionWritingClassroomNameResponse = "";
                String sessionWritingTeacherNameResponse = "";

                if (redCapRecord.nameWritingScore != null)
                    sessionWiritngScoreList[0] = (int)redCapRecord.nameWritingScore;
                if (redCapRecord.sentenceWritingScore != null)
                    sessionWiritngScoreList[1] = (int)redCapRecord.sentenceWritingScore;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdWriting))
                    sessionWritingAssesorIdResponse = redCapRecord.assessorIdWriting;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdWriting))
                    sessionWritingClassroomIdResponse = redCapRecord.classroomIdWriting;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdWriting))
                    sessionWritingTeacherIdResponse = redCapRecord.teacherIdWriting;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameWriting))
                    sessionWritingAssesorNameResponse = redCapRecord.assessorNameWriting;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameWriting))
                    sessionWritingClassroomNameResponse = redCapRecord.classroomNameWriting;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameWriting))
                    sessionWritingTeacherNameResponse = redCapRecord.teacherNameWriting;

                serialData.sIndividualWritingScoreList[redCapRecord.writingSessionNo.Value -1] = sessionWiritngScoreList;
                serialData.sAssessorIdWritingList[redCapRecord.writingSessionNo.Value - 1] = sessionWritingAssesorIdResponse;
                serialData.sClassroomIdWritingList[redCapRecord.writingSessionNo.Value - 1] = sessionWritingClassroomIdResponse;
                serialData.sTeacherIdWritingList[redCapRecord.writingSessionNo.Value - 1] = sessionWritingTeacherIdResponse;
                serialData.sAssessorNameWritingList[redCapRecord.writingSessionNo.Value - 1] = sessionWritingAssesorNameResponse;
                serialData.sClassroomNameWritingList[redCapRecord.writingSessionNo.Value - 1] = sessionWritingClassroomNameResponse;
                serialData.sTeacherNameWritingList[redCapRecord.writingSessionNo.Value - 1] = sessionWritingTeacherNameResponse;

                serialData.sCompleteWriting[redCapRecord.writingSessionNo.Value - 1] = redCapRecord.writingComplete.Value;
                serialData.sDateTimeFieldWriting[redCapRecord.writingSessionNo.Value - 1] = redCapRecord.writingDateTimeField.ToString();
            }

            //Populate Story Retell
            //serialData.sGradeSRTotal = new int[3];
            //serialData.sIndividualSRResponseList = new List<List<bool>>();
            //serialData.sIndividualSRQuestionsList = new List<List<string>>();
            // Responsible for storing Story retell syllables related data
            if (redCapRecord.srSession != null && redCapRecord.srSession != 0 && serialData.sDateTimeFieldSR[redCapRecord.srSession.Value - 1].CompareTo(redCapRecord.srDateTimeField) < 0)
            {
                String sessionSRAssesorIdResponse = "";
                String sessionSRClassroomIdResponse = "";
                String sessionSRTeacherIdResponse = "";
                String sessionSRAssesorNameResponse = "";
                String sessionSRClassroomNameResponse = "";
                String sessionSRTeacherNameResponse = "";
                if (redCapRecord.srTotal != null)
                    serialData.sGradeSRTotal[redCapRecord.srSession.Value - 1] = (int)redCapRecord.srTotal;

                List<bool> sessionResultList = new List<bool>{false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false};
                List<string> sessionIndividualQuestions = new List<string> { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };


                if (redCapRecord.srQs1result != null)
                    sessionResultList[0] = getTrueFalse(redCapRecord.srQs1result);
                if (redCapRecord.srQs2result != null)
                    sessionResultList[1] = getTrueFalse(redCapRecord.srQs2result);
                if (redCapRecord.srQs2result != null)
                    sessionResultList[2] = getTrueFalse(redCapRecord.srQs3result);
                if (redCapRecord.srQs4result != null)
                    sessionResultList[3] = getTrueFalse(redCapRecord.srQs4result);
                if (redCapRecord.srQs5result != null)
                    sessionResultList[4] = getTrueFalse(redCapRecord.srQs5result);
                if (redCapRecord.srQs6result != null)
                    sessionResultList[5] = getTrueFalse(redCapRecord.srQs6result);
                if (redCapRecord.srQs7result != null)
                    sessionResultList[6] = getTrueFalse(redCapRecord.srQs7result);
                if (redCapRecord.srQs8result != null)
                    sessionResultList[7] = getTrueFalse(redCapRecord.srQs8result);
                if (redCapRecord.srQs9result != null)
                    sessionResultList[8] = getTrueFalse(redCapRecord.srQs9result);
                if (redCapRecord.srQs10result != null)
                    sessionResultList[9] = getTrueFalse(redCapRecord.srQs10result);
                if (redCapRecord.srQs11result != null)
                    sessionResultList[10] = getTrueFalse(redCapRecord.srQs11result);
                if (redCapRecord.srQs12result != null)
                    sessionResultList[11] = getTrueFalse(redCapRecord.srQs12result);
                if (redCapRecord.srQs13result != null)
                    sessionResultList[12] = getTrueFalse(redCapRecord.srQs13result);
                if (redCapRecord.srQs14result != null)
                    sessionResultList[13] = getTrueFalse(redCapRecord.srQs14result);
                if (redCapRecord.srQs15result != null)
                    sessionResultList[14] = getTrueFalse(redCapRecord.srQs15result);
                if (redCapRecord.srQs16result != null)
                    sessionResultList[15] = getTrueFalse(redCapRecord.srQs16result);

                if (!string.IsNullOrEmpty(redCapRecord.srQuestion1))
                    sessionIndividualQuestions[0] = redCapRecord.srQuestion1;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion2))
                    sessionIndividualQuestions[1] = redCapRecord.srQuestion2;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion3))
                    sessionIndividualQuestions[2] = redCapRecord.srQuestion3;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion4))
                    sessionIndividualQuestions[3] = redCapRecord.srQuestion4;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion5))
                    sessionIndividualQuestions[4] = redCapRecord.srQuestion5;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion6))
                    sessionIndividualQuestions[5] = redCapRecord.srQuestion6;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion7))
                    sessionIndividualQuestions[6] = redCapRecord.srQuestion7;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion8))
                    sessionIndividualQuestions[7] = redCapRecord.srQuestion8;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion9))
                    sessionIndividualQuestions[8] = redCapRecord.srQuestion9;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion10))
                    sessionIndividualQuestions[9] = redCapRecord.srQuestion10;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion11))
                    sessionIndividualQuestions[10] = redCapRecord.srQuestion11;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion12))
                    sessionIndividualQuestions[11] = redCapRecord.srQuestion12;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion13))
                    sessionIndividualQuestions[12] = redCapRecord.srQuestion13;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion14))
                    sessionIndividualQuestions[13] = redCapRecord.srQuestion14;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion15))
                    sessionIndividualQuestions[14] = redCapRecord.srQuestion15;
                if (!string.IsNullOrEmpty(redCapRecord.srQuestion16))
                    sessionIndividualQuestions[15] = redCapRecord.srQuestion16;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdSR))
                    sessionSRAssesorIdResponse = redCapRecord.assessorIdSR;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdCS))
                    sessionSRClassroomIdResponse = redCapRecord.classroomIdSR;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdSR))
                    sessionSRTeacherIdResponse = redCapRecord.teacherIdSR;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameSR))
                    sessionSRAssesorNameResponse = redCapRecord.assessorNameSR;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameSR))
                    sessionSRClassroomNameResponse = redCapRecord.classroomNameSR;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameSR))
                    sessionSRTeacherNameResponse = redCapRecord.teacherNameSR;

                serialData.sIndividualSRResponseList[redCapRecord.srSession.Value - 1] = sessionResultList;
                serialData.sIndividualSRQuestionsList[redCapRecord.srSession.Value - 1] = sessionIndividualQuestions;
                serialData.sAssessorIdSRList[redCapRecord.srSession.Value - 1] = sessionSRAssesorIdResponse;
                serialData.sClassroomIdSRList[redCapRecord.srSession.Value - 1] = sessionSRClassroomIdResponse;
                serialData.sTeacherIdSRList[redCapRecord.srSession.Value - 1] = sessionSRTeacherIdResponse;
                serialData.sAssessorNameSRList[redCapRecord.srSession.Value - 1] = sessionSRAssesorNameResponse;
                serialData.sClassroomNameSRList[redCapRecord.srSession.Value - 1] = sessionSRClassroomNameResponse;
                serialData.sTeacherNameSRList[redCapRecord.srSession.Value - 1] = sessionSRTeacherNameResponse;

                serialData.sCompleteSR[redCapRecord.srSession.Value - 1] = redCapRecord.storyRetellComplete.Value;
                serialData.sDateTimeFieldSR[redCapRecord.srSession.Value - 1] = redCapRecord.srDateTimeField.ToString();

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // while (sGradeSRTotal.Count < redCapRecord.srSession)
                //     serialData.sGradeSRTotal[index] = score_sr;

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // serialData.sGradeSRTotal[index] = score_sr;
            }

            //Populate Book Summary
            //serialData.sGradeBookSumTotal = new int[3];
            //serialData.sIndividualBookSumResponseList = new List<List<bool>>();
            //serialData.sIndividualBookSumQuestionsList = new List<List<string>>();
            // Responsible for storing Story retell syllables related data
            if (redCapRecord.bookSumSession != null && redCapRecord.bookSumSession != 0 && serialData.sDateTimeFieldBookSum[redCapRecord.bookSumSession.Value - 1].CompareTo(redCapRecord.bookSumDateTimeField) < 0)
            {
                String sessionBookSumAssesorIdResponse = "";
                String sessionBookSumClassroomIdResponse = "";
                String sessionBookSumTeacherIdResponse = "";
                String sessionBookSumAssesorNameResponse = "";
                String sessionBookSumClassroomNameResponse = "";
                String sessionBookSumTeacherNameResponse = "";
                if (serialData.sGradeBookSumTotal != null)
                    serialData.sGradeBookSumTotal[redCapRecord.bookSumSession.Value - 1] = (int)redCapRecord.bookSumTotal;

                List<bool> sessionResultList = new List<bool>{false, false, false, false, false, false, false, false,
                false, false, false};
                List<string> sessionIndividualQuestions = new List<string> { "", "", "", "", "", "", "", "", "", "", "" };
                List<string> sessionResponseList = new List<string> { "", "", "", "", "", "", "", "", "", "", "" };


                if (redCapRecord.booksumQs1result != null)
                {
                    sessionResultList[0] = getTrueFalse(redCapRecord.booksumQs1result);
                    sessionResponseList[0] = redCapRecord.booksumQuestion1Response;
                }
                if (redCapRecord.booksumQs2result != null)
                {
                    sessionResultList[1] = getTrueFalse(redCapRecord.booksumQs2result);
                    sessionResponseList[1] = redCapRecord.booksumQuestion2Response;
                }
                if (redCapRecord.booksumQs3result != null)
                {
                    sessionResultList[2] = getTrueFalse(redCapRecord.booksumQs3result);
                    sessionResponseList[2] = redCapRecord.booksumQuestion3Response;
                }
                if (redCapRecord.booksumQs4result != null)
                {
                    sessionResultList[3] = getTrueFalse(redCapRecord.booksumQs4result);
                    sessionResponseList[3] = redCapRecord.booksumQuestion4Response;
                }
                if (redCapRecord.booksumQs5result != null)
                {
                    sessionResultList[4] = getTrueFalse(redCapRecord.booksumQs5result);
                    sessionResponseList[4] = redCapRecord.booksumQuestion5Response;
                }
                if (redCapRecord.booksumQs6result != null)
                {
                    sessionResultList[5] = getTrueFalse(redCapRecord.booksumQs6result);
                    sessionResponseList[5] = redCapRecord.booksumQuestion6Response;
                }
                if (redCapRecord.booksumQs7result != null)
                {
                    sessionResultList[6] = getTrueFalse(redCapRecord.booksumQs7result);
                    sessionResponseList[6] = redCapRecord.booksumQuestion7Response;
                }
                if (redCapRecord.booksumQs8result != null)
                {
                    sessionResultList[7] = getTrueFalse(redCapRecord.booksumQs8result);
                    sessionResponseList[7] = redCapRecord.booksumQuestion8Response;
                }
                if (redCapRecord.booksumQs9result != null)
                {
                    sessionResultList[8] = getTrueFalse(redCapRecord.booksumQs9result);
                    sessionResponseList[8] = redCapRecord.booksumQuestion9Response;
                }
                if (redCapRecord.booksumQs10result != null)
                {
                    sessionResultList[9] = getTrueFalse(redCapRecord.booksumQs10result);
                    sessionResponseList[9] = redCapRecord.booksumQuestion10Response;
                }
                if (redCapRecord.booksumQs11result != null)
                {
                    sessionResultList[10] = getTrueFalse(redCapRecord.booksumQs11result);
                    sessionResponseList[10] = redCapRecord.booksumQuestion11Response;
                }

                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion1))
                    sessionIndividualQuestions[0] = redCapRecord.booksumQuestion1;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion2))
                    sessionIndividualQuestions[1] = redCapRecord.booksumQuestion2;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion3))
                    sessionIndividualQuestions[2] = redCapRecord.booksumQuestion3;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion4))
                    sessionIndividualQuestions[3] = redCapRecord.booksumQuestion4;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion5))
                    sessionIndividualQuestions[4] = redCapRecord.booksumQuestion5;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion6))
                    sessionIndividualQuestions[5] = redCapRecord.booksumQuestion6;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion7))
                    sessionIndividualQuestions[6] = redCapRecord.booksumQuestion7;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion8))
                    sessionIndividualQuestions[7] = redCapRecord.booksumQuestion8;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion9))
                    sessionIndividualQuestions[8] = redCapRecord.booksumQuestion9;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion10))
                    sessionIndividualQuestions[9] = redCapRecord.booksumQuestion10;
                if (!string.IsNullOrEmpty(redCapRecord.booksumQuestion11))
                    sessionIndividualQuestions[10] = redCapRecord.booksumQuestion11;

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdBookSum))
                    sessionBookSumAssesorIdResponse = redCapRecord.assessorIdBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdBookSum))
                    sessionBookSumClassroomIdResponse = redCapRecord.classroomIdBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdBookSum))
                    sessionBookSumTeacherIdResponse = redCapRecord.teacherIdBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameSR))
                    sessionBookSumAssesorNameResponse = redCapRecord.assessorNameBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameBookSum))
                    sessionBookSumClassroomNameResponse = redCapRecord.classroomNameBookSum;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameBookSum))
                    sessionBookSumTeacherNameResponse = redCapRecord.teacherNameBookSum;

                serialData.sIndividualBookSumResponseList[redCapRecord.bookSumSession.Value - 1] = sessionResultList;
                serialData.sIndividualBookSumQuestionsList[redCapRecord.bookSumSession.Value - 1] = sessionIndividualQuestions;
                serialData.sIndividualBookSumChildResponseList[redCapRecord.bookSumSession.Value - 1] = sessionResponseList;
                serialData.sAssessorIdBookSumList[redCapRecord.bookSumSession.Value - 1] = sessionBookSumAssesorIdResponse;
                serialData.sClassroomIdBookSumList[redCapRecord.bookSumSession.Value - 1] = sessionBookSumClassroomIdResponse;
                serialData.sTeacherIdBookSumList[redCapRecord.bookSumSession.Value - 1] = sessionBookSumTeacherIdResponse;
                serialData.sAssessorNameBookSumList[redCapRecord.bookSumSession.Value - 1] = sessionBookSumAssesorNameResponse;
                serialData.sClassroomNameBookSumList[redCapRecord.bookSumSession.Value - 1] = sessionBookSumClassroomNameResponse;
                serialData.sTeacherNameBookSumList[redCapRecord.bookSumSession.Value - 1] = sessionBookSumTeacherNameResponse;

                serialData.sCompleteBookSum[redCapRecord.bookSumSession.Value - 1] = redCapRecord.bookSummaryComplete.Value;
                serialData.sDateTimeFieldBookSum[redCapRecord.bookSumSession.Value - 1] = redCapRecord.bookSumDateTimeField;

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // while (sGradeSRTotal.Count < redCapRecord.srSession)
                //     serialData.sGradeSRTotal[index] = score_sr;

                // int index = redCapRecord.srSession.Value - 1;
                // int score_sr = sessionResultList.Count(item => item);
                // if(sessionResultList.Count==8){
                //     score_sr = score_sr +8;
                // }
                // serialData.sGradeSRTotal[index] = score_sr;
            }

            //Populate sLearnedLetterNames
            //serialData.sLearnedLetterNamesLNI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
            //    false, false, false, false, false, false, false, false, false, false, false, false, false};
            /*
            if (redCapRecord.LNI_A != null)
                serialData.sLearnedLetterNamesLNI[0] = getTrueFalse(redCapRecord.LNI_A);
            if (redCapRecord.LNI_B != null)
                serialData.sLearnedLetterNamesLNI[1] = getTrueFalse(redCapRecord.LNI_B);
            if (redCapRecord.LNI_C != null)
                serialData.sLearnedLetterNamesLNI[2] = getTrueFalse(redCapRecord.LNI_C);
            if (redCapRecord.LNI_D != null)
                serialData.sLearnedLetterNamesLNI[3] = getTrueFalse(redCapRecord.LNI_D);
            if (redCapRecord.LNI_E != null)
                serialData.sLearnedLetterNamesLNI[4] = getTrueFalse(redCapRecord.LNI_E);
            if (redCapRecord.LNI_F != null)
                serialData.sLearnedLetterNamesLNI[5] = getTrueFalse(redCapRecord.LNI_F);
            if (redCapRecord.LNI_G != null)
                serialData.sLearnedLetterNamesLNI[6] = getTrueFalse(redCapRecord.LNI_G);
            if (redCapRecord.LNI_H != null)
                serialData.sLearnedLetterNamesLNI[7] = getTrueFalse(redCapRecord.LNI_H);
            if (redCapRecord.LNI_I != null)
                serialData.sLearnedLetterNamesLNI[8] = getTrueFalse(redCapRecord.LNI_I);
            if (redCapRecord.LNI_J != null)
                serialData.sLearnedLetterNamesLNI[9] = getTrueFalse(redCapRecord.LNI_J);
            if (redCapRecord.LNI_K != null)
                serialData.sLearnedLetterNamesLNI[10] = getTrueFalse(redCapRecord.LNI_K);
            if (redCapRecord.LNI_L != null)
                serialData.sLearnedLetterNamesLNI[11] = getTrueFalse(redCapRecord.LNI_L);
            if (redCapRecord.LNI_M != null)
                serialData.sLearnedLetterNamesLNI[12] = getTrueFalse(redCapRecord.LNI_M);
            if (redCapRecord.LNI_N != null)
                serialData.sLearnedLetterNamesLNI[13] = getTrueFalse(redCapRecord.LNI_N);
            if (redCapRecord.LNI_O != null)
                serialData.sLearnedLetterNamesLNI[14] = getTrueFalse(redCapRecord.LNI_O);
            if (redCapRecord.LNI_P != null)
                serialData.sLearnedLetterNamesLNI[15] = getTrueFalse(redCapRecord.LNI_P);
            if (redCapRecord.LNI_Q != null)
                serialData.sLearnedLetterNamesLNI[16] = getTrueFalse(redCapRecord.LNI_Q);
            if (redCapRecord.LNI_R != null)
                serialData.sLearnedLetterNamesLNI[17] = getTrueFalse(redCapRecord.LNI_R);
            if (redCapRecord.LNI_S != null)
                serialData.sLearnedLetterNamesLNI[18] = getTrueFalse(redCapRecord.LNI_S);
            if (redCapRecord.LNI_T != null)
                serialData.sLearnedLetterNamesLNI[19] = getTrueFalse(redCapRecord.LNI_T);
            if (redCapRecord.LNI_U != null)
                serialData.sLearnedLetterNamesLNI[20] = getTrueFalse(redCapRecord.LNI_U);
            if (redCapRecord.LNI_V != null)
                serialData.sLearnedLetterNamesLNI[21] = getTrueFalse(redCapRecord.LNI_V);
            if (redCapRecord.LNI_W != null)
                serialData.sLearnedLetterNamesLNI[22] = getTrueFalse(redCapRecord.LNI_W);
            if (redCapRecord.LNI_X != null)
                serialData.sLearnedLetterNamesLNI[23] = getTrueFalse(redCapRecord.LNI_X);
            if (redCapRecord.LNI_Y != null)
                serialData.sLearnedLetterNamesLNI[24] = getTrueFalse(redCapRecord.LNI_Y);
            if (redCapRecord.LNI_Z != null)
                serialData.sLearnedLetterNamesLNI[25] = getTrueFalse(redCapRecord.LNI_Z);
            */

            //Populate sIndividual_LNI
            //serialData.sIndividual_LNI = new AdaptiveResponse[26,6];
            if (redCapRecord.lnirSessionNumber != null && redCapRecord.lnirSessionNumber != 0 && serialData.sDateTimeFieldLNI[redCapRecord.lnirSessionNumber.Value - 1].CompareTo(redCapRecord.lniDateTimeField) < 0)
            {
                int lniTime = (int)redCapRecord.lnirSessionNumber - 1;

                String sessionAssesorIdResponseLni = "";
                String sessionClassroomIdResponseLni = "";
                String sessionTeacherIdResponseLni = "";
                String sessionAssesorNameResponseLni = "";
                String sessionClassroomNameResponseLni = "";
                String sessionTeacherNameResponseLni = "";

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdLni))
                    sessionAssesorIdResponseLni = redCapRecord.assessorIdLni;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdLni))
                    sessionClassroomIdResponseLni = redCapRecord.classroomIdLni;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdLni))
                    sessionTeacherIdResponseLni = redCapRecord.teacherIdLni;

                if (!string.IsNullOrEmpty(redCapRecord.assessorNameLni))
                    sessionAssesorNameResponseLni = redCapRecord.assessorNameLni;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameLni))
                    sessionClassroomNameResponseLni = redCapRecord.classroomNameLni;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameLni))
                    sessionTeacherNameResponseLni = redCapRecord.teacherNameLni;

                if (redCapRecord.rLNI_A != null)
                    serialData.sIndividual_LNI[0, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_A;
                if (redCapRecord.rLNI_B != null)
                    serialData.sIndividual_LNI[1, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_B;
                if (redCapRecord.rLNI_C != null)
                    serialData.sIndividual_LNI[2, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_C;
                if (redCapRecord.rLNI_D != null)
                    serialData.sIndividual_LNI[3, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_D;
                if (redCapRecord.rLNI_E != null)
                    serialData.sIndividual_LNI[4, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_E;
                if (redCapRecord.rLNI_F != null)
                    serialData.sIndividual_LNI[5, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_F;
                if (redCapRecord.rLNI_G != null)
                    serialData.sIndividual_LNI[6, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_G;
                if (redCapRecord.rLNI_H != null)
                    serialData.sIndividual_LNI[7, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_H;
                if (redCapRecord.rLNI_I != null)
                    serialData.sIndividual_LNI[8, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_I;
                if (redCapRecord.rLNI_J != null)
                    serialData.sIndividual_LNI[9, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_J;
                if (redCapRecord.rLNI_K != null)
                    serialData.sIndividual_LNI[10, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_K;
                if (redCapRecord.rLNI_L != null)
                    serialData.sIndividual_LNI[11, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_L;
                if (redCapRecord.rLNI_M != null)
                    serialData.sIndividual_LNI[12, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_M;
                if (redCapRecord.rLNI_N != null)
                    serialData.sIndividual_LNI[13, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_N;
                if (redCapRecord.rLNI_O != null)
                    serialData.sIndividual_LNI[14, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_O;
                if (redCapRecord.rLNI_P != null)
                    serialData.sIndividual_LNI[15, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_P;
                if (redCapRecord.rLNI_Q != null)
                    serialData.sIndividual_LNI[16, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_Q;
                if (redCapRecord.rLNI_R != null)
                    serialData.sIndividual_LNI[17, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_R;
                if (redCapRecord.rLNI_S != null)
                    serialData.sIndividual_LNI[18, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_S;
                if (redCapRecord.rLNI_T != null)
                    serialData.sIndividual_LNI[19, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_T;
                if (redCapRecord.rLNI_U != null)
                    serialData.sIndividual_LNI[20, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_U;
                if (redCapRecord.rLNI_V != null)
                    serialData.sIndividual_LNI[21, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_V;
                if (redCapRecord.rLNI_W != null)
                    serialData.sIndividual_LNI[22, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_W;
                if (redCapRecord.rLNI_X != null)
                    serialData.sIndividual_LNI[23, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_X;
                if (redCapRecord.rLNI_Y != null)
                    serialData.sIndividual_LNI[24, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_Y;
                if (redCapRecord.rLNI_Z != null)
                    serialData.sIndividual_LNI[25, lniTime] = (AdaptiveResponse)(int)redCapRecord.rLNI_Z;

                serialData.sAssessorIdLniList[redCapRecord.lnirSessionNumber.Value - 1] = sessionAssesorIdResponseLni;
                serialData.sClassroomIdLniList[redCapRecord.lnirSessionNumber.Value - 1] = sessionClassroomIdResponseLni;
                serialData.sTeacherIdLniList[redCapRecord.lnirSessionNumber.Value - 1] = sessionTeacherIdResponseLni;
                serialData.sAssessorNameLniList[redCapRecord.lnirSessionNumber.Value - 1] = sessionAssesorNameResponseLni;
                serialData.sClassroomNameLniList[redCapRecord.lnirSessionNumber.Value - 1] = sessionClassroomNameResponseLni;
                serialData.sTeacherNameLniList[redCapRecord.lnirSessionNumber.Value - 1] = sessionTeacherNameResponseLni;

                serialData.sCompleteLNI[redCapRecord.lnirSessionNumber.Value - 1] = redCapRecord.LNIResultsComplete.Value;
                serialData.sDateTimeFieldLNI[redCapRecord.lnirSessionNumber.Value - 1] = redCapRecord.lniDateTimeField.ToString();
            }


            //---------

            //Populate sLearnedLetterNames
            //serialData.sLearnedLetterNamesLSI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
            //    false, false, false, false, false, false, false, false, false, false, false, false, false};
            /*
            if (redCapRecord.LSI_A != null)
                serialData.sLearnedLetterNamesLSI[0] = getTrueFalse(redCapRecord.LSI_A);
            if (redCapRecord.LSI_B != null)
                serialData.sLearnedLetterNamesLSI[1] = getTrueFalse(redCapRecord.LSI_B);
            if (redCapRecord.LSI_C != null)
                serialData.sLearnedLetterNamesLSI[2] = getTrueFalse(redCapRecord.LSI_C);
            if (redCapRecord.LSI_D != null)
                serialData.sLearnedLetterNamesLSI[3] = getTrueFalse(redCapRecord.LSI_D);
            if (redCapRecord.LSI_E != null)
                serialData.sLearnedLetterNamesLSI[4] = getTrueFalse(redCapRecord.LSI_E);
            if (redCapRecord.LSI_F != null)
                serialData.sLearnedLetterNamesLSI[5] = getTrueFalse(redCapRecord.LSI_F);
            if (redCapRecord.LSI_G != null)
                serialData.sLearnedLetterNamesLSI[6] = getTrueFalse(redCapRecord.LSI_G);
            if (redCapRecord.LSI_H != null)
                serialData.sLearnedLetterNamesLSI[7] = getTrueFalse(redCapRecord.LSI_H);
            if (redCapRecord.LSI_I != null)
                serialData.sLearnedLetterNamesLSI[8] = getTrueFalse(redCapRecord.LSI_I);
            if (redCapRecord.LSI_J != null)
                serialData.sLearnedLetterNamesLSI[9] = getTrueFalse(redCapRecord.LSI_J);
            if (redCapRecord.LSI_K != null)
                serialData.sLearnedLetterNamesLSI[10] = getTrueFalse(redCapRecord.LSI_K);
            if (redCapRecord.LSI_L != null)
                serialData.sLearnedLetterNamesLSI[11] = getTrueFalse(redCapRecord.LSI_L);
            if (redCapRecord.LSI_M != null)
                serialData.sLearnedLetterNamesLSI[12] = getTrueFalse(redCapRecord.LSI_M);
            if (redCapRecord.LSI_N != null)
                serialData.sLearnedLetterNamesLSI[13] = getTrueFalse(redCapRecord.LSI_N);
            if (redCapRecord.LSI_O != null)
                serialData.sLearnedLetterNamesLSI[14] = getTrueFalse(redCapRecord.LSI_O);
            if (redCapRecord.LSI_P != null)
                serialData.sLearnedLetterNamesLSI[15] = getTrueFalse(redCapRecord.LSI_P);
            if (redCapRecord.LSI_Q != null)
                serialData.sLearnedLetterNamesLSI[16] = getTrueFalse(redCapRecord.LSI_Q);
            if (redCapRecord.LSI_R != null)
                serialData.sLearnedLetterNamesLSI[17] = getTrueFalse(redCapRecord.LSI_R);
            if (redCapRecord.LSI_S != null)
                serialData.sLearnedLetterNamesLSI[18] = getTrueFalse(redCapRecord.LSI_S);
            if (redCapRecord.LSI_T != null)
                serialData.sLearnedLetterNamesLSI[19] = getTrueFalse(redCapRecord.LSI_T);
            if (redCapRecord.LSI_U != null)
                serialData.sLearnedLetterNamesLSI[20] = getTrueFalse(redCapRecord.LSI_U);
            if (redCapRecord.LSI_V != null)
                serialData.sLearnedLetterNamesLSI[21] = getTrueFalse(redCapRecord.LSI_V);
            if (redCapRecord.LSI_W != null)
                serialData.sLearnedLetterNamesLSI[22] = getTrueFalse(redCapRecord.LSI_W);
            if (redCapRecord.LSI_X != null)
                serialData.sLearnedLetterNamesLSI[23] = getTrueFalse(redCapRecord.LSI_X);
            if (redCapRecord.LSI_Y != null)
                serialData.sLearnedLetterNamesLSI[24] = getTrueFalse(redCapRecord.LSI_Y);
            if (redCapRecord.LSI_Z != null)
                serialData.sLearnedLetterNamesLSI[25] = getTrueFalse(redCapRecord.LSI_Z);

            */
            //Populate sIndividual_LSI
            //serialData.sIndividual_LSI = new AdaptiveResponse[26,6];
            if (redCapRecord.lsirSessionNumber != null && redCapRecord.lsirSessionNumber != 0 && serialData.sDateTimeFieldLSI[redCapRecord.lsirSessionNumber.Value - 1].CompareTo(redCapRecord.lsiDateTimeField) < 0)
            {
                int lsiTime = (int)redCapRecord.lsirSessionNumber - 1;

                String sessionAssesorIdResponseLsi = "";
                String sessionClassroomIdResponseLsi = "";
                String sessionTeacherIdResponseLsi = "";
                String sessionAssesorNameResponseLsi = "";
                String sessionClassroomNameResponseLsi = "";
                String sessionTeacherNameResponseLsi = "";
                if (!string.IsNullOrEmpty(redCapRecord.assessorIdLsi))
                    sessionAssesorIdResponseLsi = redCapRecord.assessorIdLsi;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdLsi))
                    sessionClassroomIdResponseLsi = redCapRecord.classroomIdLsi;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdLsi))
                    sessionTeacherIdResponseLsi = redCapRecord.teacherIdLsi;
                if (!string.IsNullOrEmpty(redCapRecord.assessorNameLsi))
                    sessionAssesorNameResponseLsi = redCapRecord.assessorNameLsi;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameLsi))
                    sessionClassroomNameResponseLsi = redCapRecord.classroomNameLsi;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameLsi))
                    sessionTeacherNameResponseLsi = redCapRecord.teacherNameLsi;

                if (redCapRecord.rLSI_A != null)
                    serialData.sIndividual_LSI[0, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_A;
                if (redCapRecord.rLSI_B != null)
                    serialData.sIndividual_LSI[1, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_B;
                if (redCapRecord.rLSI_C != null)
                    serialData.sIndividual_LSI[2, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_C;
                if (redCapRecord.rLSI_D != null)
                    serialData.sIndividual_LSI[3, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_D;
                if (redCapRecord.rLSI_E != null)
                    serialData.sIndividual_LSI[4, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_E;
                if (redCapRecord.rLSI_F != null)
                    serialData.sIndividual_LSI[5, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_F;
                if (redCapRecord.rLSI_G != null)
                    serialData.sIndividual_LSI[6, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_G;
                if (redCapRecord.rLSI_H != null)
                    serialData.sIndividual_LSI[7, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_H;
                if (redCapRecord.rLSI_I != null)
                    serialData.sIndividual_LSI[8, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_I;
                if (redCapRecord.rLSI_J != null)
                    serialData.sIndividual_LSI[9, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_J;
                if (redCapRecord.rLSI_K != null)
                    serialData.sIndividual_LSI[10, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_K;
                if (redCapRecord.rLSI_L != null)
                    serialData.sIndividual_LSI[11, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_L;
                if (redCapRecord.rLSI_M != null)
                    serialData.sIndividual_LSI[12, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_M;
                if (redCapRecord.rLSI_N != null)
                    serialData.sIndividual_LSI[13, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_N;
                if (redCapRecord.rLSI_O != null)
                    serialData.sIndividual_LSI[14, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_O;
                if (redCapRecord.rLSI_P != null)
                    serialData.sIndividual_LSI[15, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_P;
                if (redCapRecord.rLSI_Q != null)
                    serialData.sIndividual_LSI[16, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_Q;
                if (redCapRecord.rLSI_R != null)
                    serialData.sIndividual_LSI[17, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_R;
                if (redCapRecord.rLSI_S != null)
                    serialData.sIndividual_LSI[18, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_S;
                if (redCapRecord.rLSI_T != null)
                    serialData.sIndividual_LSI[19, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_T;
                if (redCapRecord.rLSI_U != null)
                    serialData.sIndividual_LSI[20, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_U;
                if (redCapRecord.rLSI_V != null)
                    serialData.sIndividual_LSI[21, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_V;
                if (redCapRecord.rLSI_W != null)
                    serialData.sIndividual_LSI[22, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_W;
                if (redCapRecord.rLSI_X != null)
                    serialData.sIndividual_LSI[23, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_X;
                if (redCapRecord.rLSI_Y != null)
                    serialData.sIndividual_LSI[24, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_Y;
                if (redCapRecord.rLSI_Z != null)
                    serialData.sIndividual_LSI[25, lsiTime] = (AdaptiveResponse)(int)redCapRecord.rLSI_Z;

                serialData.sAssessorIdLsiList[redCapRecord.lsirSessionNumber.Value - 1] = sessionAssesorIdResponseLsi;
                serialData.sClassroomIdLsiList[redCapRecord.lsirSessionNumber.Value - 1] = sessionClassroomIdResponseLsi;
                serialData.sTeacherIdLsiList[redCapRecord.lsirSessionNumber.Value - 1] = sessionTeacherIdResponseLsi;
                serialData.sAssessorNameLsiList[redCapRecord.lsirSessionNumber.Value - 1] = sessionAssesorNameResponseLsi;
                serialData.sClassroomNameLsiList[redCapRecord.lsirSessionNumber.Value - 1] = sessionClassroomNameResponseLsi;
                serialData.sTeacherNameLsiList[redCapRecord.lsirSessionNumber.Value - 1] = sessionTeacherNameResponseLsi;
                

                serialData.sCompleteLSI[redCapRecord.lsirSessionNumber.Value - 1] = redCapRecord.LSIResultsComplete.Value;
                serialData.sDateTimeFieldLSI[redCapRecord.lsirSessionNumber.Value - 1] = redCapRecord.lsiDateTimeField.ToString();
            }

            //Populate Beginning Sounds
            //serialData.final_BSscores = new Tuple<double, double>[6];
            //serialData.sIndividual_BS = new AdaptiveResponse[36, 6];
            //serialData.sIndividual_BSChildResponse = new string[36, 6];
            if (redCapRecord.bsSessionNumber != null && redCapRecord.bsSessionNumber != 0)
            {
                int bsTime = (int)redCapRecord.bsSessionNumber - 1; //offset for zero array
                String sessionAssesorIdResponseBs = "";
                String sessionClassroomIdResponseBs = "";
                String sessionTeacherIdResponseBs = "";
                String sessionAssesorNameResponseBs = "";
                String sessionClassroomNameResponseBs = "";
                String sessionTeacherNameResponseBs = "";
                if (redCapRecord.bsEAP != null && redCapRecord.bsStdError != null)
                {
                    serialData.final_BSscores[bsTime] = new Tuple<double, double>((double)redCapRecord.bsEAP, (double)redCapRecord.bsStdError);
                }

                if (!string.IsNullOrEmpty(redCapRecord.assessorIdBs))
                    sessionAssesorIdResponseBs = redCapRecord.assessorIdBs;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdBs))
                    sessionClassroomIdResponseBs = redCapRecord.classroomIdBs;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdBs))
                    sessionTeacherIdResponseBs = redCapRecord.teacherIdBs;

                if (!string.IsNullOrEmpty(redCapRecord.assessorNameBs))
                    sessionAssesorNameResponseBs = redCapRecord.assessorNameBs;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameBs))
                    sessionClassroomNameResponseBs = redCapRecord.classroomNameBs;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameBs))
                    sessionTeacherNameResponseBs = redCapRecord.teacherNameBs;

                //store the scores
                //Refer to bs_items.json for reesponse list
                if (redCapRecord.bsHand != null)
                    serialData.sIndividual_BS[0, bsTime] = (AdaptiveResponse)redCapRecord.bsHand;
                if (redCapRecord.bsMoon != null) serialData.sIndividual_BS[1, bsTime] = (AdaptiveResponse)redCapRecord.bsMoon;
                if (redCapRecord.bsSun != null) serialData.sIndividual_BS[2, bsTime] = (AdaptiveResponse)redCapRecord.bsSun;
                if (redCapRecord.bsDoor != null) serialData.sIndividual_BS[3, bsTime] = (AdaptiveResponse)redCapRecord.bsDoor;
                if (redCapRecord.bsMouse != null) serialData.sIndividual_BS[4, bsTime] = (AdaptiveResponse)redCapRecord.bsMouse;
                if (redCapRecord.bsCar != null) serialData.sIndividual_BS[5, bsTime] = (AdaptiveResponse)redCapRecord.bsCar;
                if (redCapRecord.bsFan != null) serialData.sIndividual_BS[6, bsTime] = (AdaptiveResponse)redCapRecord.bsFan;
                if (redCapRecord.bsPot != null) serialData.sIndividual_BS[7, bsTime] = (AdaptiveResponse)redCapRecord.bsPot;
                if (redCapRecord.bsHat != null) serialData.sIndividual_BS[8, bsTime] = (AdaptiveResponse)redCapRecord.bsHat;
                if (redCapRecord.bsBall != null) serialData.sIndividual_BS[9, bsTime] = (AdaptiveResponse)redCapRecord.bsBall;
                if (redCapRecord.bsDuck != null) serialData.sIndividual_BS[10, bsTime] = (AdaptiveResponse)redCapRecord.bsDuck;
                if (redCapRecord.bsVan != null) serialData.sIndividual_BS[11, bsTime] = (AdaptiveResponse)redCapRecord.bsVan;
                if (redCapRecord.bsDog != null) serialData.sIndividual_BS[12, bsTime] = (AdaptiveResponse)redCapRecord.bsDog;
                if (redCapRecord.bsCake != null) serialData.sIndividual_BS[13, bsTime] = (AdaptiveResponse)redCapRecord.bsCake;
                if (redCapRecord.bsLeaf != null) serialData.sIndividual_BS[14, bsTime] = (AdaptiveResponse)redCapRecord.bsLeaf;
                if (redCapRecord.bsHeart != null) serialData.sIndividual_BS[15, bsTime] = (AdaptiveResponse)redCapRecord.bsHeart;
                if (redCapRecord.bsFour != null) serialData.sIndividual_BS[16, bsTime] = (AdaptiveResponse)redCapRecord.bsFour;
                if (redCapRecord.bsMilk != null) serialData.sIndividual_BS[17, bsTime] = (AdaptiveResponse)redCapRecord.bsMilk;
                if (redCapRecord.bsNut != null) serialData.sIndividual_BS[18, bsTime] = (AdaptiveResponse)redCapRecord.bsNut;
                if (redCapRecord.bsNest != null) serialData.sIndividual_BS[19, bsTime] = (AdaptiveResponse)redCapRecord.bsNest;
                if (redCapRecord.bsBook != null) serialData.sIndividual_BS[20, bsTime] = (AdaptiveResponse)redCapRecord.bsBook;
                if (redCapRecord.bsSock != null) serialData.sIndividual_BS[21, bsTime] = (AdaptiveResponse)redCapRecord.bsSock;
                if (redCapRecord.bsBird != null) serialData.sIndividual_BS[22, bsTime] = (AdaptiveResponse)redCapRecord.bsBird;
                if (redCapRecord.bsFox != null) serialData.sIndividual_BS[23, bsTime] = (AdaptiveResponse)redCapRecord.bsFox;
                if (redCapRecord.bsCup != null) serialData.sIndividual_BS[24, bsTime] = (AdaptiveResponse)redCapRecord.bsCup;
                if (redCapRecord.bsPants != null) serialData.sIndividual_BS[25, bsTime] = (AdaptiveResponse)redCapRecord.bsPants;
                if (redCapRecord.bsChalk != null) serialData.sIndividual_BS[26, bsTime] = (AdaptiveResponse)redCapRecord.bsChalk;
                if (redCapRecord.bsNose != null) serialData.sIndividual_BS[27, bsTime] = (AdaptiveResponse)redCapRecord.bsNose;
                if (redCapRecord.bsChin != null) serialData.sIndividual_BS[28, bsTime] = (AdaptiveResponse)redCapRecord.bsChin;
                if (redCapRecord.bsChair != null) serialData.sIndividual_BS[29, bsTime] = (AdaptiveResponse)redCapRecord.bsChair;
                if (redCapRecord.bsLeg != null) serialData.sIndividual_BS[30, bsTime] = (AdaptiveResponse)redCapRecord.bsLeg;
                if (redCapRecord.bsNet != null) serialData.sIndividual_BS[31, bsTime] = (AdaptiveResponse)redCapRecord.bsNet;
                if (redCapRecord.bsFish != null) serialData.sIndividual_BS[32, bsTime] = (AdaptiveResponse)redCapRecord.bsFish;
                if (redCapRecord.bsCat != null) serialData.sIndividual_BS[33, bsTime] = (AdaptiveResponse)redCapRecord.bsCat;
                if (redCapRecord.bsLamp != null) serialData.sIndividual_BS[34, bsTime] = (AdaptiveResponse)redCapRecord.bsLamp;
                if (redCapRecord.bsCheese != null) serialData.sIndividual_BS[35, bsTime] = (AdaptiveResponse)redCapRecord.bsCheese;

                //Now that the scores are out of the way,
                //Let's also store the child responses
                if (redCapRecord.bsResHand != null)
                    serialData.sIndividual_BSChildResponse[0, bsTime] = redCapRecord.bsResHand;
                if (redCapRecord.bsResMoon != null) serialData.sIndividual_BSChildResponse[1, bsTime] = redCapRecord.bsResMoon;
                if (redCapRecord.bsResSun != null) serialData.sIndividual_BSChildResponse[2, bsTime] = redCapRecord.bsResSun;
                if (redCapRecord.bsResDoor != null) serialData.sIndividual_BSChildResponse[3, bsTime] = redCapRecord.bsResDoor;
                if (redCapRecord.bsResMouse != null) serialData.sIndividual_BSChildResponse[4, bsTime] = redCapRecord.bsResMouse;
                if (redCapRecord.bsResCar != null) serialData.sIndividual_BSChildResponse[5, bsTime] = redCapRecord.bsResCar;
                if (redCapRecord.bsResFan != null) serialData.sIndividual_BSChildResponse[6, bsTime] = redCapRecord.bsResFan;
                if (redCapRecord.bsResPot != null) serialData.sIndividual_BSChildResponse[7, bsTime] = redCapRecord.bsResPot;
                if (redCapRecord.bsResHat != null) serialData.sIndividual_BSChildResponse[8, bsTime] = redCapRecord.bsResHat;
                if (redCapRecord.bsResBall != null) serialData.sIndividual_BSChildResponse[9, bsTime] = redCapRecord.bsResBall;
                if (redCapRecord.bsResDuck != null) serialData.sIndividual_BSChildResponse[10, bsTime] = redCapRecord.bsResDuck;
                if (redCapRecord.bsResVan != null) serialData.sIndividual_BSChildResponse[11, bsTime] = redCapRecord.bsResVan;
                if (redCapRecord.bsResDog != null) serialData.sIndividual_BSChildResponse[12, bsTime] = redCapRecord.bsResDog;
                if (redCapRecord.bsResCake != null) serialData.sIndividual_BSChildResponse[13, bsTime] = redCapRecord.bsResCake;
                if (redCapRecord.bsResLeaf != null) serialData.sIndividual_BSChildResponse[14, bsTime] = redCapRecord.bsResLeaf;
                if (redCapRecord.bsResHeart != null) serialData.sIndividual_BSChildResponse[15, bsTime] = redCapRecord.bsResHeart;
                if (redCapRecord.bsResFour != null) serialData.sIndividual_BSChildResponse[16, bsTime] = redCapRecord.bsResFour;
                if (redCapRecord.bsResMilk != null) serialData.sIndividual_BSChildResponse[17, bsTime] = redCapRecord.bsResMilk;
                if (redCapRecord.bsResNut != null) serialData.sIndividual_BSChildResponse[18, bsTime] = redCapRecord.bsResNut;
                if (redCapRecord.bsResNest != null) serialData.sIndividual_BSChildResponse[19, bsTime] = redCapRecord.bsResNest;
                if (redCapRecord.bsResBook != null) serialData.sIndividual_BSChildResponse[20, bsTime] = redCapRecord.bsResBook;
                if (redCapRecord.bsResSock != null) serialData.sIndividual_BSChildResponse[21, bsTime] = redCapRecord.bsResSock;
                if (redCapRecord.bsResBird != null) serialData.sIndividual_BSChildResponse[22, bsTime] = redCapRecord.bsResBird;
                if (redCapRecord.bsResFox != null) serialData.sIndividual_BSChildResponse[23, bsTime] = redCapRecord.bsResFox;
                if (redCapRecord.bsResCup != null) serialData.sIndividual_BSChildResponse[24, bsTime] = redCapRecord.bsResCup;
                if (redCapRecord.bsResPants != null) serialData.sIndividual_BSChildResponse[25, bsTime] = redCapRecord.bsResPants;
                if (redCapRecord.bsResChalk != null) serialData.sIndividual_BSChildResponse[26, bsTime] = redCapRecord.bsResChalk;
                if (redCapRecord.bsResNose != null) serialData.sIndividual_BSChildResponse[27, bsTime] = redCapRecord.bsResNose;
                if (redCapRecord.bsResChin != null) serialData.sIndividual_BSChildResponse[28, bsTime] = redCapRecord.bsResChin;
                if (redCapRecord.bsResChair != null) serialData.sIndividual_BSChildResponse[29, bsTime] = redCapRecord.bsResChair;
                if (redCapRecord.bsResLeg != null) serialData.sIndividual_BSChildResponse[30, bsTime] = redCapRecord.bsResLeg;
                if (redCapRecord.bsResNet != null) serialData.sIndividual_BSChildResponse[31, bsTime] = redCapRecord.bsResNet;
                if (redCapRecord.bsResFish != null) serialData.sIndividual_BSChildResponse[32, bsTime] = redCapRecord.bsResFish;
                if (redCapRecord.bsResCat != null) serialData.sIndividual_BSChildResponse[33, bsTime] = redCapRecord.bsResCat;
                if (redCapRecord.bsResLamp != null) serialData.sIndividual_BSChildResponse[34, bsTime] = redCapRecord.bsResLamp;
                if (redCapRecord.bsResCheese != null) serialData.sIndividual_BSChildResponse[35, bsTime] = redCapRecord.bsResCheese;

                serialData.sAssessorIdBsList[redCapRecord.bsSessionNumber.Value - 1] = sessionAssesorIdResponseBs;
                serialData.sClassroomIdBsList[redCapRecord.bsSessionNumber.Value - 1] = sessionClassroomIdResponseBs;
                serialData.sTeacherIdBsList[redCapRecord.bsSessionNumber.Value - 1] = sessionTeacherIdResponseBs;
                serialData.sAssessorNameBsList[redCapRecord.bsSessionNumber.Value - 1] = sessionAssesorNameResponseBs;
                serialData.sClassroomNameBsList[redCapRecord.bsSessionNumber.Value - 1] = sessionClassroomNameResponseBs;
                serialData.sTeacherNameBsList[redCapRecord.bsSessionNumber.Value - 1] = sessionTeacherNameResponseBs;

                serialData.sCompleteBS[redCapRecord.bsSessionNumber.Value - 1] = redCapRecord.beginningSoundsComplete.Value;
                serialData.sDateTimeFieldBS[redCapRecord.bsSessionNumber.Value - 1] = redCapRecord.bsDateTimeField.ToString();
            }

            //serialData.final_CAPscores = new Tuple<double, double>[6];
            //serialData.sIndividual_CAP = new AdaptiveResponse[13, 6];
            if (redCapRecord.CAPSessionNumber != null && redCapRecord.CAPSessionNumber != 0 && serialData.sDateTimeFieldCAP[redCapRecord.CAPSessionNumber.Value - 1].CompareTo(redCapRecord.capDateTimeField) < 0)
            {
                int CAPTime = (int)redCapRecord.CAPSessionNumber - 1; //offset for zero array
                String sessionAssesorIdResponseCAP = "";
                String sessionClassroomIdResponseCAP = "";
                String sessionTeacherIdResponseCAP = "";
                String sessionAssesorNameResponseCAP = "";
                String sessionClassroomNameResponseCAP = "";
                String sessionTeacherNameResponseCAP = "";
                if (redCapRecord.CAPEAP != null && redCapRecord.CAPStdError != null)
                {
                    serialData.final_CAPscores[CAPTime] = new Tuple<double, double>((double)redCapRecord.CAPEAP, (double)redCapRecord.CAPStdError);
                }

                if (redCapRecord.CAPQs1result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion1))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion1]),
                        CAPTime] = redCapRecord.CAPQs1result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs2result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion2))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion2]),
                        CAPTime] = redCapRecord.CAPQs2result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs3result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion3))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion3]),
                        CAPTime] = redCapRecord.CAPQs3result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs4result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion4))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion4]),
                        CAPTime] = redCapRecord.CAPQs4result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs5result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion5))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion5]),
                        CAPTime] = redCapRecord.CAPQs5result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs6result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion6))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion6]),
                        CAPTime] = redCapRecord.CAPQs6result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs7result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion7))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion7]),
                        CAPTime] = redCapRecord.CAPQs7result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs8result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion8))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion8]),
                        CAPTime] = redCapRecord.CAPQs8result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs9result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion9))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion9]),
                        CAPTime] = redCapRecord.CAPQs9result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs10result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion10))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion10]),
                        CAPTime] = redCapRecord.CAPQs10result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs11result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion11))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion11]),
                        CAPTime] = redCapRecord.CAPQs11result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;
                if (redCapRecord.CAPQs12result != null && !string.IsNullOrEmpty(redCapRecord.CAPQuestion12))
                    serialData.sIndividual_CAP[(AdvanceCAPItem.prompts_difficulties_universal).IndexOf(AdvanceCAPItem.prompts_UniversalMap_CAP[redCapRecord.CAPQuestion12]),
                        CAPTime] = redCapRecord.CAPQs12result == 1 ? AdaptiveResponse.Correct : AdaptiveResponse.Incorrect;


                if (!string.IsNullOrEmpty(redCapRecord.assessorIdCAP))
                    sessionAssesorIdResponseCAP = redCapRecord.assessorIdCAP;
                if (!string.IsNullOrEmpty(redCapRecord.classroomIdCAP))
                    sessionClassroomIdResponseCAP = redCapRecord.classroomIdCAP;
                if (!string.IsNullOrEmpty(redCapRecord.teacherIdCAP))
                    sessionTeacherIdResponseCAP = redCapRecord.teacherIdCAP;

                if (!string.IsNullOrEmpty(redCapRecord.assessorNameCAP))
                    sessionAssesorNameResponseCAP = redCapRecord.assessorNameCAP;
                if (!string.IsNullOrEmpty(redCapRecord.classroomNameCAP))
                    sessionClassroomNameResponseCAP = redCapRecord.classroomNameCAP;
                if (!string.IsNullOrEmpty(redCapRecord.teacherNameCAP))
                    sessionTeacherNameResponseCAP = redCapRecord.teacherNameCAP;

                serialData.sAssessorIdCAPList[redCapRecord.CAPSessionNumber.Value - 1] = sessionAssesorIdResponseCAP;
                serialData.sClassroomIdCAPList[redCapRecord.CAPSessionNumber.Value - 1] = sessionClassroomIdResponseCAP;
                serialData.sTeacherIdCAPList[redCapRecord.CAPSessionNumber.Value - 1] = sessionTeacherIdResponseCAP;
                serialData.sAssessorNameCAPList[redCapRecord.CAPSessionNumber.Value - 1] = sessionAssesorNameResponseCAP;
                serialData.sTeacherNameCAPList[redCapRecord.CAPSessionNumber.Value - 1] = sessionTeacherNameResponseCAP;
                serialData.sClassroomNameCAPList[redCapRecord.CAPSessionNumber.Value - 1] = sessionClassroomNameResponseCAP;

                serialData.sCompleteCAP[redCapRecord.CAPSessionNumber.Value - 1] = redCapRecord.CAPComplete.Value;
                serialData.sDateTimeFieldCAP[redCapRecord.CAPSessionNumber.Value - 1] = redCapRecord.capDateTimeField.ToString();
            }
        }

        resultOfLearnerLNI(serialData);
        resultOfLearnerLSI(serialData);

        return serialData;
    }

    public static void resultOfLearnerLNI(SerialData serialData)
    {
        string[] exceptionalCharactersLNI = new[] { "K", "M", "U", "W", "Z" };
        Dictionary<int, int> letterVsCounter = new Dictionary<int, int>();
        for (int time = 0; time < 6; time++)
        {
            for (int letterChar = 0; letterChar < 26; letterChar++)
            {
                string letter = ((char)(letterChar + 65)).ToString();

                int adaptiveCounter = 0;
                if (letterVsCounter.ContainsKey(letterChar) && letterVsCounter[letterChar] > 0)
                {
                    adaptiveCounter = letterVsCounter[letterChar];

                }
                if (serialData.sIndividual_LNI[letterChar, time] == AdaptiveResponse.Correct ||
                                serialData.sIndividual_LNI[letterChar, time] == AdaptiveResponse.CSKIP)
                {
                    adaptiveCounter++;
                }

                //If incorrect, reset adaptive counter. Note that we don't count ISKIP
                else if (serialData.sIndividual_LNI[letterChar, time] == AdaptiveResponse.Incorrect)
                {
                    adaptiveCounter = 0;
                }

                if (exceptionalCharactersLNI.Contains(letter))
                {
                    if (adaptiveCounter >= 3)
                    {
                        serialData.sLearnedLetterNamesLNI[letterChar] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                                                                              //there's no mechanic to take this back to false--test out once and you're good
                    }
                    else
                    {
                        serialData.sLearnedLetterNamesLNI[letterChar] = false;
                    }
                }
                else
                {
                    if (adaptiveCounter >= 2)
                    {
                        serialData.sLearnedLetterNamesLNI[letterChar] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                                                                              //there's no mechanic to take this back to false--test out once and you're good
                    }
                    else
                    {
                        serialData.sLearnedLetterNamesLNI[letterChar] = false;
                    }
                }
                letterVsCounter[letterChar] = adaptiveCounter;

            }
        }
    }

    public static void resultOfLearnerLSI(SerialData serialData)
    {
        string[] exceptionalCharactersLSI = new[] { "A", "B", "E", "O", "S", "U" };
        Dictionary<int, int> letterVsCounter = new Dictionary<int, int>();

        for (int time = 0; time < 6; time++)
        {
            for (int letterChar = 0; letterChar < 26; letterChar++)
            {
                string letter = ((char)(letterChar + 65)).ToString();

                int adaptiveCounter = 0;
                if (letterVsCounter.ContainsKey(letterChar) && letterVsCounter[letterChar] > 0)
                {
                    adaptiveCounter = letterVsCounter[letterChar];

                }
                if (serialData.sIndividual_LSI[letterChar, time] == AdaptiveResponse.Correct ||
                                serialData.sIndividual_LSI[letterChar, time] == AdaptiveResponse.CSKIP)
                {
                    adaptiveCounter++;
                }

                //If incorrect, reset adaptive counter. Note that we don't count ISKIP
                else if (serialData.sIndividual_LSI[letterChar, time] == AdaptiveResponse.Incorrect)
                {
                    adaptiveCounter = 0;
                }

                if (exceptionalCharactersLSI.Contains(letter))
                {
                    if (adaptiveCounter >= 3)
                    {
                        serialData.sLearnedLetterNamesLSI[letterChar] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                                                                              //there's no mechanic to take this back to false--test out once and you're good
                    }
                    else
                    {
                        serialData.sLearnedLetterNamesLSI[letterChar] = false;
                    }
                }
                else
                {
                    if (adaptiveCounter >= 2)
                    {
                        serialData.sLearnedLetterNamesLSI[letterChar] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                                                                              //there's no mechanic to take this back to false--test out once and you're good
                    }
                    else
                    {
                        serialData.sLearnedLetterNamesLSI[letterChar] = false;
                    }
                }
                letterVsCounter[letterChar] = adaptiveCounter;

            }
        }
    }

    // Function responsible for returning bool truth value
    private static bool getTrueFalse(int? value)
    {
        return value != null && value == 1;
    }

    // Function responsible for calculating expressive and receptive percentage values
    private static void addExpressiveAndReceptiveScore(List<bool> sessionExpressiveList, 
                                                        List<bool> sessionReceptiveList,
                                                        int vocabSession,
                                                        SerialData serialData)
    {
        int index = vocabSession - 1;
        int score_expressive = sessionExpressiveList.Count(item => item);
        int score_receptive = sessionReceptiveList.Count(item => item);
        
        double totalQuestions = DataManager.vocabularyTotalQuestions;
        serialData.sGradeVocabExp[index] = (score_expressive / totalQuestions) * 100;
        serialData.sGradeVocabRec[index] = (score_receptive / totalQuestions) * 100;
        
        int score_total = score_expressive + score_receptive;
        serialData.sGradeVocabTotal[index] = (score_total / (totalQuestions * 2)) * 100;
    }
}
