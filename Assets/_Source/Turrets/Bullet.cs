using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private int _bulletDamage = 1;

    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        if (!_target) return;

        Vector2 direction = (_target.position - transform.position).normalized;

        rb.velocity = direction * _bulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamge(_bulletDamage);
        Destroy(gameObject);
    }
}
