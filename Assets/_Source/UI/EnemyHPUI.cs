using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _healthUI;
    [SerializeField] private Slider _enemyHealthVisual;
    [SerializeField] private TextMeshProUGUI _enemyHealthText;

    private Health _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<Health>();
        _enemyHealthVisual.maxValue = _enemyHealth.MaxHealth;
    }

    private void OnGUI()
    {
        _enemyHealthText.text = $"{_enemyHealth.MaxHealth.ToString()}/{_enemyHealth.GetCurrentHealth().ToString()}";
        _enemyHealthVisual.value = _enemyHealth.GetCurrentHealth();
    }
    private void OnMouseEnter()
    {
        _healthUI.SetActive(true);
    }
    private void OnMouseExit()
    {
        _healthUI.SetActive(false);
    }
}
