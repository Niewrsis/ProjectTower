using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocationChoosingSceneManager : MonoBehaviour
{
    [SerializeField] private Button _kitchenLocationButton, _storageLocationButton, _shopButton, _inventoryButton;

    private void Start()
    {
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
