using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    public float MaxHealth = 20;
    public int _moneyWorth = 50;

    private float _currentHealth;
    private bool _isDestroyed = false;
    private void Start()
    {
        _currentHealth = MaxHealth;
    }
    public void TakeDamge(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0 && !_isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseMoney(_moneyWorth);
            _isDestroyed = true;
            Destroy(gameObject);
        }
    }
    public void EnemyPassed()
    {
        BaseHealth.main.TakeBaseDamage(_currentHealth);
        Destroy(gameObject);
    }
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
}
