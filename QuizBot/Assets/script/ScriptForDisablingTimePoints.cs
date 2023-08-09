using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScriptForDisablingTimePoints : MonoBehaviour
{
    public Button[] loadTimePointList;

    void Start()
    {
        verifyButton();

    }
    /*void Update()
    {
        verifyButton();
    }*/

    void verifyButton()
    {
        for (int i=0; i<loadTimePointList.Length; i++) {
            Button loadBtn = loadTimePointList[i];
            if (loadBtn.name == "button1")
            {
                verifyTest(0, loadBtn);
            }
            if (loadBtn.name == "button2")
            {
                verifyTest(1, loadBtn);
            }
            if (loadBtn.name == "button3")
            {
                verifyTest(2, loadBtn);
            }
            if (loadBtn.name == "button4")
            {
                verifyTest(3, loadBtn);
            }
            if (loadBtn.name == "button5")
            {
                verifyTest(4, loadBtn);
            }
            if (loadBtn.name == "button6")
            {
                verifyTest(5,loadBtn);
            }
        }
    }
    void verifyTest(int testNo, Button loadBtn)
    {
        if (DataManager.globalGame == "BS_Instructions_1")
        {
            if(DataManager.completeBS[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "BookSum_Instructions_1" || DataManager.globalGame == "BookSum_Instructions_New_1")
        {
            if (DataManager.completeBookSum[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "CS_Instructions")
        {
            if (DataManager.completeCS[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "CAP_Instructions_1")
        {
            if (DataManager.completeCAP[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "LNI_Instructions")
        {
            if (DataManager.completeLNI[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "LSI_Instructions")
        {
            if (DataManager.completeLSI[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "SR_Instructions_1")
        {
            if (DataManager.completeSR[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "Instructions" || DataManager.globalGame == "Instructions_Vocab")
        {
            if (DataManager.completeVocabulary[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
        if (DataManager.globalGame == "Writing_Instructions")
        {
            if (DataManager.completeWriting[testNo] == 2)
            {
                loadBtn.enabled = false;
            }
            else
            {
                loadBtn.enabled = true;
            }
        }
    }
}
