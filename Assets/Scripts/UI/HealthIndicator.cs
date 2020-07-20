using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _lifeCount;

    private void OnEnable()
    {
        _health.ReceivedDamage += SetLifeCount;
    }

    private void OnDisable()
    {
        _health.ReceivedDamage -= SetLifeCount;
    }

    private void SetLifeCount(int lifeCount)
    {
        _lifeCount.text = lifeCount.ToString();
    }
}
