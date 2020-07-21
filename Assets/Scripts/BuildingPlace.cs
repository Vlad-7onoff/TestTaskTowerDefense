using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class BuildingPlace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Tower _towerPrefab;

    private SpriteRenderer _spriteRenderer;

    public UnityAction<Vector3, BuildingPlace> Building;
    public UnityAction<Vector3, BuildingPlace> Destroying;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Tower == null)
            Building?.Invoke(transform.position, this);
        else
            Destroying.Invoke(transform.position, this);
    }
}
