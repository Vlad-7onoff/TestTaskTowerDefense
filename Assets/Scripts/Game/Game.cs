using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Castle _castle;
    [SerializeField] private int _gold = 0;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private GameInfoPanel _gameInfoPanel;
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private List<BuildingPlace> _buildingPlaces;

    private void OnEnable()
    {
        foreach (BuildingPlace buildingPlace in _buildingPlaces)
        {
            buildingPlace.EarnedGold += AddGold;
            buildingPlace.SpentedGold += PayGold;
        }

        _castle.OnReceivedDamage += SetLifeCount;
        _castle.Destroyed += GameOver;
    }

    private void OnDisable()
    {
        foreach (BuildingPlace buildingPlace in _buildingPlaces)
        {
            buildingPlace.EarnedGold -= AddGold;
            buildingPlace.SpentedGold -= PayGold;
        }

        _castle.OnReceivedDamage -= SetLifeCount;
        _castle.Destroyed -= GameOver;
    }

    private void Awake()
    {
        SetLifeCount(_castle.Health);
        _gameInfoPanel.SetGoldCount(_gold);
    }

    private void GameOver()
    {
        _gameOverPanel.GameOver();
    }

    private void SetLifeCount(int health)
    {
        _gameInfoPanel.SetLifeCount(health);
    }

    private void AddGold(int goldCount)
    {
        _gold += goldCount;
        _gameInfoPanel.SetGoldCount(_gold);
    }

    public bool TryPayGold(int goldCount)
    {
        if (_gold >= goldCount)
        {
            return true;
        }
        else
        {
            _gameInfoPanel.NeededMoreGold();
            return false;
        }
    }

    private void PayGold(int goldCount)
    {
        _gold -= goldCount;
        _gameInfoPanel.SetGoldCount(_gold);
    }
}
