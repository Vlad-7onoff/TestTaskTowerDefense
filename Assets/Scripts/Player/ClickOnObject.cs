using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnObject : MonoBehaviour
{
    [SerializeField] private BuildPanel _buildPanel;
    [SerializeField] private SellPanel _sellPanel;
    [SerializeField] private LayerMask _layerMask;

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
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.down, 20, _layerMask);

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out BuildingPlace place))
                {
                    if (place.Tower == null)
                    {
                        _buildPanel.OpenPanel(_camera.ScreenToWorldPoint(Input.mousePosition),place);
                    }
                    else if (place.Tower != null)
                    {
                        _sellPanel.OpenPanel(_camera.ScreenToWorldPoint(Input.mousePosition),place);
                    }
                }
            }
        }
#endif
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 1)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {

            }
        }
    }
#endif
}
