//This class is used to exit the app when a button is clicked
using UnityEngine;
using UnityEngine.UI;

public class GradeQuestion : MonoBehaviour
{
    public Button gradeButton; //Button clicked
    public DataManager gradeData;
    public AdvanceText gradedQuestions;
    public AdvanceBSItem gradedQuestionsBS;
    public AdvanceCAPItem gradedQuestionsCAP;
    public AdvanceVocabItem gradedQuestionsVocab;
    public Validation_Games checker; //Used to check for valid answer before proceeding

    void Start()
    {
        //Create listener for the button in question
        gradeButton.onClick.AddListener(GradeOnClick);
    }

    void GradeOnClick()
    {
        //Prevents incrementing during final question
        //Due to uncertain execution order, we let the data manager
        //grade the final question in its class
        checker.Validator();
        if (checker.GetValidInput())
        {
            if ((DataManager.globalGame == "BS_Instructions"
                || DataManager.globalGame == "BS_Instructions_1") && gradedQuestionsBS.gradeMe)
                gradeData.GradeQuestion();
            else if ((DataManager.globalGame == "CAP_Instructions"
                 || DataManager.globalGame == "CAP_Instructions_1") && gradedQuestionsCAP.gradeMe)
                    gradeData.GradeQuestion();
            else if ((DataManager.globalGame == "Instructions_Vocab") && gradedQuestionsVocab.gradeMe)
                gradeData.GradeQuestion();
            else if (null != gradedQuestions && gradedQuestions.gradeMe)
                gradeData.GradeQuestion();
        }
    }
}
