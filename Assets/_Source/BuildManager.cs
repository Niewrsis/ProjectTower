using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] _towers = new Tower[4];

    private const int MAXIMUM_TOWER_SLOTS = 4;
    private int _selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        return _towers[_selectedTower];
    }
    public Tower[] GetTowers()
    {
        return _towers;
    }

    public void SetSelectedTower(int selectedTower)
    {
        _selectedTower = selectedTower;
    }
}
