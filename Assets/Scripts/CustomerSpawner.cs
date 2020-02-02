using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public CustomerObject[] customerObjects;

    public bool customerInShop = false;

    public static CustomerSpawner instance;

    public bool waitingForCustomer = false;

    void Awake()
    {
        instance = this;
    }

    public int currentCustomer = 0;
    public void SpawnCustomer()
    {
        customerObjects[currentCustomer].isInShop = true;
        customerInShop = true;
        CustomerController.instance.GetNewCustomer(customerObjects[currentCustomer]);

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
        customerObjects[currentCustomer].FadeOut();
        CustomerController.instance.customerObject = null;
        if(!waitingForCustomer)
        {
           StartCoroutine(WaitForCustomer()); 
        }
        
        waitingForCustomer = true;
    }

    IEnumerator WaitForCustomer()
    {
    
        yield return new WaitForSeconds(2);
        waitingForCustomer = false;
        customerInShop = false;
        
    }
}
