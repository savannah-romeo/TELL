
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class AdvanceCAPItem: MonoBehaviour
{
    public TextMeshProUGUI shownText;
    public Toggle response_yes;
    public Toggle response_no;
    public Button clickedButton;
    
    public int iterator; //Used to track our position in the array.
    public bool complete; //Indicates when iteration moves to last element, viewed by other scripts for scene transition logic
    public bool gradeMe; //Seperate bool tracks actual last element, used for data sync purposes with other scripts
    public static double pi = 3.1416;
    public List<int> recordedSolutions;

    public Validation_Games checker; //Used to check for valid answer before proceeding
    public static Dictionary<double, string> prompts_CAP = new Dictionary<double, string>(){
            {-0.029, "Show me which way to read. (Page 1) "},
            {-1.112, "Show me the front of the book. "},
            {-0.964, "Show me the back of the book. "},
            {-0.288, "Show me the title. (Front Cover) "},
            {0.656, "Show me the author. (Front Cover) "},
            {-1.709, "Show me the picture. (Page 1) "},
            {0.403, "Show me where to begin to read. (Page 1) "},
            {0.608, "Show me an upper case letter. (Page 2) "},
            {-0.371, "Show me a lower case letter. (Page 3) "},
            {-0.345, "Show me a word. (Page 3) "},
            {0.779, "Show me a space between words. (Page 4) "},
            {0.991, "Show me a question mark. (Page 4) "},
            {-1.390, "Show me a letter. (Page 3) "}
        };
    public List<double> prompts_difficulties;
    public static List<double> prompts_difficulties_universal = new List<double>(){
            -0.029,
            -0.288,
             -0.371,
            -0.345,
            0.403,
            0.656,
            0.608,
            -0.964,
            0.779,
            0.991,
            -1.112,
            -1.709,
            -1.390
        };

public static Dictionary<string,double> prompts_UniversalMap_CAP = new Dictionary<string, double>(){
            {"Show me which way to read. (Page 1) ", -0.029},
            {"Show me the front of the book. ", -1.112},
            {"Show me the back of the book. ", -0.964},
            {"Show me the title. (Front Cover) ", -0.288},
            {"Show me the author. (Front Cover) ", 0.656},
            {"Show me the picture. (Page 1) ", -1.709},
            {"Show me where to begin to read. (Page 1) ", 0.403},
            {"Show me an upper case letter. (Page 2) ", 0.608},
            {"Show me a lower case letter. (Page 3) ", -0.371},
            {"Show me a word. (Page 3) ", -0.345},
            {"Show me a space between words. (Page 4) ", 0.779},
            {"Show me a question mark. (Page 4) ", 0.991},
            {"Show me a letter. (Page 3) ", -1.390}
        };

    public static string sep = "  ";
    public List<double> promptDisplayDifficulty;
    public static bool responsedYes;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        responsedYes = false;
        complete = false;
        gradeMe = true;
        iterator = 0; //Selects the starting text to display
        recordedSolutions = new List<int>();
        
        populateValues();

        double initialValue = -0.029;
        promptDisplayDifficulty.Add(initialValue);

        shownText.text = "("+(iterator+1)+") "+prompts_CAP.GetValueOrDefault(initialValue); //Display the first text
        //prompts_CAP.Remove(initialValue);
        prompts_difficulties.Remove(initialValue);
        //image.sprite = sprites[prompts.promptsToDisplay[iterator].index + 1];
        //image.preserveAspect = true;
        //iterator++;
        //assignImage();

        clickedButton.onClick.AddListener(TaskOnClick);
    }
    
    public void populateValues()
    {

        prompts_difficulties = new List<double>(){
            -1.112,
            -0.964,
            -0.288,
            0.656,
            -1.709,
            0.403, 
            -0.029,
            0.608, 
            -0.371,
            -0.345,
            0.779,
            0.991,
            -1.390
        };
    }
    //Occurs when button is clicked
    protected virtual void TaskOnClick()
    {
        bool validScene = checker.Validator();
        if (checker.GetValidInput() && !validScene)
        {
                Tuple<double, double> eapResults = getEAPEstimationScore();
                double eap_estimation_value = eapResults.Item1;
                double standard_error = eapResults.Item2;

                if (standard_error <= 0.5 || promptDisplayDifficulty.Count == 12 /*|| (iterator == 3 && !responsedYes)*/)
                {
                    this.complete = true;
                    DataManager.final_CAPscores[DataManager.globalTime - 1] = eapResults;
                }
                else
                {
                    double nextSelectedValue = pickNextItemRandomly(eap_estimation_value);
                    //if (nextSelectedValue != 0)
                    //{
                    iterator++;
                    promptDisplayDifficulty.Add(nextSelectedValue);
                    shownText.text = "(" + (iterator + 1) + ") " + prompts_CAP.GetValueOrDefault(nextSelectedValue); //Display the first text
                        //prompts_CAP.Remove(nextSelectedValue);
                    prompts_difficulties.Remove(nextSelectedValue);
                        
                    //}
                }

        }
    }

    private Tuple<double, double> getEAPEstimationScore()
    {
        if (checker.GetValidInput())
        {
            if (response_no.isOn)
                this.recordedSolutions.Add(0);
            if (response_yes.isOn)
            {
                responsedYes = true;
                this.recordedSolutions.Add(1);
            }

            double D = 2.77112763740014;
            double q = 81.0;
            int array_size = (int) q;
            double[] x = new double[array_size];
            double[] g = new double[array_size];
            double[] l = new double[array_size];
            for (int i=1; i <= q; i++)
            {
                x[i-1] = (-4) + (i - 1) * (8 / (q - 1));
                g[i-1] = Math.Exp(-1 * Math.Pow(x[i-1], 2) / 2) / (Math.Sqrt(2 * pi));

                l[i-1] = 1;

                for (int j=1; j <= recordedSolutions.Count; j++)
                {
                    double difficultyItem = promptDisplayDifficulty[j-1];
                    int responseItem = recordedSolutions[j - 1];
                    double p = 1 / (1 + Math.Exp(-D * (x[i - 1] - difficultyItem)));
                    l[i - 1] = l[i - 1] * Math.Pow(p, responseItem) * Math.Pow((1-p), 1-responseItem);
                }
            }

            double denominator = 0D;
            double first_moment = 0D;
            double second_moment = 0D;
            for (int i = 1; i <= q; i++)
            {
                denominator += (l[i - 1] * g[i - 1]);
                first_moment += (x[i - 1] * l[i - 1] * g[i - 1]);
                second_moment += Math.Pow(x[i - 1], 2) * l[i - 1] * g[i - 1];
            }

            double eap_estimation_value = first_moment / denominator;
            double standard_error = Math.Sqrt((second_moment / denominator) - Math.Pow(eap_estimation_value, 2));

            if (eap_estimation_value < -3)
                eap_estimation_value = -3;
            if (eap_estimation_value > 3)
                eap_estimation_value = 3;

            return Tuple.Create(eap_estimation_value, standard_error);
        }

        return Tuple.Create(-999.999, -999.999);
    }

    private double pickNextItemRandomly(double eap_estimation_value)
    {
        int randomnessThreshold = 4;
        if(prompts_difficulties.Count < randomnessThreshold)
        {
            randomnessThreshold = prompts_difficulties.Count;
        }
        Random random = new Random();
        List<Tuple<double, int>> absDifference = new List<Tuple<double, int>>();
        
        // Create a list of tuples where each tuple contains (absDiff, index)
        for (int index = 0; index < prompts_difficulties.Count; index++)
        {
            double diff = Math.Abs(prompts_difficulties[index] - eap_estimation_value);
            absDifference.Add(new Tuple<double, int>(diff, index));
        }
        
        // Sort the list and get smallest abs difference first
        absDifference.Sort();
        List<Tuple<double, int>> randomList = absDifference.GetRange(0, randomnessThreshold);
        Tuple<double, int> randomTuple = randomList[random.Next(randomList.Count)];

        return prompts_difficulties[randomTuple.Item2];
    }
}