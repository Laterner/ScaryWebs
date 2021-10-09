using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GLOBAL;

public class Menu : MonoBehaviour
{
    [SerializeField] private BuildingGrid buildingGrid;
    
    public void SelectModeNone()
    {
        buildingGrid.ChangeMode(BuildingMode.none);
    }
    public void SelectModeBuild()
    {
        buildingGrid.ChangeMode(BuildingMode.buildMode);
    }
    public void SelectModeGrid()
    {
        buildingGrid.ChangeMode(BuildingMode.gridMode);
    }
}
