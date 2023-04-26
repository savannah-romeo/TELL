
using UnityEngine.UI;

public class Validation_CAP : Validation_Games
{
    //Takes the required toggle inputs from the evaluator
    public Toggle response_yes;
    public Toggle response_no;
    public AdvanceCAPItem advanceCAPItem;
    public bool validScene; //Used for checks to advance scene
    public bool validInput; //Used for checks to advance prompts
    public override bool Validator()
    {
        validScene = true;
        validInput = true;

        //Do not advance scene until prompts are done
        if (!advanceCAPItem.complete)
            validScene = false;

        //Invalid if neither response is ticked
        if (!response_yes.isOn && !response_no.isOn)
        {
            validScene = false;
            validInput = false;
        }

        return validScene;
    }

    public override bool GetValidInput()
    {
        return validInput;
    }
}