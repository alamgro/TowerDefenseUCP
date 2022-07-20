using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private WavesData _wavesData;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private GameObject _prefabEnemyWeak;
    [SerializeField] private GameObject _prefabEnemyMid;
    [SerializeField] private GameObject _prefabEnemyHeavy;
    [SerializeField] private UnityEvent OnWavesEnded;

    private int _currentWaveIndex = 0;

    private void Start()
    {
        StartCoroutine(CreateEnemyWave());
    }

    private IEnumerator CreateEnemyWave()
    {
        while(_currentWaveIndex < _wavesData.Waves.Length)
        {
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_currentWaveIndex].WeakEnemies, _prefabEnemyWeak));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_currentWaveIndex].MidEnemies, _prefabEnemyMid));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_currentWaveIndex].HeavyEnemies, _prefabEnemyHeavy));

            while (GameManager.Instance.EnemyCount > 0)
            {
                yield return null;
            }

            _currentWaveIndex++;
        }

        //Winner
        OnWavesEnded?.Invoke();
    }

    private IEnumerator SpawnEnemies(int enemyAmount, GameObject enemyPrefab)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            float randTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            yield return new WaitForSecondsRealtime(randTime);
            Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}
