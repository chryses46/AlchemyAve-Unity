using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessPotion : MonoBehaviour
{
    [SerializeField] Text potionName;
    [SerializeField] Text potionDesc;
    [SerializeField] Image potionImage;

    [SerializeField] Sprite wolfPotion;
    [SerializeField] Sprite ghostPotion;
    [SerializeField] Sprite golemPotion;
    [SerializeField] Sprite jawaPotion;


    void Start()
    {
        SetScreen();
    }

    public void SetScreen()
    {
        if(CustomerController.instance.customerObject.customerName == "Werewolf")
        {
            potionName.text = "Wolf's Grip";
            potionDesc.text = "A smooth concoction made to cure lycanthropy. Made with: A heart, Pickeled Eyeballs, and bones.";
            potionImage.sprite = wolfPotion;
        }
        else if(CustomerController.instance.customerObject.customerName == "Maj. Flanders")
        {
            potionName.text = "Wraith's Tears";
            potionDesc.text = "A flourescent drink made to cure hauntings. Really just makes them drunk enough to forget why they're here. Made with: A bottle of green (alcohol), Nightshade, and a magic lamp.";
            potionImage.sprite = ghostPotion;
        }
        else if(CustomerController.instance.customerObject.customerName == "Golem")
        {
            potionName.text = "Cough Medicine";
            potionDesc.text = "It's just cough medicine. Made with: A bottle of green, Mushrooms, and a heart.";
            potionImage.sprite = golemPotion;
        }
        else if(CustomerController.instance.customerObject.customerName == "Jawa")
        {
            potionName.text = "Fish";
            potionDesc.text = "Fish wrapped in herbs and goodness. Made with: Mushrooms, Nightshade, and Pickeled Eyeballs.";
            potionImage.sprite = jawaPotion;
        }
    }
    
}
