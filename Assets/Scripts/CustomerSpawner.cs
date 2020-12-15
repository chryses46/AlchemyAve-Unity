using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public CustomerObject[] customerObjects;

    [SerializeField] float timeUntilNextCustomer = 5;

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
        
        CustomerController.instance.GetNewCustomer(customerObjects[currentCustomer]);
    }

    void Update()
    {
        WaitForQuestComplete();
    }

    private void WaitForQuestComplete()
    {
        if(CustomerController.instance.questComplete && !CustomerController.instance.isWaiting)
        {
            DespawnCustomer();
        }
    }

    private void DespawnCustomer()
    {
        CustomerController.instance.questComplete = false;

        customerObjects[currentCustomer].isInShop = false;

        UIController.instance.DisplayDialogueBox(false);
        
        customerObjects[currentCustomer].FadeOut();
        

        if(!waitingForCustomer)
        {
           StartCoroutine(WaitForCustomer()); 
        }
        
        waitingForCustomer = true;
    }

    IEnumerator WaitForCustomer()
    {
    
        yield return new WaitForSeconds(timeUntilNextCustomer);
        waitingForCustomer = false;
        AttemptToSpawnCustomer();
        
    }

    private void AttemptToSpawnCustomer()
    {
        if(currentCustomer + 1 >= customerObjects.Length)
        {
            // Day is over

        }
        else
        {
            currentCustomer ++;
            SpawnCustomer();
        }
    }
}
