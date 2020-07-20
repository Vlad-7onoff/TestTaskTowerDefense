using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _restart;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _restart.onClick.AddListener(OnRestartClick);
        _health.Destroyed += GameOver;
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(OnRestartClick);
        _health.Destroyed -= GameOver;
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;
        _gameOverGroup.blocksRaycasts = false;
    }

    private void OnRestartClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;
        _gameOverGroup.blocksRaycasts = true;
    }
}