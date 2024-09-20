using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KitchenChoosingLevelSceneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button, _level3Button, _backButton;
    [SerializeField] private Image _spriteLevel2, _spriteLevel3;
    [SerializeField] private Color _blockedColor;

    private Color _baseColor;

    private void Start()
    {
        _baseColor = _spriteLevel2.color;

        if (PlayerPrefs.GetInt("level_index") < 2)
        {
            _spriteLevel2.color = _blockedColor;
        }
        else
        {
            _spriteLevel2.color = _baseColor;
        }

        if (PlayerPrefs.GetInt("level_index") < 3)
        {
            _spriteLevel3.color = _blockedColor;
        }
        else
        {
            _spriteLevel3.color = _baseColor;
        }
        _backButton.onClick.AddListener(BackToLocationChooser);

        _level1Button.onClick.AddListener(onClickLevel1);
        _level2Button.onClick.AddListener(onClickLevel2);
        _level3Button.onClick.AddListener(onClickLevel3);
    }
    private void BackToLocationChooser()
    {
        SceneManager.LoadScene(1);
    }
    private void onClickLevel1()
    {
        if (PlayerPrefs.GetInt("level_index") >= 1)
        {
            SceneManager.LoadScene(6);
        }
    }
    private void onClickLevel2()
    {
        Debug.Log("Preesed " + PlayerPrefs.GetInt("level_index"));
        if (PlayerPrefs.GetInt("level_index") >= 2)
        {
            SceneManager.LoadScene(7);
        }
    }
    private void onClickLevel3()
    {
        if (PlayerPrefs.GetInt("level_index") >= 3)
        {
            SceneManager.LoadScene(8);
        }
    }
}
