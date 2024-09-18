using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Attributes")]
    [SerializeField] private float _moveSpeed = 2f;

    private float _baseSpeed;
    private Transform _target;
    private int _pathIndex = 0;

    private void Start()
    {
        _baseSpeed = _moveSpeed;
        _target = LevelManager.main.path[_pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(_target.position, transform.position) <= .1f)
        {
            _pathIndex++;

            if (_pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                _target = LevelManager.main.path[_pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (_target.position - transform.position).normalized;

        _rb.velocity = direction * _moveSpeed;
    }

    public void UpdateSpeed(float newSpeed)
    {
        _moveSpeed *= newSpeed;
    }
    public void ResetSpeed()
    {
        _moveSpeed = _baseSpeed;
    }
}
