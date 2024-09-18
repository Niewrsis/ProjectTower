using TMPro;
using UnityEngine;

public class ResourcesView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private EnemySpawner _currentWave;

    private void OnGUI()
    {
        _moneyText.text = LevelManager.main.Money.ToString();
        _waveText.text = _currentWave.GetCurrentWave().ToString();
    }
}
