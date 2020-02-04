using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerObject : MonoBehaviour
{
    public string customerName;
    public Sprite[] customerImages;
    public string ailment;
    public string[] dialogueMessages;
    public string potionAcceptDialogue;
    public string questCompleteDialogue;
    public string[] neededIngredients;

    public bool isInShop = false;

    Animator animator;

    Image image;
    float fadeInTarget = 255;
    float fadeOutTarget = 0;

    void Awake()
    {
        image = GetComponent<Image>();
        animator = GetComponent<Animator>();
    }
    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        if(customerName == "Werewolf")
        {
            animator.SetBool("isBlinking", false);
        }

        animator.SetTrigger("FadeOut");
    }

    public void SetCustomerSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void CustomerHasArrived()
    {
        CustomerController.instance.customerArrived = true;
    }

    public void CustomerHasLeft()
    {
        Debug.Log("CustomerHasLeft called");
        CustomerController.instance.CustomerLeft();
    }
}
