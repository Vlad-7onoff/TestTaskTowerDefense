using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Tower : MonoBehaviour
{
    private int _price;
    private int _damage;
    private float _range;
    private float _cooldown;
    private Sprite _sprite;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    private List<Enemy> _enemiesInRange = new List<Enemy>();
    private Timer _cooldownTimer;
    private Enemy _nearestEnemy = null;

    private void ChoiseNearestEnemy()
    {
        _nearestEnemy = _enemiesInRange.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).FirstOrDefault();

        if (_nearestEnemy != null)
            Shoot();
    }

    private void Shoot()
    {
        _nearestEnemy.TakeDamage(_damage);
    }

    public void Fill(TowerData towerData)
    {
        _price = towerData.Price;
        _damage = towerData.Damage;
        _range = towerData.Range;
        _cooldown = towerData.Cooldown;
        _sprite = towerData.Sprite;
        Init();
    }

    private void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprite;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.radius = _range;
        _circleCollider2D.isTrigger = true;
        _cooldownTimer = GetComponent<Timer>();
        _cooldownTimer.SetTimeThreshold(_cooldown);
        _cooldownTimer.OnTimeGone += ChoiseNearestEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemiesInRange.Remove(enemy);
        }
        if (_enemiesInRange.Count == 0)
        {
            _nearestEnemy = null;
        }
    }
}
