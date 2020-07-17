using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class BuildingPlace : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Tower _tower = null;
    private int _towerSellPrice;

    public Tower Tower => _tower;

    public UnityAction<int> EarnedGold;
    public UnityAction<int> SpentedGold;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTower(Tower tower, TowerData towerData)
    {
        _spriteRenderer.enabled = false;
        _tower = Instantiate(tower, transform.position, Quaternion.identity);
        _tower.Fill(towerData);
        _towerSellPrice = towerData.Price / 2;
        SpentedGold.Invoke(towerData.Price);
    }

    public void SellTower()
    {
        _spriteRenderer.enabled = true;
        EarnedGold.Invoke(_towerSellPrice);
        Destroy(_tower);
        _tower = null;
    }
}
