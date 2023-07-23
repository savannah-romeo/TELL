//This class is used to store and load data.
//Useful for scene transitions, data exports, and local saves.
//By using static variables we keep a persistent location in memory.
//Note: Use doubles to store all numbers to avoid expensive casting

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Math;

public class DataManager : MonoBehaviour
{  
    public static bool childExists;
    public static bool childFileExists;
    public static bool internetAvailable;

    //User info
    //Note ID can be name or an ID #
    public static string recordID;
    public static string teacherID;
    public static string assessorID;
    public static string childID;
    public static string classroomID;

    public static string exportImportRef;
    public static int vocabTime;
    public static int BSTime;
    public static int LNITime;
    public static int LSITime;
    public static int SRTime;
    public static int CSTime;
    public static int writingTime;
    public static int bookSumTime;

    public static string currentScene; //used to determine what logic to use

    public static string globalGame; //Var used to store what game we are playing
    public static int globalTime; //Var used to store which 'Time'/unit/week we are on

    // Student should answer 3 of these alphabets to skip these alphabets
    public static string[] exceptionalAdaptCharactersLSI = new[] { "A", "B", "E", "O", "S", "U" }; 
    public static string[] exceptionalTwoStageCharactersLSI = new[] { "A", "B", "M", "P", "S", "T" };

    public static string[] exceptionalAdaptCharactersLNI = new[] { "K", "M", "U", "W", "Z" };

    public static string childNameLNI; //used to store child name for use in LNI
                                       //PII THAT SHOULD NOT BE SAVED LONG-TERM
    
                                       

    //Per-game scored answers
    //LNI Grades
    public static bool[] learnedLetterNamesLNI; //Tracks letters that we have 'tested out of'
    public static AdaptiveResponse[,] individual_LNI; //26 letters, 6 times
    public static List<string> assessorIdLniReponses;
    public static List<string> teacherIdLniResponses;
    public static List<string> classroomIdLniResponses;
    public static List<string> assessorNameLniReponses;
    public static List<string> teacherNameLniResponses;
    public static List<string> classroomNameLniResponses;
    public static List<string> lniDateTimeField;
    public static List<int> completeLNI;

    //Per-game scored answers
    //LSI Grades
    public static bool[] learnedLetterNamesLSI; //Tracks letters that we have 'tested out of'
    public static AdaptiveResponse[,] individual_LSI; //26 letters, 6 times
    public static List<string> assessorIdLsiReponses;
    public static List<string> teacherIdLsiResponses;
    public static List<string> classroomIdLsiResponses;
    public static List<string> assessorNameLsiReponses;
    public static List<string> teacherNameLsiResponses;
    public static List<string> classroomNameLsiResponses;
    public static List<string> lsiDateTimeField;
    public static List<int> completeLSI;

    //Per-game scored answers
    //BS Grades
    public static AdaptiveResponse[,] individual_BS;
    public static string[,] individual_BSChildResponse;
    public static Tuple<double, double>[] final_BSscores;
    public static List<string> assessorIdBsReponses;
    public static List<string> teacherIdBsResponses;
    public static List<string> classroomIdBsResponses;
    public static List<string> assessorNameBsReponses;
    public static List<string> teacherNameBsResponses;
    public static List<string> classroomNameBsResponses;
    public static List<string> bsDateTimeField;
    public static List<int> completeBS;

    //CAP Grades
    public static AdaptiveResponse[,] individual_CAP;
    //public static string[,] individual_CAPChildResponse;
    public static Tuple<double, double>[] final_CAPscores;
    public static List<string> assessorIdCAPReponses;
    public static List<string> teacherIdCAPResponses;
    public static List<string> classroomIdCAPResponses;
    public static List<string> assessorNameCAPReponses;
    public static List<string> teacherNameCAPResponses;
    public static List<string> classroomNameCAPResponses;
    public static List<string> capDateTimeField;
    public static List<int> completeCAP;

    //Vocab Grades
    //These hold the total score for the game
    public static double score_expressive;
    public static double score_receptive;
    public static double score_total;
    public static List<string> responses; //List of answers given

    public static List<bool> individual_expressive;
    public static List<bool> individual_receptive;
    public static List<bool> individual_expressiveFlag;
    public static List<bool> individual_receptiveFlag;
    public static List<int> individual_total;

    public static double vocabularyTotalQuestions; //How many vocab questions are asked per unit?
    public static double[] grade_vocabularyExpressive;
    public static double[] grade_vocabularyReceptive;
    public static double[] grade_vocabularyTotal;
    public static List<string> assessorIdVocabReponses;
    public static List<string> teacherIdVocabResponses;
    public static List<string> classroomIdVocabResponses;
    public static List<string> assessorNameVocabReponses;
    public static List<string> teacherNameVocabResponses;
    public static List<string> classroomNameVocabResponses;
    public static List<string> vocabDateTimeField;

    public static List<List<bool>> individual_vocabularyExpressive;
    public static List<List<bool>> individual_vocabularyReceptive;
    public static List<List<string>> individual_vocabularyResponses;
    public static List<List<bool>> individual_vocabularyExpressiveFlag;
    public static List<List<bool>> individual_vocabularyReceptiveFlag;
    public static List<int> completeVocabulary;

    // CS
    public static int score_cs;
    public static List<bool> individual_cs;
    public static List<string> assessorIdCSReponses;
    public static List<string> teacherIdCSResponses;
    public static List<string> classroomIdCSResponses;
    public static List<string> assessorNameCSReponses;
    public static List<string> teacherNameCSResponses;
    public static List<string> classroomNameCSResponses;
    public static List<string> csDateTimeField;
    public static List<int> completeCS;

    public static int[] grade_csTotal;
    public static List<List<bool>> individual_csResponse;

    // SR
    public static int score_sr;
    public static List<bool> individual_sr;
    public static List<string> individual_srQues;
    public static double srTotalQuestions; //How many cs questions are asked per unit?
    public static List<string> assessorIdSRReponses;
    public static List<string> teacherIdSRResponses;
    public static List<string> classroomIdSRResponses;
    public static List<string> assessorNameSRReponses;
    public static List<string> teacherNameSRResponses;
    public static List<string> classroomNameSRResponses;
    public static List<string> srDateTimeField;
    public static List<int> completeSR;

    public static int[] grade_srTotal;
    public static List<List<bool>> individual_srResponse;
    public static List<List<string>> individual_srQuestions;

    // BookSummary
    public static int score_bookSum;
    public static List<bool> individual_bookSum;
    public static List<string> individual_bookSumQues;
    public static double bookSumTotalQuestions; //How many cs questions are asked per unit?
    public static List<string> assessorIdBookSumReponses;
    public static List<string> teacherIdBookSumResponses;
    public static List<string> classroomIdBookSumResponses;
    public static List<string> assessorNameBookSumReponses;
    public static List<string> teacherNameBookSumResponses;
    public static List<string> classroomNameBookSumResponses;
    public static List<string> bookSumDateTimeField;
    public static List<int> completeBookSum;

    public static int[] grade_bookSumTotal;
    public static List<List<bool>> individual_bookSumResponse;
    public static List<List<string>> individual_bookSumQuestions;

    //Continuation flags
    public static bool continuation_flag;
    public static string continuation_scene;
    public static int question_no;

    // Writing
    public static int individual_name_score;
    public static int individual_sentence_score;
    public static List<string> assessorIdWritingReponses;
    public static List<string> teacherIdWritingResponses;
    public static List<string> classroomIdWritingResponses;
    public static List<string> assessorNameWritingReponses;
    public static List<string> teacherNameWritingResponses;
    public static List<string> classroomNameWritingResponses;
    public static List<string> writingDateTimeField;
    public static List<int> completeWriting;

    public static int[] individual_cs_name;
    public static int[] individual_cs_sentence;
    public static List<List<int>> individual_writing_score;

    //UserInfo Fields
    public TMP_InputField teacherNameField;
    public TMP_InputField assessorNameField;
    public TMP_InputField childNameField;
    public TMP_InputField classroomField;
    public TMP_InputField teacherIDField;
    public TMP_InputField assessorIDField;
    public TMP_InputField childIDField;
    public TMP_InputField classroomIDField;

    //Instructions Fields
    public TMP_InputField lniNameField;
    
    //BS Child Response Field
    public TMP_InputField bsChildResponseField;

    //Evaluator Fields
    public TMP_InputField responseField;
    public Toggle primaryToggle;
    public Toggle receptiveToggle; //Vocab
    public Toggle expressiveToggle;
    public Toggle receptiveToggleNo;
    public Toggle expressiveFlag;
    public Toggle receptiveFlag;
    public TextMeshProUGUI questionField;

    public Toggle bookSumExtraMarkToggle;
    public TextMeshProUGUI textBookSumExtraMarkToggle;

    //Writing Evaluator Fields
    public Toggle name0Toggle;
    public Toggle name1Toggle; 
    public Toggle name2Toggle;
    public Toggle name3Toggle;
    public Toggle name4Toggle;
    public Toggle sen0Toggle;
    public Toggle sen1Toggle; 
    public Toggle sen2Toggle;
    public Toggle sen3Toggle;
    public Toggle sen4Toggle;
    public ToggleGroup[] srToggleGroups;

    //Grader Fields
    public AdvanceText promptCycler;
    public AdvanceBSItem promptCyclerBS;
    public AdvanceCAPItem advanceCAPItem;
    public AdvanceVocabItem advanceVocabItem;
    public TextMeshProUGUI childText; //Displays child ID
    public TextMeshProUGUI[] promptText;
    public TextMeshProUGUI[] responsesText; //Displays child answers
    public TextMeshProUGUI[] expressiveText;
    public TextMeshProUGUI[] receptiveText;
    public TextMeshProUGUI expressiveTotalText;
    public TextMeshProUGUI receptiveTotalText;
    public TextMeshProUGUI csScoreTotal;
    public TextMeshProUGUI[] csPromptText;
    public TextMeshProUGUI[] csResponseScore;

    public TextMeshProUGUI srScoreTotal;
    public TextMeshProUGUI[] srPromptText;
    public TextMeshProUGUI[] srResponseScore;

    public TextMeshProUGUI bookSumScoreTotal;

    public TextMeshProUGUI writingNameScore;
    public TextMeshProUGUI writingSentenceScore;

    //RVocab Fields
    public TextMeshProUGUI[] expressivePercent;
    public TextMeshProUGUI[] receptivePercent;

