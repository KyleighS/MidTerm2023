using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint basicTurret;
    public TurretBluePrint missileLauncher;
    public AudioSource turretBought;

    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectBasicTurret()
    {
        //can copy script for other turrets
        Debug.Log("Bsaic Turret Bought");
        buildManager.SelectTurretBuild(basicTurret);

    }  
    public void SelectMissileLauncher()
    {
        //can copy script for other turrets
        Debug.Log("Missile Bought");
        buildManager.SelectTurretBuild(missileLauncher);

    }
}
