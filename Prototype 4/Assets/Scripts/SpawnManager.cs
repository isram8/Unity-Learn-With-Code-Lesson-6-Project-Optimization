using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float randomSpawnTime = 3;
    Vector3 randomSpawnLocation;
    float spawnRange = 9;

    public GameObject powerUp;
    public int powerUpCount = 0;
    public int enemyCount = 0;
    public int enemyWaveCount = 0;
    int currentWave = 0;

    void Start()
    {
        
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        SpawnEnemy(enemyWaveCount);
    }


    private void SpawnEnemy(int enemyWaveCount)
    {
        if (currentWave < enemyWaveCount && enemyCount < 1)
        {
            SpawnPowerUp();
            currentWave++;
            for (int i = 0; i < currentWave; i++)
            {
                Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
            }
        }
    }

    private void SpawnPowerUp()
    {

            Instantiate(powerUp, GenerateRandomPos(), powerUp.transform.rotation);
            powerUpCount++;
    }

    private Vector3 GenerateRandomPos()
    {
        return randomSpawnLocation = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

    }

    
}
