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
    public TMP_InputField teacherName;
    public TMP_InputField teacherID;
    public TMP_InputField assessorName;
    public TMP_InputField assessorID;
    public TMP_InputField childName;
    public TMP_InputField childID;

    //Time to validate!
    //Requires one of each teacher, assessor, and child field filled
    public override bool Validator()
    {
        bool valid = true; //Return result
        string empty = ""; //Used to more clearly indicate null strings

        if(teacherName.text == empty && teacherID.text == empty)
            valid = false;

        if (assessorName.text == empty && assessorID.text == empty)
            valid = false;

        if(childName.text == empty && childID.text == empty)
            valid = false;

        return valid;
    }
}