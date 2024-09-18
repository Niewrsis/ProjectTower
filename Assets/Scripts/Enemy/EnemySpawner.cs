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
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = .5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = .75f;
    [SerializeField] private float enemiesPerSecondCap = 15f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private const int MAX_WAVE = 15;
    private int _currentWave = 1;
    private float _timeSinceLastSpawn;
    private int _enemiesAlive;
    private int _enemiesLeftToSpawn;
    private bool _isSpawning = false;
    private float _enemiesPerSecond;

    public int GetCurrentWave()
    {
        return _currentWave;
    }

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
        if (_currentWave >= MAX_WAVE) yield return null;
        yield return new WaitForSeconds(timeBetweenWaves);
        _isSpawning = true;
        _enemiesLeftToSpawn = baseEnemies;
        _enemiesPerSecond = EnemiesPerSecond();
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
        int index = UnityEngine.Random.Range(0, _enemyPrefabs.Length);
        GameObject prefabToSpawn = _enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave() {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(_currentWave, difficultyScalingFactor));
    }
    private float EnemiesPerSecond() {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(_currentWave, difficultyScalingFactor), 0f, enemiesPerSecondCap);
    }
}
