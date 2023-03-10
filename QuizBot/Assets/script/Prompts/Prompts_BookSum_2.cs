//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum_2 : Array_Prompts
{
    Prompts_BookSum_2()
    {
        //See array_prompts for definition
        prompts1 = new string[5] {
            "(4) Do you toss the dough to keep it from getting dry?",
            "(5) Is this book mostly about pizza or about dough?",
            "(6) Do you make pizza dough with flour or sugar?",
            "(7) The pizza is ready to eat when it's hot. How do you know it is hot?",
            "(8) After we toss the dough, what is the next step in making the pizza?"

        };

        prompts2 = new string[5] {
            "(4) Do all giraffes have the same pattern of spots?",
            "(5) Is this book mostly about giraffes or about leaves?",
            "(6) Do giraffes like to eat leaves or flowers?",
            "(7) Giraffes do not like to be alone. How do you know that?",
            "(8) About how many giraffes are in a herd?" 
        };

        prompts3 = new string[5] {
            "(4) Are baby seals born in the ocean?",
            "(5) Is this book mostly about seals or about clams?",
            "(6) Do seals like to eat clams or seaweed?",
            "(7) Seals can hold their breath. How do you know that?",
            "(8) Why do seals need a thick layer of fat?"

        };
    }
}
