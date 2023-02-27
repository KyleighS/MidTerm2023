using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 yOffset;

    private Renderer rend;
    private Color startColor;
    private GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Cant build here");
            return;
        }   
        GameObject buildTurret = BuildManager.instance.GetTurretBuild();
        turret = (GameObject)Instantiate(buildTurret, transform.position + yOffset, transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
