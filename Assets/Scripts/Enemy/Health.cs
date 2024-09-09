using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int _hitPoints = 2;
    [SerializeField] private int _moneyWorth = 50;

    private bool _isDestroyed = false;
    public void TakeDamge(int damage)
    {
        _hitPoints -= damage;

        if ( _hitPoints <= 0 && !_isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseMoney(_moneyWorth);
            _isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
