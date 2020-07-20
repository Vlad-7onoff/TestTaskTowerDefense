using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifeCount;

    public void SetLifeCount(int lifeCount)
    {
        _lifeCount.text = lifeCount.ToString();
    }
}
