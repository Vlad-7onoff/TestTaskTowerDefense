using System.Collections;
using TMPro;
using UnityEngine;

public class GoldIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldCount;

    public void SetGoldCount(int goldCount)
    {
        _goldCount.text = goldCount.ToString();
    }

    public void NeededMoreGold()
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
