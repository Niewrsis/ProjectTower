using UnityEngine;
using UnityEngine.UI;

public class BaseHealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider _healtBar;

    private void Start()
    {
        _healtBar.maxValue = BaseHealth.main.GetCurrentBaseHealth();
        _healtBar.value = _healtBar.maxValue;
    }
    private void OnGUI()
    {
        _healtBar.value = BaseHealth.main.GetCurrentBaseHealth();
    }
}
