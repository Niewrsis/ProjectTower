using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plots : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _hoverColor;

    private GameObject _tower;
    private Color _startColor;
    private void Start()
    {
        _startColor = _spriteRenderer.color;
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
        if (_tower != null) return;

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        if (transform.childCount == 0)
            Instantiate(towerToBuild, transform.position, Quaternion.identity, transform);
    }
}
