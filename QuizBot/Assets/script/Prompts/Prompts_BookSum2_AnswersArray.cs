//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum2_AnswersArray : Array_Prompts_BookSum_Answers
{

    Prompts_BookSum2_AnswersArray()
    {
        prompt1Answers = new Dictionary<int, string[]>();
        //See array_prompts for definition
        prompt1Answers.Add(1,new string[1] { "Yes" });
        prompt1Answers.Add(2, new string[1] { "Pizza" });
        prompt1Answers.Add(3, new string[1] { "Flour" });
        prompt1Answers.Add(4, new string[3] { "Because you cook it in a hot oven (2 points)",
            "Because you see the cheese bubble or hear it sizzle (2 points)", "Because you eat hot pizza (1 point)" });
        prompt1Answers.Add(5, new string[1] { "Sauce, toppings, and/or cheese" });

        prompt2Answers = new Dictionary<int, string[]>();
        prompt2Answers.Add(1, new string[1] { "No" });
        prompt2Answers.Add(2, new string[1] { "Giraffes" });
        prompt2Answers.Add(3, new string[1] { "Leaves" });
        prompt2Answers.Add(4, new string[2] { "Because they travel in herds (2 points)", "Answer relates to child’s experience of being alone (1 point)" });
        prompt2Answers.Add(5, new string[1] { "Six to twelve" });

        prompt3Answers = new Dictionary<int, string[]>();
        prompt3Answers.Add(1, new string[1] { "No" });
        prompt3Answers.Add(2, new string[1] { "Seals" });
        prompt3Answers.Add(3, new string[1] { "Clams" });
        prompt3Answers.Add(4, new string[2] { "Because they can stay underwater for a long time (2 points)", "Any other logical answer (1 point)" });
        prompt3Answers.Add(5, new string[1] { "To keep them warm" });
    }
}
