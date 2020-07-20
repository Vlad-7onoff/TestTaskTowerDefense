using UnityEngine;

public class GoldStorage : MonoBehaviour
{
    [SerializeField] private GoldIndicator _goldIndicator;
    [SerializeField] private int _goldAmount;

    private void Awake()
    {
        _goldIndicator.SetGoldCount(_goldAmount);
    }

    public void AddGold(int goldCount)
    {
        _goldAmount += goldCount;
        _goldIndicator.SetGoldCount(_goldAmount);
    }

    public bool TryPayGold(int goldCount)
    {
        if (_goldAmount >= goldCount)
        {
            _goldAmount -= goldCount;
            _goldIndicator.SetGoldCount(_goldAmount);
            return true;
        }
        else
        {
            _goldIndicator.NeededMoreGold();
            return false;
        }
    }
}
