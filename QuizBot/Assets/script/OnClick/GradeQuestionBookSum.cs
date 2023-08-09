//This class is used to exit the app when a button is clicked
using UnityEngine;
using UnityEngine.UI;

public class GradeQuestionBookSum : MonoBehaviour
{
    public Button gradeButton; //Button clicked
    public DataManager gradeData;
    public AdvanceTextBookSum gradedQuestionsBookSum;

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
        if (gradedQuestionsBookSum.validateInput())
        {
            if ((DataManager.globalGame == "BookSum_Instructions_New_1") && gradedQuestionsBookSum.gradeMe)
                gradeData.GradeQuestion();
            
        }
    }
}
