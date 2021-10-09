using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject[] builds;
    [SerializeField] private GameObject buttonObj;
    [SerializeField] GameObject buildPanel;

    private GameObject flyingBuild = null;


    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject m_YourFirstButton = Instantiate(buttonObj);
            m_YourFirstButton.GetComponent<Button>().onClick.AddListener(CreateTower);
            m_YourFirstButton.transform.SetParent(buildPanel.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SelectTile();
    }

    private void SelectTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<BuildCell>())
            {
                if(flyingBuild != null) flyingBuild.GetComponent<BuildCell>().SetMaterial(materials[0]);
                flyingBuild = hit.collider.gameObject;
                flyingBuild.GetComponent<BuildCell>().SetMaterial(materials[1]);
                //buildPanel.transform.position = new Vector3(ray.GetPoint());
                //buildPanel.SetActive(true);
            }
        }
    }
    public void CreateTower()
    {
        if(flyingBuild != null)
        {
            flyingBuild.GetComponent<BuildCell>().SetBuilding(builds[0]);
        }
    }
}
