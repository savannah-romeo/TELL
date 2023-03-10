//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_SR_1 : Array_Prompts
{
    Prompts_SR_1()
    {
        //See array_prompts for definition
        prompts1 = new string[8] {
            "(1) Did the child use the main character's name?",
            "(2) Did the child say what the main character wanted to make?",
            "(3) Did the child say that the present was for Emma's father?",
            "(4) Did the child give a reason why Emma wanted to give a present to her father?",
            "(5) Did the child say what Emma used to make the picture?",
            "(6) Did the child say that Emma drew a pictire of her family?",
            "(7) Did the child say that Emma wrapped the present?",
            "(8) Did the child say that the father was very happy with Emma's present?"

        };

        prompts2 = new string[8] {
            "(1) Did the child use the main character's name?",
            "(2) Did the child say what the main character wanted to make?",
            "(3) Did the child say that the cake was for Johnny’s mother?",
            "(4) Did the child give a reason why Johnny wanted to make a cake for his mother?",
            "(5) Did the child say what Johnny used to make the cake?",
            "(6) Did the child say that Johnny mixed the ingredients and/or put it in the pan?",
            "(7) Did the child say that Johnny frosted the cake?",
            "(8) Did the child say that the mother was very happy with Johnny’s cake?"

        };

        prompts3 = new string[8] {
            "(1) Did the child use the main character's name?",
            "(2) Did the child say what the main character wanted to do?",
            "(3) Did the child say that Miguel and his dad went outside?",
            "(4) Did the child say that Miguel put on his helmet?",
            "(5) Did the child say Miguel climbed on his bike and/or that his dad held the bike?",
            "(6) Did the child say that Miguel rode down the street?",
            "(7) Did the child say that Miguel was so happy that he could ride his bike?",
            "(8) Did the child say that the dad was very happy for Miguel?"

        };

    }
}
