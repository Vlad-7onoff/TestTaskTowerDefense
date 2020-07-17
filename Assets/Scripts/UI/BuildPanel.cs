using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class BuildPanel : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private List<TowerData> _towerData;
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private Button _machineGun;
    [SerializeField] private Button _rifle;
    [SerializeField] private Button _sniper;
    [SerializeField] private Button _cancel;
    [SerializeField] private TMP_Text _machineGunPrice;
    [SerializeField] private TMP_Text _riflePrice;
    [SerializeField] private TMP_Text _sniperPrice;

    private BuildingPlace _buildingPlace;
    private CanvasGroup _buildPanelGroup;

    private void OnEnable()
    {
        _machineGun.onClick.AddListener(BuildMachineGunTower);
        _rifle.onClick.AddListener(BuildRifleTower);
        _sniper.onClick.AddListener(BuildSniperTower);
        _cancel.onClick.AddListener(ClosePanel);
    }

    private void OnDisable()
    {
        _machineGun.onClick.RemoveListener(BuildMachineGunTower);
        _rifle.onClick.RemoveListener(BuildRifleTower);
        _sniper.onClick.RemoveListener(BuildSniperTower);
        _cancel.onClick.RemoveListener(ClosePanel);
    }

    private void Awake()
    {
        _buildPanelGroup = GetComponent<CanvasGroup>();
        ClosePanel();
        _machineGunPrice.text = _towerData[0].Price.ToString();
        _riflePrice.text = _towerData[1].Price.ToString();
        _sniperPrice.text = _towerData[2].Price.ToString();
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



    public void BuildMachineGunTower()
    {
        TryBuildTower(_towerData[0], _buildingPlace);
        ClosePanel();
    }

    public void BuildRifleTower()
    {
        TryBuildTower(_towerData[1], _buildingPlace);
        ClosePanel();
    }

    public void BuildSniperTower()
    {
        TryBuildTower(_towerData[2], _buildingPlace);
        ClosePanel();
    }

    private void TryBuildTower(TowerData towerData, BuildingPlace buildingPlace)
    {
        if (_game.TryPayGold(towerData.Price))
        {
            _towerBuilder.BuildTower(towerData, buildingPlace);
        }
    }
}
