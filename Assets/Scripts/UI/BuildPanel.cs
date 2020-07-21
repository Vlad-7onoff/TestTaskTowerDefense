using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class BuildPanel : MonoBehaviour
{
    [SerializeField] private BuildingPlace[] _buildingPlaces;
    [SerializeField] private GoldStorage _goldStorage;
    [SerializeField] private BuildTowerButton[] _buildTowerButtons;
    [SerializeField] private Button _cancel;

    private BuildingPlace _buildingPlace;
    private CanvasGroup _buildPanelGroup;

    private void OnEnable()
    {
        foreach (BuildingPlace buildingPlace in _buildingPlaces)
            buildingPlace.Building += OpenPanel;

        foreach (BuildTowerButton buildTowerButton in _buildTowerButtons)
            buildTowerButton.Clicked += TryBuildTower;

        _cancel.onClick.AddListener(ClosePanel);
    }

    private void OnDisable()
    {
        foreach (BuildingPlace buildingPlace in _buildingPlaces)
            buildingPlace.Building -= OpenPanel;

        foreach (BuildTowerButton buildTowerButton in _buildTowerButtons)
            buildTowerButton.Clicked -= TryBuildTower;

        _cancel.onClick.RemoveListener(ClosePanel);
    }

    private void Awake()
    {
        _buildPanelGroup = GetComponent<CanvasGroup>();
        ClosePanel();
    }

    public void OpenPanel(Vector3 position, BuildingPlace buildingPlace)
    {
        _buildingPlace = buildingPlace;
        position.z = -9;
        transform.position = position;
        _buildPanelGroup.alpha = 1;
        _buildPanelGroup.interactable = true;
        _buildPanelGroup.blocksRaycasts = true;
    }

    public void ClosePanel()
    {
        _buildPanelGroup.alpha = 0;
        _buildPanelGroup.interactable = false;
        _buildPanelGroup.blocksRaycasts = false;
    }

    private void TryBuildTower(TowerData towerData)
    {
        if (_goldStorage.TryPayGold(towerData.Price))
            _buildingPlace.SetTower(towerData);

        ClosePanel();
    }
}
