using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorageLocationSceneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _level4Button;
    [SerializeField] private Button _level5Button, _level6Button, _backButton;

    private void Start()
    {
        _backButton.onClick.AddListener(BackToLocationChooser);

        _level4Button.onClick.AddListener(onClickLevel4);
        //_level5Button.onClick.AddListener(onClickLevel5);
        //_level6Button.onClick.AddListener(onClickLevel6);
    }
    private void BackToLocationChooser()
    {
        SceneManager.LoadScene(1);
    }
    private void onClickLevel4()
    {
        if (PlayerPrefs.GetInt("level_index") >= 4)
        {
            SceneManager.LoadScene(9);
        }
    }
    private void onClickLevel5()
    {
        if (PlayerPrefs.GetInt("level_index") >= 5)
        {
            SceneManager.LoadScene(10);
        }
    }
    private void onClickLevel6()
    {
        if (PlayerPrefs.GetInt("level_index") >= 6)
        {
            SceneManager.LoadScene(11);
        }
    }
}
