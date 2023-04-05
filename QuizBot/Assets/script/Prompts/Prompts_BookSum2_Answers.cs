//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum2_Answers : Array_Prompts
{
    Prompts_BookSum2_Answers()
    {
        //See array_prompts for definition
        prompts1 = new string[5] {
            "(4) Yes",
            "(5) Pizza",
            "(6) Flour",
            "(7) 2 points:\r\n Because you cook it in a hot oven \r\n Because you see the cheese bubble or hear it sizzle\r\n" +
            "1 point:\r\n Because you eat hot pizza\r\n0 points:\r\n No logical answer",
            "(8) Sauce, toppings, and/or cheese"

        };

        prompts2 = new string[5] {
            "(4) No",
            "(5) Giraffes",
            "(6) Leaves",
            "(7) 2 points:\r\n Because they travel in herds.\r\n1 point:\r\n Answer relates to child’s experience of being alone." +
            "\r\n0 points:\r\n No logical answer",
            "(8) Six to twelve"
        };

        prompts3 = new string[5] {
            "(4) No",
            "(5) Seals",
            "(6) Clams",
            "(7) 2 points:\r\n Because they can stay underwater for a long time\r\n1 point:\r\n Write child’s answer for " +
            "one point credit\r\n0 points:\r\n No logical answer",
            "(8) To keep them warm"

        };
    }
}
