using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool MouseOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOver = true;
        UIManager.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOver = false;
        UIManager.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }
}