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

    public void Update()
    {
        if(customerObject)
        {
            if(DialogueController.instance.customerNameToDisplay == "")
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

            if(customerObject.GetCustomerSprite() == customerObject.customerImages[0])
            {
                //if animation is not playing
                //play animation
            }

            if(DialogueController.instance.dialogueTextToDisplay == "" && currentDialogueIteration < customerObject.dialogueMessages.Length && !dialogueBoxAction)
            {

                Debug.Log(currentDialogueIteration);

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
                StartCoroutine(WaitForText(12f));
            }
            
        }

    }

    IEnumerator WaitForText(float wait)
    {
        yield return new WaitForSeconds(wait);
        DialogueController.instance.SetDialogueText("");
        dialogueBoxAction = false;
        currentDialogueIteration += 1;
    }


    // pass in the customer object (array?)

    // begin customer interact sequence
        // set first  sprite    
}
