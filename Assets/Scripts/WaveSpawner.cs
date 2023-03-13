using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public TextMeshProUGUI WaveCountdownText;
    public float timeBetweenWaves = 5f;
    private float countDown = 5f;

    private int waveNumber  = 0;

    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if(countDown <=0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveNumber];
        Debug.Log("Spawning wave");

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);

            yield return new WaitForSeconds(1 / wave.rate);
        }
        
        waveNumber++;

        if(waveNumber == waves.Length)
        {
            Debug.Log("LEVEL CLEARED");
            this.enabled = false;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
