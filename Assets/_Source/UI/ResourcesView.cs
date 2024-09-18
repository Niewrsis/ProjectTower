using TMPro;
using UnityEngine;

public class ResourcesView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _baseHealth;
    [SerializeField] private EnemySpawner _currentWave;

    private void OnGUI()
    {
        _moneyText.text = LevelManager.main.Money.ToString();
        _waveText.text = $"{ _currentWave.GetCurrentWave().ToString()}/{_currentWave.GetMaximumWaves().ToString()}";
        _baseHealth.text = BaseHealth.main.GetCurrentBaseHealth().ToString();
    }
}
