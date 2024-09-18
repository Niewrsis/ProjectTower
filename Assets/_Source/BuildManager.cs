using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] _towers;

    private int _selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        return _towers[_selectedTower];
    }

    public void SetSelectedTower(int selectedTower)
    {
        _selectedTower = selectedTower;
    }
}
