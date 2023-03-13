using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    public float startHealth = 5;
    private float health;
    public Image healthBar;

    public int droppedMoney = 10;

    public GameObject deathEffect;

    private Transform target;
    private int wayPointIndex = 0;

    void Start()
    {
        target = Waypoints.wayPoints[0];
        health = startHealth;
    }

    public void Damage(int dmg)
    {
        health -= dmg;

        healthBar.fillAmount = health / startHealth;

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

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
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
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
