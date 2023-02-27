using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject basicTurretPrefab;
    public GameObject GetTurretBuild()
    {
        return buildTurret;

    }
    private GameObject buildTurret;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        buildTurret = basicTurretPrefab;
    }

}
