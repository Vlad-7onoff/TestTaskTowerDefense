using UnityEngine;
using UnityEngine.Events;

public class GoldStorage : MonoBehaviour
{
    [SerializeField] private int _goldAmount;

    public UnityAction<int> GoldAmountHasChanged;
    public UnityAction NeededMoreGold;

    private void Start()
    {
        GoldAmountHasChanged?.Invoke(_goldAmount);
    }

    public void AddGold(int goldCount)
    {
        _goldAmount += goldCount;
        GoldAmountHasChanged?.Invoke(_goldAmount);
    }

    public bool TryPayGold(int goldCount)
    {
        if (_goldAmount >= goldCount)
        {
            _goldAmount -= goldCount;
            GoldAmountHasChanged?.Invoke(_goldAmount);
            return true;
        }
        else
        {
            NeededMoreGold?.Invoke();
            return false;
        }
    }
}
