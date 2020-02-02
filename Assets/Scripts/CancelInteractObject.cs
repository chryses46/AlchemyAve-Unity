using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelInteractObject : MonoBehaviour
{
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = UIController.instance.currentCancelSprite;
    }
}
