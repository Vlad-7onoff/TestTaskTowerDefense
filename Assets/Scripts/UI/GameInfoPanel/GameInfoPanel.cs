using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfoPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifeCount;
    [SerializeField] private TMP_Text _waveInfo;
    [SerializeField] private TMP_Text _goldCount;

    public void SetWaveInfo(int currentWave, int WaveCount)
    {
        _waveInfo.text = currentWave.ToString() + '/' + WaveCount.ToString();
    }

    public void SetGoldCount(int goldCount)
    {
        _goldCount.text = goldCount.ToString();
    }

    public void SetLifeCount(int lifeCount)
    {
        _lifeCount.text = lifeCount.ToString();
    }

    public void NeededMoreGold()
    {
        _goldCount.color = Color.red;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(1);
        _goldCount.color = Color.white;
    }
}
