//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum_3 : Array_Prompts
{
    Prompts_BookSum_3()
    {
        //See array_prompts for definition
        prompts1 = new string[3] {
            "(9) What do we do first to make the pizza? (Turn to 3rd page)",
            "(10) Whatdowedowith the dough after we make it? (Turn to 5th page)",
            "(11) What do we do when the pizza is ready? (Turn to last page)"

        };

        prompts2 = new string[3] {
            "(9) What do giraffes like to eat? (Turn to 2nd page)",
            "(10) What do you call a group of giraffes? (Turn to 6th-7th page)",
            "(11)) Do giraffes have big babies?"
        };

        prompts3 = new string[3] {
            "(9) What do seals like to eat? (Turn to 2nd page)",
            "(10) What are baby seals called? (Turn to 4th page)",
            "(11) What does a seal have to do when it swims underwater? (Turn to last page)"

        };
    }
}
