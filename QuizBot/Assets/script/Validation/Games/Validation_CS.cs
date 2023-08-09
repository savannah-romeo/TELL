using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Validation_Vocab checks to see if Vocab input is valid
public class Validation_CS : Validation_Games
{
    //Takes the required toggle inputs from the Vocab
    public Toggle expressive_yes;
    public Toggle expressive_no;
    public AdvanceText prompts;
    public bool validScene; //Used for checks to advance scene
    public bool validInput; //Used for checks to advance prompts

    //Check the input
    public override bool Validator()
    {
        validScene = true;
        validInput = true;

        //Do not advance scene until prompts are done
        if (!prompts.complete)
            validScene = false;

        //Invalid if neither expressive is ticked
        if (expressive_yes != null && !expressive_yes.isOn && expressive_no != null && !expressive_no.isOn)
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
