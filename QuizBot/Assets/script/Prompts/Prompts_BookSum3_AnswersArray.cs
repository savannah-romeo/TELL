//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum3_AnswersArray : Array_Prompts_BookSum_Answers
{

    Prompts_BookSum3_AnswersArray()
    {
        prompt1Answers = new Dictionary<int, string[]>();
        //See array_prompts for definition
        prompt1Answers.Add(1,new string[1] { "Turn on the oven" });
        prompt1Answers.Add(2, new string[1] { "Toss it" });
        prompt1Answers.Add(3, new string[1] { "Slice it/eat it" });

        prompt2Answers = new Dictionary<int, string[]>();
        prompt2Answers.Add(1, new string[1] { "Leaves" });
        prompt2Answers.Add(2, new string[1] { "A herd" });
        prompt2Answers.Add(3, new string[1] { "Yes" });

        prompt3Answers = new Dictionary<int, string[]>();
        prompt3Answers.Add(1, new string[1] { "Fish/seabirds/clams" });
        prompt3Answers.Add(2, new string[1] { "Pups" });
        prompt3Answers.Add(3, new string[1] { "Hold its breath" });
        
    }
}
