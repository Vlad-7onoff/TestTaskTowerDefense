using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveEnemiesData", menuName = "WaveEnemies Data", order = 53)]
public class WaveEnemiesData : ScriptableObject
{
    [SerializeField] private float _waveTime;
    [SerializeField] private float _spawnTime;
    [SerializeField] private List<EnemyData> _enemiesData = new List<EnemyData>();

    public float WaveTime => _waveTime;
    public float SpawnTime => _spawnTime;
    public List<EnemyData> EnemiesData => _enemiesData;
}
