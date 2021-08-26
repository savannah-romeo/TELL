using UnityEngine;
using UnityEngine.UI;

//Validation_Evaluator checks to see if Evaluator input is valid
public class Validation_Evaluator : Validation_Parent
{
    //Takes the required toggle inputs from the evaluator
    public Toggle expressive_yes;
    public Toggle expressive_no;
    public Toggle receptive_yes;
    public Toggle receptive_no;
    public OnClick_Button_AdvanceText prompts;
    public bool valid;

    //Check the input
    public override bool Validator()
    {
        valid = true;

        //Do not advance scene until prompts are done
        if (!prompts.complete)
            valid = false;

        //Invalid if neither expressive is ticked
        if (!expressive_yes.isOn && !expressive_no.isOn)
            valid = false;

        //Invalid if expressive no is ticked AND 
        //neither receptive is ticked
        if (expressive_no.isOn && !receptive_yes.isOn && !receptive_no.isOn)
            valid = false;

        return valid;
    }
}
