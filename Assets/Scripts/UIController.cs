﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Canvas mainMenuUICanvas;
    [SerializeField] Canvas gameUICanvas;
    [SerializeField] Canvas pauseMenuUICanvas;
    [SerializeField] GameObject frontOfShopGameObject;
    public Canvas cauldronCloseUp;
    [SerializeField] Image backOfShopImage;
    public Image potionBook;
    [SerializeField] Image dialogueBox;
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
        mainMenuUICanvas.gameObject.SetActive(isActive);
    }

    public void EnableGameUICanvas(bool isActive)
    {
        gameUICanvas.gameObject.SetActive(isActive);
    }

    public void EnablePauseMenuUICanvas(bool isActive)
    {
        pauseMenuUICanvas.gameObject.SetActive(isActive);
    }

    public void DisplayDialogueBox(bool isActive)
    {
        dialogueBox.gameObject.SetActive(isActive);
    }

    public void DisplayBackOfShop(bool isActive)
    {
        backOfShopImage.gameObject.SetActive(isActive);
    }

    public void DisplayFrontOfShop(bool isActive)
    {
        frontOfShopGameObject.gameObject.SetActive(isActive);
    }

    public void DisplayCauldronCloseUp(bool isActive)
    {
        cauldronCloseUp.gameObject.SetActive(isActive);
    }

    public void ShowPotionBook(bool isActive)
    {
        Debug.Log("click");
        potionBook.gameObject.SetActive(isActive);
    }
}
