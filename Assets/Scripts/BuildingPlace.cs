using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;

    private SpriteRenderer _spriteRenderer;

    public Tower Tower { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTower(TowerData towerData)
    {
        _spriteRenderer.enabled = false;
        Tower = Instantiate(_towerPrefab, transform.position, Quaternion.identity);
        Tower.Set(towerData);
    }

    public void DestroyTower()
    {
        _spriteRenderer.enabled = true;
        Destroy(Tower.gameObject);
    }
}
