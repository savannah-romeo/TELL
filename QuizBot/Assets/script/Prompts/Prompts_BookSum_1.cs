//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum_1 : Array_Prompts
{
    Prompts_BookSum_1()
    {
        //See array_prompts for definition
        prompts1 = new string[3] {
            "(1) What is this book about?",
            "(2) Tell me one interesting detail you learned in this book.",
            "(3) Tell me something else you learned about making a pizza. (If the child gives the same detail, assessor may prompt, 'Tell me something different you learned.'"

        };

        prompts2 = new string[3] {
            "(1) What is this book about?",
            "(2) Tell me one interesting detail you learned in this book.",
            "(3) Tell me something else you learned about giraffes. (If the child gives the same detail, assessor may prompt, 'Tell me something different you learned.'"

        };

        prompts3 = new string[3] {
            "(1) What is this book about?",
            "(2) Tell me one interesting detail you learned in this book.",
            "(3) Tell me something else you learned about seals. (If the child gives the same detail, assessor may prompt, 'Tell me something different you learned.'"

        };
    }
}
