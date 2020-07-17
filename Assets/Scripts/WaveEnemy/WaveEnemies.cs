using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _enemyPool;
    [SerializeField] private Timer _timerBetweenSpawn;
    [SerializeField] private Timer _waveTimer;

    private float _waveTime;
    private float _timeBetweenSpawn;
    private List<EnemyData> _enemiesData = new List<EnemyData>();
    private int _currentEnemy = 0;
    private Transform _path;

    public UnityAction OnWaveGone;

    public void Fill(WaveEnemiesData waveEnemiesData, Transform path)
    {
        _waveTime = waveEnemiesData.WaveTime;
        _timeBetweenSpawn = waveEnemiesData.TimeBetweenSpawn;
        _enemiesData = waveEnemiesData.EnemiesData;
        _path = path;
        Init();
    }

    private void Init()
    {
        _timerBetweenSpawn.SetTimeThreshold(_timeBetweenSpawn);
        _timerBetweenSpawn.OnTimeGone += SpawnEnemy;
        _waveTimer.SetTimeThreshold(_waveTime);
        _waveTimer.OnTimeGone += WaveGone;
    }

    private void WaveGone()
    {
        OnWaveGone.Invoke();
    }

    private void SpawnEnemy()
    {
        if (_currentEnemy < _enemiesData.Count)
        {
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity, _enemyPool);
            enemy.Fill(_enemiesData[_currentEnemy], _path);
            _currentEnemy++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
