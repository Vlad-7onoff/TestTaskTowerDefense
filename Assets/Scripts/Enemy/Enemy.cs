using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaypointMover))]
[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    private int _health;
    private int _reward;
    private float _moveSpeed;
    private int _damage;
    private Sprite _sprite;
    private SpriteRenderer _spriteRenderer;
    private WaypointMover _waypointMover;
    private Transform _path;

    public void Fill(EnemyData enemyData, Transform path)
    {
        _health = enemyData.Health;
        _reward = enemyData.Reward;
        _moveSpeed = enemyData.MoveSpeed;
        _damage = enemyData.Damage;
        _sprite = enemyData.Sprite;
        _path = path;
        Init();
    }

    private void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprite;
        _waypointMover = GetComponent<WaypointMover>();
        _waypointMover.Init(_moveSpeed, _path);
    }

    public int DealDamage()
    {
        Destroy(gameObject);
        return _damage;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
