using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

   // string[] wolfCure = new string[3] {"heart","eyeball","bones"};

   // string[] fish = new string[3] {"mushroom","nighshade","eyeball"};

   // string[] ghost = new string[3] {"green","nighshade","lamp"};

   // string[] golem = new string[3] {"green", "mushroom", "heart"};
   
   int INGREDIENDS_NEEDED = 3;

   int currentNumberOfIngredients = 0;

   public bool win = false;

   void Update()
   {
         if(currentNumberOfIngredients == INGREDIENDS_NEEDED & win != true)
         {
            UIController.instance.ShowSuccessPotionWindow(true);
            FindObjectOfType<SuccessPotion>().SetScreen();
            win = true;
            currentNumberOfIngredients = 0;
         }
   }

    void OnTriggerEnter2D(Collider2D other)
   {
      if(other.gameObject.GetComponent<IngredientObject>())
      {
         for(int i = 0; i< CustomerController.instance.customerObject.neededIngredients.Length; i++ )
         {
            if(other.gameObject.GetComponent<IngredientObject>().ingredientName == CustomerController.instance.customerObject.neededIngredients[i])
            {
               currentNumberOfIngredients += 1;
               AudioController.instance.PlayIngredientEffect();
               Destroy(other.gameObject.GetComponent<DragAndDrop>());

            }
            else
            {

            }
         }
         
      }
   }
}
