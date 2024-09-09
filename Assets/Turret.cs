using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _turretRotationPoint;
    [SerializeField] private LayerMask _enemyMask;

    [Header("Attribute")]
    [SerializeField] private float _targetingRange = 5f;
    [SerializeField] private float _rotationSpeed = 5f;

    private Transform _target;

    private void Update()
    {
        if(_target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            _target = null;
        }
    }
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(_target.position, transform.position) <= _targetingRange;
    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _targetingRange, (Vector2)transform.position, 0f, _enemyMask);

        if (hits.Length > 0 )
        {
            _target = hits[0].transform;
        }
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg - 90;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        _turretRotationPoint.rotation = Quaternion.RotateTowards(_turretRotationPoint.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, _targetingRange);
    }
}
