using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _rewardText;
    [SerializeField] private Button _exitButton;

    private int _currentLevel;
    private int _rewardAmount;

    private void Awake()
    {
        _currentLevel = PlayerPrefs.GetInt("level_index");
    }
    private void Start()
    {
        _exitButton.onClick.AddListener(onBack);

        if (LevelManager.CurrentGameState == GameState.Win)
        {
            _currentLevel++;
            onWin();
        }
        else if (LevelManager.CurrentGameState == GameState.Lose)
        {
            onLose();
        }

        Time.timeScale = 0f;
    }
    private void onWin()
    {
        _titleText.text = "Win";
        _rewardAmount = Random.Range(100, 300);
        _rewardText.text = "+" + _rewardAmount.ToString();
        PlayerPrefs.SetInt("level_index", _currentLevel);
    }
    private void onLose()
    {
        _titleText.text = "Lose";
        _rewardAmount = 0;
        _rewardText.text = "+" + _rewardAmount.ToString();
    }
    private void onBack()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_currentLevel < 3 ? 2 : 3);
        Destroy(gameObject);
    }
}
