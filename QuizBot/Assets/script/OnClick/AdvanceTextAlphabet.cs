//This class is a variant of advancetext
//Designed for use with the 25 prompts of the alphabet
//Used by LNI and LSi
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdvanceTextAlphabet : AdvanceText
{
    public TextMeshProUGUI bigShownText; //holds the big text
    public LNIToggleCheck lniToggleCheck;
    public TextMeshProUGUI description;
    public Button exitButton;

    public override void Start()
    {
        base.Start();
        if ((DataManager.globalGame == "LNI_Instructions" && terminateLNI) || 
                (DataManager.globalGame == "LSI_Instructions" && terminateLSI))
        {
            bigShownText.gameObject.SetActive(false);
            bigShownText.text = "";
            description.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }
        else
        {
            bigShownText.gameObject.SetActive(true);
            bigShownText.text = textArray[iterator]; //Display the first text

            if (description != null)
            {
                description.gameObject.SetActive(false);
            }
            if (exitButton != null)
            {
                exitButton.gameObject.SetActive(false);
            }
        }
    }

    //Alphabet prompts do not depend on time, so we store all in prompts 1
    public override string[] PromptSelect(int selection)
    {
        return prompts.prompts1;
    }

    //Need to add the check for 4/6 right or abort
    protected override void TaskOnClick()
    {
        base.TaskOnClick(); //increment to iterator is here

        if (DataManager.globalGame == "LNI_Instructions")
        {
            /*int part1 = 6 - 1;
            if (iterator == part1 && lniToggleCheck.end) //ok, we've hit 6
            {
                int wrongos = 0;
                //if we can find 3+ incorrect answers, it's time to stop
                for (int index = 0; index < DataManager.individual_LNI.GetLength(0); index++)
                {
                    if(DataManager.individual_LNI[index, DataManager.globalTime-1] == AdaptiveResponse.Incorrect)
                        wrongos++;
                }
                if (wrongos >= 3)
                    complete = true;
            }*/
            bigShownText.text = textArray[iterator];
        }

        if (DataManager.globalGame == "LSI_Instructions")
        {
            int twoStepRuleThreshold = 3;
            foreach (var alphabet in DataManager.exceptionalAdaptCharactersLSI)
            {
                int alphabetValue = char.Parse(alphabet);
                int alphabetIndex = alphabetValue - 65;
                if (DataManager.learnedLetterNamesLSI[alphabetIndex])
                {
                    twoStepRuleThreshold -= 1;
                }
            }

            if (twoStepRuleThreshold > 0 && iterator == 5)
            {
                int wrongos = 0;
                //if we can find 3+ incorrect answers, it's time to stop
                for (int index = 0; index < DataManager.individual_LSI.GetLength(0); index++)
                {
                    if(DataManager.individual_LSI[index, DataManager.globalTime-1] == AdaptiveResponse.Incorrect)
                        wrongos++;
                }
                // Atleast 3 should be correct to proceed game
                if (wrongos > 3)
                    complete = true;
            }
            
            bigShownText.text = textArray[iterator];
        }
    }
}
