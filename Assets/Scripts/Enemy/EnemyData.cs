using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private Sprite _sprite;

    public int Health => _health;
    public int Reward => _reward;
    public float MoveSpeed => _moveSpeed;
    public int Damage => _damage;
    public Sprite Sprite => _sprite;
}
