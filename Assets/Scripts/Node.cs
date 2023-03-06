using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 yOffset;

    private Renderer rend;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 BuildPosition ()
    {
        return transform.position + yOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.canBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Cant build here");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
