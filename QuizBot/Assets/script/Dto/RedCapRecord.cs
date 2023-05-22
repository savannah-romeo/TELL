using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
// Represents a sample record in RedCap across all instruments
public class RedCapRecord
{
    [JsonProperty("record_id", NullValueHandling = NullValueHandling.Ignore)]
    public int? recordID = null;
    [JsonProperty("teacher_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherID = null;
    [JsonProperty("assessor_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorID = null;
    [JsonProperty("child_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string childID = null;
    [JsonProperty("classroom_id", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomID = null;
    [JsonProperty("teacher_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherName = null;
    [JsonProperty("assessor_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorName = null;
    [JsonProperty("child_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string childName = null;
    [JsonProperty("classroom_name", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomName = null;

    [JsonProperty("redcap_repeat_instrument", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string redcapRepeatInstrument = null;
    [JsonProperty("redcap_repeat_instance", NullValueHandling = NullValueHandling.Ignore)]
    public int? redcapRepeatInstance = null;
    
    [JsonProperty("vocab_session", NullValueHandling = NullValueHandling.Ignore)]
    public int? vocabSession = null;

    [JsonProperty("assessor_id_vocab", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdVocab = null;
    [JsonProperty("teacher_id_vocab", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdVocab = null;
    [JsonProperty("classroom_id_vocab", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdVocab = null;
    [JsonProperty("assessor_name_vocab", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameVocab = null;
    [JsonProperty("teacher_name_vocab", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameVocab = null;
    [JsonProperty("classroom_name_vocab", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameVocab = null;
    
    [JsonProperty("q1_expressive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q1Expressive = null;
    [JsonProperty("q1_receptive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q1Receptive = null;
    [JsonProperty("q1_expressive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q1ExpressiveFlag = null;
    [JsonProperty("q1_receptive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q1ReceptiveFlag = null;
    [JsonProperty("q1_solution", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string q1Solution = null;
    
    [JsonProperty("q2_expressive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q2Expressive = null;
    [JsonProperty("q2_receptive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q2Receptive = null;
    [JsonProperty("q2_expressive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q2ExpressiveFlag = null;
    [JsonProperty("q2_receptive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q2ReceptiveFlag = null;
    [JsonProperty("q2_solution", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string q2Solution = null;
    
    [JsonProperty("q3_expressive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q3Expressive = null;
    [JsonProperty("q3_receptive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q3Receptive = null;
    [JsonProperty("q3_expressive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q3ExpressiveFlag = null;
    [JsonProperty("q3_receptive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q3ReceptiveFlag = null;
    [JsonProperty("q3_solution", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string q3Solution = null;
    
    [JsonProperty("q4_expressive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q4Expressive = null;
    [JsonProperty("q4_receptive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q4Receptive = null;
    [JsonProperty("q4_expressive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q4ExpressiveFlag = null;
    [JsonProperty("q4_receptive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q4ReceptiveFlag = null;
    [JsonProperty("q4_solution", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string q4Solution = null;
    
    [JsonProperty("q5_expressive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q5Expressive = null;
    [JsonProperty("q5_receptive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q5Receptive = null;
    [JsonProperty("q5_expressive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q5ExpressiveFlag = null;
    [JsonProperty("q5_receptive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q5ReceptiveFlag = null;
    [JsonProperty("q5_solution", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string q5Solution = null;
    
    [JsonProperty("q6_expressive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q6Expressive = null;
    [JsonProperty("q6_receptive", NullValueHandling = NullValueHandling.Ignore)]
    public int? q6Receptive = null;
    [JsonProperty("q6_expressive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q6ExpressiveFlag = null;
    [JsonProperty("q6_receptive_flag", NullValueHandling = NullValueHandling.Ignore)]
    public int? q6ReceptiveFlag = null;
    [JsonProperty("q6_solution", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string q6Solution = null;

    [JsonProperty("vocabulary_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? vocabularyComplete = null;

    //Clapping Syllables
    [JsonProperty("cs_session", NullValueHandling = NullValueHandling.Ignore)]
    public int? csSession = null;

    [JsonProperty("assessor_id_cs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdCS = null;
    [JsonProperty("teacher_id_cs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdCS = null;
    [JsonProperty("classroom_id_cs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdCS = null;
    [JsonProperty("assessor_name_cs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameCS = null;
    [JsonProperty("teacher_name_cs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameCS = null;
    [JsonProperty("classroom_name_cs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameCS = null;
    [JsonProperty("cs_score", NullValueHandling = NullValueHandling.Ignore)]
    public int? csScore = null;
    [JsonProperty("popcorn_response", NullValueHandling = NullValueHandling.Ignore)]
    public int? popcornResponse = null;
    [JsonProperty("teacher_response", NullValueHandling = NullValueHandling.Ignore)]
    public int? teacherResponse = null;    
    [JsonProperty("umbrella_response", NullValueHandling = NullValueHandling.Ignore)]
    public int? umbrellaResponse = null;

    [JsonProperty("clapping_syllables_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? clappingSyllablesComplete = null;

    //Writing Syllables
    [JsonProperty("writing_session_no", NullValueHandling = NullValueHandling.Ignore)]
    public int? writingSessionNo = null;

    [JsonProperty("assessor_id_writing", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdWriting = null;
    [JsonProperty("teacher_id_writing", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdWriting = null;
    [JsonProperty("classroom_id_writing", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdWriting = null;
    [JsonProperty("assessor_name_writing", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameWriting = null;
    [JsonProperty("teacher_name_writing", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameWriting = null;
    [JsonProperty("classroom_name_writing", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameWriting = null;
    [JsonProperty("name_writing", NullValueHandling = NullValueHandling.Ignore)]
    public int? nameWritingScore = null;
    [JsonProperty("sentence_points", NullValueHandling = NullValueHandling.Ignore)]
    public int? sentenceWritingScore = null;

    [JsonProperty("writing_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? writingComplete = null;

    //Story Retell Syllables
    [JsonProperty("sr_session", NullValueHandling = NullValueHandling.Ignore)]
    public int? srSession = null;

    [JsonProperty("assessor_id_sr", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdSR = null;
    [JsonProperty("teacher_id_sr", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdSR = null;
    [JsonProperty("classroom_id_sr", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdSR = null;
    [JsonProperty("assessor_name_sr", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameSR = null;
    [JsonProperty("teacher_name_sr", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameSR = null;
    [JsonProperty("classroom_name_sr", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameSR = null;
    [JsonProperty("sr_total", NullValueHandling = NullValueHandling.Ignore)]
    public int? srTotal = null;
    [JsonProperty("sr_question_1", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion1 = null;
    [JsonProperty("sr_qs1_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs1result = null;
    [JsonProperty("sr_question_2", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion2 = null;
    [JsonProperty("sr_qs2_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs2result = null;
    [JsonProperty("sr_question_3", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion3 = null;
    [JsonProperty("sr_qs3_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs3result = null;
    [JsonProperty("sr_question_4", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion4 = null;
    [JsonProperty("sr_qs4_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs4result = null;
    [JsonProperty("sr_question_5", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion5 = null;
    [JsonProperty("sr_qs5_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs5result = null;
    [JsonProperty("sr_question_6", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion6 = null;
    [JsonProperty("sr_qs6_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs6result = null;
    [JsonProperty("sr_question_7", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion7 = null;
    [JsonProperty("sr_qs7_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs7result = null;
    [JsonProperty("sr_question_8", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion8 = null;
    [JsonProperty("sr_qs8_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs8result = null;
    [JsonProperty("sr_question_9", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion9 = null;
    [JsonProperty("sr_qs9_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs9result = null;
    [JsonProperty("sr_question_10", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion10 = null;
    [JsonProperty("sr_qs10_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs10result = null;
    [JsonProperty("sr_question_11", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion11 = null;
    [JsonProperty("sr_qs11_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs11result = null;
    [JsonProperty("sr_question_12", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion12 = null;
    [JsonProperty("sr_qs12_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs12result = null;
    [JsonProperty("sr_question_13", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion13 = null;
    [JsonProperty("sr_qs13_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs13result = null;
    [JsonProperty("sr_question_14", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion14 = null;
    [JsonProperty("sr_qs14_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs14result = null;
    [JsonProperty("sr_question_15", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion15 = null;
    [JsonProperty("sr_qs15_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs15result = null;
    [JsonProperty("sr_question_16", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string srQuestion16 = null;
    [JsonProperty("sr_qs16_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? srQs16result = null;

    [JsonProperty("story_retell_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? storyRetellComplete = null;

    //Book Summary Syllables
    [JsonProperty("booksum_session", NullValueHandling = NullValueHandling.Ignore)]
    public int? bookSumSession = null;

    [JsonProperty("assessor_id_booksum", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdBookSum = null;
    [JsonProperty("teacher_id_booksum", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdBookSum = null;
    [JsonProperty("classroom_id_booksum", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdBookSum = null;
    [JsonProperty("assessor_name_booksum", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameBookSum = null;
    [JsonProperty("teacher_name_booksum", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameBookSum = null;
    [JsonProperty("classroom_name_booksum", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameBookSum = null;
    [JsonProperty("booksum_total", NullValueHandling = NullValueHandling.Ignore)]
    public int? bookSumTotal = null;
    [JsonProperty("booksum_question_1", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion1 = null;
    [JsonProperty("booksum_qs1_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs1result = null;
    [JsonProperty("booksum_question_2", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion2 = null;
    [JsonProperty("booksum_qs2_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs2result = null;
    [JsonProperty("booksum_question_3", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion3 = null;
    [JsonProperty("booksum_qs3_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs3result = null;
    [JsonProperty("booksum_question_4", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion4 = null;
    [JsonProperty("booksum_qs4_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs4result = null;
    [JsonProperty("booksum_question_5", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion5 = null;
    [JsonProperty("booksum_qs5_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs5result = null;
    [JsonProperty("booksum_question_6", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion6 = null;
    [JsonProperty("booksum_qs6_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs6result = null;
    [JsonProperty("booksum_question_7", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion7 = null;
    [JsonProperty("booksum_qs7_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs7result = null;
    [JsonProperty("booksum_question_8", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion8 = null;
    [JsonProperty("booksum_qs8_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs8result = null;
    [JsonProperty("booksum_question_9", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion9 = null;
    [JsonProperty("booksum_qs9_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs9result = null;
    [JsonProperty("booksum_question_10", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion10 = null;
    [JsonProperty("booksum_qs10_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs10result = null;
    [JsonProperty("booksum_question_11", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string booksumQuestion11 = null;
    [JsonProperty("booksum_qs11_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? booksumQs11result = null;

    [JsonProperty("book_summary_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? bookSummaryComplete = null;


    //Letter Name Identification - Student Progress
    [JsonProperty("lni_a", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_A = null;
    [JsonProperty("lni_b", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_B = null;
    [JsonProperty("lni_c", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_C = null;
    [JsonProperty("lni_d", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_D = null;
    [JsonProperty("lni_e", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_E = null;
    [JsonProperty("lni_f", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_F = null;
    [JsonProperty("lni_g", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_G = null;
    [JsonProperty("lni_h", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_H = null;
    [JsonProperty("lni_i", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_I = null;
    [JsonProperty("lni_j", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_J = null;
    [JsonProperty("lni_k", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_K = null;
    [JsonProperty("lni_l", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_L = null;
    [JsonProperty("lni_m", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_M = null;
    [JsonProperty("lni_n", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_N = null;
    [JsonProperty("lni_o", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_O = null;
    [JsonProperty("lni_p", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_P = null;
    [JsonProperty("lni_q", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_Q = null;
    [JsonProperty("lni_r", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_R = null;
    [JsonProperty("lni_s", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_S = null;
    [JsonProperty("lni_t", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_T = null;
    [JsonProperty("lni_u", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_U = null;
    [JsonProperty("lni_v", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_V = null;
    [JsonProperty("lni_w", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_W = null;
    [JsonProperty("lni_x", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_X = null;
    [JsonProperty("lni_y", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_Y = null;
    [JsonProperty("lni_z", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LNI_Z = null;

    [JsonProperty("letter_name_identification_student_progress_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? LNIStudentProgressComplete = null;

    //Fields for Letter Name Recognition - Results instrument
    [JsonProperty("lnir_session_no", NullValueHandling = NullValueHandling.Ignore)]
    public int? lnirSessionNumber = null;

    [JsonProperty("assessor_id_lni", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdLni = null;
    [JsonProperty("teacher_id_lni", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdLni = null;
    [JsonProperty("classroom_id_lni", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdLni = null;
    [JsonProperty("assessor_name_lni", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameLni = null;
    [JsonProperty("teacher_name_lni", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameLni = null;
    [JsonProperty("classroom_name_lni", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameLni = null;

    [JsonProperty("lnir_a", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_A = null;
    [JsonProperty("lnir_b", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_B = null;
    [JsonProperty("lnir_c", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_C = null;
    [JsonProperty("lnir_d", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_D = null;
    [JsonProperty("lnir_e", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_E = null;
    [JsonProperty("lnir_f", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_F = null;
    [JsonProperty("lnir_g", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_G = null;
    [JsonProperty("lnir_h", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_H = null;
    [JsonProperty("lnir_i", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_I = null;
    [JsonProperty("lnir_j", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_J = null;
    [JsonProperty("lnir_k", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_K = null;
    [JsonProperty("lnir_l", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_L = null;
    [JsonProperty("lnir_m", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_M = null;
    [JsonProperty("lnir_n", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_N = null;
    [JsonProperty("lnir_o", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_O = null;
    [JsonProperty("lnir_p", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_P = null;
    [JsonProperty("lnir_q", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_Q = null;
    [JsonProperty("lnir_r", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_R = null;
    [JsonProperty("lnir_s", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_S = null;
    [JsonProperty("lnir_t", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_T = null;
    [JsonProperty("lnir_u", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_U = null;
    [JsonProperty("lnir_v", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_V = null;
    [JsonProperty("lnir_w", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_W = null;
    [JsonProperty("lnir_x", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_X = null;
    [JsonProperty("lnir_y", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_Y = null;
    [JsonProperty("lnir_z", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLNI_Z = null;

    [JsonProperty("letter_name_identification_results_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? LNIResultsComplete = null;


    //Letter Sound Identification - Student Progress
    [JsonProperty("lsi_a", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_A = null;
    [JsonProperty("lsi_b", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_B = null;
    [JsonProperty("lsi_c", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_C = null;
    [JsonProperty("lsi_d", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_D = null;
    [JsonProperty("lsi_e", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_E = null;
    [JsonProperty("lsi_f", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_F = null;
    [JsonProperty("lsi_g", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_G = null;
    [JsonProperty("lsi_h", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_H = null;
    [JsonProperty("lsi_i", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_I = null;
    [JsonProperty("lsi_j", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_J = null;
    [JsonProperty("lsi_k", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_K = null;
    [JsonProperty("lsi_l", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_L = null;
    [JsonProperty("lsi_m", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_M = null;
    [JsonProperty("lsi_n", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_N = null;
    [JsonProperty("lsi_o", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_O = null;
    [JsonProperty("lsi_p", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_P = null;
    [JsonProperty("lsi_q", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_Q = null;
    [JsonProperty("lsi_r", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_R = null;
    [JsonProperty("lsi_s", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_S = null;
    [JsonProperty("lsi_t", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_T = null;
    [JsonProperty("lsi_u", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_U = null;
    [JsonProperty("lsi_v", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_V = null;
    [JsonProperty("lsi_w", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_W = null;
    [JsonProperty("lsi_x", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_X = null;
    [JsonProperty("lsi_y", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_Y = null;
    [JsonProperty("lsi_z", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? LSI_Z = null;

    [JsonProperty("letter_sound_identification_student_progress_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? LSIStudentProgressComplete = null;

    //Fields for Letter Sound Recognition - Results instrument
    [JsonProperty("lsir_session_no", NullValueHandling = NullValueHandling.Ignore)]
    public int? lsirSessionNumber = null;

    [JsonProperty("assessor_id_lsi", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdLsi = null;
    [JsonProperty("teacher_id_lsi", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdLsi = null;
    [JsonProperty("classroom_id_lsi", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdLsi = null;
    [JsonProperty("assessor_name_lsi", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameLsi = null;
    [JsonProperty("teacher_name_lsi", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameLsi = null;
    [JsonProperty("classroom_name_lsi", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameLsi = null;

    [JsonProperty("lsir_a", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_A = null;
    [JsonProperty("lsir_b", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_B = null;
    [JsonProperty("lsir_c", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_C = null;
    [JsonProperty("lsir_d", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_D = null;
    [JsonProperty("lsir_e", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_E = null;
    [JsonProperty("lsir_f", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_F = null;
    [JsonProperty("lsir_g", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_G = null;
    [JsonProperty("lsir_h", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_H = null;
    [JsonProperty("lsir_i", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_I = null;
    [JsonProperty("lsir_j", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_J = null;
    [JsonProperty("lsir_k", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_K = null;
    [JsonProperty("lsir_l", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_L = null;
    [JsonProperty("lsir_m", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_M = null;
    [JsonProperty("lsir_n", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_N = null;
    [JsonProperty("lsir_o", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_O = null;
    [JsonProperty("lsir_p", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_P = null;
    [JsonProperty("lsir_q", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_Q = null;
    [JsonProperty("lsir_r", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_R = null;
    [JsonProperty("lsir_s", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_S = null;
    [JsonProperty("lsir_t", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_T = null;
    [JsonProperty("lsir_u", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_U = null;
    [JsonProperty("lsir_v", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_V = null;
    [JsonProperty("lsir_w", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_W = null;
    [JsonProperty("lsir_x", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_X = null;
    [JsonProperty("lsir_y", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_Y = null;
    [JsonProperty("lsir_z", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public int? rLSI_Z = null;

    [JsonProperty("letter_sound_identification_results_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? LSIResultsComplete = null;

    //Fields for beginning sounds
    [JsonProperty("bs_session_no", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsSessionNumber = null;

    [JsonProperty("assessor_id_bs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorIdBs = null;
    [JsonProperty("teacher_id_bs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherIdBs = null;
    [JsonProperty("classroom_id_bs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomIdBs = null;
    [JsonProperty("assessor_name_bs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string assessorNameBs = null;
    [JsonProperty("teacher_name_bs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string teacherNameBs = null;
    [JsonProperty("classroom_name_bs", NullValueHandling = NullValueHandling.Ignore)] [CanBeNull]
    public string classroomNameBs = null;

    [JsonProperty("bs_eap", NullValueHandling = NullValueHandling.Ignore)]
    public double? bsEAP = null;
    [JsonProperty("bs_std_error", NullValueHandling = NullValueHandling.Ignore)]
    public double? bsStdError = null;
    [JsonProperty("bs_hand", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsHand = null;
    [JsonProperty("bsr_hand", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResHand = null;
    [JsonProperty("bs_moon", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsMoon = null;
    [JsonProperty("bsr_moon", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResMoon = null;
    [JsonProperty("bs_sun", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsSun = null;
    [JsonProperty("bsr_sun", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResSun = null;
    [JsonProperty("bs_door", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsDoor = null;
    [JsonProperty("bsr_door", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResDoor = null;
    [JsonProperty("bs_mouse", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsMouse = null;
    [JsonProperty("bsr_mouse", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResMouse = null;
    [JsonProperty("bs_car", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsCar = null;
    [JsonProperty("bsr_car", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResCar = null;
    [JsonProperty("bs_fan", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsFan = null;
    [JsonProperty("bsr_fan", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResFan = null;
    [JsonProperty("bs_pot", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsPot = null;
    [JsonProperty("bsr_pot", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResPot = null;
    [JsonProperty("bs_hat", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsHat = null;
    [JsonProperty("bsr_hat", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResHat = null;
    [JsonProperty("bs_ball", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsBall = null;
    [JsonProperty("bsr_ball", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResBall = null;
    [JsonProperty("bs_duck", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsDuck = null;
    [JsonProperty("bsr_duck", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResDuck = null;
    [JsonProperty("bs_van", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsVan = null;
    [JsonProperty("bsr_van", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResVan = null;
    [JsonProperty("bs_dog", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsDog = null;
    [JsonProperty("bsr_dog", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResDog = null;
    [JsonProperty("bs_cake", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsCake = null;
    [JsonProperty("bsr_cake", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResCake = null;
    [JsonProperty("bs_leaf", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsLeaf = null;
    [JsonProperty("bsr_leaf", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResLeaf = null;
    [JsonProperty("bs_heart", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsHeart = null;
    [JsonProperty("bsr_heart", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResHeart = null;
    [JsonProperty("bs_four", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsFour = null;
    [JsonProperty("bsr_four", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResFour = null;
    [JsonProperty("bs_milk", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsMilk = null;
    [JsonProperty("bsr_milk", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResMilk = null;
    [JsonProperty("bs_nut", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsNut = null;
    [JsonProperty("bsr_nut", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResNut = null;
    [JsonProperty("bs_nest", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsNest = null;
    [JsonProperty("bsr_nest", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResNest = null;
    [JsonProperty("bs_book", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsBook = null;
    [JsonProperty("bsr_book", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResBook = null;
    [JsonProperty("bs_sock", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsSock = null;
    [JsonProperty("bsr_sock", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResSock = null;
    [JsonProperty("bs_bird", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsBird = null;
    [JsonProperty("bsr_bird", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResBird = null;
    [JsonProperty("bs_fox", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsFox = null;
    [JsonProperty("bsr_fox", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResFox = null;
    [JsonProperty("bs_cup", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsCup = null;
    [JsonProperty("bsr_cup", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResCup = null;
    [JsonProperty("bs_pants", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsPants = null;
    [JsonProperty("bsr_pants", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResPants = null;
    [JsonProperty("bs_chalk", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsChalk = null;
    [JsonProperty("bsr_chalk", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResChalk = null;
    [JsonProperty("bs_nose", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsNose = null;
    [JsonProperty("bsr_nose", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResNose = null;
    [JsonProperty("bs_chin", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsChin = null;
    [JsonProperty("bsr_chin", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResChin = null;
    [JsonProperty("bs_chair", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsChair = null;
    [JsonProperty("bsr_chair", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResChair = null;
    [JsonProperty("bs_leg", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsLeg = null;
    [JsonProperty("bsr_leg", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResLeg = null;
    [JsonProperty("bs_net", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsNet = null;
    [JsonProperty("bsr_net", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResNet = null;
    [JsonProperty("bs_fish", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsFish = null;
    [JsonProperty("bsr_fish", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResFish = null;
    [JsonProperty("bs_cat", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsCat = null;
    [JsonProperty("bsr_cat", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResCat = null;
    [JsonProperty("bs_lamp", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsLamp = null;
    [JsonProperty("bsr_lamp", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResLamp = null;
    [JsonProperty("bs_cheese", NullValueHandling = NullValueHandling.Ignore)]
    public int? bsCheese = null;
    [JsonProperty("bsr_cheese", NullValueHandling = NullValueHandling.Ignore)]
    public string bsResCheese = null;

    [JsonProperty("beginning_sounds_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? beginningSoundsComplete = null;

    [JsonProperty("cop_session", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPSessionNumber = null;

    [JsonProperty("assessor_id_cop", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string assessorIdCAP = null;
    [JsonProperty("teacher_id_cop", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string teacherIdCAP = null;
    [JsonProperty("classroom_id_cop", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string classroomIdCAP = null;
    [JsonProperty("assessor_name_cop", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string assessorNameCAP = null;
    [JsonProperty("teacher_name_cop", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string teacherNameCAP = null;
    [JsonProperty("classroom_name_cop", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string classroomNameCAP = null;

    [JsonProperty("cop_eap", NullValueHandling = NullValueHandling.Ignore)]
    public double? CAPEAP = null;
    [JsonProperty("cop_std_error", NullValueHandling = NullValueHandling.Ignore)]
    public double? CAPStdError = null;

    [JsonProperty("cop_question_1", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion1 = null;
    [JsonProperty("cop_qs1_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs1result = null;
    [JsonProperty("cop_question_2", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion2 = null;
    [JsonProperty("cop_qs2_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs2result = null;
    [JsonProperty("cop_question_3", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion3 = null;
    [JsonProperty("cop_qs3_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs3result = null;
    [JsonProperty("cop_question_4", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion4 = null;
    [JsonProperty("cop_qs4_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs4result = null;
    [JsonProperty("cop_question_5", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion5 = null;
    [JsonProperty("cop_qs5_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs5result = null;
    [JsonProperty("cop_question_6", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion6 = null;
    [JsonProperty("cop_qs6_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs6result = null;
    [JsonProperty("cop_question_7", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion7 = null;
    [JsonProperty("cop_qs7_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs7result = null;
    [JsonProperty("cop_question_8", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion8 = null;
    [JsonProperty("cop_qs8_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs8result = null;
    [JsonProperty("cop_question_9", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion9 = null;
    [JsonProperty("cop_qs9_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs9result = null;
    [JsonProperty("cop_question_10", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion10 = null;
    [JsonProperty("cop_qs10_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs10result = null;
    [JsonProperty("cop_question_11", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion11 = null;
    [JsonProperty("cop_qs11_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs11result = null;
    [JsonProperty("cop_question_12", NullValueHandling = NullValueHandling.Ignore)]
    [CanBeNull]
    public string CAPQuestion12 = null;
    [JsonProperty("cop_qs12_result", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPQs12result = null;
    [JsonProperty("concepts_of_print_complete", NullValueHandling = NullValueHandling.Ignore)]
    public int? CAPComplete = null;

    //Seems like the idea here is to create a big list of RedcapRecords
    //that match the db field names so they can be serialized later
    public static List<RedCapRecord> convertToRedCapRecord(SerialData inputData)
    {
        List<RedCapRecord> redCapRecords = new List<RedCapRecord>();
        List<RedCapRecord> vocabularyRedCapRecords = new List<RedCapRecord>();
        
        int recordID = String.IsNullOrEmpty(inputData.sRecordId) ? int.MaxValue : int.Parse(inputData.sRecordId);
        string assessorID = inputData.sAssessorID;
        string childID = inputData.sChildID;
        string classroomID = inputData.sClassroomID;
        string teacherID = inputData.sTeacherID;

        // Populate fields for Credentials Instrument in RedCap
        RedCapRecord credentialRedCapRecord = new RedCapRecord();
        credentialRedCapRecord.recordID = recordID;
        if(inputData.sExportImportRef == "ID") {
            credentialRedCapRecord.assessorID = assessorID;
            credentialRedCapRecord.childID = childID;
            credentialRedCapRecord.classroomID = classroomID;
            credentialRedCapRecord.teacherID = teacherID;
        } else{
            credentialRedCapRecord.assessorName = assessorID;
            credentialRedCapRecord.childName = childID;
            credentialRedCapRecord.classroomName = classroomID;
            credentialRedCapRecord.teacherName = teacherID;
        }
        redCapRecords.Add(credentialRedCapRecord);
        
        
        // Populate fields for Vocabulary Instrument (field-solution) in RedCap
        for (int responseIndex = 0; inputData.sIndividualResponses != null && 
                                    responseIndex < inputData.sIndividualResponses.Count; responseIndex++)
        {
            RedCapRecord redCapRecord;
            List<string> sessionData = inputData.sIndividualResponses[responseIndex];
            if (vocabularyRedCapRecords.Count - 1 < responseIndex)
                vocabularyRedCapRecords.Add(new RedCapRecord());
                        
            redCapRecord = vocabularyRedCapRecords[responseIndex];
            redCapRecord.vocabSession = responseIndex + 1;
            redCapRecord.recordID = recordID;
            redCapRecord.redcapRepeatInstrument = "vocabulary";
            redCapRecord.redcapRepeatInstance = redCapRecord.vocabSession;
            if(inputData.sAssessorIdVocabList.Count > responseIndex) {
                redCapRecord.assessorIdVocab = inputData.sAssessorIdVocabList[responseIndex];
                redCapRecord.classroomIdVocab = inputData.sClassroomIdVocabList[responseIndex];
                redCapRecord.teacherIdVocab = inputData.sTeacherIdVocabList[responseIndex];
            }
            if(inputData.sAssessorNameVocabList.Count > responseIndex) {
                redCapRecord.assessorNameVocab = inputData.sAssessorNameVocabList[responseIndex];
                redCapRecord.classroomNameVocab = inputData.sClassroomNameVocabList[responseIndex];
                redCapRecord.teacherNameVocab = inputData.sTeacherNameVocabList[responseIndex];
            }

            if ((redCapRecord.assessorIdVocab != "" && redCapRecord.assessorIdVocab != null) || (redCapRecord.assessorNameVocab != "" && redCapRecord.assessorNameVocab != null))
            {
                redCapRecord.vocabularyComplete = 2;
            }

            if (sessionData.Count > 0)
                redCapRecord.q1Solution = sessionData[0];
            if (sessionData.Count > 1)
                redCapRecord.q2Solution = sessionData[1];
            if (sessionData.Count > 2)
                redCapRecord.q3Solution = sessionData[2];
            if (sessionData.Count > 3)
                redCapRecord.q4Solution = sessionData[3];
            if (sessionData.Count > 4)
                redCapRecord.q5Solution = sessionData[4];
            if (sessionData.Count > 5)
                redCapRecord.q6Solution = sessionData[5];
        }
        
        // Populate fields for Vocabulary Instrument (field-expressive) in RedCap
        for (int responseIndex = 0; inputData.sIndividualExpressiveList != null && 
                                    responseIndex < inputData.sIndividualExpressiveList.Count; responseIndex++)
        {
            RedCapRecord redCapRecord;
            List<bool> sessionData = inputData.sIndividualExpressiveList[responseIndex];
            if (vocabularyRedCapRecords.Count - 1 < responseIndex)
                vocabularyRedCapRecords.Add(new RedCapRecord());
            
            redCapRecord = vocabularyRedCapRecords[responseIndex];
            redCapRecord.vocabSession = responseIndex + 1;
            redCapRecord.recordID = recordID;
            redCapRecord.redcapRepeatInstrument = "vocabulary";
            redCapRecord.redcapRepeatInstance = redCapRecord.vocabSession;
            if(inputData.sAssessorIdVocabList.Count > responseIndex){
                redCapRecord.assessorIdVocab = inputData.sAssessorIdVocabList[responseIndex];
                redCapRecord.classroomIdVocab = inputData.sClassroomIdVocabList[responseIndex];
                redCapRecord.teacherIdVocab = inputData.sTeacherIdVocabList[responseIndex];
            }
            if(inputData.sAssessorNameVocabList.Count > responseIndex){
                redCapRecord.assessorNameVocab = inputData.sAssessorNameVocabList[responseIndex];
                redCapRecord.classroomNameVocab = inputData.sClassroomNameVocabList[responseIndex];
                redCapRecord.teacherNameVocab = inputData.sTeacherNameVocabList[responseIndex];
            }
            if (sessionData.Count > 0)
                redCapRecord.q1Expressive = getBinaryTrueFalse(sessionData[0]);
            if (sessionData.Count > 1)
                redCapRecord.q2Expressive = getBinaryTrueFalse(sessionData[1]);
            if (sessionData.Count > 2)
                redCapRecord.q3Expressive = getBinaryTrueFalse(sessionData[2]);
            if (sessionData.Count > 3)
                redCapRecord.q4Expressive = getBinaryTrueFalse(sessionData[3]);
            if (sessionData.Count > 4)
                redCapRecord.q5Expressive = getBinaryTrueFalse(sessionData[4]);
            if (sessionData.Count > 5)
                redCapRecord.q6Expressive = getBinaryTrueFalse(sessionData[5]);
        }
        
        // Populate fields for Vocabulary Instrument (field-receptive) in RedCap
        for (int responseIndex = 0; inputData.sIndividualReceptiveList != null && 
                                    responseIndex < inputData.sIndividualReceptiveList.Count; responseIndex++)
        {
            RedCapRecord redCapRecord;
            List<bool> sessionData = inputData.sIndividualReceptiveList[responseIndex];
            if (vocabularyRedCapRecords.Count - 1 < responseIndex)
                vocabularyRedCapRecords.Add(new RedCapRecord());
            
            redCapRecord = vocabularyRedCapRecords[responseIndex];
            redCapRecord.vocabSession = responseIndex + 1;
            redCapRecord.recordID = recordID;
            redCapRecord.redcapRepeatInstrument = "vocabulary";
            redCapRecord.redcapRepeatInstance = redCapRecord.vocabSession;
            if(inputData.sAssessorIdVocabList.Count > responseIndex && inputData.sAssessorIdVocabList[responseIndex] != "")
            {
                redCapRecord.assessorIdVocab = inputData.sAssessorIdVocabList[responseIndex];
                redCapRecord.classroomIdVocab = inputData.sClassroomIdVocabList[responseIndex];
                redCapRecord.teacherIdVocab = inputData.sTeacherIdVocabList[responseIndex];
            }
            if(inputData.sAssessorNameVocabList.Count > responseIndex && inputData.sAssessorNameVocabList[responseIndex] != "")
            {
                redCapRecord.assessorNameVocab = inputData.sAssessorNameVocabList[responseIndex];
                redCapRecord.classroomNameVocab = inputData.sClassroomNameVocabList[responseIndex];
                redCapRecord.teacherNameVocab = inputData.sTeacherNameVocabList[responseIndex];
            }
            if (sessionData.Count > 0)
                redCapRecord.q1Receptive = getBinaryTrueFalse(sessionData[0]);
            if (sessionData.Count > 1)
                redCapRecord.q2Receptive = getBinaryTrueFalse(sessionData[1]);
            if (sessionData.Count > 2)
                redCapRecord.q3Receptive = getBinaryTrueFalse(sessionData[2]);
            if (sessionData.Count > 3)
                redCapRecord.q4Receptive = getBinaryTrueFalse(sessionData[3]);
            if (sessionData.Count > 4)
                redCapRecord.q5Receptive = getBinaryTrueFalse(sessionData[4]);
            if (sessionData.Count > 5)
                redCapRecord.q6Receptive = getBinaryTrueFalse(sessionData[5]);
        }
        
        // Populate fields for Vocabulary Instrument (field-expressive flag) in RedCap
        for (int responseIndex = 0; inputData.sIndividualExpressiveFlagList != null && 
                                    responseIndex < inputData.sIndividualExpressiveFlagList.Count; responseIndex++)
        {
            RedCapRecord redCapRecord;
            List<bool> sessionData = inputData.sIndividualExpressiveFlagList[responseIndex];
            if (vocabularyRedCapRecords.Count - 1 < responseIndex)
                vocabularyRedCapRecords.Add(new RedCapRecord());
            
            redCapRecord = vocabularyRedCapRecords[responseIndex];
            redCapRecord.vocabSession = responseIndex + 1;
            redCapRecord.recordID = recordID;
            redCapRecord.redcapRepeatInstrument = "vocabulary";
            redCapRecord.redcapRepeatInstance = redCapRecord.vocabSession;
            if(inputData.sAssessorIdVocabList.Count > responseIndex){
                redCapRecord.assessorIdVocab = inputData.sAssessorIdVocabList[responseIndex];
                redCapRecord.classroomIdVocab = inputData.sClassroomIdVocabList[responseIndex];
                redCapRecord.teacherIdVocab = inputData.sTeacherIdVocabList[responseIndex];
            }
            if(inputData.sAssessorNameVocabList.Count > responseIndex){
                redCapRecord.assessorNameVocab = inputData.sAssessorNameVocabList[responseIndex];
                redCapRecord.classroomNameVocab = inputData.sClassroomNameVocabList[responseIndex];
                redCapRecord.teacherNameVocab = inputData.sTeacherNameVocabList[responseIndex];
            }
            if (sessionData.Count > 0)
                redCapRecord.q1ExpressiveFlag = getBinaryTrueFalse(sessionData[0]);
            if (sessionData.Count > 1)
                redCapRecord.q2ExpressiveFlag = getBinaryTrueFalse(sessionData[1]);
            if (sessionData.Count > 2)
                redCapRecord.q3ExpressiveFlag = getBinaryTrueFalse(sessionData[2]);
            if (sessionData.Count > 3)
                redCapRecord.q4ExpressiveFlag = getBinaryTrueFalse(sessionData[3]);
            if (sessionData.Count > 4)
                redCapRecord.q5ExpressiveFlag = getBinaryTrueFalse(sessionData[4]);
            if (sessionData.Count > 5)
                redCapRecord.q6ExpressiveFlag = getBinaryTrueFalse(sessionData[5]);
        }
        
        // Populate fields for Vocabulary Instrument (field-receptive flag) in RedCap
        for (int responseIndex = 0; inputData.sIndividualReceptiveFlagList != null && 
                                    responseIndex < inputData.sIndividualReceptiveFlagList.Count; responseIndex++)
        {
            RedCapRecord redCapRecord;
            List<bool> sessionData = inputData.sIndividualReceptiveFlagList[responseIndex];
            if (vocabularyRedCapRecords.Count - 1 < responseIndex)
                vocabularyRedCapRecords.Add(new RedCapRecord());
            
            redCapRecord = vocabularyRedCapRecords[responseIndex];
            redCapRecord.vocabSession = responseIndex + 1;
            redCapRecord.recordID = recordID;
            redCapRecord.redcapRepeatInstrument = "vocabulary";
            redCapRecord.redcapRepeatInstance = redCapRecord.vocabSession;
            if(inputData.sAssessorIdVocabList.Count > responseIndex){
                redCapRecord.assessorIdVocab = inputData.sAssessorIdVocabList[responseIndex];
                redCapRecord.classroomIdVocab = inputData.sClassroomIdVocabList[responseIndex];
                redCapRecord.teacherIdVocab = inputData.sTeacherIdVocabList[responseIndex];
            }
            if(inputData.sAssessorNameVocabList.Count > responseIndex){
                redCapRecord.assessorNameVocab = inputData.sAssessorNameVocabList[responseIndex];
                redCapRecord.classroomNameVocab = inputData.sClassroomNameVocabList[responseIndex];
                redCapRecord.teacherNameVocab = inputData.sTeacherNameVocabList[responseIndex];
            }
            if (sessionData.Count > 0)
                redCapRecord.q1ReceptiveFlag = getBinaryTrueFalse(sessionData[0]);
            if (sessionData.Count > 1)
                redCapRecord.q2ReceptiveFlag = getBinaryTrueFalse(sessionData[1]);
            if (sessionData.Count > 2)
                redCapRecord.q3ReceptiveFlag = getBinaryTrueFalse(sessionData[2]);
            if (sessionData.Count > 3)
                redCapRecord.q4ReceptiveFlag = getBinaryTrueFalse(sessionData[3]);
            if (sessionData.Count > 4)
                redCapRecord.q5ReceptiveFlag = getBinaryTrueFalse(sessionData[4]);
            if (sessionData.Count > 5)
                redCapRecord.q6ReceptiveFlag = getBinaryTrueFalse(sessionData[5]);
        }
        
        redCapRecords.AddRange(vocabularyRedCapRecords);


        //Populate fields for Clapping Syllables Instrument
        List<RedCapRecord> csRedCapRecords = new();
        for (int responseIndex = 0; inputData.sIndividualCSResponseList != null && 
                                    responseIndex < inputData.sIndividualCSResponseList.Count; responseIndex++)
        {
            RedCapRecord csRedCapRecord;
            List<bool> sessionData = inputData.sIndividualCSResponseList[responseIndex];
            if (csRedCapRecords.Count - 1 < responseIndex)
                csRedCapRecords.Add(new RedCapRecord());
            
            csRedCapRecord = csRedCapRecords[responseIndex];
            csRedCapRecord.csSession = responseIndex + 1;
            csRedCapRecord.recordID = recordID;
            csRedCapRecord.redcapRepeatInstrument = "clapping_syllables";
            csRedCapRecord.redcapRepeatInstance = csRedCapRecord.csSession;
            if(inputData.sAssessorIdCSList.Count > 0 && responseIndex< inputData.sAssessorIdCSList.Count && inputData.sAssessorIdCSList[responseIndex] != "")
            {
                csRedCapRecord.assessorIdCS = inputData.sAssessorIdCSList[responseIndex];
                csRedCapRecord.classroomIdCS = inputData.sClassroomIdCSList[responseIndex];
                csRedCapRecord.teacherIdCS = inputData.sTeacherIdCSList[responseIndex];
            }
            if(inputData.sAssessorNameCSList.Count > 0 && responseIndex< inputData.sAssessorNameCSList.Count && inputData.sAssessorNameCSList[responseIndex] != "")
            {
                csRedCapRecord.assessorNameCS = inputData.sAssessorNameCSList[responseIndex];
                csRedCapRecord.classroomNameCS = inputData.sClassroomNameCSList[responseIndex];
                csRedCapRecord.teacherNameCS = inputData.sTeacherNameCSList[responseIndex];
            }
            /*if (inputData.sExportImportRef == "ID")
            {
                csRedCapRecord.assessorIdCS = assessorID;
                csRedCapRecord.classroomIdCS = classroomID;
                csRedCapRecord.teacherIdCS = teacherID;
            }
            else
            {
                csRedCapRecord.assessorNameCS = assessorID;
                csRedCapRecord.classroomNameCS = classroomID;
                csRedCapRecord.teacherNameCS = teacherID;
            }*/
            if ((csRedCapRecord.assessorIdCS != "" && csRedCapRecord.assessorIdCS != null) || (csRedCapRecord.assessorNameCS != "" && csRedCapRecord.assessorNameCS != null))
            {
                csRedCapRecord.clappingSyllablesComplete = 2;
            }
            if (sessionData.Count > 0) 
                csRedCapRecord.popcornResponse = getBinaryTrueFalse(sessionData[0]);
            if (sessionData.Count > 1)
                csRedCapRecord.teacherResponse = getBinaryTrueFalse(sessionData[1]);
            if (sessionData.Count > 2)
                csRedCapRecord.umbrellaResponse = getBinaryTrueFalse(sessionData[2]);
            csRedCapRecord.csScore = inputData.sGradeCSTotal[responseIndex];
        }
        redCapRecords.AddRange(csRedCapRecords);


        //Populate fields for Writing Instrument
        List<RedCapRecord> writingRedCapRecords = new();
        for (int responseIndex = 0; inputData.sIndividualWritingScoreList != null &&
                                    responseIndex < inputData.sIndividualWritingScoreList.Count; responseIndex++)
        {
            RedCapRecord writingRedCapRecord;
            List<int> sessionData = inputData.sIndividualWritingScoreList[responseIndex];
            if (writingRedCapRecords.Count - 1 < responseIndex)
                writingRedCapRecords.Add(new RedCapRecord());
            
            writingRedCapRecord = writingRedCapRecords[responseIndex];
            writingRedCapRecord.writingSessionNo = responseIndex + 1;
            writingRedCapRecord.recordID = recordID;
            writingRedCapRecord.redcapRepeatInstrument = "writing";
            writingRedCapRecord.redcapRepeatInstance = writingRedCapRecord.writingSessionNo;
            if(inputData.sAssessorIdWritingList.Count > 0 && responseIndex< inputData.sAssessorIdWritingList.Count && inputData.sAssessorIdWritingList[responseIndex] != "")
            {
                writingRedCapRecord.assessorIdWriting = inputData.sAssessorIdWritingList[responseIndex];
                writingRedCapRecord.classroomIdWriting = inputData.sClassroomIdWritingList[responseIndex];
                writingRedCapRecord.teacherIdWriting = inputData.sTeacherIdWritingList[responseIndex];
            }
            if(inputData.sAssessorNameWritingList.Count > 0 && responseIndex< inputData.sAssessorNameWritingList.Count && inputData.sAssessorNameWritingList[responseIndex] != "")
            {
                writingRedCapRecord.assessorNameWriting = inputData.sAssessorNameWritingList[responseIndex];
                writingRedCapRecord.classroomNameWriting = inputData.sClassroomNameWritingList[responseIndex];
                writingRedCapRecord.teacherNameWriting = inputData.sTeacherNameWritingList[responseIndex];
            }

            /*if (inputData.sExportImportRef == "ID")
            {
                writingRedCapRecord.assessorIdWriting = assessorID;
                writingRedCapRecord.classroomIdWriting = classroomID;
                writingRedCapRecord.teacherIdWriting = teacherID;
            }
            else
            {
                writingRedCapRecord.assessorNameWriting = assessorID;
                writingRedCapRecord.classroomNameWriting = classroomID;
                writingRedCapRecord.teacherNameWriting = teacherID;
            }*/

            if ((writingRedCapRecord.assessorIdWriting != "" && writingRedCapRecord.assessorIdWriting != null) || (writingRedCapRecord.assessorNameWriting != "" && writingRedCapRecord.assessorNameWriting != null))
            {
                writingRedCapRecord.writingComplete = 2;
            }
            if (sessionData.Count > 0)
                writingRedCapRecord.nameWritingScore = sessionData[0];
            if (sessionData.Count > 1)
                writingRedCapRecord.sentenceWritingScore = sessionData[1];
        }
        redCapRecords.AddRange(writingRedCapRecords);

        // Populate fields for Story Retell Instrument (field-expressive) in RedCap
        List<RedCapRecord> srRedCapRecords = new();
        for (int responseIndex = 0; inputData.sIndividualSRResponseList != null && 
                                    responseIndex < inputData.sIndividualSRResponseList.Count; responseIndex++)
        {
            RedCapRecord redCapRecord;
            List<bool> sessionData = inputData.sIndividualSRResponseList[responseIndex];
            List<string> sessionQuestionsData = inputData.sIndividualSRQuestionsList[responseIndex];
            if (srRedCapRecords.Count - 1 < responseIndex)
                srRedCapRecords.Add(new RedCapRecord());
            
            redCapRecord = srRedCapRecords[responseIndex];
            redCapRecord.srSession = responseIndex + 1;
            redCapRecord.recordID = recordID;
            redCapRecord.redcapRepeatInstrument = "story_retell";
            redCapRecord.redcapRepeatInstance = redCapRecord.srSession;
            if(inputData.sAssessorIdSRList.Count > responseIndex && inputData.sAssessorIdSRList[responseIndex] != "")
            {
                redCapRecord.assessorIdSR = inputData.sAssessorIdSRList[responseIndex];
                redCapRecord.classroomIdSR = inputData.sClassroomIdSRList[responseIndex];
                redCapRecord.teacherIdSR = inputData.sTeacherIdSRList[responseIndex];
            }
            if(inputData.sAssessorNameSRList.Count > responseIndex && inputData.sAssessorNameSRList[responseIndex] != "")
            {
                redCapRecord.assessorNameSR = inputData.sAssessorNameSRList[responseIndex];
                redCapRecord.classroomNameSR = inputData.sClassroomNameSRList[responseIndex];
                redCapRecord.teacherNameSR = inputData.sTeacherNameSRList[responseIndex];
            }
            if ((redCapRecord.assessorIdSR != "" && redCapRecord.assessorIdSR != null) || (redCapRecord.assessorNameSR != "" && redCapRecord.assessorNameSR != null))
            {
                redCapRecord.storyRetellComplete = 2;
            }
            if (sessionData.Count > 0)
                redCapRecord.srQs1result = getBinaryTrueFalse(sessionData[0]);
            if (sessionData.Count > 1)
                redCapRecord.srQs2result = getBinaryTrueFalse(sessionData[1]);
            if (sessionData.Count > 2)
                redCapRecord.srQs3result = getBinaryTrueFalse(sessionData[2]);
            if (sessionData.Count > 3)
                redCapRecord.srQs4result = getBinaryTrueFalse(sessionData[3]);
            if (sessionData.Count > 4)
                redCapRecord.srQs5result = getBinaryTrueFalse(sessionData[4]);
            if (sessionData.Count > 5)
                redCapRecord.srQs6result = getBinaryTrueFalse(sessionData[5]);
            if (sessionData.Count > 6)
                redCapRecord.srQs7result = getBinaryTrueFalse(sessionData[6]);
            if (sessionData.Count > 7)
                redCapRecord.srQs8result = getBinaryTrueFalse(sessionData[7]);
            if (sessionData.Count > 8)
                redCapRecord.srQs9result = getBinaryTrueFalse(sessionData[8]);
            if (sessionData.Count > 9)
                redCapRecord.srQs10result = getBinaryTrueFalse(sessionData[9]);
            if (sessionData.Count > 10)
                redCapRecord.srQs11result = getBinaryTrueFalse(sessionData[10]);
            if (sessionData.Count > 11)
                redCapRecord.srQs12result = getBinaryTrueFalse(sessionData[11]);
            if (sessionData.Count > 12)
                redCapRecord.srQs13result = getBinaryTrueFalse(sessionData[12]);
            if (sessionData.Count > 13)
                redCapRecord.srQs14result = getBinaryTrueFalse(sessionData[13]);
            if (sessionData.Count > 14)
                redCapRecord.srQs15result = getBinaryTrueFalse(sessionData[14]);
            if (sessionData.Count > 15)
                redCapRecord.srQs16result = getBinaryTrueFalse(sessionData[15]);

            if (sessionData.Count > 0)
                redCapRecord.srQuestion1 = sessionQuestionsData[0];
            if (sessionData.Count > 1)
                redCapRecord.srQuestion2 = sessionQuestionsData[1];
            if (sessionData.Count > 2)
                redCapRecord.srQuestion3 = sessionQuestionsData[2];
            if (sessionData.Count > 3)
                redCapRecord.srQuestion4 = sessionQuestionsData[3];
            if (sessionData.Count > 4)
                redCapRecord.srQuestion5 = sessionQuestionsData[4];
            if (sessionData.Count > 5)
                redCapRecord.srQuestion6 = sessionQuestionsData[5];
            if (sessionData.Count > 6)
                redCapRecord.srQuestion7 = sessionQuestionsData[6];
            if (sessionData.Count > 7)
                redCapRecord.srQuestion8 = sessionQuestionsData[7];
            if (sessionData.Count > 8)
                redCapRecord.srQuestion9 = sessionQuestionsData[8];
            if (sessionData.Count > 9)
                redCapRecord.srQuestion10 = sessionQuestionsData[9];
            if (sessionData.Count > 10)
                redCapRecord.srQuestion11 = sessionQuestionsData[10];
            if (sessionData.Count > 11)
                redCapRecord.srQuestion12 = sessionQuestionsData[11];
            if (sessionData.Count > 12)
                redCapRecord.srQuestion13 = sessionQuestionsData[12];
            if (sessionData.Count > 13)
                redCapRecord.srQuestion14 = sessionQuestionsData[13];
            if (sessionData.Count > 14)
                redCapRecord.srQuestion15 = sessionQuestionsData[14];
            if (sessionData.Count > 15)
                redCapRecord.srQuestion16 = sessionQuestionsData[15];
            redCapRecord.srTotal = inputData.sGradeSRTotal[responseIndex];
            
        }
        redCapRecords.AddRange(srRedCapRecords);


        // Populate fields for Book Summary Instrument (field-expressive) in RedCap
        List<RedCapRecord> booksumRedCapRecords = new();
        for (int responseIndex = 0; inputData.sIndividualBookSumResponseList != null && 
                                    responseIndex < inputData.sIndividualBookSumResponseList.Count; responseIndex++)
        {
            RedCapRecord redCapRecord;
            List<bool> sessionData = inputData.sIndividualBookSumResponseList[responseIndex];
            List<string> sessionQuestionsData = inputData.sIndividualBookSumQuestionsList[responseIndex];
            if (booksumRedCapRecords.Count - 1 < responseIndex)
                booksumRedCapRecords.Add(new RedCapRecord());
            
            redCapRecord = booksumRedCapRecords[responseIndex];
            redCapRecord.bookSumSession = responseIndex + 1;
            redCapRecord.recordID = recordID;
            redCapRecord.redcapRepeatInstrument = "book_summary";
            redCapRecord.redcapRepeatInstance = redCapRecord.bookSumSession;
            if(inputData.sAssessorIdBookSumList.Count > responseIndex && inputData.sAssessorIdBookSumList[responseIndex] != "")
            {
                redCapRecord.assessorIdBookSum = inputData.sAssessorIdBookSumList[responseIndex];
                redCapRecord.classroomIdBookSum = inputData.sClassroomIdBookSumList[responseIndex];
                redCapRecord.teacherIdBookSum = inputData.sTeacherIdBookSumList[responseIndex];
            }
            if(inputData.sAssessorNameBookSumList.Count > responseIndex && inputData.sAssessorNameBookSumList[responseIndex] != "")
            {
                redCapRecord.assessorNameBookSum = inputData.sAssessorNameBookSumList[responseIndex];
                redCapRecord.classroomNameBookSum = inputData.sClassroomNameBookSumList[responseIndex];
                redCapRecord.teacherNameBookSum = inputData.sTeacherNameBookSumList[responseIndex];
            }
            if ((redCapRecord.assessorIdBookSum != "" && redCapRecord.assessorIdBookSum != null) || (redCapRecord.assessorNameBookSum != "" && redCapRecord.assessorNameBookSum != null))
            {
                redCapRecord.bookSummaryComplete = 2;
            }
            if (sessionData.Count > 0)
                redCapRecord.booksumQs1result = getBinaryTrueFalse(sessionData[0]);
            if (sessionData.Count > 1)
                redCapRecord.booksumQs2result = getBinaryTrueFalse(sessionData[1]);
            if (sessionData.Count > 2)
                redCapRecord.booksumQs3result = getBinaryTrueFalse(sessionData[2]);
            if (sessionData.Count > 3)
                redCapRecord.booksumQs4result = getBinaryTrueFalse(sessionData[3]);
            if (sessionData.Count > 4)
                redCapRecord.booksumQs5result = getBinaryTrueFalse(sessionData[4]);
            if (sessionData.Count > 5)
                redCapRecord.booksumQs6result = getBinaryTrueFalse(sessionData[5]);
            if (sessionData.Count > 6)
                redCapRecord.booksumQs7result = getBinaryTrueFalse(sessionData[6]);
            if (sessionData.Count > 7)
                redCapRecord.booksumQs8result = getBinaryTrueFalse(sessionData[7]);
            if (sessionData.Count > 8)
                redCapRecord.booksumQs9result = getBinaryTrueFalse(sessionData[8]);
            if (sessionData.Count > 9)
                redCapRecord.booksumQs10result = getBinaryTrueFalse(sessionData[9]);
            if (sessionData.Count > 10)
                redCapRecord.booksumQs11result = getBinaryTrueFalse(sessionData[10]);

            if (sessionData.Count > 0)
                redCapRecord.booksumQuestion1 = sessionQuestionsData[0];
            if (sessionData.Count > 1)
                redCapRecord.booksumQuestion2 = sessionQuestionsData[1];
            if (sessionData.Count > 2)
                redCapRecord.booksumQuestion3 = sessionQuestionsData[2];
            if (sessionData.Count > 3)
                redCapRecord.booksumQuestion4 = sessionQuestionsData[3];
            if (sessionData.Count > 4)
                redCapRecord.booksumQuestion5 = sessionQuestionsData[4];
            if (sessionData.Count > 5)
                redCapRecord.booksumQuestion6 = sessionQuestionsData[5];
            if (sessionData.Count > 6)
                redCapRecord.booksumQuestion7 = sessionQuestionsData[6];
            if (sessionData.Count > 7)
                redCapRecord.booksumQuestion8 = sessionQuestionsData[7];
            if (sessionData.Count > 8)
                redCapRecord.booksumQuestion9 = sessionQuestionsData[8];
            if (sessionData.Count > 9)
                redCapRecord.booksumQuestion10 = sessionQuestionsData[9];
            if (sessionData.Count > 10)
                redCapRecord.booksumQuestion11 = sessionQuestionsData[10];

            redCapRecord.bookSumTotal = inputData.sGradeBookSumTotal[responseIndex];
            
        }
        redCapRecords.AddRange(booksumRedCapRecords);

        //Create Letter Name Identification - Student Progress records
        RedCapRecord lniSpRecord = new();

        lniSpRecord.recordID = recordID;
        lniSpRecord.redcapRepeatInstrument = "letter_name_identification_student_progress";
        lniSpRecord.redcapRepeatInstance = 1;
        //go through each element of sLearnedLetterNames and map to flag
        //handle null case for data w/o letternames
        if(inputData.sLearnedLetterNamesLNI is null)
        {
            inputData.sLearnedLetterNamesLNI = new bool[26];
        }
        lniSpRecord.LNI_A = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[0]);
        lniSpRecord.LNI_B = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[1]);
        lniSpRecord.LNI_C = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[2]);
        lniSpRecord.LNI_D = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[3]);
        lniSpRecord.LNI_E = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[4]);
        lniSpRecord.LNI_F = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[5]);
        lniSpRecord.LNI_G = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[6]);
        lniSpRecord.LNI_H = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[7]);
        lniSpRecord.LNI_I = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[8]);
        lniSpRecord.LNI_J = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[9]);
        lniSpRecord.LNI_K = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[10]);
        lniSpRecord.LNI_L = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[11]);
        lniSpRecord.LNI_M = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[12]);
        lniSpRecord.LNI_N = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[13]);
        lniSpRecord.LNI_O = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[14]);
        lniSpRecord.LNI_P = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[15]);
        lniSpRecord.LNI_Q = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[16]);
        lniSpRecord.LNI_R = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[17]);
        lniSpRecord.LNI_S = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[18]);
        lniSpRecord.LNI_T = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[19]);
        lniSpRecord.LNI_U = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[20]);
        lniSpRecord.LNI_V = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[21]);
        lniSpRecord.LNI_W = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[22]);
        lniSpRecord.LNI_X = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[23]);
        lniSpRecord.LNI_Y = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[24]);
        lniSpRecord.LNI_Z = getBinaryTrueFalse(inputData.sLearnedLetterNamesLNI[25]);

        redCapRecords.Add(lniSpRecord);

        //Create Letter Name Recognition - Results
        // Populate fields for Vocabulary Instrument (field-receptive flag) in RedCap
        List<RedCapRecord> lniRedCapRecords = new();
        for (int lnrRIndex = 0; inputData.sIndividual_LNI != null &&
                                    lnrRIndex < inputData.sIndividual_LNI.GetLength(1); lnrRIndex++)
        {
            //Headers, credentials, etc.
            RedCapRecord lniRRecord;
            AdaptiveResponse[,] lniRSD = inputData.sIndividual_LNI;
            if (lniRedCapRecords.Count - 1 < lnrRIndex)
                lniRedCapRecords.Add(new RedCapRecord());

            lniRRecord = lniRedCapRecords[lnrRIndex];
            lniRRecord.lnirSessionNumber = lnrRIndex + 1;
            lniRRecord.recordID = recordID;
            lniRRecord.redcapRepeatInstrument = "letter_name_identification_results";
            lniRRecord.redcapRepeatInstance = lniRRecord.lnirSessionNumber;

            if(inputData.sAssessorIdLniList.Count > 0 && lnrRIndex < inputData.sAssessorIdLniList.Count && inputData.sAssessorIdLniList[lnrRIndex] != "")
            {
                lniRRecord.assessorIdLni = inputData.sAssessorIdLniList[lnrRIndex];
                lniRRecord.classroomIdLni = inputData.sClassroomIdLniList[lnrRIndex];
                lniRRecord.teacherIdLni = inputData.sTeacherIdLniList[lnrRIndex];
            }
            if(inputData.sAssessorNameLniList.Count > 0 && lnrRIndex < inputData.sAssessorNameLniList.Count && inputData.sAssessorNameLniList[lnrRIndex] != "")
            {
                lniRRecord.assessorNameLni = inputData.sAssessorNameLniList[lnrRIndex];
                lniRRecord.classroomNameLni = inputData.sClassroomNameLniList[lnrRIndex];
                lniRRecord.teacherNameLni = inputData.sTeacherNameLniList[lnrRIndex];
            }

            if ((lniRRecord.assessorIdLni != "" && lniRRecord.assessorIdLni != null) || (lniRRecord.assessorNameLni != "" && lniRRecord.assessorNameLni != null))
            {
                lniRRecord.LNIResultsComplete = 2;
            }

            //Actual data values
            //Not using nullproofing on sessiondata
            //Since AdaptiveResponse(enum) is non-nullable
            //And the 0 value is significant in grading
            lniRRecord.rLNI_A = (int)lniRSD[0, lnrRIndex];
            lniRRecord.rLNI_B = (int)lniRSD[1, lnrRIndex];
            lniRRecord.rLNI_C = (int)lniRSD[2, lnrRIndex];
            lniRRecord.rLNI_D = (int)lniRSD[3, lnrRIndex];
            lniRRecord.rLNI_E = (int)lniRSD[4, lnrRIndex];
            lniRRecord.rLNI_F = (int)lniRSD[5, lnrRIndex];
            lniRRecord.rLNI_G = (int)lniRSD[6, lnrRIndex];
            lniRRecord.rLNI_H = (int)lniRSD[7, lnrRIndex];
            lniRRecord.rLNI_I = (int)lniRSD[8, lnrRIndex];
            lniRRecord.rLNI_J = (int)lniRSD[9, lnrRIndex];
            lniRRecord.rLNI_K = (int)lniRSD[10, lnrRIndex];
            lniRRecord.rLNI_L = (int)lniRSD[11, lnrRIndex];
            lniRRecord.rLNI_M = (int)lniRSD[12, lnrRIndex];
            lniRRecord.rLNI_N = (int)lniRSD[13, lnrRIndex];
            lniRRecord.rLNI_O = (int)lniRSD[14, lnrRIndex];
            lniRRecord.rLNI_P = (int)lniRSD[15, lnrRIndex];
            lniRRecord.rLNI_Q = (int)lniRSD[16, lnrRIndex];
            lniRRecord.rLNI_R = (int)lniRSD[17, lnrRIndex];
            lniRRecord.rLNI_S = (int)lniRSD[18, lnrRIndex];
            lniRRecord.rLNI_T = (int)lniRSD[19, lnrRIndex];
            lniRRecord.rLNI_U = (int)lniRSD[20, lnrRIndex];
            lniRRecord.rLNI_V = (int)lniRSD[21, lnrRIndex];
            lniRRecord.rLNI_W = (int)lniRSD[22, lnrRIndex];
            lniRRecord.rLNI_X = (int)lniRSD[23, lnrRIndex];
            lniRRecord.rLNI_Y = (int)lniRSD[24, lnrRIndex];
            lniRRecord.rLNI_Z = (int)lniRSD[25, lnrRIndex];
        }
        redCapRecords.AddRange(lniRedCapRecords);


        // ------
        //Create Sound Name Identification - Student Progress records
        RedCapRecord lsiSpRecord = new();

        lsiSpRecord.recordID = recordID;
        lsiSpRecord.redcapRepeatInstrument = "letter_sound_identification_student_progress";
        lsiSpRecord.redcapRepeatInstance = 1;
        //go through each element of sLearnedLetterNames and map to flag
        //handle null case for data w/o letternames
        if(inputData.sLearnedLetterNamesLSI is null)
        {
            inputData.sLearnedLetterNamesLSI = new bool[26];
        }
        lsiSpRecord.LSI_A = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[0]);
        lsiSpRecord.LSI_B = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[1]);
        lsiSpRecord.LSI_C = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[2]);
        lsiSpRecord.LSI_D = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[3]);
        lsiSpRecord.LSI_E = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[4]);
        lsiSpRecord.LSI_F = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[5]);
        lsiSpRecord.LSI_G = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[6]);
        lsiSpRecord.LSI_H = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[7]);
        lsiSpRecord.LSI_I = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[8]);
        lsiSpRecord.LSI_J = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[9]);
        lsiSpRecord.LSI_K = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[10]);
        lsiSpRecord.LSI_L = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[11]);
        lsiSpRecord.LSI_M = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[12]);
        lsiSpRecord.LSI_N = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[13]);
        lsiSpRecord.LSI_O = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[14]);
        lsiSpRecord.LSI_P = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[15]);
        lsiSpRecord.LSI_Q = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[16]);
        lsiSpRecord.LSI_R = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[17]);
        lsiSpRecord.LSI_S = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[18]);
        lsiSpRecord.LSI_T = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[19]);
        lsiSpRecord.LSI_U = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[20]);
        lsiSpRecord.LSI_V = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[21]);
        lsiSpRecord.LSI_W = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[22]);
        lsiSpRecord.LSI_X = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[23]);
        lsiSpRecord.LSI_Y = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[24]);
        lsiSpRecord.LSI_Z = getBinaryTrueFalse(inputData.sLearnedLetterNamesLSI[25]);

        redCapRecords.Add(lsiSpRecord);

        //Create Letter Name Recognition - Results
        // Populate fields for Vocabulary Instrument (field-receptive flag) in RedCap
        List<RedCapRecord> lsiRedCapRecords = new();
        for (int lsrRIndex = 0; inputData.sIndividual_LSI != null &&
                                lsrRIndex < inputData.sIndividual_LSI.GetLength(1); lsrRIndex++)
        {
            //Headers, credentials, etc.
            RedCapRecord lsiRRecord;
            AdaptiveResponse[,] lsiRSD = inputData.sIndividual_LSI;
            if (lsiRedCapRecords.Count - 1 < lsrRIndex)
                lsiRedCapRecords.Add(new RedCapRecord());

            lsiRRecord = lsiRedCapRecords[lsrRIndex];
            lsiRRecord.lsirSessionNumber = lsrRIndex + 1;
            lsiRRecord.recordID = recordID;
            lsiRRecord.redcapRepeatInstrument = "letter_sound_identification_results";
            lsiRRecord.redcapRepeatInstance = lsiRRecord.lsirSessionNumber;

            if(inputData.sAssessorIdLsiList.Count > 0 && lsrRIndex< inputData.sAssessorIdLsiList.Count && inputData.sAssessorIdLsiList[lsrRIndex] != "") {
                lsiRRecord.assessorIdLsi = inputData.sAssessorIdLsiList[lsrRIndex];
                lsiRRecord.classroomIdLsi = inputData.sClassroomIdLsiList[lsrRIndex];
                lsiRRecord.teacherIdLsi = inputData.sTeacherIdLsiList[lsrRIndex];
            }
            if(inputData.sAssessorNameLsiList.Count > 0 && lsrRIndex< inputData.sAssessorNameLsiList.Count && inputData.sAssessorNameLsiList[lsrRIndex] != "") {
                lsiRRecord.assessorNameLsi = inputData.sAssessorNameLsiList[lsrRIndex];
                lsiRRecord.classroomNameLsi = inputData.sClassroomNameLsiList[lsrRIndex];
                lsiRRecord.teacherNameLsi = inputData.sTeacherNameLsiList[lsrRIndex];
            }

            if((lsiRRecord.assessorIdLsi != "" && lsiRRecord.assessorIdLsi != null) || (lsiRRecord.assessorNameLsi != "" && lsiRRecord.assessorNameLsi != null))
            {
                lsiRRecord.LSIResultsComplete = 2;
            }

            //Actual data values
            //Not using nullproofing on sessiondata
            //Since AdaptiveResponse(enum) is non-nullable
            //And the 0 value is significant in grading
            lsiRRecord.rLSI_A = (int)lsiRSD[0, lsrRIndex];
            lsiRRecord.rLSI_B = (int)lsiRSD[1, lsrRIndex];
            lsiRRecord.rLSI_C = (int)lsiRSD[2, lsrRIndex];
            lsiRRecord.rLSI_D = (int)lsiRSD[3, lsrRIndex];
            lsiRRecord.rLSI_E = (int)lsiRSD[4, lsrRIndex];
            lsiRRecord.rLSI_F = (int)lsiRSD[5, lsrRIndex];
            lsiRRecord.rLSI_G = (int)lsiRSD[6, lsrRIndex];
            lsiRRecord.rLSI_H = (int)lsiRSD[7, lsrRIndex];
            lsiRRecord.rLSI_I = (int)lsiRSD[8, lsrRIndex];
            lsiRRecord.rLSI_J = (int)lsiRSD[9, lsrRIndex];
            lsiRRecord.rLSI_K = (int)lsiRSD[10, lsrRIndex];
            lsiRRecord.rLSI_L = (int)lsiRSD[11, lsrRIndex];
            lsiRRecord.rLSI_M = (int)lsiRSD[12, lsrRIndex];
            lsiRRecord.rLSI_N = (int)lsiRSD[13, lsrRIndex];
            lsiRRecord.rLSI_O = (int)lsiRSD[14, lsrRIndex];
            lsiRRecord.rLSI_P = (int)lsiRSD[15, lsrRIndex];
            lsiRRecord.rLSI_Q = (int)lsiRSD[16, lsrRIndex];
            lsiRRecord.rLSI_R = (int)lsiRSD[17, lsrRIndex];
            lsiRRecord.rLSI_S = (int)lsiRSD[18, lsrRIndex];
            lsiRRecord.rLSI_T = (int)lsiRSD[19, lsrRIndex];
            lsiRRecord.rLSI_U = (int)lsiRSD[20, lsrRIndex];//PROBLEM HERE OR BELOW
            lsiRRecord.rLSI_V = (int)lsiRSD[21, lsrRIndex];
            lsiRRecord.rLSI_W = (int)lsiRSD[22, lsrRIndex];
            lsiRRecord.rLSI_X = (int)lsiRSD[23, lsrRIndex];
            lsiRRecord.rLSI_Y = (int)lsiRSD[24, lsrRIndex];
            lsiRRecord.rLSI_Z = (int)lsiRSD[25, lsrRIndex];
        }
        redCapRecords.AddRange(lsiRedCapRecords);

        //Populate fields for Beginning Sounds Instrument
        List<RedCapRecord> bsRedCapRecords = new();
        for (int bsIndex = 0; inputData.sIndividual_BS != null &&
            bsIndex < inputData.sIndividual_BS.GetLength(1); bsIndex++)
        {
            //Headers, credentials, etc.
            RedCapRecord bsRecord;
            AdaptiveResponse[,] bsSD = inputData.sIndividual_BS;
            if (bsRedCapRecords.Count - 1 < bsIndex)
                bsRedCapRecords.Add(new RedCapRecord());

            bsRecord = bsRedCapRecords[bsIndex];
            bsRecord.bsSessionNumber = bsIndex + 1;
            bsRecord.recordID = recordID;
            bsRecord.redcapRepeatInstrument = "beginning_sounds";
            bsRecord.redcapRepeatInstance = bsRecord.bsSessionNumber;

            if(inputData.sAssessorIdBsList.Count > 0 && bsIndex< inputData.sAssessorIdBsList.Count && inputData.sAssessorIdBsList[bsIndex] != "")
            {
                bsRecord.assessorIdBs = inputData.sAssessorIdBsList[bsIndex];
                bsRecord.classroomIdBs = inputData.sClassroomIdBsList[bsIndex];
                bsRecord.teacherIdBs = inputData.sTeacherIdBsList[bsIndex];
            }
            if(inputData.sAssessorNameBsList.Count > 0 && bsIndex< inputData.sAssessorNameBsList.Count && inputData.sAssessorNameBsList[bsIndex] != "")
            {
                bsRecord.assessorNameBs = inputData.sAssessorNameBsList[bsIndex];
                bsRecord.classroomNameBs = inputData.sClassroomNameBsList[bsIndex];
                bsRecord.teacherNameBs = inputData.sTeacherNameBsList[bsIndex];
            }

            if ((bsRecord.assessorIdBs != "" && bsRecord.assessorIdBs != null) || (bsRecord.assessorNameBs != "" && bsRecord.assessorNameBs != null))
            {
                bsRecord.beginningSoundsComplete = 2;
            }

            //Total Scores
            var tupleTemp = (Tuple<double, double>[])inputData.final_BSscores;
            if (tupleTemp[bsIndex] != null)
            {
                bsRecord.bsEAP = tupleTemp[bsIndex].Item1;
                bsRecord.bsStdError = tupleTemp[bsIndex].Item2;
            }
            
            //Actual data values
            //Not using nullproofing on sessiondata
            //Since AdaptiveResponse(enum) is non-nullable
            //And the 0 value is significant in grading
            //Refer to bs_items.json for reesponse list
            bsRecord.bsHand = (int)bsSD[0, bsIndex];
            bsRecord.bsMoon = (int)bsSD[1, bsIndex];
            bsRecord.bsSun = (int)bsSD[2, bsIndex];
            bsRecord.bsDoor = (int)bsSD[3, bsIndex];
            bsRecord.bsMouse = (int)bsSD[4, bsIndex];
            bsRecord.bsCar = (int)bsSD[5, bsIndex];
            bsRecord.bsFan = (int)bsSD[6, bsIndex];
            bsRecord.bsPot = (int)bsSD[7, bsIndex];
            bsRecord.bsHat = (int)bsSD[8, bsIndex];
            bsRecord.bsBall = (int)bsSD[9, bsIndex];
            bsRecord.bsDuck = (int)bsSD[10, bsIndex];
            bsRecord.bsVan = (int)bsSD[11, bsIndex];
            bsRecord.bsDog = (int)bsSD[12, bsIndex];
            bsRecord.bsCake = (int)bsSD[13, bsIndex];
            bsRecord.bsLeaf = (int)bsSD[14, bsIndex];
            bsRecord.bsHeart = (int)bsSD[15, bsIndex];
            bsRecord.bsFour = (int)bsSD[16, bsIndex];
            bsRecord.bsMilk = (int)bsSD[17, bsIndex];
            bsRecord.bsNut = (int)bsSD[18, bsIndex];
            bsRecord.bsNest = (int)bsSD[19, bsIndex];
            bsRecord.bsBook = (int)bsSD[20, bsIndex];
            bsRecord.bsSock = (int)bsSD[21, bsIndex];
            bsRecord.bsBird = (int)bsSD[22, bsIndex];
            bsRecord.bsFox = (int)bsSD[23, bsIndex];
            bsRecord.bsCup = (int)bsSD[24, bsIndex];
            bsRecord.bsPants = (int)bsSD[25, bsIndex];
            bsRecord.bsChalk = (int)bsSD[26, bsIndex];
            bsRecord.bsNose = (int)bsSD[27, bsIndex];
            bsRecord.bsChin = (int)bsSD[28, bsIndex];
            bsRecord.bsChair = (int)bsSD[29, bsIndex];
            bsRecord.bsLeg = (int)bsSD[30, bsIndex];
            bsRecord.bsNet = (int)bsSD[31, bsIndex];
            bsRecord.bsFish = (int)bsSD[32, bsIndex];
            bsRecord.bsCat = (int)bsSD[33, bsIndex];
            bsRecord.bsLamp = (int)bsSD[34, bsIndex];
            bsRecord.bsCheese = (int)bsSD[35, bsIndex];
            
            //Now that the scores are out of the way,
            //Let's also store the child responses
            String[,] bsRes = inputData.sIndividual_BSChildResponse;
            bsRecord.bsResHand = bsRes[0, bsIndex];
            bsRecord.bsResMoon = bsRes[1, bsIndex];
            bsRecord.bsResSun = bsRes[2, bsIndex];
            bsRecord.bsResDoor = bsRes[3, bsIndex];
            bsRecord.bsResMouse = bsRes[4, bsIndex];
            bsRecord.bsResCar = bsRes[5, bsIndex];
            bsRecord.bsResFan = bsRes[6, bsIndex];
            bsRecord.bsResPot = bsRes[7, bsIndex];
            bsRecord.bsResHat = bsRes[8, bsIndex];
            bsRecord.bsResBall = bsRes[9, bsIndex];
            bsRecord.bsResDuck = bsRes[10, bsIndex];
            bsRecord.bsResVan = bsRes[11, bsIndex];
            bsRecord.bsResDog = bsRes[12, bsIndex];
            bsRecord.bsResCake = bsRes[13, bsIndex];
            bsRecord.bsResLeaf = bsRes[14, bsIndex];
            bsRecord.bsResHeart = bsRes[15, bsIndex];
            bsRecord.bsResFour = bsRes[16, bsIndex];
            bsRecord.bsResMilk = bsRes[17, bsIndex];
            bsRecord.bsResNut = bsRes[18, bsIndex];
            bsRecord.bsResNest = bsRes[19, bsIndex];
            bsRecord.bsResBook = bsRes[20, bsIndex];
            bsRecord.bsResSock = bsRes[21, bsIndex];
            bsRecord.bsResBird = bsRes[22, bsIndex];
            bsRecord.bsResFox = bsRes[23, bsIndex];
            bsRecord.bsResCup = bsRes[24, bsIndex];
            bsRecord.bsResPants = bsRes[25, bsIndex];
            bsRecord.bsResChalk = bsRes[26, bsIndex];
            bsRecord.bsResNose = bsRes[27, bsIndex];
            bsRecord.bsResChin = bsRes[28, bsIndex];
            bsRecord.bsResChair = bsRes[29, bsIndex];
            bsRecord.bsResLeg = bsRes[30, bsIndex];
            bsRecord.bsResNet = bsRes[31, bsIndex];
            bsRecord.bsResFish = bsRes[32, bsIndex];
            bsRecord.bsResCat = bsRes[33, bsIndex];
            bsRecord.bsResLamp = bsRes[34, bsIndex];
            bsRecord.bsResCheese = bsRes[35, bsIndex];/**/

        }
        redCapRecords.AddRange(bsRedCapRecords);

        //if (inputData.sAssessorIdCAPList.Count > 0 || inputData.sAssessorNameCAPList.Count > 0)
        //{
            List<RedCapRecord> CAPRedCapRecords = new();
            for (int CAPIndex = 0; inputData.sIndividual_CAP != null &&
                CAPIndex < inputData.sIndividual_CAP.GetLength(1); CAPIndex++)
            {
                //Headers, credentials, etc.
                RedCapRecord CAPRecord;
                AdaptiveResponse[,] CAPSD = inputData.sIndividual_CAP;
                if (CAPRedCapRecords.Count - 1 < CAPIndex)
                    CAPRedCapRecords.Add(new RedCapRecord());

                CAPRecord = CAPRedCapRecords[CAPIndex];
                CAPRecord.CAPSessionNumber = CAPIndex + 1;
                CAPRecord.recordID = recordID;
                CAPRecord.redcapRepeatInstrument = "concepts_of_print";
                CAPRecord.redcapRepeatInstance = CAPRecord.CAPSessionNumber;


                if (inputData.sAssessorIdCAPList.Count > 0 && CAPIndex< inputData.sAssessorIdCAPList.Count && inputData.sAssessorIdCAPList[CAPIndex] != "")
                {
                    CAPRecord.assessorIdCAP = inputData.sAssessorIdCAPList[CAPIndex];
                    CAPRecord.classroomIdCAP = inputData.sClassroomIdCAPList[CAPIndex];
                    CAPRecord.teacherIdCAP = inputData.sTeacherIdCAPList[CAPIndex];
                }
                if (inputData.sAssessorNameCAPList.Count > 0 && CAPIndex< inputData.sAssessorNameCAPList.Count && inputData.sAssessorNameCAPList[CAPIndex] != "")
                {
                    CAPRecord.assessorNameCAP = inputData.sAssessorNameCAPList[CAPIndex];
                    CAPRecord.classroomNameCAP = inputData.sClassroomNameCAPList[CAPIndex];
                    CAPRecord.teacherNameCAP = inputData.sTeacherNameCAPList[CAPIndex];
                }

            /*if (inputData.sExportImportRef == "ID")
            {
                CAPRecord.assessorIdCAP = assessorID;
                CAPRecord.classroomIdCAP = classroomID;
                CAPRecord.teacherIdCAP = teacherID;
            }
            else
            {
                CAPRecord.assessorNameCAP = assessorID;
                CAPRecord.classroomNameCAP = classroomID;
                CAPRecord.teacherNameCAP = teacherID;
            }*/

                int iter = 0;

                for (int ind = 0; ind < CAPSD.GetLength(0); ind++)
                {
                    if (CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct || CAPSD[ind, CAPIndex] == AdaptiveResponse.Incorrect)
                    {
                        if (iter == 0)
                        {
                            CAPRecord.CAPQuestion1 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs1result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                            CAPRecord.CAPComplete = 2;
                        }
                        if (iter == 1)
                        {
                            CAPRecord.CAPQuestion2 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs2result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 2)
                        {
                            CAPRecord.CAPQuestion3 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs3result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 3)
                        {
                            CAPRecord.CAPQuestion4 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs4result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 4)
                        {
                            CAPRecord.CAPQuestion5 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs5result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 5)
                        {
                            CAPRecord.CAPQuestion6 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs6result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 6)
                        {
                            CAPRecord.CAPQuestion7 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs7result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 7)
                        {
                            CAPRecord.CAPQuestion8 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs8result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 8)
                        {
                            CAPRecord.CAPQuestion9 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs9result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 9)
                        {
                            CAPRecord.CAPQuestion10 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs10result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 10)
                        {
                            CAPRecord.CAPQuestion11 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs11result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }
                        if (iter == 11)
                        {
                            CAPRecord.CAPQuestion12 = AdvanceCAPItem.prompts_CAP[AdvanceCAPItem.prompts_difficulties_universal[ind]];
                            CAPRecord.CAPQs12result = CAPSD[ind, CAPIndex] == AdaptiveResponse.Correct ? 1 : 0;
                        }

                        iter++;
                    }

                }



                //Total Scores
                var tupleTemp = (Tuple<double, double>[])inputData.final_CAPscores;
                if (tupleTemp[CAPIndex] != null)
                {
                    CAPRecord.CAPEAP = tupleTemp[CAPIndex].Item1;
                    CAPRecord.CAPStdError = tupleTemp[CAPIndex].Item2;
                }

            }
            redCapRecords.AddRange(CAPRedCapRecords);
        //}

        return redCapRecords;
    }

    // Function responsible for returning int truth value
    public static int getBinaryTrueFalse(bool value)
    {
        return value ? 1 : 0;
    }
}

[Serializable]
public class UsersDetails
{
    public List<RedCapRecord> users = new List<RedCapRecord>();
}