using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildTowerButton : MonoBehaviour
{
    [SerializeField] private TowerData _towerData;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _image;

    private Button _button;

    public event UnityAction<TowerData> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image.sprite = _towerData.Sprite;
        _image.useSpriteMesh = true;
        _price.text = _towerData.Price.ToString();
    }

    private void OnClicked()
    {
        Clicked?.Invoke(_towerData);
    }
}