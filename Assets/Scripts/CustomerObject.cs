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
        if(GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
    }

    public void FadeIn()
    {
        if(!animator)
        {
            GetComponent<Animation>().GetClip("FadeIn");
        }
        else
        {
            animator.Play("FadeIn");
        }
        // var alpha = image.color.a;
        // alpha = Mathf.MoveTowards(alpha, fadeInTarget, Time.deltaTime);
        // image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    public void FadeOut()
    {
        if(!animator)
        {
            GetComponent<Animation>().GetClip("FadeOut");
        }
        else
        {
            animator.Play("FadeOut");
        }
        
        // var alpha = image.color.a;
        // alpha = Mathf.MoveTowards(alpha, fadeOutTarget, Time.deltaTime);
        // image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    public void SetCustomerSprite(Sprite sprite)
    {   
        image.sprite = sprite;
    }

    public Sprite GetCustomerSprite()
    {
        return image.sprite;
    }

    public void StopAnimation()
    {
        image.sprite = customerImages[1];
        animator.StopPlayback();
        
    }

    public void StartAnimation()
    {
        animator.StartPlayback();
    }
}
