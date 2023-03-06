using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject basicTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBluePrint buildTurret;

    public bool canBuild { get { return buildTurret != null; } }

    void Awake()
    {
        instance = this;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < buildTurret.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.money -= buildTurret.cost;

        GameObject turret = (GameObject)Instantiate(buildTurret.prefab, node.BuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Built! Money left" + PlayerStats.money);
    }

    public void SelectTurretBuild(TurretBluePrint turret)
    {
        buildTurret = turret;
    }

}
