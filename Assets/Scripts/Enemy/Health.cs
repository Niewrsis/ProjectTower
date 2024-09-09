using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int _hitPoints = 2;

    public void TakeDamge(int damage)
    {
        _hitPoints -= damage;

        if ( _hitPoints <= 0 )
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
