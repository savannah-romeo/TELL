//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_BookSum1_Answers : Array_Prompts
{
    Prompts_BookSum1_Answers()
    {
        //See array_prompts for definition
        prompts1 = new string[3] {
            "(1) Pizza/How to make pizza",
            "(2) To make pizza, one..."+System.Environment.NewLine+" uses dough "+System.Environment.NewLine+" uses tomato sauce" +
            System.Environment.NewLine+" uses cheese"+System.Environment.NewLine+" uses toppings"+System.Environment.NewLine+" uses/turns on the oven" +
            System.Environment.NewLine+" tosses the dough to keep it from drying out"+System.Environment.NewLine+" bakes the pizza in a hot oven" +
            System.Environment.NewLine+" sees the cheese bubble"+System.Environment.NewLine+" hears it sizzle"+System.Environment.NewLine+" can smell pizza cooking"+System.Environment.NewLine+" can cut pizza into slices",
            "(3) To make pizza, one..."+System.Environment.NewLine+" uses dough "+System.Environment.NewLine+" uses tomato sauce" +
            System.Environment.NewLine+" uses cheese"+System.Environment.NewLine+" uses toppings"+System.Environment.NewLine+" uses/turns on the oven" +
            System.Environment.NewLine+" tosses the dough to keep it from drying out"+System.Environment.NewLine+" bakes the pizza in a hot oven" +
            System.Environment.NewLine+" sees the cheese bubble"+System.Environment.NewLine+" hears it sizzle"+System.Environment.NewLine+" can smell pizza cooking"+System.Environment.NewLine+" can cut pizza into slices"

        };


        prompts2 = new string[3] {
            "(1) Giraffes",
            "(2) Giraffes...\r\n are the tallest animals on land\r\n have long legs\r\n" +
            " have long necks\r\n eat all day\r\n eat lots of leaves\r\n have different patterns of spots" +
            "\r\n stay together in herds\r\n have very big babies",
            "(3) Giraffes...\r\n are the tallest animals on land\r\n have long legs\r\n" +
            " have long necks\r\n eat all day\r\n eat lots of leaves\r\n have different patterns of spots" +
            "\r\n stay together in herds\r\n have very big babies"

        };

        prompts3 = new string[3] {
            "(1) Seals",
            "(2) Seals...\r\n are mammals\r\n live in the sea and/or on the shore\r\n some have ears and some don’t" +
            "\r\n babies are called pups\r\n like to eat fish, seabirds,and/or clams\r\n have blubber and/or fur " +
            "to keep them warm\r\n swim under water\r\n hold their breath for a long time",
            "(3) Seals...\r\n are mammals\r\n live in the sea and/or on the shore\r\n some have ears and some don’t" +
            "\r\n babies are called pups\r\n like to eat fish, seabirds,and/or clams\r\n have blubber and/or fur " +
            "to keep them warm\r\n swim under water\r\n hold their breath for a long time"

        };
    }
}
