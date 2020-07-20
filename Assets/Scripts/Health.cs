using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthIndicator _healthIndicator;
    [SerializeField] private int _healthCount;

    public int HealthCount => _healthCount;

    public event UnityAction<int> ReceivedDamage;
    public event UnityAction Destroyed;

    private void Awake()
    {
        _healthIndicator.SetLifeCount(_healthCount);
    }

    public void ReceiveDamage(int damage)
    {
        _healthCount -= damage;
        ReceivedDamage?.Invoke(_healthCount);
        _healthIndicator.SetLifeCount(_healthCount);
        if (_healthCount <= 0)
            Destroyed?.Invoke();
    }
}