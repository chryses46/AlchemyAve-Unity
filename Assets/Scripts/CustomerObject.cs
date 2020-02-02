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

    Animation anim;

    public bool isInShop = false;

    Image image;
    float fadeInTarget = 255;
    float fadeOutTarget = 0;

    void Awake()
    {
        image = GetComponent<Image>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if(isInShop)
            FadeUp();
    }

    public void FadeUp()
    {
        var alpha = image.color.a;
        alpha = Mathf.MoveTowards(alpha, fadeInTarget, Time.deltaTime);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    public void FadeOut()
    {
        var alpha = image.color.a;
        alpha = Mathf.MoveTowards(alpha, fadeOutTarget, Time.deltaTime);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

        isInShop = false;
    }

    public void SetCustomerSprite(Sprite sprite)
    {   
        image.sprite = sprite;
    }

    public Sprite GetCustomerSprite()
    {
        return image.sprite;
    }
}