    //RCS Fields
    public TextMeshProUGUI[] csScoresForResultPage;

    //RWriting Fields
    public TextMeshProUGUI[] writingNameScoreForResultPage;
    public TextMeshProUGUI[] writingSentenceScoreForResultPage;

    //RSR Fields
    public TextMeshProUGUI[] srScoresForResultPage;

    //RbookSum Fields
    public TextMeshProUGUI[] booksumScoresForResultPage;

    //RLI Fields
    public TextMeshProUGUI[] RLNI_letterText;
    public TextMeshProUGUI[] RLSI_letterText;

    public TextMeshProUGUI[] RLI_letterText1;
    public TextMeshProUGUI[] RLI_letterText2;
    public TextMeshProUGUI[] RLI_letterText3;
    public TextMeshProUGUI[] RLI_letterText4;
    public TextMeshProUGUI[] RLI_letterText5;
    public TextMeshProUGUI[] RLI_letterText6;
    public TextMeshProUGUI[] RLI_totalScore;

    //RLI Fields - I think akshay started using this for BS but unsure if implemented
    public TextMeshProUGUI[] BS_items;
    public TextMeshProUGUI[] BS_letterText;

    public TextMeshProUGUI[] CAP_items;
    public TextMeshProUGUI[] CAP_letterText;
    public TextMeshProUGUI CAP_PercentileScore;

    //RBS Fields
    public TextMeshProUGUI[] BS_EAPScore;
    public TextMeshProUGUI BS_PercentileScore;

    public TextMeshProUGUI[] CAP_EAPScore;

    public TextMeshProUGUI gameText;
    public TextMeshProUGUI timeText;
    

