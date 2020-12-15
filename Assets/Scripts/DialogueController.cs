using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text customerNameTextBox;
    [SerializeField] Text dialogueTextBox;

    public static DialogueController instance;

    void Awake()
    {
        instance = this;
    }

    public string customerNameToDisplay = null;
    public string dialogueTextToDisplay;

    public void SetCustomerNameText(string customerName)
    {
        customerNameToDisplay = customerName;
    }

    public void SetDialogueText(string dialogueText)
    {
        dialogueTextToDisplay = dialogueText;
    }

    public void DialogeBoxManager()
    {
        if(!dialogueBox.activeSelf)
        {
            UIController.instance.DisplayDialogueBox(true);
            customerNameTextBox.text = customerNameToDisplay;
            dialogueTextBox.text = dialogueTextToDisplay;
        }
        else
        {
            customerNameTextBox.text = customerNameToDisplay;
            dialogueTextBox.text = dialogueTextToDisplay;
        }
    }

    public void CloseDialogueBox()
    {
        customerNameTextBox.text = null;
        dialogueTextBox.text = null;
        customerNameToDisplay = null;
        dialogueTextToDisplay = null;
        UIController.instance.DisplayDialogueBox(false); 
    }
}
