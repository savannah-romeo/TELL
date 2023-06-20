using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Validation_Vocab checks to see if Vocab input is valid
public class Validation_SR : Validation_Games
{
    //Takes the required toggle inputs from the Vocab
    
    public ToggleGroup[] srToggleGroups;
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
        if (togglesSelected())
        {
            validScene = false;
            validInput = false;
        }

        return validScene;
    }

    public bool togglesSelected()
    {
        bool returnVal = false;
        
            for (int i = 0; i < srToggleGroups.Length; i++)
            {
                Toggle[] correctAndIncorrect = srToggleGroups[i].GetComponentsInChildren<Toggle>();
                if (!correctAndIncorrect[0].isOn && !correctAndIncorrect[1].isOn)
                {
                    returnVal = true;
                    break;
                }
            }
        return returnVal;
        }
    

    public override bool GetValidInput()
    {
        return validInput;
    }
}
