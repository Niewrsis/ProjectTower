using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public void OnPause()
    {
        Time.timeScale = 0f;
    }
    public void OnEndPause()
    {
        Time.timeScale = 1f;
    }
    public void OnQuitKitchen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void OnQuitStorage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
}
