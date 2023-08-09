//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum1_AnswersArray : Array_Prompts_BookSum_Answers
{

    Prompts_BookSum1_AnswersArray()
    {
        prompt1Answers = new Dictionary<int, string[]>();
        //See array_prompts for definition
        prompt1Answers.Add(1,new string[1] { "Pizza / How to make pizza" });
        prompt1Answers.Add(2, new string[11] { "uses dough", "uses tomato sauce", "uses cheese", "uses toppings", "uses/turns on the oven",
            "tosses the dough to keep it from drying out", "bakes the pizza in a hot oven", "sees the cheese bubble", "hears it sizzle", "can smell pizza cooking", "can cut pizza into slices"});
        prompt1Answers.Add(3, new string[11] { "uses dough", "uses tomato sauce", "uses cheese", "uses toppings", "uses/turns on the oven",
            "tosses the dough to keep it from drying out", "bakes the pizza in a hot oven", "sees the cheese bubble", "hears it sizzle", "can smell pizza cooking", "can cut pizza into slices"});


        prompt2Answers = new Dictionary<int, string[]>();
        prompt2Answers.Add(1, new string[1] { "Giraffes" });
        prompt2Answers.Add(2, new string[8] { "are the tallest animals on land", "have long legs", "have long necks", "eat all day",
            "eat lots of leaves", "have different patterns of spots", "stay together in herds", "have very big babies" });
        prompt2Answers.Add(3, new string[8] { "are the tallest animals on land", "have long legs", "have long necks", "eat all day",
            "eat lots of leaves", "have different patterns of spots", "stay together in herds", "have very big babies" });


        prompt3Answers = new Dictionary<int, string[]>();
        prompt3Answers.Add(1, new string[1] { "Seals" });
        prompt3Answers.Add(2, new string[8] { "are mammals", "live in the sea and/or on the shore", "some have ears and some don’t",
            "babies are called pups", "like to eat fish, seabirds,and/or clams","have blubber and/or fur to keep them warm", "swim under water"
            , "hold their breath for a long time" });
        prompt3Answers.Add(3, new string[8] { "are mammals", "live in the sea and/or on the shore", "some have ears and some don’t",
            "babies are called pups", "like to eat fish, seabirds,and/or clams","have blubber and/or fur to keep them warm", "swim under water"
            , "hold their breath for a long time" });
    }
}
