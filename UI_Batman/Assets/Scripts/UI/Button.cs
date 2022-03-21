using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image ButtonImg;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonImg.DOKill();
        ButtonImg.DOFade(0.7f, 0.8f);
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonImg.DOKill();
        ButtonImg.DOFade(0.2f, 0.3f);
  
    }
    public void ShrinkBar()
    {
        ButtonImg.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.5f);
    }
    public void GrowBar()
    {
        ButtonImg.rectTransform.DOSizeDelta(new Vector2(100, 100), 0.7f);
    }

}
