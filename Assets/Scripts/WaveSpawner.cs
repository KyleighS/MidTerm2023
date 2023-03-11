using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public TextMeshProUGUI WaveCountdownText;
    public float timeBetweenWaves = 5f;
    private float countDown = 5f;

    private int waveNumber  =1 ;

    void Update()
    {
        if(countDown <=0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds = PlayerStats.rounds + 1;
        Debug.Log("Spawning wave");

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(0.5f);
        }
        
        waveNumber++;

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
