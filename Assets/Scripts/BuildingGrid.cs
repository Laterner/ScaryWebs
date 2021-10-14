using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GLOBAL;
public class BuildingGrid : MonoBehaviour
{
    private const int gridSize = 15;

    private Vector2Int buildingGridSize = new Vector2Int(gridSize, gridSize);

    private BuildingMode buildingMode = BuildingMode.none;

    [SerializeField] private GameObject dirBlock;
    [SerializeField] private GameObject[,] blocksGrid = new GameObject[gridSize, gridSize];
    [SerializeField] private Material[] textures;
    private const int offset = (gridSize - 1) / 2;

    private void Awake()
    {
        //dirBlock.GetComponent<Material>().color = new Color(87, 57, 6, 1);

        for (int x = 0; x < buildingGridSize.x; x++)
        {
            for (int y = 0; y < buildingGridSize.y; y++)
            {
                blocksGrid[x, y] = Instantiate(dirBlock, new Vector3(x - offset, -0.5f, y - offset), Quaternion.identity, transform);

                blocksGrid[x, y].GetComponent<BuildCell>().CreateCell(
                    false,
                    new Vector2Int(x - 4, y - 4)
                    );

                blocksGrid[x, y].GetComponent<BuildCell>().SetName(x.ToString() + " || " + y.ToString());
            }
        }
    }
    public void ChangeMode(BuildingMode mode)
    {
        buildingMode = mode;
    }

}
