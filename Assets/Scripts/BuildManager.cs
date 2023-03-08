using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject basicTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject BuildEffect;

    private TurretBluePrint buildTurret;

    public bool canBuild { get { return buildTurret != null; } }
    public bool hasMoney { get { return PlayerStats.money >= buildTurret.cost; } }

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

        GameObject effect = (GameObject)Instantiate(BuildEffect, node.BuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Built! Money left" + PlayerStats.money);
    }

    public void SelectTurretBuild(TurretBluePrint turret)
    {
        buildTurret = turret;
    }

}
