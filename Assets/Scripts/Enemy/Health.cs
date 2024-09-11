using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    public int HitPoints = 2;
    public int _moneyWorth = 50;

    private bool _isDestroyed = false;
    public void TakeDamge(int damage)
    {
        HitPoints -= damage;

        if (HitPoints <= 0 && !_isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseMoney(_moneyWorth);
            _isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
