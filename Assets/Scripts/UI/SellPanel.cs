using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class SellPanel : MonoBehaviour
{
    [SerializeField] private Button _sell;
    [SerializeField] private Button _cancel;

    private BuildingPlace _buildingPlace;
    private CanvasGroup _sellPanelGroup;

    private void OnEnable()
    {
        _sell.onClick.AddListener(SellBuilding);
        _cancel.onClick.AddListener(ClosePanel);
    }

    private void OnDisable()
    {
        _sell.onClick.RemoveListener(SellBuilding);
        _cancel.onClick.RemoveListener(ClosePanel);
    }

    private void Awake()
    {
        _sellPanelGroup = GetComponent<CanvasGroup>();
        ClosePanel();
    }

    public void OpenPanel(Vector3 position, BuildingPlace buildingPlace)
    {
        _buildingPlace = buildingPlace;
        position.z = -9;
        transform.position = position;
        _sellPanelGroup.alpha = 1;
        _sellPanelGroup.interactable = true;
        _sellPanelGroup.blocksRaycasts = true;
    }

    public void ClosePanel()
    {
        _sellPanelGroup.alpha = 0;
        _sellPanelGroup.interactable = false;
        _sellPanelGroup.blocksRaycasts = false;
    }

    public void SellBuilding()
    {
        _buildingPlace.SellTower();
        ClosePanel();
    }
}
