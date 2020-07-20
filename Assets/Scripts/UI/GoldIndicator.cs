using System.Collections;
using TMPro;
using UnityEngine;

public class GoldIndicator : MonoBehaviour
{
    [SerializeField] private GoldStorage _goldStorage;
    [SerializeField] private TMP_Text _goldCount;

    private void OnEnable()
    {
        _goldStorage.GoldAmountHasChanged += SetGoldCount;
        _goldStorage.NeededMoreGold += NeededMoreGold;
    }

    private void OnDisable()
    {
        _goldStorage.GoldAmountHasChanged -= SetGoldCount;
        _goldStorage.NeededMoreGold -= NeededMoreGold;
    }

    private void SetGoldCount(int goldCount)
    {
        _goldCount.text = goldCount.ToString();
    }

    private void NeededMoreGold()
    {
        _goldCount.color = Color.red;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(1);
        _goldCount.color = Color.white;
    }
}
