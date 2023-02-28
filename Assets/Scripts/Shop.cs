using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
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

    public void BuyBasicTurret()
    {
        //can copy script for other turrets
        Debug.Log("Bsaic Turret Bought");
        buildManager.SetTurretBuild(buildManager.basicTurretPrefab);

    }  
    public void BuyCannonTurret()
    {
        //can copy script for other turrets
        Debug.Log("Cannon Turret Bought");
        buildManager.SetTurretBuild(buildManager.cannonTurretPrefab);

    }
}
