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
            "(11) Who is it for? (Answer: Her father)",
            "(12) Why? (Answer: His Birthday)",
            "(13) What did Emma use to draw the picture? (Answer: Paper and crayons)",
            "(14) What did she draw? (Answer: Her family)",
            "(15) What did Emma do after she finished her picture? (Answer: Wrapped it)",
            "(16) What happened at the end? (Answer: Dad said 'thank you' OR He was happy)"

        };

        prompts2 = new string[8] {
            "(9) Who is this boy? (Answer: Johnny)",
            "(10) What did he want to make? (Answer: A cake)",
            "(11) Who is it for? (Answer: His mother)",
            "(12) Why? (Answer: For Mother's Day)",
            "(13) What did Johnny use to make the cake? (Answer: Eggs, sugar and flour)",
            "(14) What did he do after he mixed the ingredients? (Answer: Put it in a pan and in the oven)",
            "(15) What did Johnny do last? (Answer: Frosted it)",
            "(16) What happened at the end? (Answer: Mother said 'thank you' OR I love it!)"

        };

        prompts3 = new string[8] {
            "(9) Who is this boy? (Answer: Miguel)",
            "(10) What did he want to do? (Answer: Learn to ride his bike)",
            "(11) Where do Miguel and his dad go? (Answer: Outside)",
            "(12) What did Miguel do first? (Answer: Put on his helmet)",
            "(13) What did Miguel do next? (Answer: Climbed on his bike and/or dad held the bike)",
            "(14) Where did Miguel ride? (Answer: Down the street)",
            "(15) How did Miguel feel at the end? (Answer: Happy)",
            "(16) What does Miguel’s dad say at the end? (Answer: Great job, and/or You did it!)"
        };
    }
}
