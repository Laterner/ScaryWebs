using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GLOBAL;

public class BuildingMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] builds;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void BuildTower()
    {
        buildCell.GetComponent<BuildCell>().SetBuilding(builds[0]);
        gameObject.SetActive(false);
    }

    public void BuildWall()
    {
        buildCell.GetComponent<BuildCell>().SetBuilding(builds[1]);
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
