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

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.Cost > LevelManager.main.Money) return;
        if (transform.childCount == 0)
            Instantiate(towerToBuild.Prefab, transform.position, Quaternion.identity, transform);
        LevelManager.main.SpendMoney(towerToBuild.Cost);
    }
}
