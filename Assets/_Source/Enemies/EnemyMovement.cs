using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Transform> waypoints;

    [Header("Attributes")]
    [SerializeField] private float speed;

    private int _currentWaypointIndex;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PathFinding();
    }
    private void PathFinding()
    {
        if (_currentWaypointIndex >= waypoints.Count)
        {
            //Base damaged by this enemy
            Destroy(gameObject);
            return;
        }

        Transform targetWaypoint = waypoints[_currentWaypointIndex];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        _rb.velocity = direction * speed;

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.05f)
        {
            _currentWaypointIndex++;
        }
    }
}
