using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Tower _tower = null;
    [SerializeField] private int _goldCount;

    public void BuildTower(TowerData towerData, BuildingPlace buildingPlace)
    {
        buildingPlace.SetTower(_tower, towerData);
    }
}
