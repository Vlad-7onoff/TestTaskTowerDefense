using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveEnemiesData", menuName = "WaveEnemies Data", order = 53)]
public class WaveEnemiesData : ScriptableObject
{
    [SerializeField] private float _waveTime;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private List<EnemyData> _enemiesData = new List<EnemyData>();

    public float WaveTime => _waveTime;
    public float TimeBetweenSpawn => _timeBetweenSpawn;
    public List<EnemyData> EnemiesData => _enemiesData;
}
