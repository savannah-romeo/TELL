//This class is used to validate input when entering user info
//before saving and moving to the next scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Validation_UserInfo : Validation_Parent
{
    //Expected fields to check in the scene
    public TMP_InputField teacher;
    public TMP_InputField assessor;
    public TMP_InputField childName;
    public TMP_InputField childID;

    //Time to validate!
    //Requires teacher, assessor, and one child field filled
    public override bool Validator()
    {
        bool valid = true; //Return result
        string empty = ""; //Used to more clearly indicate null strings

        if(teacher.text == empty || assessor.text == empty)
            valid = false;

        if(childName.text == empty && childID.text == empty)
            valid = false;

        return valid;
    }
}