using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "Tower Data", order = 51)]
public class TowerData : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    [SerializeField] private float _cooldown;
    [SerializeField] private Sprite _sprite;

    public int Price => _price;
    public int SellPrice => _price / 2;
    public int Damage => _damage;
    public float Range => _range;
    public float Cooldown => _cooldown;
    public Sprite Sprite => _sprite;
}
