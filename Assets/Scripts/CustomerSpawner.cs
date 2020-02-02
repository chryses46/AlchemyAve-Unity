using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] CustomerObject[] customerObjects;

    public bool customerInShop = false;

    int currentCustomer = 0;
    public void SpawnCustomer()
    {
        customerObjects[currentCustomer].isInShop = true;
        customerInShop = true;
        CustomerController.instance.GetNewCustomer(customerObjects[currentCustomer]);
        //pass stuff to something

        // wait for stuff mission accomplushed

        
        // set a bool CustomerInShop
        // once the quest is complete
            // set bool !CustomerInShop
        

        //rinse, wash, repeat

    }

    void Update()
    {
        WaitForQuestComplete();
    }

    private void WaitForQuestComplete()
    {
        if(CustomerController.instance.questComplete)
        {
            DespawnCustomer();
        }
    }

    private void DespawnCustomer()
    {
        CustomerController.instance.customerObject = null;
        customerObjects[currentCustomer].FadeOut();
        currentCustomer ++;
        StartCoroutine(WaitForCustomer());
    }

    IEnumerator WaitForCustomer()
    {
        yield return new WaitForSeconds(2);
        customerInShop = false;
    }
}
