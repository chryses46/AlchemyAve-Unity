using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{

    public static CustomerController instance;

    void Awake()
    {
        instance = this;
    }

    public CustomerObject customerObject;

    int currentDialogueIteration = 0;

    public bool questComplete = false;
    public bool dialogueBoxAction = false;

    public bool isWaiting = false;

    public void Update()
    {
        if(customerObject)
        {
            if(DialogueController.instance.customerNameToDisplay == null)
            {
                SetCustomerName(customerObject.customerName);
            }
            
            CheckOnCustomers();

        }
    }

    public void GetNewCustomer(CustomerObject shopVisitor)
    {
        customerObject = shopVisitor;
    }

    public void SetCustomerName(string customerName)
    {
        DialogueController.instance.SetCustomerNameText(customerName);
    }


    public void CheckOnCustomers()
    {
        if(customerObject.customerName == "Werewolf")
        {

            if(DialogueController.instance.dialogueTextToDisplay == "" && currentDialogueIteration < customerObject.dialogueMessages.Length && !dialogueBoxAction)
            {

                if(currentDialogueIteration == 1)
                {
                    customerObject.SetCustomerSprite(customerObject.customerImages[1]);
                }
                else if(currentDialogueIteration == 2)
                {
                    customerObject.SetCustomerSprite(customerObject.customerImages[0]);
                }

                SetCustomerName(customerObject.customerName);

                DialogueController.instance.SetDialogueText(customerObject.dialogueMessages[currentDialogueIteration]);

                DialogueController.instance.DialogeBoxManager();

                dialogueBoxAction = true;
            }
            else if(DialogueController.instance.dialogueTextToDisplay != "" && dialogueBoxAction)
            {
                if(!isWaiting)
                {
                    StartCoroutine(WaitForText(12f));
                    isWaiting = true;
                }
                    
            }
            else if(currentDialogueIteration >= customerObject.dialogueMessages.Length)
            {
                DialogueController.instance.CloseDialogueBox();
            }
            
        }
        else
        {
            if(DialogueController.instance.dialogueTextToDisplay == "" && currentDialogueIteration < customerObject.dialogueMessages.Length && !dialogueBoxAction)
            {
                SetCustomerName(customerObject.customerName);

                DialogueController.instance.SetDialogueText(customerObject.dialogueMessages[currentDialogueIteration]);

                DialogueController.instance.DialogeBoxManager();

                dialogueBoxAction = true;
            }
            else if(DialogueController.instance.dialogueTextToDisplay != "" && dialogueBoxAction)
            {
                if(!isWaiting)
                {
                    StartCoroutine(WaitForText(12f));
                    isWaiting = true;
                }
                    
            }
            else if(currentDialogueIteration >= customerObject.dialogueMessages.Length)
            {
                DialogueController.instance.CloseDialogueBox();
            }
        }
    }

    public void AcceptPotionQuestCompleteDialogue()
    {
        DialogueController.instance.SetDialogueText(customerObject.potionAcceptDialogue);
        DialogueController.instance.DialogeBoxManager();

        if (!isWaiting)
        {
            StartCoroutine(WaitForText(3f));
            isWaiting = true;
        }

        DialogueController.instance.CloseDialogueBox();
        questComplete = true;

    }

    public void QuestCompleteDialogue()
    {
        DialogueController.instance.SetDialogueText(customerObject.questCompleteDialogue);

        DialogueController.instance.DialogeBoxManager();
        Debug.Log(customerObject.questCompleteDialogue);

        if (!isWaiting)
        {
            StartCoroutine(WaitForText(12f));
            isWaiting = true;
        }
    }

    IEnumerator WaitForText(float wait)
    {
        yield return new WaitForSeconds(wait);
        DialogueController.instance.SetDialogueText("");
        dialogueBoxAction = false;
        isWaiting = false;
        if(customerObject)
        {
          if(currentDialogueIteration < customerObject.dialogueMessages.Length)
            {
                currentDialogueIteration += 1;
            }  
        }
        
        
    }


    // pass in the customer object (array?)

    // begin customer interact sequence
        // set first  sprite    
}
