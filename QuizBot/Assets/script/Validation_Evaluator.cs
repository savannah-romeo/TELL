using UnityEngine;
using UnityEngine.UI;

//Validation_Evaluator checks to see if Evaluator input is valid
public class Validation_Evaluator : MonoBehaviour
{
    //Takes the required toggle inputs from the evaluator
    public Toggle expressive_yes;
    public Toggle expressive_no;
    public Toggle receptive_yes;
    public Toggle receptive_no;

    //Check the input
    public bool EvaluatorValidation()
    {
        bool valid = true;

        //Invalid if neither expressive is ticked
        if (!expressive_yes.isOn && !expressive_no.isOn)
            valid = false;

        //Invalid if neither receptive is ticked
        if (!receptive_yes.isOn && !receptive_no.isOn)
            valid = false;

        return valid;
    }
}
