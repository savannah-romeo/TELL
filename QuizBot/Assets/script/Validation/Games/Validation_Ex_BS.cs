
using UnityEngine.UI;

public class Validation_Ex_BS : Validation_Games
{
    //Takes the required toggle inputs from the evaluator
    public Toggle response_yes;
    public Toggle response_no;
    public bool validScene; //Used for checks to advance scene
    public bool validInput; //Used for checks to advance prompts
    public override bool Validator()
    {
        return true;
    }

    public override bool GetValidInput()
    {
        return validInput;
    }
}