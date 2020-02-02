using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

   string[] wolfCure = new string[3] {"heart","eye","bones"};

   string[] fish = new string[3] {"mushroom","nighshade","eyeball"};

   string[] ghost = new string[3] {"green","nighshade","lamp"};

   string[] golem = new string[3] {"green", "mushroom", "heart"};
   
   string targetCure;

   void Update()
   {
      if(targetCure == "")
      {
         targetCure = GetCustomerCure();
         Debug.Log(targetCure);
      }
         
   }

    private string GetCustomerCure()
    {
        return CustomerController.instance.neededPotion;
    }

    void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log(other.gameObject.name);

      if(other.gameObject.GetComponent<IngredientObject>())
      {
         if(other.gameObject.GetComponent<IngredientObject>().matchingPotion == CustomerController.instance.neededPotion)
         {
         }
      }
   }
}
