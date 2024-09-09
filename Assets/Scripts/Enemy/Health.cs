using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int _hitPoints = 2;

    private bool _isDestroyed = false;
    public void TakeDamge(int damage)
    {
        _hitPoints -= damage;

        if ( _hitPoints <= 0 && !_isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            _isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
