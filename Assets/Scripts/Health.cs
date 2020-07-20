using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthCount;

    public event UnityAction<int> ReceivedDamage;
    public event UnityAction Destroyed;

    private void Awake()
    {
        ReceivedDamage?.Invoke(_healthCount);
    }

    public void ReceiveDamage(int damage)
    {
        _healthCount -= damage;
        ReceivedDamage?.Invoke(_healthCount);
        if (_healthCount <= 0)
            Destroyed?.Invoke();
    }
}