using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GameController : MonoBehaviour
{
    
    public static GameController instance;

    public bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    void Awake()
    {
        instance = this;
        CheckForControllers();
    }

    void Start()
    {
        AudioController.instance.PlayMainMenuMusic();
    }

    void Update()
    {
        CheckForControllers();
    }

    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    // just call it only from main menu
    public void StartGame()
    {
        UIController.instance.EnableMainMenuUI(false);
        UIController.instance.EnableGameUICanvas(true);
        StateController.instance.gameState = StateController.State.Play;
        GetComponent<CustomerSpawner>().SpawnCustomer();
        
        SetTimeScale(1);

    }

    public void PauseGame()
    {
        UIController.instance.EnableGameUICanvas(false);
        UIController.instance.EnablePauseMenuUICanvas(true);
        StateController.instance.gameState = StateController.State.Pause;
        SetTimeScale(0);
    }

    public void UnPauseGame()
    {
        UIController.instance.EnablePauseMenuUICanvas(false);
        UIController.instance.EnableGameUICanvas(true);
        StateController.instance.gameState = StateController.State.Play;
        SetTimeScale(1);
    }

    public void GoToBackOfShop()
    {
        UIController.instance.DisplayFrontOfShop(false);
        UIController.instance.DisplayBackOfShop(true);
    }

    public void GoToFrontOfShop()
    {
        UIController.instance.DisplayBackOfShop(false);
        UIController.instance.DisplayFrontOfShop(true);
    }

    public void DisplayPotionBook()
    {
        if(UIController.instance.potionBook.gameObject.activeSelf)
        {
            UIController.instance.ShowPotionBook(false);
        }
        else
        {
            UIController.instance.ShowPotionBook(true);
        }
        
    }

    public void ShowCauldronCloseUp()
    {
        if(!UIController.instance.cauldronCloseUp.gameObject.activeSelf)
        {
            UIController.instance.DisplayCauldronCloseUp(true);
        }    
        else
        {
            UIController.instance.DisplayCauldronCloseUp(false);
        }
            
    }

    

    public void ClosePotionWin()
    {
        UIController.instance.ShowSuccessPotionWindow(false);
        FindObjectOfType<Cauldron>().win = false;
        UIController.instance.DisplayCauldronCloseUp(false);
        UIController.instance.DisplayBackOfShop(false);
        UIController.instance.DisplayFrontOfShop(true);

        CustomerController.instance.QuestCompleteDialogue();
    }
        
        



    private void CheckForControllers()
    {
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);
    }

}
