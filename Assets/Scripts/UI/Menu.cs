using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _moneyUI;
    [SerializeField] private Animator _anim;

    private bool _isMenuOpen = true;
    [field: SerializeField] public bool mouseOver { get; private set; }
    public void ToggleMenu()
    {
        _isMenuOpen = !_isMenuOpen;
        _anim.SetBool("MenuOpen", _isMenuOpen);
    }

    private void OnGUI()
    {
        _moneyUI.text = LevelManager.main.Money.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        UIManager.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        UIManager.main.SetHoveringState(false);
    }
}
