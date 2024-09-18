using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plots : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private GameObject _uiTowerChooser;

    private bool _isPlotBusy = false;
    private Color _startColor;
    private void Start()
    {
        _startColor = _spriteRenderer.color;
        _uiTowerChooser.SetActive(false);
    }

    private void OnMouseEnter()
    {
        _spriteRenderer.color = _hoverColor;
    }
    private void OnMouseExit()
    {
        _spriteRenderer.color = _startColor;
    }
    private void OnMouseDown()
    {
        if (_isPlotBusy == false)
        {
            _uiTowerChooser.SetActive(true);
        }
        else
        {
            //upgrade logic
        }
    }
    public void ChangeToPlotBusy()
    {
        _isPlotBusy = true;
    }
}
