using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerController : MonoBehaviour
{

    public static CustomerController instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField] Image werewolfSweat;

    public CustomerObject customerObject;

    public int currentDialogueIteration = 0;

    public bool questComplete = false;
    public bool dialogueBoxAction = false;

    public bool isWaiting = false;

    public void Update()
    {
        if(customerObject)
        {
            CheckOnCustomers();
        }
    }

    public void GetNewCustomer(CustomerObject shopVisitor)
    {
        customerObject = shopVisitor;
        
        customerObject.FadeIn();
        DialogueController.instance.customerNameToDisplay = customerObject.customerName;
    }

    public void CheckOnCustomers()
    {
        if(customerObject.customerName == "Werewolf")
        {
            if(DialogueController.instance.dialogueTextToDisplay == "" && currentDialogueIteration < customerObject.dialogueMessages.Length && !dialogueBoxAction)
            {   
                if(currentDialogueIteration == 1)
                {
                    werewolfSweat.gameObject.SetActive(true);
                }
                else
                {
                    werewolfSweat.gameObject.SetActive(false);
                }
                

                DialogueController.instance.SetDialogueText(customerObject.dialogueMessages[currentDialogueIteration]);

                DialogueController.instance.DialogeBoxManager();

                dialogueBoxAction = true;
            }
            else if(dialogueBoxAction)
            {
                if(!isWaiting)
                {
                    StartCoroutine(WaitForText(9f));
                    isWaiting = true;
                }
                    
            }
            else if(currentDialogueIteration >= customerObject.dialogueMessages.Length)
            {
                DialogueController.instance.CloseDialogueBox();
                // engage quest book here. (in the future)
            }
            
        }
        else
        {
            if(DialogueController.instance.dialogueTextToDisplay == "" && currentDialogueIteration < customerObject.dialogueMessages.Length && !dialogueBoxAction)
            {
                DialogueController.instance.SetDialogueText(customerObject.dialogueMessages[currentDialogueIteration]);

                DialogueController.instance.DialogeBoxManager();

                dialogueBoxAction = true;
            }
            else if(DialogueController.instance.dialogueTextToDisplay != "" && dialogueBoxAction)
            {
                if(!isWaiting)
                {
                    StartCoroutine(WaitForText(9f));
                    isWaiting = true;
                }
                    
            }
            else if(currentDialogueIteration >= customerObject.dialogueMessages.Length)
            {
                DialogueController.instance.CloseDialogueBox();
            }
        }
    }

    public void QuestCompleteDialogue()
    {
        DialogueController.instance.customerNameToDisplay = customerObject.customerName;
        DialogueController.instance.SetDialogueText(customerObject.questCompleteDialogue);
        DialogueController.instance.DialogeBoxManager();
        dialogueBoxAction = true;
        questComplete = true;

        if (!isWaiting)
        {
            StartCoroutine(WaitForText(4f));
            isWaiting = true;
        }
    }

    IEnumerator WaitForText(float wait)
    {
        yield return new WaitForSeconds(wait);
        DialogueController.instance.SetDialogueText("");
        dialogueBoxAction = false;
        isWaiting = false;

        if(currentDialogueIteration < customerObject.dialogueMessages.Length)
        {
            currentDialogueIteration += 1;
        }
    }


    // public void AcceptPotionQuestCompleteDialogue()
    // {
    //     DialogueController.instance.customerNameToDisplay = customerObject.customerName;
    //     DialogueController.instance.SetDialogueText(customerObject.potionAcceptDialogue);
    //     DialogueController.instance.DialogeBoxManager();
    //     dialogueBoxAction = true;

    //     if (!isWaiting)
    //     {
    //         StartCoroutine(WaitForText(3f));
    //         isWaiting = true;
    //     }

    //     DialogueController.instance.CloseDialogueBox();
    //     questComplete = true;

    // }

     
}
