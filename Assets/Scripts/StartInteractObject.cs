using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartInteractObject : MonoBehaviour
{
    Image image;

    bool spriteSet = false;

    void Awake()
    {
        image = GetComponent<Image>();
        
    }

    void Update()
    {
        if(!spriteSet)
        {
           image.sprite = UIController.instance.currentStartSprite;
           image.preserveAspect = true;
           spriteSet = !spriteSet; 
        }
        
    }


}
