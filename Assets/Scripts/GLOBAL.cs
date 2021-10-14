using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GLOBAL 
{
    public enum BuildingMode
    {
        none,
        gridMode,
        buildMode
    }
    public enum Builds
    {
        air,
        block,
        townHall,
        path,
        decor,
        tower
    }
    public static GameObject buildCell;

}
