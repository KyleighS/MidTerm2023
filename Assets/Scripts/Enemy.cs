using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    public int health = 5;

    public int droppedMoney = 10;

    public GameObject deathEffect;

    private Transform target;
    private int wayPointIndex = 0;

    public void Damage(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.money += droppedMoney;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    void Start()
    {
        target = Waypoints.wayPoints[0];

    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.4)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wayPointIndex >= Waypoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }

        wayPointIndex++;
        target = Waypoints.wayPoints[wayPointIndex];

    }

    void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
