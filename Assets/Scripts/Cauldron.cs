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

   bool win = false;

   void Update()
   {
         if(currentNumberOfIngredients == INGREDIENDS_NEEDED & win != true)
         {
            Debug.Log("You Win!");
            win = true;
         }
   }

    void OnTriggerEnter2D(Collider2D other)
   {
      

      if(other.gameObject.GetComponent<IngredientObject>())
      {

         Debug.Log(other.gameObject.name);

         for(int i = 0; i< CustomerController.instance.customerObject.neededIngredients.Length; i++ )
         {
            if(other.gameObject.GetComponent<IngredientObject>().ingredientName == CustomerController.instance.customerObject.neededIngredients[i])
            {
               currentNumberOfIngredients += 1;
               Destroy(other.gameObject.GetComponent<DragAndDrop>());
               Debug.Log(currentNumberOfIngredients);
            }
            else
            {
               Debug.Log("You Lose!");
            }
         }
         
      }
   }
}
