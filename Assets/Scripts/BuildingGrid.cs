using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GLOBAL;
public class BuildingGrid : MonoBehaviour
{
    

    [SerializeField] private Vector2Int buildingGridSize = new Vector2Int(9, 9);
    int[,] buildingGrid = new int[,] { 
        {1, 1, 0, 0, 0, 0, 0, 1, 1},
        {1, 0, 0, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 2, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 0, 0, 0, 0, 0, 1, 1}
    }; //= new Vector3Int[10, 10];

    private BuildingMode buildingMode = BuildingMode.none;

    [SerializeField] private GameObject dirBlock;
    [SerializeField] private GameObject[,] blocksGrid = new GameObject[9, 9];
    [SerializeField] private Material[] textures;


    //private void OnDrawGizmosSelected()
    //{
    //    for(int x = 0; x < buildingGridSize.x; x++)
    //    {
    //        for (int y = 0; y < buildingGridSize.y; y++)
    //        {
    //            if (buildingGrid[x, y] == (int)Builds.air)
    //            {
    //                if ((x + y) % 2 == 0) Gizmos.color = new Color(0, 1, 0, 0.8f);
    //                else Gizmos.color = new Color(0f, 0.8f, 0f, 0.8f);
    //            }
    //            else
    //            {
    //                Gizmos.color = new Color(1f, 0, 0, 0.8f);
    //            }
    //            Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
    //        }
    //    }
    //}

    private void Awake()
    {
        //dirBlock.GetComponent<Material>().color = new Color(87, 57, 6, 1);

        for (int x = 0; x < buildingGridSize.x; x++)
        {
            for (int y = 0; y < buildingGridSize.y; y++)
            {
                blocksGrid[x, y] = Instantiate(dirBlock, new Vector3(x - 4, -0.5f, y - 4), Quaternion.identity, transform);

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
