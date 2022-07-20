using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private WavesData _wavesData;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _prefabEnemyWeak;
    [SerializeField] private GameObject _prefabEnemyMid;
    [SerializeField] private GameObject _prefabEnemyHeavy;

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

            yield return new WaitForSecondsRealtime(5f);
            _currentWaveIndex++;
        }
    }

    private IEnumerator SpawnEnemies(int enemyAmount, GameObject enemyPrefab)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
