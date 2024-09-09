using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _moneyUI;
    [SerializeField] private Animator _anim;

    private bool _isMenuOpen = true;

    public void ToggleMenu()
    {
        _isMenuOpen = !_isMenuOpen;
        _anim.SetBool("MenuOpen", _isMenuOpen);
    }

    private void OnGUI()
    {
        _moneyUI.text = LevelManager.main.Money.ToString();
    }
}
