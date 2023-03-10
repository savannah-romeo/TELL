//This class stores the prompts for vocab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts_SR_2 : Array_Prompts
{
    Prompts_SR_2()
    {
        //See array_prompts for definition
        prompts1 = new string[8] {
            "(9) Who is the girl?" +
            "(Answer: Emma)",
            "(10) What did she want to make? (Answer: A present/picture)",
            "(11) Who is it for?",
            "(12) Why?",
            "(13) What did Emma use to draw the picture?",
            "(14) What did she draw?",
            "(15) What did Emma do after she finished her picture?",
            "(16) What happened at the end?"

        };

        prompts2 = new string[8] {
            "(9) Who is this boy?",
            "(10) What did he want to make?",
            "(11) Who is it for?",
            "(12) Why?",
            "(13) What did Johnny use to make the cake?",
            "(14) What did he do after he mixed the ingredients?",
            "(15) What did Johnny do last?",
            "(16) What happened at the end?"

        };

        prompts3 = new string[8] {
            "(9) Who is this boy?",
            "(10) What did he want to do?",
            "(11) Where do Miguel and his dad go?",
            "(12) What did Miguel do first?",
            "(13) What did Miguel do next?",
            "(14) Where did Miguel ride?",
            "(15) How did Miguel feel at the end?",
            "(16) What does Miguel’s dad say at the end?"
        };
    }
}
