using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private BuildPanel _buildPanel;
    [SerializeField] private SellPanel _sellPanel;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _raycastRange;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.down, _raycastRange, _layerMask);

            if (hit.collider != null && IsPointerOverUIObject() == false)
                if (hit.collider.gameObject.TryGetComponent(out BuildingPlace place))
                    if (place.Tower == null)
                        _buildPanel.OpenPanel(_camera.ScreenToWorldPoint(Input.mousePosition), place);
                    else if (place.Tower != null)
                        _sellPanel.OpenPanel(_camera.ScreenToWorldPoint(Input.mousePosition), place);
        }
#endif
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 1)
        {
            Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.down, _raycastRange, _layerMask);

            if (hit.collider != null && IsPointerOverUIObject() == false)
                if (hit.collider.gameObject.TryGetComponent(out BuildingPlace place))
                    if (place.Tower == null)
                        _buildPanel.OpenPanel(_camera.ScreenToWorldPoint(Input.mousePosition), place);
                    else if (place.Tower != null)
                        _sellPanel.OpenPanel(_camera.ScreenToWorldPoint(Input.mousePosition), place);
        }
    }
#endif

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
