using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _waveInfo;

    public void SetWaveInfo(int currentWave, int WaveCount)
    {
        _waveInfo.text = currentWave.ToString() + '/' + WaveCount.ToString();
    }
}
