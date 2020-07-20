using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Tower : MonoBehaviour
{
    private int _damage;
    private float _cooldown;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    private List<Enemy> _enemiesInRange = new List<Enemy>();
    private Timer _cooldownTimer;
    private Enemy _nearestEnemy;

    public int SellPrice { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cooldownTimer = GetComponent<Timer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void ChooseNearestEnemy()
    {
        _nearestEnemy = _enemiesInRange.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).FirstOrDefault();

        if (_nearestEnemy != null)
            Shoot();

        StartCoroutine(_cooldownTimer.SetTimeOut(ChooseNearestEnemy, _cooldown));
    }

    private void Shoot()
    {
        _nearestEnemy.TakeDamage(_damage);
    }

    public void Set(TowerData towerData)
    {
        _damage = towerData.Damage;
        _circleCollider2D.radius = towerData.Range;
        _cooldown = towerData.Cooldown;
        _spriteRenderer.sprite = towerData.Sprite;
        SellPrice = towerData.SellPrice;
        ChooseNearestEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemiesInRange.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemiesInRange.Remove(enemy);
        if (_enemiesInRange.Count == 0)
            _nearestEnemy = null;
    }
}
