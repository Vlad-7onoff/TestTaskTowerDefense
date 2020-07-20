using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveIndicator : MonoBehaviour
{
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private TMP_Text _waveInfo;

    private void OnEnable()
    {
        _waveSpawner.NextWaveStarted += SetWaveInfo;
    }

    private void OnDisable()
    {
        _waveSpawner.NextWaveStarted -= SetWaveInfo;
    }

    private void SetWaveInfo(int currentWave, int WaveCount)
    {
        _waveInfo.text = currentWave.ToString() + '/' + WaveCount.ToString();
    }
}
