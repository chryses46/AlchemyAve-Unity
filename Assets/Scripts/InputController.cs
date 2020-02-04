using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    void Update()
    {
        // while in menu state
        if(StateController.instance.gameState == StateController.State.MainMenu)
        {
            if(Input.GetButton("Submit"))
            {
                GameController.instance.StartGame();
            }
        }

        //while in play state

        if(StateController.instance.gameState == StateController.State.Play)
        {
            // basic gameplay controls here

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameController.instance.PauseGame();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                CustomerController.instance.SkipDialogueIteration();
            }
        }


        if(StateController.instance.gameState == StateController.State.Pause)
        {
            if(Input.GetButton("Submit"))
            {
                GameController.instance.UnPauseGame();
            }
        }
    }
}
