using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Castle : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;

    public UnityAction<int> OnReceivedDamage;
    public event UnityAction Destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _health -= enemy.DealDamage();
            OnReceivedDamage.Invoke(_health);
        }
        if (_health <= 0)
        {
            Destroyed.Invoke();
        }
    }
}
