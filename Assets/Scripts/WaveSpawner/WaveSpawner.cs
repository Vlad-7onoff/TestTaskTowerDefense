using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _wavePool;
    [SerializeField] private WaveEnemies _waveEnemies;
    [SerializeField] private Transform _path;
    [SerializeField] private List<WaveEnemiesData> _waveEnemiesData = new List<WaveEnemiesData>();

    private int _currentWave = 0;

    private void Start()
    {
        SpawnWave();
    }

    public void SpawnWave()
    {
        if (_currentWave < _waveEnemiesData.Count)
        {
            WaveEnemies waveEnemies = Instantiate(_waveEnemies, transform.position, Quaternion.identity, _wavePool);
            waveEnemies.Fill(_waveEnemiesData[_currentWave], _path);
            waveEnemies.OnWaveGone += SpawnWave;
            _currentWave++;
        }
    }
}
