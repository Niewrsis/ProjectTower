using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KitchenChoosingLevelSceneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button, _level3Button;

    private void Start()
    {
        _level1Button.onClick.AddListener(onClickLevel1);
        _level2Button.onClick.AddListener(onClickLevel2);
        _level3Button.onClick.AddListener(onClickLevel3);
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
