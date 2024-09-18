using UnityEngine;
using UnityEngine.EventSystems;

public class TowerChooser : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.main.SetHoveringState(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }
}