    // Start is called before the first frame update
    void Start()
    {
        vocabularyTotalQuestions = 6;
        srTotalQuestions = 16;

        //Instantializes arrays if brand new
        if (grade_vocabularyExpressive == null)
        {
            grade_vocabularyExpressive = new double[6] { -1, -1, -1, -1, -1, -1 };
            grade_vocabularyReceptive = new double[6] { -1, -1, -1, -1, -1, -1 };
            grade_vocabularyTotal = new double[6] { -1, -1, -1, -1, -1, -1 };
            if (grade_csTotal == null)
            {
                grade_csTotal = new int[6] { -1, -1, -1, -1, -1, -1 };
            }
            if (grade_srTotal == null) {
                grade_srTotal = new int[3] { -1, -1, -1 };
            }
            if (grade_bookSumTotal == null)
            {
                grade_bookSumTotal = new int[3] { -1, -1, -1 };
            }
            continuation_flag = false;
            question_no = 0;
            continuation_scene = "";
            if (final_BSscores == null)
            {
                final_BSscores = new Tuple<double, double>[6] { Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0) };

            }
            if (final_CAPscores == null)
            {
                final_CAPscores = new Tuple<double, double>[6] { Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0) };
            }
            if (individual_cs_name == null)
            {
                individual_cs_name = new int[6] { -1, -1, -1, -1, -1, -1 };
            }
            if (individual_cs_sentence == null)
            {
                individual_cs_sentence = new int[6] { -1, -1, -1, -1, -1, -1 };
            }
            if (individual_writing_score == null)
            {
                individual_writing_score = new List<List<int>>() { new List<int>(), new List<int>() , new List<int>() , new List<int>() , new List<int>() , new List<int>() };
            }
            individual_vocabularyExpressive = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyExpressiveFlag = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyReceptive = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyReceptiveFlag = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyResponses = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>()};
            if(completeVocabulary != null)
            {
                completeVocabulary = new List<int>() { -1, -1, -1, -1, -1, -1 };
            }
            if (completeBookSum != null)
            {
                completeBookSum = new List<int>() { -1, -1, -1 };
            }
            if (completeSR != null)
            {
                completeSR = new List<int>() { -1, -1, -1 };
            }
            if (completeLSI != null)
            {
                completeLSI = new List<int>() { -1, -1, -1, -1, -1, -1 };
            }
            if (completeLNI != null)
            {
                completeLNI = new List<int>() { -1, -1, -1, -1, -1, -1 };
            }
            if (completeCAP != null)
            {
                completeCAP = new List<int>() { -1, -1, -1, -1, -1, -1 };
            }
            if (completeBS != null)
            {
                completeBS = new List<int>() { -1, -1, -1, -1, -1, -1 };
            }
            if (completeCS != null)
            {
                completeCS = new List<int>() { -1, -1, -1, -1, -1, -1 };
            }
            if (completeWriting != null)
            {
                completeWriting = new List<int>() { -1, -1, -1, -1, -1, -1 };
            }
            if (assessorIdVocabReponses == null)
            {
                assessorIdVocabReponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (teacherIdVocabResponses == null)
            {
                teacherIdVocabResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (classroomIdVocabResponses == null)
            {
                classroomIdVocabResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (assessorNameVocabReponses == null)
            {
                assessorNameVocabReponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (teacherNameVocabResponses == null)
            {
                teacherNameVocabResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (classroomNameVocabResponses == null)
            {
                classroomNameVocabResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (assessorIdBsReponses == null)
            {
                assessorIdBsReponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (teacherIdBsResponses == null)
            {
                teacherIdBsResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (classroomIdBsResponses == null)
            {
                classroomIdBsResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (assessorNameBsReponses == null)
            {
                assessorNameBsReponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (teacherNameBsResponses == null)
            {
                teacherNameBsResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (classroomNameBsResponses == null)
            {
                classroomNameBsResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (assessorIdCAPReponses == null)
            {
                assessorIdCAPReponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (teacherIdCAPResponses == null)
            {
                teacherIdCAPResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (classroomIdCAPResponses == null)
            {
                classroomIdCAPResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (assessorNameCAPReponses == null)
            {
                assessorNameCAPReponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (teacherNameCAPResponses == null)
            {
                teacherNameCAPResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (classroomNameCAPResponses == null)
            {
                classroomNameCAPResponses = new List<string>() { "", "", "", "", "", "" }; ;
            }
            if (assessorIdLniReponses == null)
            {
                assessorIdLniReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherIdLniResponses == null)
            {
                teacherIdLniResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomIdLniResponses == null)
            {
                classroomIdLniResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (assessorNameLniReponses == null)
            {
                assessorNameLniReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherNameLniResponses == null)
            {
                teacherNameLniResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomNameLniResponses == null)
            {
                classroomNameLniResponses = new List<string>() { "", "", "", "", "", "" };
            }

            if (assessorIdLsiReponses == null)
            {
                assessorIdLsiReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherIdLsiResponses == null)
            {
                teacherIdLsiResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomIdLsiResponses == null)
            {
                classroomIdLsiResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (assessorNameLsiReponses == null)
            {
                assessorNameLsiReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherNameLsiResponses == null)
            {
                teacherNameLsiResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomNameLsiResponses == null)
            {
                classroomNameLsiResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (assessorIdCSReponses == null)
            {
                assessorIdCSReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherIdCSResponses == null)
            {
                teacherIdCSResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomIdCSResponses == null)
            {
                classroomIdCSResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (assessorNameCSReponses == null)
            {
                assessorNameCSReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherNameCSResponses == null)
            {
                teacherNameCSResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomNameCSResponses == null)
            {
                classroomNameCSResponses = new List<string>() { "", "", "", "", "", "" };
            }

            if (assessorIdWritingReponses == null)
            {
                assessorIdWritingReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherIdWritingResponses == null)
            {
                teacherIdWritingResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomIdWritingResponses == null)
            {
                classroomIdWritingResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (assessorNameWritingReponses == null)
            {
                assessorNameWritingReponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (teacherNameWritingResponses == null)
            {
                teacherNameWritingResponses = new List<string>() { "", "", "", "", "", "" };
            }
            if (classroomNameWritingResponses == null)
            {
                classroomNameWritingResponses = new List<string>() { "", "", "", "", "", "" };
            }

            if (assessorIdSRReponses == null)
            {
                assessorIdSRReponses = new List<string>() { "", "", "" };
            }
            if (teacherIdSRResponses == null)
            {
                teacherIdSRResponses = new List<string>() { "", "", "" };
            }
            if (classroomIdSRResponses == null)
            {
                classroomIdSRResponses = new List<string>() { "", "", "" };
            }
            if (assessorNameSRReponses == null)
            {
                assessorNameSRReponses = new List<string>() { "", "", "" };
            }
            if (teacherNameSRResponses == null)
            {
                teacherNameSRResponses = new List<string>() { "", "", "" };
            }
            if (classroomNameSRResponses == null)
            {
                classroomNameSRResponses = new List<string>() { "", "", "" };
            }

            if (assessorIdBookSumReponses == null)
            {
                assessorIdBookSumReponses = new List<string>() { "","",""};
            }
            if (teacherIdBookSumResponses == null)
            {
                teacherIdBookSumResponses = new List<string>() { "","",""};
            }
            if (classroomIdBookSumResponses == null)
            {
                classroomIdBookSumResponses = new List<string>() { "","",""};
            }
            if (assessorNameBookSumReponses == null)
            {
                assessorNameBookSumReponses = new List<string>() { "", "", "" };
            }
            if (teacherNameBookSumResponses == null)
            {
                teacherNameBookSumResponses = new List<string>() { "", "", "" };
            }
            if (classroomNameBookSumResponses == null)
            {
                classroomNameBookSumResponses = new List<string>() { "", "", "" };
            }


            if (individual_csResponse == null)
            {
                individual_csResponse = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() , new List<bool>() , new List<bool>() };
            }
            if (individual_srResponse == null)
            {
                individual_srResponse = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>() };//{ Capacity = 3};;
            }
            if (individual_srQuestions == null)
            {
                individual_srQuestions = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>() }; //{Capacity = 3};;
                //individual_srQuestions = new List<List<string>>();
            }
            if (individual_bookSumResponse == null)
            {
                individual_bookSumResponse = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>() };
                //individual_bookSumResponse = new List<List<bool>>();
            }
            if (individual_bookSumQuestions == null)
            {
                individual_bookSumQuestions = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>() };
                //individual_bookSumQuestions = new List<List<string>>();
            }
            if(vocabDateTimeField == null)
            {
                vocabDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(capDateTimeField == null)
            {
                capDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(writingDateTimeField == null)
            {
                writingDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(bookSumDateTimeField == null)
            {
                bookSumDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(bsDateTimeField == null)
            {
                bsDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(srDateTimeField == null)
            {
                srDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(lniDateTimeField == null)
            {
                lniDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(lsiDateTimeField == null)
            {
                lsiDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }
            if(csDateTimeField == null)
            {
                csDateTimeField = new List<string>() { "", "", "", "", "", "" };
            }

            if (learnedLetterNamesLNI == null)
            {
                learnedLetterNamesLNI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false, false, false, false};
            }
            if (learnedLetterNamesLSI == null)
            {
                learnedLetterNamesLSI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false, false, false, false};
            }
        }

        //Initializes currentScene
        if(currentScene == null)
            currentScene = "UserInfo";

        //Fill saved UserInfo
        if(currentScene == "UserInfo" || currentScene == "StartGame" || currentScene == "UserInfoMultiple")
        {
            // teacherIDField.text = teacherID;
            // assessorIDField.text = assessorID;
            // childIDField.text = childID;
            // classroomIDField.text = classroomID;
            
            // Add logout code here
            childExists = false;
            childFileExists = false;
            teacherID = null;
            recordID = null;
            assessorID = null;
            childID = null;
            classroomID = null;
            vocabTime = 0;
            BSTime = 0;
            LNITime = 0;
            LSITime = 0;
            CSTime = 0;
            SRTime = 0;
            writingTime = 0;
            bookSumTime = 0;
            grade_vocabularyExpressive = new double[6] { -1, -1, -1, -1, -1, -1 };
            grade_vocabularyReceptive = new double[6] { -1, -1, -1, -1, -1, -1 };
            grade_vocabularyTotal = new double[6] { -1, -1, -1, -1, -1, -1 };
            grade_csTotal = new int[6] {-1,-1,-1,-1,-1,-1};
            grade_srTotal = new int[3] {-1,-1,-1};
            individual_sr = new List<bool>();
            individual_srQues = new List<string>();
            grade_bookSumTotal = new int[3] {-1,-1,-1};
            individual_bookSumQues = new List<string>();
            individual_bookSum = new List<bool>();
            continuation_flag = false;
            question_no = 0;
            continuation_scene = "";
            final_BSscores = new Tuple<double, double>[6] { Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0) };
            final_CAPscores = new Tuple<double, double>[6] { Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0), Tuple.Create(-10.0, -10.0) };
            individual_vocabularyExpressive = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyExpressiveFlag = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyReceptive = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyReceptiveFlag = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_vocabularyResponses = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>() };
            individual_csResponse = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>(), new List<bool>() };
            individual_cs_name = new int[6] { -1, -1, -1, -1, -1, -1 };
            individual_cs_sentence = new int[6] { -1, -1, -1, -1, -1, -1 };
            
            completeVocabulary = new List<int>() { -1, -1, -1, -1, -1, -1 };
            completeBookSum = new List<int>() { -1, -1, -1 };
            completeSR = new List<int>() { -1, -1, -1 };
            completeLSI = new List<int>() { -1, -1, -1, -1, -1, -1 };
            completeLNI = new List<int>() { -1, -1, -1, -1, -1, -1 };
            completeCAP = new List<int>() { -1, -1, -1, -1, -1, -1 };
            completeBS = new List<int>() { -1, -1, -1, -1, -1, -1 };
            completeCS = new List<int>() { -1, -1, -1, -1, -1, -1 };
            completeWriting = new List<int>() { -1, -1, -1, -1, -1, -1 };

            //individual_srResponse = new List<List<bool>>();
            //individual_srQuestions = new List<List<string>>();
            individual_srResponse = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>() };//{ Capacity = 3};;
            individual_srQuestions = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>() }; //{Capacity = 3};;
            individual_bookSumResponse = new List<List<bool>>() { new List<bool>(), new List<bool>(), new List<bool>() };
            individual_bookSumQuestions = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>() };
            individual_LNI =  new AdaptiveResponse[26, 6];
            individual_LSI =  new AdaptiveResponse[26, 6];
            individual_BS =  new AdaptiveResponse[36, 6];
            individual_BSChildResponse =  new string[36, 6];
            individual_CAP = new AdaptiveResponse[13,6];
            individual_writing_score = new List<List<int>>() { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>() };

            //individual_CAPChildResponse = new string[13, 6];

            /*for (int loop = 0; loop < 6; loop++)
            {
                // writingNameScoreForResultPage[loop].text = individual_cs_name[loop].ToString("F0"); //Parameter ensures two decimal points
                // writingSentenceScoreForResultPage[loop].text = individual_cs_sentence[loop].ToString("F0"); //Parameter ensures two decimal points
                List<int> sampleValues = new List<int> { -1, -1 };
                individual_writing_score.Insert(loop,sampleValues); //Parameter ensures two decimal points
                 

            }*/

            assessorIdVocabReponses = new List<string>() { "", "", "", "", "", "" };
            teacherIdVocabResponses = new List<string>() { "", "", "", "", "", "" };
            classroomIdVocabResponses = new List<string>() { "", "", "", "", "", "" };
            assessorNameVocabReponses = new List<string>() { "", "", "", "", "", "" };
            teacherNameVocabResponses = new List<string>() { "", "", "", "", "", "" };
            classroomNameVocabResponses = new List<string>() { "", "", "", "", "", "" };

            assessorIdBsReponses = new List<string>() { "", "", "", "", "", "" };
            teacherIdBsResponses = new List<string>() { "", "", "", "", "", "" };
            classroomIdBsResponses = new List<string>() { "", "", "", "", "", "" };
            assessorNameBsReponses = new List<string>() { "", "", "", "", "", "" };
            teacherNameBsResponses = new List<string>() { "", "", "", "", "", "" };
            classroomNameBsResponses = new List<string>() { "", "", "", "", "", "" };

            assessorIdCAPReponses = new List<string>() { "", "", "", "", "", "" };
            teacherIdCAPResponses = new List<string>() { "", "", "", "", "", "" };
            classroomIdCAPResponses = new List<string>() { "", "", "", "", "", "" };
            assessorNameCAPReponses = new List<string>() { "", "", "", "", "", "" };
            teacherNameCAPResponses = new List<string>() { "", "", "", "", "", "" };
            classroomNameCAPResponses = new List<string>() { "", "", "", "", "", "" };

            assessorIdLsiReponses = new List<string>() { "", "", "", "", "", "" };
            teacherIdLsiResponses = new List<string>() { "", "", "", "", "", "" };
            classroomIdLsiResponses = new List<string>() { "", "", "", "", "", "" };
            assessorNameLsiReponses = new List<string>() { "", "", "", "", "", "" };
            teacherNameLsiResponses = new List<string>() { "", "", "", "", "", "" };
            classroomNameLsiResponses = new List<string>() { "", "", "", "", "", "" };

            assessorIdLniReponses = new List<string>() { "", "", "", "", "", "" };
            teacherIdLniResponses = new List<string>() { "", "", "", "", "", "" };
            classroomIdLniResponses = new List<string>() { "", "", "", "", "", "" };
            assessorNameLniReponses = new List<string>() { "", "", "", "", "", "" };
            teacherNameLniResponses = new List<string>() { "", "", "", "", "", "" };
            classroomNameLniResponses = new List<string>() { "", "", "", "", "", "" };

            assessorIdWritingReponses = new List<string>() { "", "", "", "", "", "" };
            teacherIdWritingResponses = new List<string>() { "", "", "", "", "", "" };
            classroomIdWritingResponses = new List<string>() { "", "", "", "", "", "" };
            assessorNameWritingReponses = new List<string>() { "", "", "", "", "", "" };
            teacherNameWritingResponses = new List<string>() { "", "", "", "", "", "" };
            classroomNameWritingResponses = new List<string>() { "", "", "", "", "", "" };

            assessorIdCSReponses = new List<string>() { "", "", "", "", "", "" };
            teacherIdCSResponses = new List<string>() { "", "", "", "", "", "" };
            classroomIdCSResponses = new List<string>() { "", "", "", "", "", "" };
            assessorNameCSReponses = new List<string>() { "", "", "", "", "", "" };
            teacherNameCSResponses = new List<string>() { "", "", "", "", "", "" };
            classroomNameCSResponses = new List<string>() { "", "", "", "", "", "" };

            assessorIdSRReponses = new List<string>() { "", "", "" };
            teacherIdSRResponses = new List<string>() { "", "", "" };
            classroomIdSRResponses = new List<string>() { "", "", "" };
            assessorNameSRReponses = new List<string>() { "", "", "" };
            teacherNameSRResponses = new List<string>() { "", "", "" };
            classroomNameSRResponses = new List<string>() { "", "", "" };

            assessorIdBookSumReponses = new List<string>() { "", "", "" };
            teacherIdBookSumResponses = new List<string>() { "", "", "" };
            classroomIdBookSumResponses = new List<string>() { "", "", "" };
            assessorNameBookSumReponses = new List<string>() { "", "", "" };
            teacherNameBookSumResponses = new List<string>() { "", "", "" };
            classroomNameBookSumResponses = new List<string>() { "", "", "" };

            vocabDateTimeField = new List<string>() { "", "", "", "", "", "" };
            capDateTimeField = new List<string>() { "", "", "", "", "", "" };
            writingDateTimeField = new List<string>() { "", "", "", "", "", "" };
            bookSumDateTimeField = new List<string>() { "", "", "", "", "", "" };
            bsDateTimeField = new List<string>() { "", "", "", "", "", "" };
            srDateTimeField = new List<string>() { "", "", "", "", "", "" };
            lniDateTimeField = new List<string>() { "", "", "", "", "", "" };
            lsiDateTimeField = new List<string>() { "", "", "", "", "", "" };
            csDateTimeField = new List<string>() { "", "", "", "", "", "" };

            learnedLetterNamesLNI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false, false, false, false};

            learnedLetterNamesLSI = new bool[26] {false, false, false, false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false, false, false, false};
        }

        //Reset scores and wipe responses
        if(currentScene == "Evaluator" || currentScene == "Evaluator_Vocab" || currentScene == "LNI_Evaluator" || 
           currentScene == "LSI_Evaluator" || currentScene == "BS_Evaluator" || currentScene == "CS_Evaluator"
           || currentScene == "Writing_Evaluator" || currentScene == "SR_Evaluator"
           || currentScene == "BookSum_Evaluator" || currentScene == "CAP_Evaluator")
        {
            individual_expressive = new List<bool>();
            individual_expressiveFlag = new List<bool>();
            individual_receptive = new List<bool>();
            individual_receptiveFlag = new List<bool>();
            individual_total = new List<int>();
            score_expressive = 0;
            score_receptive = 0;
            score_total = 0;
            individual_cs = new List<bool>();
            individual_name_score = -999;
            individual_sentence_score = -999;
            score_cs = 0;
            score_sr = 0;
            score_bookSum = 0;
            question_no = 0;
            individual_sr = new List<bool>();
            individual_srQues = new List<string>();
            individual_bookSumQues = new List<string>();
            individual_bookSum = new List<bool>();
            responses = new List<string>();
            /*for (int letterIndex = 0; letterIndex < individual_LSI.GetLength(0); letterIndex++)
            {
                individual_LSI[letterIndex, globalTime - 1] = AdaptiveResponse.Missing;
            }
            for (int letterIndex = 0; letterIndex < individual_LNI.GetLength(0); letterIndex++)
            {
                individual_LNI[letterIndex, globalTime - 1] = AdaptiveResponse.Missing;
            }
            for (int item = 0; item < individual_BS.GetLength(0); item++)
            {
                individual_BS[item, globalTime - 1] = AdaptiveResponse.Missing;
            }
            for (int item = 0; item < individual_CAP.GetLength(0); item++)
            {
                individual_CAP[item, globalTime - 1] = AdaptiveResponse.Missing;
            }*/
        }

        //Display all our data!
        if (currentScene == "Grader" || currentScene == "Grader_Vocab")
        {
            childText.text = childID;
            completeVocabulary[globalTime - 1] = 2;
            vocabDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            gameText.text = "Test : Vocabulary";
            timeText.text = "Time : " + globalTime;
            string[] promptStorage = promptCycler.PromptSelect(globalTime);
            //Loop populates table textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for (int wheel = 0; wheel < 6; wheel++)
            {
                promptText[wheel].text = promptStorage[wheel];
                if (responses.Count > 0)
                {
                    responsesText[wheel].text = responses[wheel];
                }
                else
                {
                    responsesText[wheel].text = "";
                }
                expressiveText[wheel].text = individual_expressive[wheel] ? "1" : "0";
                receptiveText[wheel].text = individual_receptive[wheel] ? "1" : "0";
            }
            //Access calculated total grades for this time
            //See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings for formatting
            expressiveTotalText.text = grade_vocabularyExpressive[globalTime - 1].ToString("F0") + '%';
            receptiveTotalText.text = grade_vocabularyReceptive[globalTime - 1].ToString("F0") + '%';
        }

        if (currentScene == "CS_Grader")
        {
            childText.text = childID;
            completeCS[globalTime - 1] = 2;
            csDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            gameText.text = "Test : Clapping Syllables";
            timeText.text = "Time : " + globalTime;
            string[] promptStorage = promptCycler.PromptSelect(globalTime);
            //Loop populates table textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            //for (int wheel = 0; wheel < 3; wheel++)
            /*for (int wheel = 0; wheel < individual_cs.Count; wheel++)
            {
                csPromptText[wheel].text = promptStorage[wheel];
                csResponseScore[wheel].text = individual_cs[wheel] ? "1" : "0";
            }*/
            //Access calculated total grades for this time
            //See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings for formatting
            csScoreTotal.text = grade_csTotal[globalTime - 1].ToString("F0")+" out of 3";
        }

        if (currentScene == "SR_Grader")
        {
            childText.text = childID;
            completeSR[globalTime - 1] = 2;
            srDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            gameText.text = "Test : Story Retell";
            timeText.text = "Time : " + ((2 * globalTime) - 1);
            print("_______-");
            //See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings for formatting
            srScoreTotal.text = grade_srTotal[globalTime - 1].ToString("F0");
        }

        if (currentScene == "BookSum_Grader")
        {
            childText.text = childID;
            completeBookSum[globalTime - 1] = 2;
            bookSumDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            gameText.text = "Test : Book Summary";
            timeText.text = "Time : " + (2 * globalTime);
            //Access calculated total grades for this time
            //See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings for formatting
            bookSumScoreTotal.text = grade_bookSumTotal[globalTime - 1].ToString("F0")+" out of 11";
        }

        if (currentScene == "Writing_Grader")
        {
            childText.text = childID;
            completeWriting[globalTime - 1] = 2;
            writingDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            gameText.text = "Test : Writing";
            timeText.text = "Time : " + globalTime;
            writingNameScore.text = individual_name_score.ToString("F0");
            writingSentenceScore.text = individual_sentence_score.ToString("F0");
        }

        if (currentScene == "LNI_Grader" )
        {
            gameText.text = "Test : Letter Name Identification";
            timeText.text = "Time : " + globalTime;
            completeLNI[globalTime - 1] = 2;
            lniDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            //Check for "Tested Out" Letters
            for (int letter = 0; letter < individual_LNI.GetLength(0); letter++)
            {
                string letterChar = ((char)(letter + 65)).ToString();
                int adaptiveCounter = 0; //Var used to track 'consecutive' correct answers

                for (int time = 0; time < individual_LNI.GetLength(1); time++)
                {
                    if (time == globalTime-1)
                    {
                        if (individual_LNI[letter, time] == AdaptiveResponse.Correct ||
                            individual_LNI[letter, time] == AdaptiveResponse.CSKIP)
                        {
                            RLNI_letterText[letter].text = "+";
                            RLNI_letterText[letter].color = new Color(0, 0.6f, 0);
                        }
                        else
                        {
                            RLNI_letterText[letter].text = "<color=red>-</color>";
                        }
                    }
                    
                    //If score was correct or CSkipped, increase adaptive counter
                    if (individual_LNI[letter, time] == AdaptiveResponse.Correct ||
                        individual_LNI[letter, time] == AdaptiveResponse.CSKIP)
                    {
                        adaptiveCounter++;
                    }

                    //If incorrect, reset adaptive counter. Note that we don't count ISKIP
                    else if  (individual_LNI[letter, time] == AdaptiveResponse.Incorrect)
                    {
                        adaptiveCounter = 0;
                    }

                    /*if(adaptiveCounter>=2)
                    {
                        learnedLetterNamesLNI[letter] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                        //there's no mechanic to take this back to false--test out once and you're good
                    }*/

                    if (exceptionalAdaptCharactersLNI.Contains(letterChar))
                    {
                        if (adaptiveCounter >= 3)
                        {
                            learnedLetterNamesLNI[letter] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                                                                       //there's no mechanic to take this back to false--test out once and you're good
                        }
                    }
                    else
                    {
                        if (adaptiveCounter >= 2)
                        {
                            learnedLetterNamesLNI[letter] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                                                                       //there's no mechanic to take this back to false--test out once and you're good
                        }
                    }

                }
            }

            /*Populate answers and scores entered for this time
            string[] promptStorage = promptCycler.PromptSelect(globalTime);
            for (int wheel = 0; wheel < 6; wheel++)
            {
                promptText[wheel].text = promptStorage[wheel];
                responsesText[wheel].text = responses[wheel];
            }*/
        }

        if (currentScene == "LSI_Grader" )
        {
            gameText.text = "Test : Letter Sound Identification";
            timeText.text = "Time : " + globalTime;
            completeLSI[globalTime - 1] = 2;
            lsiDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            //Check for "Tested Out" Letters
            for (int letterIndex = 0; letterIndex < individual_LSI.GetLength(0); letterIndex++)
            {
                string letter = ((char)(letterIndex + 65)).ToString(); //65 is code for 'A'
                int adaptiveCounter = 0; //Var used to track 'consecutive' correct answers

                for (int time = 0; time < individual_LSI.GetLength(1); time++)
                {
                    if (time == globalTime-1)
                    {
                        if (individual_LSI[letterIndex, time] == AdaptiveResponse.Correct ||
                            individual_LSI[letterIndex, time] == AdaptiveResponse.CSKIP)
                        {
                            RLSI_letterText[letterIndex].text = "+";
                            RLSI_letterText[letterIndex].color = new Color(0, 0.6f, 0);
                        }
                        else
                        {
                            RLSI_letterText[letterIndex].text = "<color=red>-</color>";
                        }
                    }
                    
                    //If score was correct or CSkipped, increase adaptive counter
                    if (individual_LSI[letterIndex, time] == AdaptiveResponse.Correct ||
                        individual_LSI[letterIndex, time] == AdaptiveResponse.CSKIP)
                    {
                        adaptiveCounter++;
                    }

                    //If incorrect, reset adaptive counter. Note that we don't count ISKIP
                    else if  (individual_LSI[letterIndex, time] == AdaptiveResponse.Incorrect)
                    {
                        adaptiveCounter = 0;
                    }
                }

                if (exceptionalAdaptCharactersLSI.Contains(letter))
                {
                    if(adaptiveCounter>=3)
                    {
                        learnedLetterNamesLSI[letterIndex] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                        //there's no mechanic to take this back to false--test out once and you're good
                    }
                }
                else
                {
                    if(adaptiveCounter>=2)
                    {
                        learnedLetterNamesLSI[letterIndex] = true; //THIS IS OUR PROBLEM LINE--WHAT CHANGES WHEN TRUE
                        //there's no mechanic to take this back to false--test out once and you're good
                    }
                }
            }

            /*Populate answers and scores entered for this time
            string[] promptStorage = promptCycler.PromptSelect(globalTime);
            for (int wheel = 0; wheel < 6; wheel++)
            {
                promptText[wheel].text = promptStorage[wheel];
                responsesText[wheel].text = responses[wheel];
            }*/
        }
        
        if (currentScene == "BS_Grader" )
        {
            gameText.text = "Test : Beginning Sounds";
            timeText.text = "Time : " + globalTime;
            completeBS[globalTime - 1] = 2;
            bsDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            List<BSItem> universalItems;
            string json = Resources.Load<TextAsset>("bs_items").ToString();
            universalItems = JsonConvert.DeserializeObject<List<BSItem>>(json);
            
            //Check for "Tested Out" Letters
            int iterator = 0;

            for (int item = 0; item < individual_BS.GetLength(0); item++)
            {
                for (int time = 0; time < individual_BS.GetLength(1); time++)
                {
                    if (time == globalTime-1 && iterator < BS_items.Length)
                    {
                        if (individual_BS[item, time] == AdaptiveResponse.Correct)
                        {
                            BS_items[iterator].text = universalItems.Find(bsItem => bsItem.index.Equals(item)).item;
                            BS_letterText[iterator].text = "+";
                            BS_letterText[iterator].color = new Color(0, 0.6f, 0);
                            iterator++;
                        }
                        else if (individual_BS[item, time] == AdaptiveResponse.Incorrect)
                        {
                            BS_items[iterator].text = universalItems.Find(bsItem => bsItem.index.Equals(item)).item;
                            BS_letterText[iterator].text = "<color=red>-</color>";
                            iterator++;
                        }
                    }
                }
            }

            double x = final_BSscores[DataManager.globalTime - 1].Item1;
            //double percentile = (1 + Math.Sign(x) * Math.Sqrt(1 - Math.Exp(-2 * x * x / Math.PI))) / 2;
            //Debug.Log("percentile "+x.ToString("0.00"));
            double percentile = calculateStandardNormalPercenatage(x) * 100;
            BS_PercentileScore.text = "The relative ranking of this child to the 4-year-old age group: "+percentile.ToString("0.00")+"%";
            //The relative ranking of this child to the 4-year-old age group: XX%
        }

        if (currentScene == "CAP_Grader")
        {
            gameText.text = "Test : Concepts about Print";
            timeText.text = "Time : " + globalTime;
            completeCAP[globalTime - 1] = 2;
            capDateTimeField[globalTime - 1] = DateTime.Now.ToString("MM-dd-yyyy HH:mm");
            //List<BSItem> universalItems;
            //string json = Resources.Load<TextAsset>("bs_items").ToString();
            //universalItems = JsonConvert.DeserializeObject<List<BSItem>>(json);

            //Check for "Tested Out" Letters
            int iterator = 0;

            for (int item = 0; item < individual_CAP.GetLength(0); item++)
            {
                for (int time = 0; time < individual_CAP.GetLength(1); time++)
                {
                    if (time == globalTime - 1 && iterator < CAP_items.Length)
                    {
                        if (individual_CAP[item, time] == AdaptiveResponse.Correct)
                        {
                            CAP_items[iterator].text = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[item]];
                            CAP_letterText[iterator].text = "+";
                            CAP_letterText[iterator].color = new Color(0, 0.6f, 0);
                            iterator++;
                        }
                        else if (individual_CAP[item, time] == AdaptiveResponse.Incorrect)
                        {
                            CAP_items[iterator].text = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[item]];
                            CAP_letterText[iterator].text = "<color=red>-</color>";
                            iterator++;
                        }
                    }
                }
            }

            double x = final_CAPscores[DataManager.globalTime - 1].Item1;
            //double percentile = (1 + Math.Sign(x) * Math.Sqrt(1 - Math.Exp(-2 * x * x / Math.PI))) / 2;
            double percentile = calculateStandardNormalPercenatage(x) * 100;
            //Debug.Log("percentile " + x.ToString("0.00"));
            CAP_PercentileScore.text = "The relative ranking of this child to the 4-year-old age group: " + percentile.ToString("0.00") + "%";
            //The relative ranking of this child to the 4-year-old age group: XX%
        }

        //Report card - show all times
        if (currentScene == "RVocab")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for(int loop = 0; loop < 6; loop++) 
            {
                if (completeVocabulary[loop] == 2)
                {
                    expressivePercent[loop].text = ((grade_vocabularyExpressive[loop]*vocabularyTotalQuestions)/100).ToString("F0"); //Parameter ensures two decimal points
                    receptivePercent[loop].text = ((grade_vocabularyReceptive[loop] * vocabularyTotalQuestions)/ 100).ToString("F0");
                }
                else
                {
                    expressivePercent[loop].text = "";
                    receptivePercent[loop].text = "";
                }
            }
        }

        //Report card - show all times
        if (currentScene == "RCS")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for(int loop = 0; loop < 6; loop++) 
            {
                if (completeCS[loop] == 2)
                {
                    csScoresForResultPage[loop].text = grade_csTotal[loop].ToString("F0"); //Parameter ensures two decimal points
                }
                else
                {
                    csScoresForResultPage[loop].text = "";
                }
            }
        }

        //Report card - show all times
        if (currentScene == "RWriting")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for(int loop = 0; loop < 6; loop++) 
            {
                // writingNameScoreForResultPage[loop].text = individual_cs_name[loop].ToString("F0"); //Parameter ensures two decimal points
                // writingSentenceScoreForResultPage[loop].text = individual_cs_sentence[loop].ToString("F0"); //Parameter ensures two decimal points
                if (completeWriting[loop] == 2)
                {
                    if (individual_writing_score != null && individual_writing_score.Count > loop)
                    {
                        writingNameScoreForResultPage[loop].text = individual_writing_score[loop][0].ToString("F0"); //Parameter ensures two decimal points
                        writingSentenceScoreForResultPage[loop].text = individual_writing_score[loop][1].ToString("F0"); //Parameter ensures two decimal points
                    }
                    else
                    {
                        writingNameScoreForResultPage[loop].text = (-999).ToString("F0");
                        writingSentenceScoreForResultPage[loop].text = (-999).ToString("F0"); //Parameter ensures two decimal points
                    }
                }
                else
                {
                    writingNameScoreForResultPage[loop].text = "";
                    writingSentenceScoreForResultPage[loop].text = "";
                }
            
            }
        }

        //Report card - show all times
        if (currentScene == "RSR")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 3 due to issues reading unfully instantiated sizes
            for(int loop = 0; loop < 3; loop++) 
            {
                if (completeSR[loop] == 2)
                {
                    srScoresForResultPage[loop].text = grade_srTotal[loop].ToString("F0"); //Parameter ensures two decimal points
                }
                else
                {
                    srScoresForResultPage[loop].text = "";
                }
            }
        }

        //Report card - show all times
        if (currentScene == "RBookSum")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 3 due to issues reading unfully instantiated sizes
            for(int loop = 0; loop < 3; loop++) 
            {
                if (completeBookSum[loop] == 2)
                {
                    booksumScoresForResultPage[loop].text = grade_bookSumTotal[loop].ToString("F0"); //Parameter ensures two decimal points
                }
                else
                {
                    booksumScoresForResultPage[loop].text = "";
                }
            }
        }

        //RLI - show scores for each letter
        if (currentScene == "RLI")
        {
            //look for last good score
            childText.text = childID;
            /*for(int loop = 0; loop < learnedLetterNamesLNI.Length; loop++)
            {
                string result;
                if (learnedLetterNamesLNI[loop] == true)
                {
                    result = "<color=green>+</color>";
                }
                else result = "<color=red>-</color>";
                RLNI_letterText[loop].text = result;
            }*/

            for (int time = 0; time < individual_LNI.GetLength(1); time++)
            {
                int total_score = 0;
                for (int letter = 0; letter < individual_LNI.GetLength(0); letter++)
            {
                //string letterChar = ((char)(letter + 65)).ToString();
                //int adaptiveCounter = 0; //Var used to track 'consecutive' correct answers
                
                
                    if (time == 0) {
                        total_score = populateResults(letter, time, RLI_letterText1, individual_LNI, total_score);
                    }
                    else if (time == 1)
                    {
                        total_score = populateResults(letter, time, RLI_letterText2, individual_LNI, total_score);
                    }
                    else if (time == 2)
                    {
                        total_score = populateResults(letter, time, RLI_letterText3, individual_LNI, total_score);
                    }
                    else if (time == 3)
                    {
                        total_score = populateResults(letter, time, RLI_letterText4, individual_LNI, total_score);
                    }
                    else if (time == 4)
                    {
                        total_score = populateResults(letter, time, RLI_letterText5, individual_LNI, total_score);
                    }
                    else if (time == 5)
                    {
                        total_score = populateResults(letter, time, RLI_letterText6, individual_LNI, total_score);
                    }
                    
                }
                RLI_totalScore[time].text = total_score.ToString();
            }

            /*for(int loop = 0; loop < learnedLetterNamesLSI.Length; loop++)
            {
                string result;
                if (learnedLetterNamesLSI[loop] == true)
                {
                    result = "<color=green>+</color>";
                }
                else result = "<color=red>-</color>";
                RLSI_letterText[loop].text = result;
            }*/
            //if none, zero
            //else track back and add, exit once tested out


        }
        if (currentScene == "RLSI")
        {
            //look for last good score
            childText.text = childID;

            /*for (int loop = 0; loop < learnedLetterNamesLSI.Length; loop++)
            {
                string result;
                if (learnedLetterNamesLSI[loop] == true)
                {
                    result = "<color=green>+</color>";
                }
                else result = "<color=red>-</color>";
                RLSI_letterText[loop].text = result;
            }*/

            for (int time = 0; time < individual_LSI.GetLength(1); time++)
            {
                int total_score = 0;
                for (int letter = 0; letter < individual_LSI.GetLength(0); letter++)
            {
                //string letterChar = ((char)(letter + 65)).ToString();
                //int adaptiveCounter = 0; //Var used to track 'consecutive' correct answers

                    if (time == 0)
                    {
                        total_score = populateResults(letter, time, RLI_letterText1, individual_LSI, total_score);
                    }
                    else if (time == 1)
                    {
                        total_score = populateResults(letter, time, RLI_letterText2, individual_LSI, total_score);
                    }
                    else if (time == 2)
                    {
                        total_score = populateResults(letter, time, RLI_letterText3, individual_LSI, total_score);
                    }
                    else if (time == 3)
                    {
                        total_score = populateResults(letter, time, RLI_letterText4, individual_LSI, total_score);
                    }
                    else if (time == 4)
                    {
                        total_score = populateResults(letter, time, RLI_letterText5, individual_LSI, total_score);
                    }
                    else if (time == 5)
                    {
                        total_score = populateResults(letter, time, RLI_letterText6, individual_LSI, total_score);
                    }                    
                }
                RLI_totalScore[time].text = total_score.ToString();
            }
            //if none, zero
            //else track back and add, exit once tested out


        }

        //Report card - show all times
        if (currentScene == "RBS")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for (int loop = 0; loop < 6; loop++)
            {
                if(final_BSscores[loop] != null && completeBS[loop] == 2){
                    double percentile = calculateStandardNormalPercenatage(final_BSscores[loop].Item1) * 100;
                    BS_EAPScore[loop].text = percentile.ToString("0.00")+"%"; //Parameter ensures two decimal points
                }
                else
                {
                    BS_EAPScore[loop].text = "";
                }
            }
        }

        if (currentScene == "RCAP")
        {
            childText.text = childID;
            //Loop populates grades textboxes, hardcoded at 6 due to issues reading unfully instantiated sizes
            for (int loop = 0; loop < 6; loop++)
            {
                if (final_CAPscores[loop] != null && completeCAP[loop] == 2)
                {
                    double percentile = calculateStandardNormalPercenatage(final_CAPscores[loop].Item1) * 100;
                    CAP_EAPScore[loop].text = percentile.ToString("0.00") + "%"; //Parameter ensures two decimal points
                }
                else
                {
                    CAP_EAPScore[loop].text = "";
                }
            }
        }
    }

    //This function can be called to grade a current question
    //and adjust scores accordingly
    public void GradeQuestion()
    {
        //Calculate scores based on toggles
        if (currentScene == "Evaluator")
        {
            if (primaryToggle.isOn)
            {
                individual_expressive.Add(true);
                individual_receptive.Add(true);
                individual_total.Add(2);
                score_expressive++;
                score_receptive++;
            }
            else if (receptiveToggle.isOn) //Only visible if expressive is off
            {
                individual_expressive.Add(false);
                individual_receptive.Add(true);
                individual_total.Add(1);
                score_receptive++;
            }
            else
            {
                individual_expressive.Add(false);
                individual_receptive.Add(false);
                individual_total.Add(0);
            }
            
            if (expressiveFlag.isOn)
                individual_expressiveFlag.Add(true);
            else
                individual_expressiveFlag.Add(false);
            
            if (receptiveFlag.isOn)
                individual_receptiveFlag.Add(true);
            else
                individual_receptiveFlag.Add(false);

            if (responseField != null)
            {
                responses.Add(responseField.text);
            }
        }

        else if (currentScene == "Evaluator_Vocab")
        {
            if (advanceVocabItem.expressive && primaryToggle.isOn)
            {
                individual_expressive.Add(true);
                individual_receptive.Add(true);
                individual_total.Add(2);
                score_expressive++;
                score_receptive++;
            }
            else if (!advanceVocabItem.expressive && receptiveToggle.isOn) //Only visible if expressive is off
            {
                individual_expressive.Add(false);
                individual_receptive.Add(true);
                individual_total.Add(1);
                score_receptive++;
            }
            else if(!advanceVocabItem.expressive && receptiveToggleNo.isOn)
            {
                individual_expressive.Add(false);
                individual_receptive.Add(false);
                individual_total.Add(0);
            }

            if (advanceVocabItem.expressive)
            {
                if (responseField != null)
                {
                    responses.Add(responseField.text);
                }
                if (expressiveFlag.isOn)
                    individual_expressiveFlag.Add(true);
                else
                    individual_expressiveFlag.Add(false);

                if(primaryToggle.isOn)
                    individual_receptiveFlag.Add(false);

            }
            if (!advanceVocabItem.expressive)
            {
                if (receptiveFlag.isOn)
                    individual_receptiveFlag.Add(true);
                else
                    individual_receptiveFlag.Add(false);
            }

        }
        //Calculate scores based on toggles
        if (currentScene == "CS_Evaluator" || currentScene == "CS_Evaluator_1")
        {
            Debug.Log("score getting incremented");
            if (primaryToggle.isOn)
            {
                individual_cs.Add(true);
                score_cs++;
            }
            else
            {
                individual_cs.Add(false);
            }

            int timeIndex = globalTime - 1; //Global Time starts at 1 instead of 0
            
        }

        if(currentScene == "SR_Evaluator" || currentScene == "SR_Evaluator_2")
        {
            for(int i = 0; i < srToggleGroups.Length; i++)
            {
                individual_srQues.Add(srPromptText[i].text);
                question_no++;
                Toggle[] correctAndIncorrect = srToggleGroups[i].GetComponentsInChildren<Toggle>();
                if (correctAndIncorrect[1].isOn)
                {
                    individual_sr.Add(true);
                    score_sr++;
                }
                else
                {
                    individual_sr.Add(false);
                }
            }

            if (question_no == 8 && score_sr > 0)
            {
                score_sr = score_sr + 8;
            }

        }
        //Calculate scores based on toggles
        /*if (currentScene == "SR_Evaluator" || currentScene == "SR_Evaluator_2")
        {
            question_no++;
            if (primaryToggle.isOn)
            {
                individual_sr.Add(true);
                score_sr++;
            }
            else
            {
                individual_sr.Add(false);
            }
            if(question_no==8 && score_sr >0){
                score_sr = score_sr +8;
            }
            individual_srQues.Add(questionField.text);

            int timeIndex = globalTime - 1; //Global Time starts at 1 instead of 0
                        
        }*/

        //Calculate scores based on toggles
        if (currentScene == "BookSum_Evaluator" || currentScene == "BookSum_Evaluator_2" || currentScene =="BookSum_Evaluator_3")
        {
            question_no++;
            if (primaryToggle.isOn)
            {
                individual_bookSum.Add(true);
                score_bookSum++;
                Debug.Log("question_no "+question_no);
                
                if (currentScene == "BookSum_Evaluator_2" && question_no == 7)
                {
                    if (bookSumExtraMarkToggle.isOn)
                    {
                        score_bookSum++;
                    }
                    bookSumExtraMarkToggle.gameObject.SetActive(false);
                    textBookSumExtraMarkToggle.gameObject.SetActive(false);
}
                else if(currentScene == "BookSum_Evaluator_2" && question_no == 6)
                {
                    bookSumExtraMarkToggle.gameObject.SetActive(true);
                    textBookSumExtraMarkToggle.gameObject.SetActive(true);
                }
                /*if(currentScene=="BookSum_Evaluator_2" && question_no==4){
                    score_bookSum++;
                }*/
            }
            else
            {
                individual_bookSum.Add(false);
            }
            if(question_no==8 && score_bookSum >0){
                score_bookSum = score_bookSum +3;
            }
            individual_bookSumQues.Add(questionField.text);

            int timeIndex = globalTime - 1; //Global Time starts at 1 instead of 0
            
        }

        //Calculate scores based on toggles
        if (currentScene == "Writing_Evaluator")
        {
            if (name0Toggle.isOn)
                individual_name_score = 0;
            else if(name1Toggle.isOn)
                individual_name_score = 1;
            else if(name2Toggle.isOn)
                individual_name_score = 2;
            else if(name3Toggle.isOn)
                individual_name_score = 3;
            else if(name4Toggle.isOn)
                individual_name_score = 4;

            if (sen0Toggle.isOn)
                individual_sentence_score = 0;
            else if(sen1Toggle.isOn)
                individual_sentence_score = 1;
            else if(sen2Toggle.isOn)
                individual_sentence_score = 2;
            else if(sen3Toggle.isOn)
                individual_sentence_score = 3;
            else if(sen4Toggle.isOn)
                individual_sentence_score = 4;

            int timeIndex = globalTime - 1;
            // Add individual answers
            // individual_cs_name[timeIndex] = individual_name_score;
            // individual_cs_sentence[timeIndex] = individual_sentence_score;
            List<int> writing_scores = new List<int>(){-999, -999};
            writing_scores[0] = individual_name_score;
            writing_scores[1] = individual_sentence_score;
            // individual_writing_score[timeIndex] = writing_scores;
            //individual_writing_score.Insert(timeIndex, writing_scores);
            individual_writing_score[timeIndex] = writing_scores;
        }

        if (currentScene == "LNI_Evaluator")
        {
            //Get prompt array for current time, get exact prompt we're on, convert from str to char to int to number of alphabet
            int charNum = (int)(char.Parse(promptCycler.PromptSelect(globalTime)[promptCycler.iterator])) - 65; //'A' ASCII int is 65   

            if (primaryToggle.isOn)
            {
                individual_LNI[charNum, globalTime-1] = AdaptiveResponse.Correct;
                responses.Add("<span style='color: rgb(0, 150, 0);'>Correct</span>");
            }
            else
            {
                individual_LNI[charNum, globalTime-1] = AdaptiveResponse.Incorrect;
                responses.Add("<color=red>Incorrect</color>");
            }
            if(exportImportRef == "ID"){
                /*assessorIdLniReponses.Insert(globalTime-1, assessorID);
                teacherIdLniResponses.Insert(globalTime-1, teacherID);
                classroomIdLniResponses.Insert(globalTime-1, classroomID);*/
                assessorIdLniReponses[globalTime - 1] = assessorID;
                teacherIdLniResponses[globalTime - 1] = teacherID;
                classroomIdLniResponses[globalTime - 1] = classroomID;
                /*assessorIdLniReponses.Add(assessorID);
                teacherIdLniResponses.Add(teacherID);
                classroomIdLniResponses.Add(classroomID);*/
            } else{
                Debug.Log("LNI entered global time "+globalTime+" assessorID "+assessorID);
                /*assessorNameLniReponses.Insert(globalTime-1, assessorID);
                teacherNameLniResponses.Insert(globalTime-1, teacherID);
                classroomNameLniResponses.Insert(globalTime-1, classroomID);*/
                assessorNameLniReponses[globalTime - 1] = assessorID;
                teacherNameLniResponses[globalTime - 1] = teacherID;
                classroomNameLniResponses[globalTime - 1] = classroomID;
                /*assessorNameLniReponses.Add(assessorID);
                teacherNameLniResponses.Add(teacherID);
                classroomNameLniResponses.Add(classroomID);*/
            }
        }

        if (currentScene == "LSI_Evaluator")
        {
            //Get prompt array for current time, get exact prompt we're on, convert from str to char to int to number of alphabet
            int charNum = (int)(char.Parse(promptCycler.PromptSelect(globalTime)[promptCycler.iterator])) - 65; //'A' ASCII int is 65   

            if (primaryToggle.isOn)
            {
                individual_LSI[charNum, globalTime-1] = AdaptiveResponse.Correct;
                responses.Add("<span style='color: rgb(0, 150, 0);'>Correct</span>");
            }
            else
            {
                individual_LSI[charNum, globalTime-1] = AdaptiveResponse.Incorrect;
                responses.Add("<color=red>Incorrect</color>");
            }
            if(exportImportRef == "ID"){
                /*assessorIdLsiReponses.Insert(globalTime-1, assessorID);
                teacherIdLsiResponses.Insert(globalTime-1, teacherID);
                classroomIdLsiResponses.Insert(globalTime-1, classroomID);*/
                assessorIdLsiReponses[globalTime - 1] = assessorID;
                teacherIdLsiResponses[globalTime - 1] = teacherID;
                classroomIdLsiResponses[globalTime - 1] = classroomID;
                /*assessorIdLsiReponses.Add(assessorID);
                teacherIdLsiResponses.Add(teacherID);
                classroomIdLsiResponses.Add(classroomID);*/
            } else{
                Debug.Log("LSI entered global time " + globalTime + " assessorID " + assessorID);
                /*assessorNameLsiReponses.Insert(globalTime-1, assessorID);
                teacherNameLsiResponses.Insert(globalTime-1, teacherID);
                classroomNameLsiResponses.Insert(globalTime-1, classroomID);*/
                assessorNameLsiReponses[globalTime - 1] = assessorID;
                teacherNameLsiResponses[globalTime - 1] = teacherID;
                classroomNameLsiResponses[globalTime - 1] = classroomID;
                /*assessorNameLsiReponses.Add(assessorID);
                teacherNameLsiResponses.Add(teacherID);
                classroomNameLsiResponses.Add(classroomID);*/
            }
        }

        if (currentScene == "BS_Evaluator")
        {
            BSItem itemToGrade = promptCyclerBS.prompts.promptsToDisplay[promptCyclerBS.iterator];
            if (!itemToGrade.item.Equals(Prompts_BS.testItem))
            {
                if (primaryToggle.isOn)
                {
                    individual_BS[itemToGrade.index, globalTime-1] = AdaptiveResponse.Correct;
                }
                else
                {
                    individual_BS[itemToGrade.index, globalTime-1] = AdaptiveResponse.Incorrect;
                }
                if (!String.IsNullOrEmpty(bsChildResponseField.text))
                    individual_BSChildResponse[itemToGrade.index, globalTime-1] = bsChildResponseField.text;
            }
            if(exportImportRef == "ID"){
                /*assessorIdBsReponses.Insert(globalTime-1, assessorID);
                teacherIdBsResponses.Insert(globalTime-1, teacherID);
                classroomIdBsResponses.Insert(globalTime-1, classroomID);*/
                assessorIdBsReponses[globalTime - 1] = assessorID;
                teacherIdBsResponses[globalTime - 1] = teacherID;
                classroomIdBsResponses[globalTime - 1] = classroomID;
                /*assessorIdBsReponses.Add(assessorID);
                teacherIdBsResponses.Add(teacherID);
                classroomIdBsResponses.Add(classroomID);*/
            } else{
                Debug.Log("BS entered global time " + globalTime + " assessorID " + assessorID);
                /*assessorNameBsReponses.Insert(globalTime-1, assessorID);
                teacherNameBsResponses.Insert(globalTime-1, teacherID);
                classroomNameBsResponses.Insert(globalTime-1, classroomID);*/
                assessorNameBsReponses[globalTime - 1] = assessorID;
                teacherNameBsResponses[globalTime - 1] = teacherID;
                classroomNameBsResponses[globalTime - 1] = classroomID;
                /*assessorNameBsReponses.Add(assessorID);
                teacherNameBsResponses.Add(teacherID);
                classroomNameBsResponses.Add(classroomID);*/
            }
        }

        if (currentScene == "CAP_Evaluator")
        {
            double difficulty = advanceCAPItem.promptDisplayDifficulty[advanceCAPItem.iterator];
            if (difficulty != 0)
            {
                int difficultyIndex = (AdvanceCAPItem.prompts_difficulties_universal).IndexOf(difficulty);
                if (primaryToggle.isOn)
                {
                    individual_CAP[difficultyIndex, globalTime - 1] = AdaptiveResponse.Correct;
                }
                else
                {
                    individual_CAP[difficultyIndex, globalTime - 1] = AdaptiveResponse.Incorrect;
                }
                /*if (!String.IsNullOrEmpty(capChildResponseField.text))
                    individual_CAPChildResponse[difficultyIndex, globalTime - 1] = capChildResponseField.text;*/
            }
            if (exportImportRef == "ID")
            {
                /*assessorIdCAPReponses.Insert(globalTime-1, assessorID);
                teacherIdCAPResponses.Insert(globalTime-1, teacherID);
                classroomIdCAPResponses.Insert(globalTime-1, classroomID);*/
                assessorIdCAPReponses[globalTime - 1] = assessorID;
                teacherIdCAPResponses[globalTime - 1] = teacherID;
                classroomIdCAPResponses[globalTime - 1] = classroomID;
                /*assessorIdCAPReponses.Add(assessorID);
                teacherIdCAPResponses.Add(teacherID);
                classroomIdCAPResponses.Add(classroomID);*/
            }
            else
            {
                Debug.Log("CAP entered global time " + globalTime + " assessorID " + assessorID);
                /*assessorNameCAPReponses.Insert(globalTime-1, assessorID);
                teacherNameCAPResponses.Insert(globalTime-1, teacherID);
                classroomNameCAPResponses.Insert(globalTime-1, classroomID);*/
                assessorNameCAPReponses[globalTime - 1] = assessorID;
                teacherNameCAPResponses[globalTime - 1] = teacherID;
                classroomNameCAPResponses[globalTime - 1] = classroomID;
                /*assessorNameCAPReponses.Add(assessorID);
                teacherNameCAPResponses.Add(teacherID);
                classroomNameCAPResponses.Add(classroomID);*/
            }
        }
    }


    public int populateResults(int letter, int time, TextMeshProUGUI[] RLI, AdaptiveResponse[,] individual_LI, int total_score)
    {
        if (individual_LI[letter, time] == AdaptiveResponse.Correct ||
                            individual_LI[letter, time] == AdaptiveResponse.CSKIP)
        {
            RLI[letter].text = "+";
            RLI[letter].color = new Color(0, 0.6f, 0);
            total_score++;
        }
        else if (individual_LI[letter, time] == AdaptiveResponse.Incorrect ||
            individual_LI[letter, time] == AdaptiveResponse.ISKIP)
        {
            RLI[letter].text = "<color=red>-</color>";
        }
        else
        {
            RLI[letter].text = "";
        }
        return total_score;
    }
    //General-purpose function
    //that can be called to store data before scene transitions
    public void SceneCleanup()
    {
        Debug.Log("currentScene " + currentScene);

        //Save UserInfo
        if (currentScene == "UserInfo")
        {
            //Save child name or ID, with ID taking precedence
            exportImportRef = "Name";
            teacherID = teacherNameField.text;
            if (teacherIDField.text != "")
                teacherID = teacherIDField.text;
            assessorID = assessorNameField.text;
            if (assessorIDField.text != "")
                assessorID = assessorIDField.text;
            childID = childNameField.text;
            if(childNameField.text != "")
            {
                childNameField.text = childNameField.text.ToLower();
            }
            if(childIDField.text != "") {
                childID = childIDField.text;
                childIDField.text = childIDField.text.ToLower();
                exportImportRef = "ID";
            }
            if (childID != "")
            {
                childID = childID.ToLower();
            }
            classroomID = classroomField.text;
            if(classroomIDField.text != "")
                classroomID = classroomIDField.text;
            
        }

        if (currentScene == "UserInfoMultiple")
        {
            //Save child name or ID, with ID taking precedence
            exportImportRef = "Name";
            
            childID = childNameField.text;
            if (childNameField.text != "")
            {
                childNameField.text = childNameField.text.ToLower();
            }
            if (childIDField.text != "")
            {
                childID = childIDField.text;
                childIDField.text = childIDField.text.ToLower();
                exportImportRef = "ID";
            }
            if (childID != "")
            {
                childID = childID.ToLower();
            }
            

        }

        //Store child name for letter randomization
        if (currentScene == "LNI_Instructions" && null != lniNameField)
        {
            childNameLNI = lniNameField.text;
        }

        //Grade final question and calculate results before moving on
        if (currentScene == "CS_Evaluator" || currentScene == "CS_Evaluator_1")
        {
            Debug.Log("currentScene "+currentScene);
            Debug.Log("continuation_flag " + continuation_flag);
            GradeQuestion();
            /*if (DataManager.currentScene != DataManager.continuation_scene)
            {
                GradeQuestion();
            }*/
            int timeIndex = globalTime - 1;
            Debug.Log("score_cs " + score_cs);
            if (currentScene == "CS_Evaluator" && score_cs > 0)
            {
                continuation_flag = true;
                continuation_scene = "CS_Evaluator_1";
            }
            /*if (currentScene == "CS_Evaluator_1")
            {
                continuation_flag = false;
            }*/

            // Add individual answers
            if (grade_csTotal == null) {
                grade_csTotal = new int[6] { -1, -1, -1, -1, -1, -1 };
            }

            if ((currentScene == "CS_Evaluator" && continuation_flag == false) || currentScene == "CS_Evaluator_1")
            {
                grade_csTotal[timeIndex] = score_cs;
            //individual_csResponse.Insert(timeIndex, individual_cs);
            individual_csResponse[timeIndex] = (individual_cs);
            //individual_csResponse.Add(individual_cs);
            if (exportImportRef == "ID") {
                /*assessorIdCSReponses.Insert(timeIndex, assessorID);
                teacherIdCSResponses.Insert(timeIndex, teacherID);
                classroomIdCSResponses.Insert(timeIndex, classroomID);*/
                /*assessorIdCSReponses.Add(assessorID);
                teacherIdCSResponses.Add(teacherID);
                classroomIdCSResponses.Add(classroomID);*/
                assessorIdCSReponses[timeIndex] = (assessorID);
                teacherIdCSResponses[timeIndex] = (teacherID);
                classroomIdCSResponses[timeIndex] = (classroomID);
            } else {
                /*assessorNameCSReponses.Insert(timeIndex, assessorID);
                teacherNameCSResponses.Insert(timeIndex, teacherID);
                classroomNameCSResponses.Insert(timeIndex, classroomID);*/
                /*assessorNameCSReponses.Add(assessorID);
                teacherNameCSResponses.Add(teacherID);
                classroomNameCSResponses.Add(classroomID);*/
                assessorNameCSReponses[timeIndex] = (assessorID);
                teacherNameCSResponses[timeIndex] = (teacherID);
                classroomNameCSResponses[timeIndex] = (classroomID);
            }
        }
        }

        
        //Grade final question and calculate results before moving on
        if (currentScene == "SR_Evaluator" || currentScene == "SR_Evaluator_2")
        {
            GradeQuestion();
            int timeIndex = globalTime - 1;
            
            if (currentScene == "SR_Evaluator" && score_sr ==0){
                continuation_flag = true;
                continuation_scene = "SR_Evaluator_2";
            }
            if(currentScene == "SR_Evaluator_2"){
                continuation_flag = false;                
            }
            if(grade_srTotal==null){
                grade_srTotal = new int[3] {-1,-1,-1};
            }
            if((currentScene == "SR_Evaluator" && continuation_flag==false) || currentScene == "SR_Evaluator_2"){
                grade_srTotal[timeIndex] = score_sr;
                individual_srResponse[timeIndex] = individual_sr;
                individual_srQuestions[timeIndex] = individual_srQues;
                //individual_srResponse.Add(individual_sr);
                //individual_srQuestions.Add(individual_srQues);
                /*individual_srResponse.Insert(timeIndex, individual_sr);
                individual_srQuestions.Insert(timeIndex, individual_srQues);*/

                if (exportImportRef == "ID"){
                    /*assessorIdSRReponses.Insert(timeIndex, assessorID);
                    teacherIdSRResponses.Insert(timeIndex, teacherID);
                    classroomIdSRResponses.Insert(timeIndex, classroomID);*/
                    /*assessorIdSRReponses.Add(assessorID);
                    teacherIdSRResponses.Add(teacherID);
                    classroomIdSRResponses.Add(classroomID);*/
                    assessorIdSRReponses[timeIndex] = (assessorID);
                    teacherIdSRResponses[timeIndex] = (teacherID);
                    classroomIdSRResponses[timeIndex] = (classroomID);
                } else{
                    /*assessorNameSRReponses.Insert(timeIndex, assessorID);
                    teacherNameSRResponses.Insert(timeIndex, teacherID);
                    classroomNameSRResponses.Insert(timeIndex, classroomID);*/
                    /*assessorNameSRReponses.Add(assessorID);
                    teacherNameSRResponses.Add(teacherID);
                    classroomNameSRResponses.Add(classroomID);*/
                    assessorNameSRReponses[timeIndex] = (assessorID);
                    teacherNameSRResponses[timeIndex] = (teacherID);
                    classroomNameSRResponses[timeIndex] = (classroomID);
                }
            }
        }

        //Grade final question and calculate results before moving on
        if (currentScene == "BookSum_Evaluator" || currentScene == "BookSum_Evaluator_2" || currentScene == "BookSum_Evaluator_3")
        {
            GradeQuestion();
            int timeIndex = globalTime - 1;
            
            if (currentScene == "BookSum_Evaluator" && question_no==3 && score_bookSum == 0 /*grade_bookSumTotal[timeIndex] == 0*/)
            {
                continuation_flag = true;
                continuation_scene = "BookSum_Evaluator_3";
            } else if(currentScene == "BookSum_Evaluator" && question_no==3 && score_bookSum<=3 /*grade_bookSumTotal[timeIndex] <=3*/){
                continuation_flag = true;
                continuation_scene = "BookSum_Evaluator_2";
            }
            if(currentScene == "BookSum_Evaluator_2" || currentScene == "BookSum_Evaluator_3"){
                continuation_flag = false;
            }

            if(grade_bookSumTotal==null){
                grade_bookSumTotal = new int[3] {-1,-1,-1};
            }
            if(continuation_flag == false) {
            grade_bookSumTotal[timeIndex] = score_bookSum;
            individual_bookSumResponse[timeIndex] = (individual_bookSum);
            individual_bookSumQuestions[timeIndex] = (individual_bookSumQues);
             //individual_bookSumResponse.Add(individual_bookSum);
             //individual_bookSumQuestions.Add(individual_bookSumQues);
                /*individual_bookSumResponse.Insert(timeIndex, individual_bookSum);
                individual_bookSumQuestions.Insert(timeIndex, individual_bookSumQues);*/

                if (exportImportRef == "ID"){
                    /*assessorIdBookSumReponses.Insert(timeIndex, assessorID);
                    teacherIdBookSumResponses.Insert(timeIndex, teacherID);
                    classroomIdBookSumResponses.Insert(timeIndex, classroomID);*/
                    assessorIdBookSumReponses[timeIndex]= (assessorID);
                    teacherIdBookSumResponses[timeIndex] = (teacherID);
                    classroomIdBookSumResponses[timeIndex] = (classroomID);
                    /*assessorIdBookSumReponses.Add(assessorID);
                    teacherIdBookSumResponses.Add(teacherID);
                    classroomIdBookSumResponses.Add(classroomID);*/
                } else{
                    /*assessorNameBookSumReponses.Insert(timeIndex, assessorID);
                    teacherNameBookSumResponses.Insert(timeIndex, teacherID);
                    classroomNameBookSumResponses.Insert(timeIndex, classroomID);*/
                    /*assessorNameBookSumReponses.Add(assessorID);
                    teacherNameBookSumResponses.Add(teacherID);
                    classroomNameBookSumResponses.Add(classroomID);*/
                    assessorNameBookSumReponses[timeIndex] = (assessorID);
                    teacherNameBookSumResponses[timeIndex] = (teacherID);
                    classroomNameBookSumResponses[timeIndex] = (classroomID);
                }
            }
        }

        //Grade final question and calculate results before moving on
        if (currentScene == "Writing_Evaluator")
        {
            GradeQuestion();
            int timeIndex = globalTime - 1;
            if(exportImportRef == "ID"){
                /*assessorIdWritingReponses.Insert(timeIndex, assessorID);
                teacherIdWritingResponses.Insert(timeIndex, teacherID);
                classroomIdWritingResponses.Insert(timeIndex, classroomID);*/
                /*assessorIdWritingReponses.Add(assessorID);
                teacherIdWritingResponses.Add(teacherID);
                classroomIdWritingResponses.Add(classroomID);*/
                assessorIdWritingReponses[timeIndex] = (assessorID);
                teacherIdWritingResponses[timeIndex] = (teacherID);
                classroomIdWritingResponses[timeIndex] = (classroomID);
            } else{
                /*assessorNameWritingReponses.Insert(timeIndex, assessorID);
                teacherNameWritingResponses.Insert(timeIndex, teacherID);
                classroomNameWritingResponses.Insert(timeIndex, classroomID);*/
                /*assessorNameWritingReponses.Add(assessorID);
                teacherNameWritingResponses.Add(teacherID);
                classroomNameWritingResponses.Add(classroomID);*/
                assessorNameWritingReponses[timeIndex] = (assessorID);
                teacherNameWritingResponses[timeIndex] = (teacherID);
                classroomNameWritingResponses[timeIndex] = (classroomID);
            }
        }

        //Grade final question and calculate results before moving on
        if (currentScene == "Evaluator" || currentScene == "Evaluator_Vocab")
        {
            GradeQuestion();
            int timeIndex = globalTime - 1; //Global Time starts at 1 instead of 0
            //*100 for percentile
            grade_vocabularyExpressive[timeIndex] = (score_expressive / vocabularyTotalQuestions) * 100;
            grade_vocabularyReceptive[timeIndex] = (score_receptive / vocabularyTotalQuestions) * 100;
            score_total = score_expressive + score_receptive;
            grade_vocabularyTotal[timeIndex] = (score_total / (vocabularyTotalQuestions * 2)) * 100;

            // Add individual answers
            /*individual_vocabularyExpressive.Add(individual_expressive);
            individual_vocabularyReceptive.Add(individual_receptive);
            individual_vocabularyExpressiveFlag.Add(individual_expressiveFlag);
            individual_vocabularyReceptiveFlag.Add(individual_receptiveFlag);
            individual_vocabularyResponses.Add(responses);*/
            individual_vocabularyExpressive[timeIndex] = (individual_expressive);
            individual_vocabularyReceptive[timeIndex] = (individual_receptive);
            individual_vocabularyExpressiveFlag[timeIndex] = (individual_expressiveFlag);
            individual_vocabularyReceptiveFlag[timeIndex] = (individual_receptiveFlag);
            individual_vocabularyResponses[timeIndex] = (responses);
            /*individual_vocabularyExpressive.Insert(timeIndex, individual_expressive);
            individual_vocabularyReceptive.Insert(timeIndex, individual_receptive);
            individual_vocabularyExpressiveFlag.Insert(timeIndex, individual_expressiveFlag);
            individual_vocabularyReceptiveFlag.Insert(timeIndex, individual_receptiveFlag);
            individual_vocabularyResponses.Insert(timeIndex, responses);*/
            if (exportImportRef == "ID"){
                /*assessorIdVocabReponses.Add(assessorID);
                teacherIdVocabResponses.Add(teacherID);
                classroomIdVocabResponses.Add(classroomID);*/
                assessorIdVocabReponses[timeIndex] = (assessorID);
                teacherIdVocabResponses[timeIndex] = (teacherID);
                classroomIdVocabResponses[timeIndex] = (classroomID);
                /*assessorIdVocabReponses.Insert(timeIndex, assessorID);
                teacherIdVocabResponses.Insert(timeIndex, teacherID);
                classroomIdVocabResponses.Insert(timeIndex, classroomID);*/
            } else{
                /*assessorNameVocabReponses.Add(assessorID);
                teacherNameVocabResponses.Add(teacherID);
                classroomNameVocabResponses.Add(classroomID);*/
                assessorNameVocabReponses[timeIndex] = (assessorID);
                teacherNameVocabResponses[timeIndex] = (teacherID);
                classroomNameVocabResponses[timeIndex] = (classroomID);
                /*assessorNameVocabReponses.Insert(timeIndex, assessorID);
                teacherNameVocabResponses.Insert(timeIndex, teacherID);
                classroomNameVocabResponses.Insert(timeIndex, classroomID);*/
            }
        }
    }

    public static double calculateStandardNormalPercenatage(double z)
    {
        if (z < -6.0)
        {
            return 0.0;
        }
        else if (z > 6.0)
        {
            return 1.0;
        }
        else
        {
            const double b1 = 0.31938153;
            const double b2 = -0.356563782;
            const double b3 = 1.781477937;
            const double b4 = -1.821255978;
            const double b5 = 1.330274429;
            const double p = 0.2316419;
            const double c2 = 0.3989423;
            double a = Math.Abs(z);
            double t = 1.0 / (1.0 + a * p);
            double b = c2 * Math.Exp((-z) * z / 2.0);
            double n = ((((b5 * t + b4) * t + b3) * t + b2) * t + b1) * t;
            n = 1.0 - b * n;
            if (z < 0.0)
            {
                return 1.0 - n;
            }
            else
            {
                return n;
            }
        }
    }
}
