using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int _baseEnemies = 8;
    [SerializeField] private float _enemiesPerSecond = .5f;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private float _difficultyScalingFactor = .75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int _currentWave = 1;
    private float _timeSinceLastSpawn;
    private int _enemiesAlive;
    private int _enemiesLeftToSpawn;
    private bool _isSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!_isSpawning) return;

        _timeSinceLastSpawn += Time.deltaTime;

        if(_timeSinceLastSpawn >= (1f / _enemiesPerSecond) && _enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            _enemiesLeftToSpawn--;
            _enemiesAlive++;
            _timeSinceLastSpawn = 0f;
        }
        if (_enemiesAlive == 0 && _enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }
    private void EnemyDestroyed()
    {
        _enemiesAlive--;
    }
    private IEnumerator StartWave() {
        yield return new WaitForSeconds(_timeBetweenWaves);
        _isSpawning = true;
        _enemiesLeftToSpawn = _baseEnemies;
    }
    private void EndWave()
    {
        _isSpawning = false;
        _timeSinceLastSpawn = 0;
        _currentWave++;
        StartCoroutine(StartWave());
    }
    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = _enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave() {
        return Mathf.RoundToInt(_baseEnemies * Mathf.Pow(_currentWave, _difficultyScalingFactor));
    }
}
