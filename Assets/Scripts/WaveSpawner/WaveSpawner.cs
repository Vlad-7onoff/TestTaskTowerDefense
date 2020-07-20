using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveIndicator _waveIndicator;
    [SerializeField] private GoldStorage _goldStorage;
    [SerializeField] private Transform _path;
    [SerializeField] private List<WaveEnemiesData> _waveEnemiesData = new List<WaveEnemiesData>();
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _spawnParrent;
    [SerializeField] private Timer _timer;

    private int _currentWave = 0;

    private void Start()
    {
        SpawnNewWave();
        _waveIndicator.SetWaveInfo(_currentWave, _waveEnemiesData.Count);
    }

    private void SpawnNewWave()
    {
        if (_currentWave >= _waveEnemiesData.Count)
            return;

        WaveEnemiesData currentEnemyData = _waveEnemiesData[_currentWave++];

        StartCoroutine(SpawningWave(currentEnemyData));
        StartCoroutine(_timer.SetTimeOut(SpawnNewWave, currentEnemyData.WaveTime));
    }

    private IEnumerator SpawningWave(WaveEnemiesData waveEnemiesData)
    {
        int currentEnemy = 0;

        while (currentEnemy < waveEnemiesData.EnemiesData.Count)
        {
            yield return new WaitForSeconds(waveEnemiesData.SpawnTime);
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity, _spawnParrent);
            enemy.Fill(waveEnemiesData.EnemiesData[currentEnemy++], _path);
            enemy.Died += _goldStorage.AddGold;
        }
        _waveIndicator.SetWaveInfo(_currentWave, _waveEnemiesData.Count);
    }
}
