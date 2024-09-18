using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerChooser : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [Header("References")]
    [SerializeField] private Button _slot1;
    [SerializeField] private Button _slot2, _slot3, _slot4;
    [SerializeField] private Image[] _towersImages;
    [SerializeField] private TextMeshProUGUI[] _towersCost;

    private Tower[] _towers = new Tower[4];
    private void Start()
    {
        _slot1.onClick.AddListener(SetTower1);
        _slot2.onClick.AddListener(SetTower2);
        _slot3.onClick.AddListener(SetTower3);
        _slot4.onClick.AddListener(SetTower4);

        _towers = BuildManager.main.GetTowers();

        for (int i = 0; i < _towers.Length; i++)
        {
            _towersCost[i].text = _towers[i].Cost.ToString();
        }
    }
    private void SetTower1()
    {
        if (LevelManager.main.Money < _towers[0].Cost) return;

        LevelManager.main.SpendMoney(_towers[0].Cost);
        Instantiate(_towers[0].Prefab, transform.parent.position, Quaternion.identity);
        GetComponentInParent<Plots>().ChangeToPlotBusy();
        gameObject.SetActive(false);
    }
    private void SetTower2()
    {
        if (LevelManager.main.Money < _towers[1].Cost) return;

        LevelManager.main.SpendMoney(_towers[1].Cost);
        Instantiate(_towers[1].Prefab, transform.parent.position, Quaternion.identity);
        GetComponentInParent<Plots>().ChangeToPlotBusy();
        gameObject.SetActive(false);
    }
    private void SetTower3()
    {
        if (LevelManager.main.Money < _towers[2].Cost) return;

        LevelManager.main.SpendMoney(_towers[2].Cost);
        Instantiate(_towers[2].Prefab, transform.parent.position, Quaternion.identity);
        GetComponentInParent<Plots>().ChangeToPlotBusy();
        gameObject.SetActive(false);
    }
    private void SetTower4()
    {
        if (LevelManager.main.Money < _towers[3].Cost) return;

        LevelManager.main.SpendMoney(_towers[3].Cost);
        Instantiate(_towers[3].Prefab, transform.parent.position, Quaternion.identity);
        GetComponentInParent<Plots>().ChangeToPlotBusy();
        gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.main.SetHoveringState(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }
}
