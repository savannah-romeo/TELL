//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum3_Answers : Array_Prompts
{
    Prompts_BookSum3_Answers()
    {
        //See array_prompts for definition
        prompts1 = new string[3] {
            "(9) Turn on the oven",
            "(10) Toss it",
            "(11) Slice it/eat it"

        };

        prompts2 = new string[3] {
            "(9) Leaves",
            "(10) A herd",
            "(11) Yes"
        };

        prompts3 = new string[3] {
            "(9) Fish/seabirds/clams",
            "(10) Pups",
            "(11) Hold its breath"

        };
    }
}
