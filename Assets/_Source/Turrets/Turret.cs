using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float attackPerSecond = 1f;
    [SerializeField] private float baseUpgradeCost = 100f;

    private float _attackPerSecondBase;
    private float _targetingRangeBase;

    private Transform _target;
    private float _timeUntilFire;

    private int _level = 1;

    private void Start()
    {
        _attackPerSecondBase = attackPerSecond;
        _targetingRangeBase = targetingRange;

        upgradeButton.onClick.AddListener(Upgrade);
    }
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
        else
        {
            _timeUntilFire += Time.deltaTime;

            if (_timeUntilFire >= (1f / attackPerSecond))
            {
                Shoot();
                _timeUntilFire = 0f;
            }    
        }
    }
    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(_target);
    }
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(_target.position, transform.position) <= targetingRange;
    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0 )
        {
            _target = hits[0].transform;
        }
    }
    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg - 90;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }
    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }
    public void Upgrade()
    {
        if (CalculateCost() > LevelManager.main.Money) return;

        LevelManager.main.SpendMoney(CalculateCost());
        _level++;

        attackPerSecond = CalculateAPS();
        targetingRange = CaluclateRange();

        CloseUpgradeUI();
    }
    private int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(_level, .8f));
    }
    private float CalculateAPS()
    {
        return _attackPerSecondBase * Mathf.Pow(_level, .6f);
    }
    private float CaluclateRange()
    {
        return _targetingRangeBase * Mathf.Pow(_level, .4f);
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
