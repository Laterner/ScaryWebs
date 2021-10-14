using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GLOBAL;

public class BuildCell : MonoBehaviour
{
    public bool _isBussy;
    public Vector2Int _cords;
    public GameObject _building = null;

    [SerializeField]
    private GameObject BuildingPanel;

    #region Вариации создания объекта клетки
    public void CreateCell(bool isBussy, int x, int y)
    {
        _isBussy = isBussy;
        _cords = new Vector2Int(x, y);
    }
    public void CreateCell(bool isBussy, int x, int y, GameObject building)
    {
        _isBussy = isBussy;
        _cords = new Vector2Int(x, y);
        _building = building;
    }
    public void CreateCell(bool isBussy, Vector2Int cords)
    {
        _isBussy = isBussy;
        _cords = cords;
    }
    public void CreateCell(bool isBussy, Vector2Int cords, GameObject building)
    {
        _isBussy = isBussy;
        _cords = cords;
        _building = building;
    }
    #endregion

    #region Настройки клетки
    public void SetName(string name)
    {
        gameObject.name = name;
    }
    public void SetMaterial(Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
    }
    public void SetBuilding(GameObject building)
    {
        if (!_isBussy)
        {
            _isBussy = true;
            _building = Instantiate(building, new Vector3(_cords.x, 0.5f, _cords.y), Quaternion.identity, transform);
        }
    }
    #endregion

    private void Awake()
    {
        BuildingPanel = GameObject.FindGameObjectWithTag("BuildingPanel");
    }
    private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (!BuildingPanel.activeSelf && !_isBussy)
            {
                BuildingPanel.SetActive(true);
                buildCell = gameObject;
            }
            else
            {
                BuildingPanel.SetActive(false);
                buildCell = null;
            }
        }
    }
}

