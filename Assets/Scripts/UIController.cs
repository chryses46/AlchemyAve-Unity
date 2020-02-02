using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Canvas MainMenuUICanvas;
    [SerializeField] Canvas GameUICanvas;
    [SerializeField] Canvas PauseMenuUICanvas;
    [SerializeField] Image DialogueBox;
    [SerializeField] Sprite gamePadStartSprite;
    [SerializeField] Sprite gamePadCancelSprite;
    [SerializeField] Sprite keyBoardStartSprite;
    [SerializeField] Sprite keyBoardCancelSprite;
    public static UIController instance;

    public Sprite currentStartSprite;
    public Sprite currentCancelSprite;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetInteractableSprites();
    }

    private void SetInteractableSprites()
    {
        if (GameController.instance.playerIndexSet)
        {
            currentStartSprite = gamePadStartSprite;
            currentCancelSprite = gamePadCancelSprite;
        }
        else
        {
            currentStartSprite = keyBoardStartSprite;
            currentCancelSprite = keyBoardCancelSprite;
        }
    }

    void Update()
    {
        
    }

    public void EnableMainMenuUI(bool isActive)
    {
        MainMenuUICanvas.gameObject.SetActive(isActive);
    }

    public void EnableGameUICanvas(bool isActive)
    {
        GameUICanvas.gameObject.SetActive(isActive);
    }

    public void EnablePauseMenuUICanvas(bool isActive)
    {
        PauseMenuUICanvas.gameObject.SetActive(isActive);
    }

    public void DisplayDialogueBox(bool isActive)
    {
        DialogueBox.gameObject.SetActive(isActive);
    }
}
