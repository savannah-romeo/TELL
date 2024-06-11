
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class AdvanceVocabItem: MonoBehaviour
{
    public TextMeshProUGUI shownText;
    public TextMeshProUGUI displayInstruction;
    public Toggle expressiveToggle;
    public Button clickedButton;
    public Image image;
    public Prompts_Vocab prompts;
    public Canvas displayExpressiveCanvas;
    public Canvas displayReceptiveCanvas;
    public bool gradeMe;
    public TMP_InputField responseField;

    public int expressiveIterator; //Used to track our position in the array.
    public int receptiveIterator;
    public bool complete = false;

    public Validation_Games checker;

    public static string sep = "  ";
    int localTime;
    public string[] textArray;
    public string[] instructionArray;
    public string[] receptiveArray;
    public bool expressive;
    public List<Sprite> expressiveSprites;
    public List<Sprite> receptiveSprites;
    int imageIterator = 0;


    // Start is called before the first frame update
    public virtual void Start()
    {
        localTime = DataManager.globalTime;
        gradeMe = true;
        complete = false;
        expressiveIterator = 0;
        receptiveIterator = 0;
        imageIterator = (localTime - 1) * 6;
        textArray = PromptSelect(localTime);
        instructionArray = InstructionSelect(localTime);
        receptiveArray = promptReceptive(localTime);
        
        shownText.text = textArray[expressiveIterator];
        displayInstruction.text = instructionArray[expressiveIterator];
        expressive = true;
        displayExpressiveCanvas.enabled = true;
        displayReceptiveCanvas.enabled = false;
        image.sprite = expressiveSprites[imageIterator];
            //shownText.text = prompts.promptsToDisplay[iterator].item + sep + prompts.promptsToDisplay[iterator].pronounce; //Display the first text
            //image.sprite = sprites[prompts.promptsToDisplay[iterator].index + 1];
        image.preserveAspect = true;
            
        clickedButton.onClick.AddListener(TaskOnClick); 
    }

    protected virtual void TaskOnClick()
    {
        checker.Validator();
        if (checker.GetValidInput())
        {
            if (expressiveIterator == textArray.Length - 1 && (!expressive || expressiveToggle.isOn) )
                complete = true;
            else
            {
                if (expressive && expressiveToggle.isOn || !expressive)
                {
                    displayExpressiveCanvas.enabled = true;
                    displayReceptiveCanvas.enabled = false;
                    expressiveIterator++;
                    receptiveIterator++;
                    imageIterator++;
                    expressive = true;
                    responseField.text = "";
                    //displayInstruction.enabled = true;
                    shownText.text = textArray[expressiveIterator];
                    displayInstruction.text = instructionArray[expressiveIterator];
                    image.sprite = expressiveSprites[imageIterator];
                    //shownText.text = prompts.promptsToDisplay[iterator].item + sep + prompts.promptsToDisplay[iterator].pronounce; //Display the first text
                    //image.sprite = sprites[prompts.promptsToDisplay[iterator].index + 1];
                    image.preserveAspect = true;

                }
                else
                {
                    displayExpressiveCanvas.enabled = false;
                    displayReceptiveCanvas.enabled = true;
                    shownText.text = receptiveArray[receptiveIterator];
                    displayInstruction.text = receptiveArray[receptiveIterator];
                    //displayInstruction.enabled = false;
                    //displayInstruction.text = instructionArray[expressiveIterator];
                    expressive = false;
                    image.sprite = receptiveSprites[imageIterator];
                    //shownText.text = prompts.promptsToDisplay[iterator].item + sep + prompts.promptsToDisplay[iterator].pronounce; //Display the first text
                    //image.sprite = sprites[prompts.promptsToDisplay[iterator].index + 1];
                    image.preserveAspect = true;
                    if (expressiveIterator == textArray.Length - 1)
                        complete = true;
                }
            }
            
                
        }
    }
    public virtual string[] PromptSelect(int selection) => selection switch
    {
        1 => prompts.prompts1,
        2 => prompts.prompts2,
        3 => prompts.prompts3,
        4 => prompts.prompts4,
        5 => prompts.prompts5,
        6 => prompts.prompts6,
        _ => Array_Prompts.prompts
    };

    public virtual string[] promptReceptive(int selection) => selection switch
    {
        1 => new string[6]
        {
            "(1) Show me <b>alphabet</b>.",
            "(2) Show me <b>senses</b>.",
            "(3) Show me <b>schedule</b>.",
            "(4) Show me <b>student</b>.",
            "(5) Show me <b>scent</b>.",
            "(6) Show me <b>taste</b>."
        },
        2 => new string[6]
        {
            "(1) Show me <b>transportation</b>.",
            "(2) Show me <b>engine</b>.",
            "(3) Show me <b>vehicles</b>.",
            "(4) Show me <b>pretend</b>.",
            "(5) Show me <b>dangerous</b>.",
            "(6) Show me <b>delicious</b>."
        },
        3 => new string[6]
        {
            "(1) Show me <b>stretch</b>.",
            "(2) Show me <b>creatures</b>.",
            "(3) Show me <b>lantern</b>.",
            "(4) Show me <b>harvest</b>.",
            "(5) Show me <b>enormous</b>.",
            "(6) Show me <b>autumn</b>."
        },
        4 => new string[6]
        {
            "(1) Show me <b>astronaut</b>.",
            "(2) Show me <b>rocket</b>.",
            "(3) Show me <b>planet</b>.",
            "(4) Show me <b>fossil</b>.",
            "(5) Show me <b>tracks</b>.",
            "(6) Show me <b>scientist</b>."
        },
        5 => new string[6]
        {
            "(1) Show me <b>wild</b>.",
            "(2) Show me <b>jungle</b>.",
            "(3) Show me <b>tame</b>.",
            "(4) Show me <b>branches</b>.",
            "(5) Show me <b>seeds</b>.",
            "(6) Show me <b>stem</b>."
        },
        6 => new string[6]
        {
            "(1) Show me <b>veterinarian</b>.",
            "(2) Show me <b>collar</b>.",
            "(3) Show me <b>leash</b>.",
            "(4) Show me <b>farmer</b>.",
            "(5) Show me <b>soil</b>.",
            "(6) Show me <b>wheat</b>."
        },
    };

    public virtual string[] InstructionSelect(int selection) => selection switch
    {

        1 => new string[6] {
            "(1) When you see all of these letters together it is called the ___________________.",
            "(2) Sight, hearing, touch, taste, and smell are the five ___________________.",
            "(3) A plan that tells us when to do something is called a ___________________.",
            "(4) The children in a classroom are called __________________.",
            "(5) When something smells good it has a nice __________________.",
            "(6) I know whether I like to eat something because of its flavor and my sense of _____________________."
        },
        2 => new string[6] {
                "(1) When we move things from one place to another, we use ___________________.",
                "(2) At the front of the train we see the ___________________.",
                "(3) These are all different kinds of ____________________.",
                "(4) These children aren't really cooks, they are just ___________________.",
                "(5) Walking across the street when a car is coming is very ____________________.",
                "(6) We don't think pizza is just good. We think it is ____________________!"
            },
        3 => new string[6] {
                "(1) When you pull the rubber band, you are making it ___________________.",
                "(2) Snakes, birds, and crickets can all be called ________________.",
                "(3) This kind of light that is good to take camping is called a ____________________.",
                "(4) When crops are ripe and we gather them, it is called the ____________________.",
                "(5) This ice cream cone isn't just big, it is ______________________.",
                "(6) When it gets colder and the leaves change color, it is _____________________!"
            },
        4 => new string[6] {
                "(1) This person travels in space and is called an ___________________.",
                "(2) An astronaut can blast into space in a __________________.",
                "(3) We live on Earth, which is a __________________.",
                "(4) Very old bones that look like a skeleton and are found in a rock are called ____________________.",
                "(5) Sometimes, after an animal walks by, you can see its ____________________.",
                "(6) Someone who studies things by testing them is called a ___________________."
            },
        5 => new string[6] {
                "(1) This lion is not tame it is ____________________.",
                "(2) There are lots of plants and vines in the _____________________.",
                "(3) This rabbit isn't wild, it is ____________________.",
                "(4) There are no leaves on this tree's ___________________.",
                "(5) To grow plants first you have to plant ___________________.",
                "(6) The main part of a plant that the leaves and flowers grow from is the _____________________."
            },
        6 => new string[6] {
                "(1) A doctor who takes care of animals is a ________________________.",
                "(2) The band around this cat's neck is a ____________________.",
                "(3) When you take your dog for a walk, he needs to wear a _________________________.",
                "(4) A person who grows crops is a ____________________.",
                "(5) To grow, seeds must be planted in _____________________.",
                "(6) The grain we grind to make bread is called _______________________."
            }
    };


}