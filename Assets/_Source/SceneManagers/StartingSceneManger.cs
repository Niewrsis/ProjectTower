using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartingSceneManger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _continueGameButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private TextMeshProUGUI _masterVolumePercentText;
    [SerializeField] private GameObject _settingsObj;

    private int _masterVolumePercent = 100;

    private void Start()
    {
        _settingsObj.SetActive(false);

        _masterVolumeSlider.value = _masterVolumePercent;
        _masterVolumePercentText.text = _masterVolumePercent.ToString() + "%";

        _continueGameButton.onClick.AddListener(ContinueGame);
        _newGameButton.onClick.AddListener(NewGame);
        _quitButton.onClick.AddListener(OnApplicationQuit);
    }
    public void OnSliderChange()
    {
        PlayerPrefs.SetInt("master_volume", (int)_masterVolumeSlider.value);
        _masterVolumePercent = (int)_masterVolumeSlider.value;
        _masterVolumePercentText.text = _masterVolumePercent.ToString() + "%";
    }
    private void ContinueGame()
    {
        SceneManager.LoadScene(1);
    }
    private void NewGame()
    {
        PlayerPrefs.SetInt("gold", 0);
        PlayerPrefs.SetInt("level_index", 1);
        SceneManager.LoadScene(1);
    }
    private void OnApplicationQuit()
    {
        Application.Quit();
    }
}
