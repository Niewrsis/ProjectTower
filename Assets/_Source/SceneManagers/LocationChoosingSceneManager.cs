using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocationChoosingSceneManager : MonoBehaviour
{
    [SerializeField] private Button _kitchenLocationButton, _storageLocationButton, _shopButton, _inventoryButton;
    [SerializeField] private Image _storageSprite;
    [SerializeField] private Color _blockedColor;

    private Color _baseColor;

    private void Start()
    {
        _baseColor = _storageSprite.color;

        if (PlayerPrefs.GetInt("level_index") <= 3)
        {
            _storageSprite.color = _blockedColor;
        }
        else
        {
            _storageSprite.color = _baseColor;
        }
        _kitchenLocationButton.onClick.AddListener(OpenKitchenScene);
        _storageLocationButton.onClick.AddListener(OpenStorageScene);
        _shopButton.onClick.AddListener(OpenShop);
        _inventoryButton.onClick.AddListener(OpenInventory);
    }
    private void OpenKitchenScene()
    {
        SceneManager.LoadScene(2);
    }
    private void OpenStorageScene()
    {
        if (PlayerPrefs.GetInt("level_index") <= 3) return;
        SceneManager.LoadScene(3);
    }
    private void OpenShop()
    {
        SceneManager.LoadScene(4);
    }
    private void OpenInventory()
    {
        SceneManager.LoadScene(5);
    }
}
