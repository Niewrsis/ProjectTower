using System;
using UnityEngine;
using UnityEngine.Events;

public class BaseHealth : MonoBehaviour
{
    public static BaseHealth main;

    [Header("Attributes")]
    [SerializeField] private float _maxHealth;

    private float _currentHealt;
    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        _currentHealt = _maxHealth;
    }

    public void TakeBaseDamage(float damage)
    {
        _currentHealt -= damage;
        if(_currentHealt <= 0)
        {
            //Game Over Logic
        }
    }
    public float GetCurrentBaseHealth()
    {
        return _currentHealt;
    }
}