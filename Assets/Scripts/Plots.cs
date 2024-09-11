using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plots : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _hoverColor;

    public GameObject TowerObj;
    public Turret Turret;
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
        if (UIManager.main.IsHoveringUI()) return;

        if (TowerObj != null)
        {
            Turret.OpenUpgradeUI();
            return;
        }

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.Cost > LevelManager.main.Money) return;

        LevelManager.main.SpendMoney(towerToBuild.Cost);
        
        TowerObj = Instantiate(towerToBuild.Prefab, transform.position, Quaternion.identity);

        Turret = TowerObj.GetComponent<Turret>();
    }
}
