using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 7f;
    public GameObject bulletImpact;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrme = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrme)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrme, Space.World);
    }

    void HitTarget()
    {
        GameObject impactEffect = (GameObject) Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(impactEffect, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject); 
    }
}
