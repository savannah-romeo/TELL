using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Validation_Vocab checks to see if Vocab input is valid
public class Validation_Writing : Validation_Games
{
    //Takes the required toggle inputs from the Vocab
    public Toggle name_score_0;
    public Toggle name_score_1;
    public Toggle name_score_2;
    public Toggle name_score_3;
    public Toggle name_score_4;
    public Toggle sen_score_0;
    public Toggle sen_score_1;
    public Toggle sen_score_2;
    public Toggle sen_score_3;
    public Toggle sen_score_4;
    public bool validScene; //Used for checks to advance scene
    public bool validInput; //Used for checks to advance prompts

    //Check the input
    public override bool Validator()
    {
        validScene = true;
        validInput = true;

        //Invalid if neither expressive is ticked
        if (!name_score_0.isOn && !name_score_1.isOn && !name_score_2.isOn && !name_score_3.isOn && !name_score_4.isOn)
        {
            validScene = false;
            validInput = false;
        }
        if (!sen_score_0.isOn && !sen_score_1.isOn && !sen_score_2.isOn && !sen_score_3.isOn && !sen_score_4.isOn)
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
