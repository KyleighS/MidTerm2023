using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 7f;

    public int dmg = 2;

    public float explosionRad = 0f;
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
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject impactEffect = (GameObject) Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(impactEffect, 5f);

        if(explosionRad > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject); 
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRad);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e =enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.Damage(dmg);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRad);
    }
}
