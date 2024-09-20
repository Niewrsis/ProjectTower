using System;
using UnityEngine;
using UnityEngine.Events;

public class BaseHealth : MonoBehaviour
{
    public static BaseHealth main;
    [Header("References")]
    [SerializeField] private GameObject _endGamePrefab;

    [Header("Attributes")]
    [SerializeField] private float _maxHealth;

    private float _currentHealt;
    private void Awake()
    {
        main = this;
        _currentHealt = _maxHealth;
    }

    public void TakeBaseDamage(float damage)
    {
        _currentHealt -= damage;
        if(_currentHealt <= 0)
        {
            LevelManager.CurrentGameState = GameState.Lose;
            Instantiate(_endGamePrefab, transform.parent);
        }
    }
    public float GetCurrentBaseHealth()
    {
        return _currentHealt;
    }
}