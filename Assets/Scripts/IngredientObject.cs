using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientObject : MonoBehaviour
{
   public string ingredientName;

   RectTransform rectTransform;

   Vector3 originalRectTransformPosition;

   void Awake()
   {
      rectTransform = GetComponent<RectTransform>();
      originalRectTransformPosition = rectTransform.transform.position;
   }

   public void ResetPosition()
   {
      rectTransform.transform.position = originalRectTransformPosition;
   }
}
