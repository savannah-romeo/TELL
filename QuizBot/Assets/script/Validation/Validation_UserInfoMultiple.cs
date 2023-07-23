using TMPro;

public class Validation_UserInfoMultiple : Validation_UserInfo
{
    
    //Time to validate!
    //Requires one of each teacher, assessor, child and classroom field filled
    public override bool Validator()
    {
        bool valid = true; //Return result
        string empty = ""; //Used to more clearly indicate null strings

        
        if (childName.text == empty && childID.text == empty)
            valid = false;


        return valid;
    }
    
}