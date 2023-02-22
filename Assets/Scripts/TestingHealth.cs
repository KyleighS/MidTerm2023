using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHealth : MonoBehaviour
{
    int rightClickDamage = 50;

    // Update is called once per frame
    void Update()
    {
        //if the player is righclicking AND the ray drwn, with a maximum length of infinity,
        //hits something we proceed with the info of the hit
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(1) &&
            Physics.Raycast(ray, out RaycastHit info, Mathf.Infinity))
        {
            //we tell the component to recieve the rightClickDamage amount of damage
            if (info.transform.TryGetComponent<Turrets>(out Turrets target))
            {
                target.Damage(rightClickDamage);
            }
        }
    }
}
